using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SceneEditor
{
    public partial class DmdEdit : UserControl
    {
        // Pixel data
        public byte[,] dots = new byte[128, 32];

        // Mask data
        public byte[,] mask = new byte[128, 32];

        // Palette
        Color[] palette = new Color[16];

        private int brushSize = 1;
        private int dotSide;
        private bool isdirty = false;
        private bool isfill = false;

        public DmdEdit()
        {
            // Size of dots to display
            dotSide = 4;

            // Double buffered output for performance
            DoubleBuffered = true;

            // Create a default palette
            for(int idx = 0; idx < palette.Count();  idx++)
            {
                palette[idx] = Color.FromArgb(0xFF, idx * 17, 0, 0);
            }

            InitializeComponent();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // Blank the background
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), DisplayRectangle);

            for (int x = 0; x < 128; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    e.Graphics.FillRectangle(mask[x, y] == 0x01 ? new SolidBrush(Color.White) : new SolidBrush(Color.Black), x * dotSide, y * dotSide, dotSide, dotSide);
                    if(dots[x, y] != 0x00)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(palette[dots[x,y]]), new Rectangle(x * dotSide, y * dotSide, dotSide, dotSide));
                    }
                }
            }
        }

        private void DmdEdit_MouseDown(object sender, MouseEventArgs e)
        {
            int idxX = e.X / dotSide;
            int idxY = e.Y / dotSide;

            // Check range
            if(!(idxX < 0 || idxX > 127 || idxY < 0 || idxY > 31))
            {
                if(e.Button == MouseButtons.Left)
                {
                    if(isfill)
                    {
                        MaskFill(idxX, idxY);
                    }
                    else
                    {
                        MaskPaintBrush(idxX, idxY, true, brushSize);
                    }
                }
                else
                if (e.Button == MouseButtons.Right)
                {
                    if(!isfill)
                    {
                        MaskPaintBrush(idxX, idxY, false, brushSize);
                    }
                }

                this.Invalidate();
            }
        }

        private void MaskPaintBrush(int x, int y, bool set, int size)
        {
            for (int idxX = (x - (size / 2)); idxX < (x + size); idxX++)
            {
                for (int idxY = (y - (size / 2)); idxY < (y + size); idxY++)
                {
                    MaskPaintDot(idxX, idxY, set);
                }
            }
        }

        private void MaskPaintDot(int x, int y, bool set)
        {
            if(!(x < 0 || x > 127 || y < 0 || y > 31))
            if (dots[x, y] == 0x00)
            {
                if (set)
                {
                    mask[x, y] = 0x01;
                    
                }
                else
                {
                    mask[x, y] = 0x00;
                }
            }

            isdirty = true;
        }

        private void MaskFill(int xstart, int ystart)
        {
            int ymin, xmin;

            // Find the top of the fill area
            for(ymin = ystart; ymin >= 0; ymin--)
            {
                if(dots[xstart, ymin] != 0x00 || mask[xstart,ymin] != 0x00)
                {
                    break;
                }
            }

            if(ymin == ystart)
            {
                // No where to fill from this start point
                return;
            }

            if(ymin < 0)
            {
                ymin = 0;
            }
            else
            {
                ymin+=1;
            }
            
            for(int y = ymin; y < 32; y++)
            {
                if (dots[xstart, y] != 0x00 || mask[xstart, y] != 0x00)
                {
                    break;
                }

                // Find the left of the fill row
                for (xmin = xstart; xmin >= 0; xmin--)
                {
                    if (dots[xmin, y] != 0x00 || mask[xmin, y] != 0x00)
                    {
                        break;
                    }
                }

                if(xmin == xstart)
                {
                    continue;
                }

                if(xmin < 0)
                {
                    xmin = 0;
                }
                else
                {
                    xmin+=1;
                }

                for (int x = xmin; x < 128; x++)
                {
                    if (dots[x,y] != 0x00 || mask[x,y] != 0x00)
                    {
                        break;
                    }
                    else
                    {
                        mask[x, y] = 0x01;
                    }
                }
            }
        }

        private void DmdEdit_MouseMove(object sender, MouseEventArgs e)
        {
            DmdEdit_MouseDown(sender, e);
        }

        public void SetPaletteEntry(int idx, Color color)
        {
            if (idx >= 0 && idx <= 15)
            {
                palette[idx] = color;
            }
        }

        public int BrushSize
        {
            get { return brushSize; }
            set { brushSize = value; }
        }

        public bool IsDirty
        {
            get { return isdirty; }
            set { isdirty = IsDirty; }
        }

        public bool Fill
        {
            set { isfill = value; }
        }

        public void ClearDots()
        {
            // Clear the dot array and redraw
            Array.Clear(dots, 0, dots.Length);
            Invalidate();
        }

        public void ClearMask()
        {
            // Clear the mask array and redraw
            Array.Clear(mask, 0, mask.Length);
            Invalidate();
        }
    }
}
