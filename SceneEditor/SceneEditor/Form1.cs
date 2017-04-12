using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace SceneEditor
{
    public partial class Form1 : Form
    {
        private List<byte[,]> dots = new List<byte[,]>();
        private Dictionary<int, byte[,]> mask = new Dictionary<int, byte[,]>();
        private String pathScene = String.Empty;
        private int valuePrev = 0;
        private bool IsDirty = false;

        public Form1()
        {
            InitializeComponent();
            ClearForm();
        }

        private void WriteScene(String pathScene)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(pathScene, FileMode.Create)))
            {
                ushort Version = 1;
                ushort CntItemDotmap = Convert.ToUInt16(dots.Count());
                ushort CntItemStoryboard = 1;
                ushort FirstFrameDelay = Convert.ToUInt16(txtFirstFrameDelay.Text);
                ushort FirstFrameLayer = Convert.ToUInt16(chkFirstClock.Checked ? 1 : 0);
                ushort FirstBlank = Convert.ToUInt16(chkFirstBlank.Checked ? 1 : 0);
                ushort FrameDelay = Convert.ToUInt16(txtFrameDelay.Text);
                ushort FrameLayer = Convert.ToUInt16(chkClock.Checked ? 1 : 0);
                ushort LastFrameDelay = Convert.ToUInt16(txtLastFrameDelay.Text);
                ushort LastFrameLayer = Convert.ToUInt16(chkLastClock.Checked ? 1 : 0);
                ushort LastBlank = Convert.ToUInt16(chkLastBlank.Checked ? 1 : 0);
                byte ClockStyle = Convert.ToByte(cmbClockStyle.SelectedIndex);

                // Write Scene Header
                writer.Write(Version);
                writer.Write(CntItemDotmap);
                writer.Write(CntItemStoryboard);

                // Write storyboard
                writer.Write(FirstFrameDelay);
                writer.Write(FirstFrameLayer);
                writer.Write(FirstBlank);
                writer.Write(FrameDelay);
                writer.Write(FrameLayer);
                writer.Write(LastFrameDelay);
                writer.Write(LastFrameLayer);
                writer.Write(LastBlank);
                writer.Write(ClockStyle);

                // Leave a bit of space for future features
                byte[] blank = new Byte[19];
                writer.Write(blank);

                // Write dotmaps
                for (int idx = 0; idx < dots.Count; idx++)
                {
                    ushort DmpWidth = 128;
                    ushort DmpHeight = 32;
                    ushort DmpBpp = 4;
                    ushort HasMask = 0;

                    if (mask.ContainsKey(idx))
                    {
                        // Add the optional mask data
                        HasMask = 1;
                    }

                    // Write Dotmap Item Header
                    writer.Write(DmpWidth);
                    writer.Write(DmpHeight);
                    writer.Write(DmpBpp);
                    writer.Write(HasMask);

                    // Write Dotmap data
                    for (int y = 0; y < 32; y += 1)
                    {
                        for (int x = 0; x < 128; x += 2)
                        {
                            Byte value;

                            value = dots[idx][x, y];
                            value |= Convert.ToByte((dots[idx][x + 1, y]) << 4);

                            writer.Write(value);
                        }
                    }

                    if (HasMask == 1)
                    {
                        // Write mask data
                        for (int y = 0; y < 32; y += 1)
                        {
                            for (int x = 0; x < 128; x += 8)
                            {
                                Byte value = 0x00;

                                for (int bit = 0; bit < 8; bit++)
                                {
                                    value |= Convert.ToByte((mask[idx][x + bit, y] << bit));
                                }

                                writer.Write(value);
                            }
                        }
                    }
                }
            }
        }

        private void ReadScene(String pathScene)
        {
            dots.Clear();
            mask.Clear();

            using (BinaryReader reader = new BinaryReader(File.Open(pathScene, FileMode.Open)))
            {
                ushort Version;
                ushort CntItemDotmap;
                ushort CntItemStoryboard;

                // Read Scene Header
                Version = reader.ReadUInt16();
                CntItemDotmap = reader.ReadUInt16();
                CntItemStoryboard = reader.ReadUInt16();

                // Read storyboard
                ushort FirstFrameDelay = 0;
                ushort FirstFrameLayer = 0;
                ushort FirstBlank = 0;
                ushort FrameDelay = 100;
                ushort FrameLayer = 0;
                ushort LastFrameDelay = 0;
                ushort LastFrameLayer = 0;
                ushort LastBlank = 0;
                byte ClockStyle = 0;


                for (int idxScene = 0; idxScene < CntItemStoryboard; idxScene++)
                {
                    FirstFrameDelay = reader.ReadUInt16();
                    FirstFrameLayer = reader.ReadUInt16();
                    FirstBlank = reader.ReadUInt16();

                    FrameDelay = reader.ReadUInt16();
                    FrameLayer = reader.ReadUInt16();

                    LastFrameDelay = reader.ReadUInt16();
                    LastFrameLayer = reader.ReadUInt16();
                    LastBlank = reader.ReadUInt16();

                    ClockStyle = reader.ReadByte();

                    reader.ReadBytes(19);
                }

                // Set screen items
                txtFirstFrameDelay.Text = Convert.ToString(FirstFrameDelay);
                chkFirstClock.Checked = (FirstFrameLayer == 0 ? false : true);
                chkFirstBlank.Checked = (FirstBlank == 0 ? false : true);

                txtFrameDelay.Text = Convert.ToString(FrameDelay);
                chkClock.Checked = (FrameLayer == 0 ? false : true);

                txtLastFrameDelay.Text = Convert.ToString(LastFrameDelay);
                chkLastClock.Checked = (LastFrameLayer == 0 ? false : true);
                chkLastBlank.Checked = (LastBlank == 0 ? false : true);

                cmbClockStyle.SelectedIndex = ClockStyle;

                for (int idx = 0; idx < CntItemDotmap; idx++)
                {
                    ushort DmpWidth;
                    ushort DmpHeight;
                    ushort DmpBpp;
                    ushort HasMask;

                    // Read Dotmap Item Header
                    DmpWidth = reader.ReadUInt16();
                    DmpHeight = reader.ReadUInt16();
                    DmpBpp = reader.ReadUInt16();
                    HasMask = reader.ReadUInt16();

                    // Add a dotmap
                    dots.Add(new byte[128, 32]);

                    // Read Dotmap data
                    for (int y = 0; y < 32; y += 1)
                    {
                        for (int x = 0; x < 128; x += 2)
                        {
                            Byte value;

                            value = reader.ReadByte();
                            dots[idx][x, y] = Convert.ToByte(value & 0x0F);
                            dots[idx][x + 1, y] = Convert.ToByte(value >> 4);
                        }
                    }

                    if (HasMask == 1)
                    {
                        mask.Add(idx, new byte[128, 32]);

                        // Read mask data
                        for (int y = 0; y < 32; y += 1)
                        {
                            for (int x = 0; x < 128; x += 8)
                            {
                                Byte value = reader.ReadByte();

                                for (int bit = 0; bit < 8; bit++)
                                {
                                    mask[idx][x + bit, y] = Convert.ToByte(value & 0x01);
                                    value >>= 1;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SetDmdImage(int idx)
        {
            if (dots[idx] != null)
            {
                // Set the dots
                dmdEdit1.dots = dots[idx];

                // Set the mask
                if (mask.ContainsKey(idx))
                {
                    // Mask exists, set
                    dmdEdit1.mask = mask[idx];
                }
                else
                {
                    // No mask, clear it
                    dmdEdit1.ClearMask();
                }
            }

            // Refresh the dmd
            dmdEdit1.Invalidate();

            // Set the frame details label
            lblFrame.Text = String.Format("Frame {0} / {1}", idx + 1, dots.Count());
        }

        private void ClearDmdImage()
        {
            // Set the dots
            dmdEdit1.ClearMask();
            dmdEdit1.ClearDots();

            // Set the frame details label
            lblFrame.Text = String.Empty;
        }

        private void StoreDmdMask(int idx)
        {
            bool empty = true;

            foreach (byte item in dmdEdit1.mask)
            {
                if (item != 0x00)
                {
                    empty = false;
                    break;
                }
            }

            mask.Remove(idx);

            if (!empty)
            {
                mask.Add(idx, (byte[,])dmdEdit1.mask.Clone());
            }
        }

        private void ValidateForm()
        {
            String value;
            int parseValue;

            // First frame delay
            value = txtFirstFrameDelay.Text;
            if (!int.TryParse(value, out parseValue))
            {
                parseValue = 0;
            }
            txtFirstFrameDelay.Text = String.Format("{0}", parseValue);

            // Other frame delay
            value = txtFrameDelay.Text;
            if (!int.TryParse(value, out parseValue))
            {
                parseValue = 0;
            }
            txtFrameDelay.Text = String.Format("{0}", parseValue);

            // Last frame delay
            value = txtLastFrameDelay.Text;
            if (!int.TryParse(value, out parseValue))
            {
                parseValue = 0;
            }
            txtLastFrameDelay.Text = String.Format("{0}", parseValue);
        }

        private void ClearForm()
        {
            // Frame scroll bar
            valuePrev = 0;
            scrlFrame.Minimum = 0;
            scrlFrame.Maximum = 0;
            scrlFrame.Value = 0;

            // Remove all of the dot and mask data
            dots.Clear();
            mask.Clear();

            // No longer dirty
            IsDirty = false;

            // File name
            pathScene = String.Empty;
            txtFilename.Text = String.Empty;

            // First Frame
            txtFirstFrameDelay.Text = "0";
            chkFirstClock.Checked = false;
            chkFirstBlank.Checked = false;

            // Other Frames
            txtFrameDelay.Text = "100";
            chkClock.Checked = false;

            // Last Frame
            txtLastFrameDelay.Text = "0";
            chkLastClock.Checked = false;
            chkLastBlank.Checked = false;

            // Paint controls
            cmbBrushSize.SelectedIndex = 0;
            radPen.Checked = true;
            radFill.Checked = false;

            // Clear dmd edit
            ClearDmdImage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Scene File|*.scn";
            saveFileDialog1.Title = "Save...";
            saveFileDialog1.FileName = pathScene;

            // Store the current mask
            StoreDmdMask(scrlFrame.Value);

            if (pathScene != String.Empty && File.Exists(pathScene))
            {
                ValidateForm();

                WriteScene(saveFileDialog1.FileName);
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != String.Empty)
                {
                    ValidateForm();

                    WriteScene(saveFileDialog1.FileName);
                    pathScene = saveFileDialog1.FileName;

                    txtFilename.Text = pathScene;
                }
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Scene File|*.scn";
            saveFileDialog1.Title = "Save As...";

            // Store the current mask
            StoreDmdMask(scrlFrame.Value);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != String.Empty)
            {
                ValidateForm();

                WriteScene(saveFileDialog1.FileName);
                pathScene = saveFileDialog1.FileName;

                txtFilename.Text = pathScene;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Scene dirty?
            if (IsDirty)
            {
                // Check with the user that they're happy to lose the changes
                if (MessageBox.Show(this, "Scene is changed. Continue without saving?", "Scene Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    // User doesn't want to lose the unsaved work
                    return;
                }
            }

            // Show file open dialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Scene File|*.scn";
            ofd.Title = "Load...";
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != String.Empty)
            {
                // Clear the form
                ClearForm();

                // Read the scene from file
                ReadScene(ofd.FileName);

                // Set up the form for the new scene
                scrlFrame.Maximum = dots.Count() - 1;
                pathScene = ofd.FileName;
                txtFilename.Text = pathScene;
                SetDmdImage(0);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Scene dirty?
            if (IsDirty)
            {
                // Check with the user that they're happy to lose the changes
                if (MessageBox.Show(this, "Scene is changed. Continue without saving?", "Scene Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    // User doesn't want to lose the unsaved work
                    return;
                }
            }

            // Clear the form
            ClearForm();
        }

        private void btnCapturePB_Click(object sender, EventArgs e)
        {
            PinballBrowser dlgPB = new PinballBrowser();

            // Hide the main window
            Visible = false;

            // Show the Pinball Browser capture dialog
            if (dlgPB.ShowDialog(this) == DialogResult.OK)
            {
                // Got some dots, append onto the scene
                foreach (byte[,] item in dlgPB.import)
                {
                    dots.Add(item);
                }

                // Set the new scroll bar range and set the current image to something
                scrlFrame.Maximum = dots.Count() - 1;
                SetDmdImage(valuePrev);
            }

            Visible = true;
        }

        private void btnCaptureWPC_Click(object sender, EventArgs e)
        {
            WPCEdit dlgWPC = new WPCEdit();

            // Hide the main window
            Visible = false;

            // Show the WPC capture dialog
            if (dlgWPC.ShowDialog(this) == DialogResult.OK)
            {
                // Got some dots, append onto the scene
                foreach (byte[,] item in dlgWPC.import)
                {
                    dots.Add(item);
                }

                // Set the new scroll bar range and set the current image to something
                scrlFrame.Maximum = dots.Count() - 1;
                SetDmdImage(valuePrev);
            }

            // Show the main window again
            Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Change the pen size to match the selection
            dmdEdit1.BrushSize = Convert.ToInt32(cmbBrushSize.SelectedItem);
        }

        private void scrlFrame_ValueChanged(object sender, EventArgs e)
        {
            // Store the current mask
            StoreDmdMask(valuePrev);

            // Move to next image
            SetDmdImage(scrlFrame.Value);
            valuePrev = scrlFrame.Value;
        }

        private void cbFlatColour_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFlatColour.Checked)
            {
                // Flat colour required, set all palette entries (except 0) to Red 0xFF
                for (int idx = 0; idx < 16; idx++)
                {
                    dmdEdit1.SetPaletteEntry(idx, Color.FromArgb(0xFF, idx == 0 ? 0x00 : 0xFF, 0, 0));
                }
            }
            else
            {
                // Full colour, create a palette of graduated tones in Red
                for (int idx = 0; idx < 16; idx++)
                {
                    dmdEdit1.SetPaletteEntry(idx, Color.FromArgb(0xFF, (idx * 14) + (idx == 0 ? 0 : 45), 0, 0));
                }
            }

            // Force a refresh in the new palette
            dmdEdit1.Invalidate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dots.Count > 0)
            {
                int cur = scrlFrame.Value;

                mask.Remove(cur);

                // Renumber all other masks
                for (int idx = cur + 1; idx < dots.Count; idx++)
                {
                    if (mask.ContainsKey(idx))
                    {
                        mask.Add(idx - 1, mask[idx]);
                        mask.Remove(idx);
                    }
                }

                dots.RemoveAt(cur);

                if (dots.Count == 0)
                {
                    mask.Clear();
                    valuePrev = 0;
                    scrlFrame.Minimum = 0;
                    scrlFrame.Maximum = 0;
                    scrlFrame.Value = 0;
                    ClearDmdImage();
                }
                else
                {
                    if (cur == dots.Count - 1)
                    {
                        if (scrlFrame.Value > 0)
                        {
                            valuePrev -= 1;
                            scrlFrame.Value -= 1;
                        }
                    }

                    scrlFrame.Maximum -= 1;

                    SetDmdImage(scrlFrame.Value);
                }
            }
        }

        private void radPen_CheckedChanged(object sender, EventArgs e)
        {
            if (radPen.Checked)
            {
                // Switch to pen mode
                dmdEdit1.Fill = false;
            }
        }

        private void radFill_CheckedChanged(object sender, EventArgs e)
        {
            if (radFill.Checked)
            {
                // Switch to fill mode
                dmdEdit1.Fill = true;
            }
        }

        private void btnClearMask_Click(object sender, EventArgs e)
        {
            // Clear the dmd edeit mask
            dmdEdit1.ClearMask();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the app
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Scene dirty?
            if (IsDirty)
            {
                // Check with the user that they're happy to lose the changes
                if (MessageBox.Show(this, "Scene is changed. Continue without saving?", "Scene Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    // Don't exit from the app
                    e.Cancel = true;
                }
            }
        }
    }
}