using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace DotClock
{
    public partial class PinballBrowser : Form
    {
        RamGecTools.MouseHook mouseHook;
        IntPtr wndPinballBrowser = IntPtr.Zero;
        bool HookEnabled = false;

        public List<byte[,]> import = new List<byte[,]>();

        public PinballBrowser()
        {
            InitializeComponent();
            for (int idx = 0; idx < 16; idx++)
            {
                dmdPreview.SetPaletteEntry(idx, Color.FromArgb(0xFF, Convert.ToByte((idx * 14) + (idx == 0 ? 0 : 45)), 0, 0));
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            btnStartStop.Enabled = false;
            btnStartStop.Text = "Start";

            mouseHook = new RamGecTools.MouseHook();
            mouseHook.LeftButtonDown += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_LeftButtonDown);
            mouseHook.LeftButtonUp += new RamGecTools.MouseHook.MouseHookCallback(mouseHook_LeftButtonUp);

            if (!HookEnabled)
            {
                HookEnabled = true;
                mouseHook.Install();
            }

            wndPinballBrowser = IntPtr.Zero;
        }

        private void mouseHook_LeftButtonDown(WinAPI.MSLLHOOKSTRUCT mouseStruct)
        {
            if (wndPinballBrowser == IntPtr.Zero)
            {
                wndPinballBrowser = WinAPI.WindowFromPoint(mouseStruct.pt);
                btnStartStop.Enabled = true;

                HookEnabled = false;
                mouseHook.Uninstall();
            }
        }

        private void mouseHook_LeftButtonUp(WinAPI.MSLLHOOKSTRUCT mouseStruct)
        {
            // Wait for the pinball browser window to be updated
            Thread.Sleep(100);

            if (wndPinballBrowser != IntPtr.Zero && WinAPI.IsWindow(wndPinballBrowser))
            {
                // Get the capture window rectangle
                WinAPI.RECT wndRect = new WinAPI.RECT();
                WinAPI.GetWindowRect(wndPinballBrowser, out wndRect);

                // Capture only if mouse is on the advance frame button in Pinball Browser
                if (mouseStruct.pt.x >= (wndRect.X + 246) &&
                    mouseStruct.pt.y >= (wndRect.Y - 72) &&
                    mouseStruct.pt.x <= (wndRect.X + 246 + 17) &&
                    mouseStruct.pt.y <= (wndRect.Y - 72 + 24))
                {
                    Import();
                }
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!HookEnabled)
            {
                // Start capturing
                btnStartStop.Text = "Stop";
                HookEnabled = true;
                mouseHook.Install();

                btnSave.Enabled = true;

                Import();
            }
            else
            {
                // Stop capturing
                btnStartStop.Text = "Start";
                HookEnabled = false;
                mouseHook.Uninstall();
            }
        }

        private void Import()
        {
            Bitmap bmpScreenCapture = CaptureWindow(wndPinballBrowser);

            import.Add(new byte[128, 32]);

            dmdPreview.Clear();

            for (int x = 0; x < Math.Min(512, bmpScreenCapture.Width); x += 4)
            {
                for (int y = 0; y < Math.Min(128, bmpScreenCapture.Height); y += 4)
                {
                    byte value = GetIntensity(bmpScreenCapture.GetPixel(x, y).R);

                    // Update the preview
                    dmdPreview.SetDot(x / 4, y / 4, value);

                    // Update the byte array
                    import[import.Count()-1][x / 4, y / 4] = value;
                }
            }

            // Force a redraw of the preview
            dmdPreview.Invalidate();

            // Update the screen
            lblFrame.Text = String.Format("Frame: {0}", import.Count());
        }

        public Bitmap CaptureWindow(IntPtr hWnd)
        {
            WinAPI.RECT rctForm = new WinAPI.RECT(); 
            WinAPI.GetWindowRect(hWnd, out rctForm);

            Bitmap pImage = new System.Drawing.Bitmap(rctForm.Width, rctForm.Height);
            Graphics graphics = System.Drawing.Graphics.FromImage(pImage);
            IntPtr hDC = graphics.GetHdc();
            //paint control onto graphics using provided options        
            try
            {
                WinAPI.PrintWindow(hWnd, hDC, (uint)1);
            }
            finally
            {
                graphics.ReleaseHdc(hDC);
            }
            return pImage;
        }

        private Byte GetIntensity(Byte Red)
        {
            Byte ret;

            switch (Red)
            {
                case 0x00:
                    ret = 0x00;
                    break;

                case 113:
                    ret = 0x02;
                    break;

                case 140:
                    ret = 0x04;
                    break;

                case 161:
                    ret = 0x06;
                    break;

                case 177:
                    ret = 0x07;
                    break;

                case 191:
                    ret = 0x08;
                    break;

                case 203:
                    ret = 0x09;
                    break;

                case 214:
                    ret = 0x0A;
                    break;

                case 232:
                    ret = 0x0B;
                    break;

                case 240:
                    ret = 0x0C;
                    break;

                case 247:
                    ret = 0x0D;
                    break;

                case 255:
                    ret = 0x0F;
                    break;

                default:
                    ret = 0xFF;
                    break;
            }

            return ret;
        }
    }
}
