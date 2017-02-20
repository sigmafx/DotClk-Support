using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace FontEditor
{
    public partial class MainForm : Form
    {
        private class FontItem
        {
            public char AsciiChar;
            public ushort Kerning;
            public ushort Width;
            public byte[,] Dots;
            public byte[,] Mask;
        }

        private new ushort FontHeight;
        private String FontName = String.Empty;
        private String FileName = String.Empty;
        private List<FontItem> fontItems = new List<FontItem>();

        private int lastValue = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void SetChar(int idx)
        {
            if (fontItems.Count == 0)
            {
                // No items so clear the screen
                fontEdit1.Create(0, 0);
                lblAsciiChar.Text = String.Empty;
                lblAsciiCode.Text = String.Empty;
                lblWidth.Text = String.Empty;
                lblHeight.Text = String.Empty;
                lblKerning.Text = String.Empty;
            }
            else
            {
                FontItem fi = fontItems[idx];

                // Update the edit control
                fontEdit1.Create(fi.Width, FontHeight);
                fontEdit1.Dots = fontItems[idx].Dots;
                fontEdit1.Mask = fontItems[idx].Mask;

                // Update the form with the relevant details
                lblAsciiChar.Text = String.Format("{0}", fi.AsciiChar);
                lblAsciiCode.Text = String.Format("{0}", Convert.ToByte(fi.AsciiChar));
                lblHeight.Text = String.Format("{0}", FontHeight);
                lblWidth.Text = String.Format("{0}", fi.Width);
                lblKerning.Text = String.Format("{0}", fi.Kerning);
            }
        }

        private void WriteFont(String filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                ushort Version = 1;
                ushort CntFontItems = Convert.ToUInt16(fontItems.Count);
                ushort DmpWidth = 0;

                // Write the header
                writer.Write(Version);
                writer.Write(FontName);
                writer.Write(CntFontItems);

                // Write the font items
                foreach (FontItem item in fontItems)
                {
                    writer.Write(item.AsciiChar);
                    writer.Write(item.Width);
                    writer.Write(item.Kerning);

                    // Running total of the dotmap width
                    DmpWidth += Convert.ToUInt16(item.Width);
                }

                // Write the dotmap
                // Header
                ushort DmpBpp = 4;
                ushort HasMask = 1;

                writer.Write(DmpWidth);
                writer.Write(FontHeight);
                writer.Write(DmpBpp);
                writer.Write(HasMask);

                // Dots
                for (int y = 0; y < FontHeight; y++)
                {
                    byte[] row = new byte[DmpWidth];
                    int rowByte = 0;

                    // Concatenate all of the row bytes into a single row
                    foreach (FontItem item in fontItems)
                    {
                        for (int x = 0; x < item.Width; x++)
                        {
                            row[rowByte] = item.Dots[x, y];
                            rowByte++;
                        }
                    }

                    // Write the row
                    for (rowByte = 0; rowByte < DmpWidth; rowByte += 2)
                    {
                        byte value;

                        value = row[rowByte];
                        if ((rowByte + 1) < DmpWidth)
                        {
                            // Don't add the odd last column
                            value |= Convert.ToByte((row[rowByte + 1]) << 4);
                        }

                        writer.Write(value);
                    }
                }

                // Mask
                for (int y = 0; y < FontHeight; y++)
                {
                    byte[] row = new byte[DmpWidth];
                    int rowByte = 0;

                    // Concatenate all of the row byte into a single row
                    foreach (FontItem item in fontItems)
                    {
                        for (int x = 0; x < item.Width; x++)
                        {
                            row[rowByte] = item.Mask[x, y];
                            rowByte++;
                        }
                    }

                    // Write the row
                    for (rowByte = 0; rowByte < DmpWidth; rowByte += 8)
                    {
                        byte value = 0x00;

                        for (int bit = 0; bit < 8; bit++)
                        {
                            if ((rowByte + bit) < DmpWidth)
                            {
                                value |= Convert.ToByte((row[rowByte + bit] << bit));
                            }
                        }

                        writer.Write(value);
                    }
                }
            }
        }

        private void ReadFont(String filename)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                ushort Version;
                ushort CntFontItems;

                // Read header
                Version = reader.ReadUInt16();
                FontName = reader.ReadString();
                CntFontItems = reader.ReadUInt16();

                // Read font items
                fontItems.Clear();
                for (UInt16 idx = 0; idx < CntFontItems; idx++)
                {
                    FontItem item = new FontItem();

                    item.AsciiChar = reader.ReadChar();
                    item.Width = reader.ReadUInt16();
                    item.Kerning = reader.ReadUInt16();
                    item.Dots = null;
                    item.Mask = null;

                    fontItems.Add(item);
                }

                // Read the dotmap
                // Header
                ushort DmpWidth = reader.ReadUInt16();
                FontHeight = reader.ReadUInt16();
                reader.ReadUInt16(); // DmpBpp
                ushort HasMask = reader.ReadUInt16();

                foreach (FontItem item in fontItems)
                {
                    item.Dots = new byte[item.Width, FontHeight];
                    item.Mask = new byte[item.Width, FontHeight];
                }

                // Dots
                for (int y = 0; y < FontHeight; y++)
                {
                    byte[] row = new byte[DmpWidth];
                    int rowByte;

                    for (rowByte = 0; rowByte < DmpWidth; rowByte += 2)
                    {
                        byte value = reader.ReadByte();

                        row[rowByte] = Convert.ToByte(value & 0x0F);
                        if ((rowByte + 1) < DmpWidth)
                        {
                            row[rowByte + 1] = Convert.ToByte(value >> 4);
                        }
                    }

                    rowByte = 0;
                    foreach (FontItem item in fontItems)
                    {
                        for (int x = 0; x < item.Width; x++)
                        {
                            item.Dots[x, y] = row[rowByte];
                            rowByte++;
                        }
                    }
                }

                // Mask (optional)
                if (HasMask == 1)
                {
                    // Mask
                    for (int y = 0; y < FontHeight; y++)
                    {
                        byte[] row = new byte[DmpWidth];
                        int rowByte;

                        for (rowByte = 0; rowByte < DmpWidth; rowByte += 8)
                        {
                            byte value = reader.ReadByte();

                            for (int bit = 0; bit < 8; bit++)
                            {
                                if ((rowByte + bit) < DmpWidth)
                                {
                                    row[rowByte + bit] = Convert.ToByte((value >> bit) & 0x01);
                                }
                            }
                        }

                        rowByte = 0;
                        foreach (FontItem item in fontItems)
                        {
                            for (int x = 0; x < item.Width; x++)
                            {
                                item.Mask[x, y] = row[rowByte];
                                rowByte++;
                            }
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbColour.SelectedIndex = 0;
            hScrollBar1.Value = 15;

            fontEdit1.Create(0, 0);

            Form1_SizeChanged(sender, e);
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            fontEdit1.DotSide = hScrollBar1.Value;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            fontEdit1.Width = Width - 5;
            fontEdit1.Height = Height - 5;
        }

        private void rbDotMask_CheckChanged(object sender, EventArgs e)
        {
            if (rbDot.Checked)
            {
                fontEdit1.Mode = FontEdit.DrawMode.DOT;
            }
            else
            {
                fontEdit1.Mode = FontEdit.DrawMode.MASK;
            }
        }

        private void cbColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontEdit1.DotColour = Convert.ToUInt16(cbColour.Items[cbColour.SelectedIndex]);
        }

        private void btnClearMask_Click(object sender, EventArgs e)
        {
            fontEdit1.ClearMask();
        }

        private void btnClearDots_Click(object sender, EventArgs e)
        {
            fontEdit1.ClearDots();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmNewFont n = new frmNewFont();

            if (n.ShowDialog(this) == DialogResult.OK)
            {
                FontHeight = n.FontHeight;
                FontName = n.FontName;

                scrlChar.Maximum = 0;
                lblFileDetails.Text = "Font Name: " + FontName;

                FileName = String.Empty;

                fontItems.Clear();
            }
        }

        private void btnNewChar_Click(object sender, EventArgs e)
        {
            frmNewChar c = new frmNewChar();

            // Show the New/Amend Char dialog
            if (c.ShowDialog(this) == DialogResult.OK)
            {
                int idxItem = -1,
                    idxCur = 0;

                // Determine if the char already exists - Amend
                foreach (FontItem item in fontItems)
                {
                    if (item.AsciiChar == c.AsciiChar)
                    {
                        idxItem = idxCur;
                        break;
                    }

                    idxCur++;
                }

                if (idxItem != -1)
                {
                    // Existing item,amend
                    fontItems[idxItem].Width = c.AsciiCharWidth;
                    fontItems[idxItem].Kerning = c.Kerning;

                    // Set the screen, but amend the font edit
                    fontEdit1.Amend(fontItems[idxItem].Width, FontHeight);
                    lblWidth.Text = String.Format("{0}", fontItems[idxItem].Width);
                    lblKerning.Text = String.Format("{0}", fontItems[idxItem].Kerning);
                }
                else
                {
                    FontItem fi = new FontItem();

                    // New item
                    fi.AsciiChar = c.AsciiChar;
                    fi.Width = c.AsciiCharWidth;
                    fi.Kerning = c.Kerning;
                    fi.Dots = null;
                    fi.Mask = null;

                    fontItems.Add(fi);
                    fontItems.Sort((x, y) => x.AsciiChar.CompareTo(y.AsciiChar));

                    idxItem = 0;
                    foreach (FontItem item in fontItems)
                    {
                        if (item.AsciiChar == c.AsciiChar)
                            break;

                        idxItem++;
                    }

                    // Has the new item shifted the index of the currently displayed item?
                    if (fontItems.Count > 1 && idxItem <= lastValue)
                    {
                        lastValue++;
                    }

                    // Update the UI
                    scrlChar.Maximum = fontItems.Count() - 1;
                    if (scrlChar.Value == idxItem)
                    {
                        if (fontItems.Count == 1)
                        {
                            SetChar(0);
                        }
                        else
                        {
                            scrlChar_ValueChanged(sender, e);
                        }
                    }
                    else
                    {
                        // Change the scroll bar, which in turn refreshes
                        scrlChar.Value = idxItem;
                    }
                }
            }
        }

        private void btnDelChar_Click(object sender, EventArgs e)
        {
            int idxItem = scrlChar.Value;

            if (fontItems.Count > 0)
            {
                fontItems.RemoveAt(idxItem);
                if (idxItem > 0 && idxItem == fontItems.Count)
                {
                    // Last but not the first!
                    scrlChar.Value = idxItem - 1;
                }

                scrlChar.Maximum = fontItems.Count == 0 ? 0 : fontItems.Count - 1;

                SetChar(scrlChar.Value);
            }
        }

        private void scrlChar_ValueChanged(object sender, EventArgs e)
        {
            if(lastValue < fontItems.Count)
            {
                // Store the current items dots and mask
                fontItems[lastValue].Dots = fontEdit1.Dots;
                fontItems[lastValue].Mask = fontEdit1.Mask;
            }

            // Set new item
            lastValue = scrlChar.Value;
            SetChar(scrlChar.Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Store the current items dots and mask
            fontItems[scrlChar.Value].Dots = fontEdit1.Dots;
            fontItems[scrlChar.Value].Mask = fontEdit1.Mask;

            if (FileName != String.Empty && File.Exists(FileName))
            {
                WriteFont(FileName);
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "Font Files | *.fnt";
                save.Title = "Save Font File";
                if (save.ShowDialog(this) == DialogResult.OK && save.FileName != String.Empty)
                {

                    WriteFont(save.FileName);
                    FileName = save.FileName;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Font Files | *.fnt";
            open.Title = "Load Font File";
            if (open.ShowDialog(this) == DialogResult.OK && open.FileName != String.Empty)
            {
                scrlChar.Value = 0;

                ReadFont(open.FileName);

                FileName = open.FileName;
                lblFileDetails.Text = "Font Name: " + FontName;

                scrlChar.Maximum = fontItems.Count - 1;
                SetChar(0);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Create a default palette
            for (int idx = 0; idx < 16; idx++)
            {
                Color color = new Color();

                if (checkBox1.Checked)
                {
                    color = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
                }
                else
                {
                    color = Color.FromArgb(0xFF, (idx * 12) + (idx == 0 ? 0 : 60), 0x00, 0x00);
                }

                fontEdit1.SetPlatte(idx, color);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Font Files | *.fnt";
            open.Title = "Convert Font File";
            if (open.ShowDialog(this) == DialogResult.OK && open.FileName != String.Empty)
            {
                using (BinaryReader reader = new BinaryReader(File.Open(open.FileName, FileMode.Open)))
                {
                    String output = String.Empty;
                    ushort Version;
                    ushort CntFontItems;
                    String FontName;
                    byte[] input;
                    int fontinfolen = 1 + sizeof(ushort) + sizeof(ushort);

                    // Read header
                    Version = reader.ReadUInt16();
                    FontName = reader.ReadString();
                    CntFontItems = reader.ReadUInt16();

                    output = String.Format("// Version: {0}\n", Version);
                    output += String.Format("// Font Name: {0}\n", FontName);
                    output += String.Format("// Count Items: {0}\n\n", CntFontItems);

                    // Output Font Char Info
                    output += String.Format("const byte {0}FontCharInfo[] = {{\n", FontName);
                    for (int item = 0; item < CntFontItems; item++)
                    {
                        input = reader.ReadBytes(fontinfolen);

                        for (int byteout = 0; byteout < fontinfolen; byteout++)
                        {
                            output += String.Format("0x{0:X02}, ", input[byteout]);
                        }

                        output += "\n";
                    }
                    output += "};\n";

                    // Dotmap
                    // Header
                    ushort DmpWidth = reader.ReadUInt16();
                    ushort DmpHeight = reader.ReadUInt16();
                    ushort DmpBpp = reader.ReadUInt16(); // DmpBpp
                    ushort HasMask = reader.ReadUInt16();

                    ushort DmpByteWidth = Convert.ToUInt16((DmpWidth / 2) + (DmpWidth % 2 == 0 ? 0 : 1));
                    ushort MaskByteWidth = Convert.ToUInt16((DmpWidth / 8) + (DmpWidth % 8 == 0 ? 0 : 1));

                    output += String.Format("// Width: {0}\n", DmpWidth);
                    output += String.Format("// Height: {0}\n", DmpHeight);

                    // Dotmap - Dots
                    output += "\n";
                    output += String.Format("const byte {0}FontDots[] = {{\n", FontName);
                    for (int row = 0; row < DmpHeight; row++)
                    {
                        input = reader.ReadBytes(DmpByteWidth);
                        for (int byteout = 0; byteout < DmpByteWidth; byteout++)
                        {
                            output += String.Format("0x{0:X02},", input[byteout]);
                        }

                        output += "\n";
                    }
                    output += "};\n";

                    // Dotmap - Mask
                    output += "\n";
                    output += String.Format("const byte {0}FontMask[] = {{\n", FontName);
                    for (int row = 0; row < DmpHeight; row++)
                    {
                        input = reader.ReadBytes(MaskByteWidth);
                        for (int byteout = 0; byteout < MaskByteWidth; byteout++)
                        {
                            output += String.Format("0x{0:X02},", input[byteout]);
                        }

                        output += "\n";
                    }
                    output += "};\n";

                    // Add to clipboard
                    Clipboard.SetText(output);
                }
            }
        }

        private void btnFillMask_Click(object sender, EventArgs e)
        {
            fontEdit1.FillMask();
        }
    }
}
