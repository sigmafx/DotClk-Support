using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SceneEditor
{
    public partial class WPCEdit : Form
    {
        IntPtr _ClipboardViewerNext;
        bool HookEnabled = false;
        public List<byte[,]> import = new List<byte[,]>();

        public WPCEdit()
        {
            InitializeComponent();

            for (int idx = 0; idx < 16; idx++)
            {
                dmdPreview.SetPaletteEntry(idx, Color.FromArgb(0xFF, Convert.ToByte((idx * 14) + (idx == 0 ? 0 : 45)), 0, 0));
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!HookEnabled)
            {
                // Start capturing
                btnStartStop.Text = "Stop";
                HookEnabled = true;
                RegisterClipboardViewer();

                btnSave.Enabled = true;
            }
            else
            {
                // Stop capturing
                btnStartStop.Text = "Start";
                HookEnabled = false;
                UnregisterClipboardViewer();
            }
        }

        private void RegisterClipboardViewer()
        {
            _ClipboardViewerNext = WinAPI.SetClipboardViewer(this.Handle);
        }

        private void UnregisterClipboardViewer()
        {
            WinAPI.ChangeClipboardChain(this.Handle, _ClipboardViewerNext);
        }

        private void Import()
        {
            if(Clipboard.ContainsText())
            {
                String clipdata;

                clipdata = Clipboard.GetText();
                if(clipdata.Length == ((128 * 32) + 64))
                {
                    int idx = 0;

                    import.Add(new byte[128, 32]);

                    dmdPreview.Clear();

                    for (int y = 0; y < 32; y += 1)
                    {
                        for (int x = 0; x < 128; x += 1)
                        {
                            byte value = GetIntensity(clipdata[idx]);

                            // Update the preview
                            dmdPreview.SetDot(x, y, value);

                            // Update the byte array
                            import[import.Count() - 1][x, y] = value;

                            // Next char please
                            idx++;
                        }

                        // Skip the line termination
                        idx += 2;
                    }

                    // Force a redraw of the preview
                    dmdPreview.Invalidate();

                    // Update the screen
                    lblFrame.Text = String.Format("Frame: {0}", import.Count());
                }
            }
        }

        private Byte GetIntensity(char value)
        {
            Byte ret;

            switch (value)
            {
                case '0':
                    ret = 0x00;
                    break;

                case '1':
                    ret = 0x02;
                    break;

                case '2':
                    ret = 0x04;
                    break;

                case '3':
                    ret = 0x0F;
                    break;

                default:
                    ret = 0x00;
                    break;
            }

            return ret;
        }

        protected override void WndProc(ref Message m)
        {
            switch ((WinAPI.Msgs)m.Msg)
            {
                //
                // The WM_DRAWCLIPBOARD message is sent to the first window 
                // in the clipboard viewer chain when the content of the 
                // clipboard changes. This enables a clipboard viewer 
                // window to display the new content of the clipboard. 
                //
                case WinAPI.Msgs.WM_DRAWCLIPBOARD:

                    Import();

                    //
                    // Each window that receives the WM_DRAWCLIPBOARD message 
                    // must call the SendMessage function to pass the message 
                    // on to the next window in the clipboard viewer chain.
                    //
                    WinAPI.SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    break;


                //
                // The WM_CHANGECBCHAIN message is sent to the first window 
                // in the clipboard viewer chain when a window is being 
                // removed from the chain. 
                //
                case WinAPI.Msgs.WM_CHANGECBCHAIN:

                    // When a clipboard viewer window receives the WM_CHANGECBCHAIN message, 
                    // it should call the SendMessage function to pass the message to the 
                    // next window in the chain, unless the next window is the window 
                    // being removed. In this case, the clipboard viewer should save 
                    // the handle specified by the lParam parameter as the next window in the chain. 

                    //
                    // wParam is the Handle to the window being removed from 
                    // the clipboard viewer chain 
                    // lParam is the Handle to the next window in the chain 
                    // following the window being removed. 
                    if (m.WParam == _ClipboardViewerNext)
                    {
                        //
                        // If wParam is the next clipboard viewer then it
                        // is being removed so update pointer to the next
                        // window in the clipboard chain
                        //
                        _ClipboardViewerNext = m.LParam;
                    }
                    else
                    {
                        WinAPI.SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    }
                    break;

                default:
                    //
                    // Let the form process the messages that we are
                    // not interested in
                    //
                    base.WndProc(ref m);
                    break;

            }
        }

        private void WPCEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(HookEnabled)
            {
                UnregisterClipboardViewer();
            }
        }
    }
}
