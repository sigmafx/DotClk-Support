using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FontEditor
{
    public partial class FontEdit : UserControl
    {
        private int dotWidth = 0;
        private int dotHeight = 0;
        private int dotSide = 7;
        private DrawMode mode = DrawMode.DOT;

        private Color[] palette = new Color[16];
        private ushort idxDotColour ;

        bool dirty = false;

        private byte[,] dots = null;
        private byte[,] mask = null;

        public enum DrawMode
        {
            DOT,
            MASK
        }

        public FontEdit()
        {
            // Create a default palette
            for(int idx = 0; idx < palette.Count(); idx++)
            {
                palette[idx] = Color.FromArgb(0xFF, (idx * 12) + (idx == 0 ? 0 : 60), 0, 0);
            }

            idxDotColour = Convert.ToUInt16(palette.Count() - 1);

            // Switch on double buffering for redraw performance
            DoubleBuffered = true;

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int x = 0; x < dotWidth; x++)
            {
                for(int y = 0; y < dotHeight; y++)
                {
                    Rectangle rectCell = new Rectangle(x * dotSide, y * dotSide, dotSide, dotSide);

                    // Draw the dot rectangle
                    if (dots[x, y] == 0x00)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Black), rectCell);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(palette[dots[x,y]]), rectCell);
                    }

                    // Draw the mask rectangle
                    if (mask[x, y] == 0x01)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.White), rectCell);
                    }

                    // Draw the surrounding rectangle
                    e.Graphics.DrawRectangle(new Pen(Color.Gray), rectCell);
                }
            }
        }

        public void Create(int width, int height)
        {
            dotWidth = width;
            dotHeight = height;

            this.Width = width * dotSide;
            this.Height = height * dotSide;

            dots = new byte[width, height];
            mask = new byte[width, height];

            Array.Clear(dots, 0, dots.Length);
            Array.Clear(mask, 0, mask.Length);

            dirty = true;
            Invalidate();
        }

        public void Amend(int width, int height)
        {
            byte[,] dotsAmend = new byte[width, height];
            byte[,] maskAmend = new byte[width, height];

            for(int x = 0; x < Math.Min(width, dotWidth); x++)
            {
                for(int y = 0; y < Math.Min(height, dotHeight); y++)
                {
                    dotsAmend[x, y] = dots[x, y];
                    maskAmend[x, y] = mask[x, y];
                }
            }

            dots = dotsAmend;
            mask = maskAmend;

            dotWidth = width;
            dotHeight = height;

            this.Width = width * dotSide;
            this.Height = height * dotSide;

            dirty = true;
            Invalidate();
        }

        public void ClearDots()
        {
            if(dots != null && dots.Length > 0)
            {
                Array.Clear(dots, 0, dots.Length);

                dirty = true;
                Invalidate();
            }
        }

        public void ClearMask()
        {
            if(mask != null && mask.Length > 0)
            {
                Array.Clear(mask, 0, mask.Length);

                dirty = true;
                Invalidate();
            }
        }

        public void FillMask()
        {
            if (mask != null && mask.Length > 0)
            {
                for(int y = 0; y < dotHeight; y++)
                {
                    for(int x = 0; x < dotWidth; x++)
                    {
                        if(dots[x,y] == 0x00)
                        {
                            mask[x, y] = 0x01;
                        }
                    }
                }

                dirty = true;
                Invalidate();
            }
        }

        public void SetPlatte(int idx, Color color)
        {
            if(!(idx < 0 || idx > 15))
            {
                palette[idx] = color;
                Invalidate();
            }
        }

        public DrawMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public int DotSide
        {
            get { return dotSide; }
            set { dotSide = value; Invalidate(); }
        }

        public bool IsDirty
        {
            get { return dirty; }
            set { dirty = value; }
        }

        public ushort DotColour
        {
            get { return idxDotColour; }
            set { if (!(value < 0 || value > (palette.Count() - 1))) idxDotColour = value; }
        }

        public int CharacterWidth
        {
            get { return dotWidth; }
        }

        public byte[,] Dots
        {
            get { return dots; }
            set
            {
                if (value == null)
                {
                    ClearDots();
                }
                else
                {
                    dots = value;
                }
            }
        }

        public byte[,] Mask
        {
            get { return mask; }
            set
            {
                if(value == null)
                {
                    ClearMask();
                }
                else
                {
                    mask = value;
                }
            }
        }

        private void FontEdit_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / dotSide;
            int y = e.Y / dotSide;

            // Check we're in range
            if(!(x < 0 || x > (dotWidth - 1) || y < 0 || y > (dotHeight - 1)))
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (mode == DrawMode.DOT)
                    {
                        mask[x, y] = 0x00;
                        dots[x, y] = Convert.ToByte(idxDotColour);
                    }
                    else
                    {
                        if(dots[x, y] == 0x00)
                        {
                            mask[x, y] = 0x01;
                        }
                    }

                    dirty = true;
                    Invalidate();
                }
                else
                if (e.Button == MouseButtons.Right)
                {
                    dots[x, y] = 0x00;
                    mask[x, y] = 0x00;

                    dirty = true;
                    Invalidate();
                }
            }
        }

        private void FontEdit_MouseMove(object sender, MouseEventArgs e)
        {
            FontEdit_MouseClick(sender, e);
        }
    }
}
