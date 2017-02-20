using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SceneEditor
{
    public partial class DmdPreview : UserControl
    {
        // Pixel data
        byte[,] dots = new byte[128, 32];

        // Palette
        Color[] palette = new Color[16];

        public DmdPreview()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // Blank the background
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), DisplayRectangle); // palette[pixels[x,y]]

            for (int x = 0; x < 128; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    e.Graphics.FillRectangle(new SolidBrush(palette[dots[x, y]]), x * 2, y * 2, 2, 2);
                }
            }
        }

        public void SetPaletteEntry(int idx, Color color)
        {
            if(idx >= 0 && idx <= 15)
            {
                palette[idx] = color;
            }
        }

        public void SetDot(int x, int y, byte dot)
        {
            if(!(x < 0 || x > 127 || y < 0 || y > 31))
            {
                dots[x, y] = dot;
            }
        }

        public void Clear()
        {
            Array.Clear(dots, 0, dots.Length);
        }
    }
}
