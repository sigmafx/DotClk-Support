#region Copyright
/// <copyright>
/// Copyright (c) 2011 Ramunas Geciauskas, http://geciauskas.com
///
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
///
/// The above copyright notice and this permission notice shall be included in
/// all copies or substantial portions of the Software.
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
/// THE SOFTWARE.
/// </copyright>
/// <author>Ramunas Geciauskas</author>
/// <summary>Contains a MouseHook class for setting up low level Windows mouse hooks.</summary>
#endregion

using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using SceneEditor;

namespace RamGecTools
{
    /// <summary>
    /// Class for intercepting low level Windows mouse hooks.
    /// </summary>
    class MouseHook
    {
        /// <summary>
        /// Internal callback processing function
        /// </summary>
        private WinAPI.MouseHookHandler hookHandler;

        /// <summary>
        /// Function to be called when defined even occurs
        /// </summary>
        /// <param name="mouseStruct">MSLLHOOKSTRUCT mouse structure</param>
        public delegate void MouseHookCallback(WinAPI.MSLLHOOKSTRUCT mouseStruct);

        #region Events
        public event MouseHookCallback LeftButtonDown;
        public event MouseHookCallback LeftButtonUp;
        public event MouseHookCallback RightButtonDown;
        public event MouseHookCallback RightButtonUp;
        public event MouseHookCallback MouseMove;
        public event MouseHookCallback MouseWheel;
        public event MouseHookCallback DoubleClick;
        public event MouseHookCallback MiddleButtonDown;
        public event MouseHookCallback MiddleButtonUp;
        #endregion

        /// <summary>
        /// Low level mouse hook's ID
        /// </summary>
        private IntPtr hookID = IntPtr.Zero;

        /// <summary>
        /// Install low level mouse hook
        /// </summary>
        /// <param name="mouseHookCallbackFunc">Callback function</param>
        public void Install()
        {
            hookHandler = HookFunc;
            hookID = SetHook(hookHandler);
        }

        /// <summary>
        /// Remove low level mouse hook
        /// </summary>
        public void Uninstall()
        {
            if (hookID == IntPtr.Zero)
                return;

            WinAPI.UnhookWindowsHookEx(hookID);
            hookID = IntPtr.Zero;
        }

        /// <summary>
        /// Destructor. Unhook current hook
        /// </summary>
        ~MouseHook()
        {
            Uninstall();
        }

        /// <summary>
        /// Sets hook and assigns its ID for tracking
        /// </summary>
        /// <param name="proc">Internal callback function</param>
        /// <returns>Hook ID</returns>
        private IntPtr SetHook(WinAPI.MouseHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                return WinAPI.SetWindowsHookEx(WinAPI.WH_MOUSE_LL, proc, WinAPI.GetModuleHandle(module.ModuleName), 0);
        }

        /// <summary>
        /// Callback function
        /// </summary>
        private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // parse system messages
            if (nCode >= 0)
            {
                if (WinAPI.MouseMessages.WM_LBUTTONDOWN == (WinAPI.MouseMessages)wParam)
                    if (LeftButtonDown != null)
                        LeftButtonDown((WinAPI.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinAPI.MSLLHOOKSTRUCT)));
                if (WinAPI.MouseMessages.WM_LBUTTONUP == (WinAPI.MouseMessages)wParam)
                    if (LeftButtonUp != null)
                        LeftButtonUp((WinAPI.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinAPI.MSLLHOOKSTRUCT)));
                if (WinAPI.MouseMessages.WM_RBUTTONDOWN == (WinAPI.MouseMessages)wParam)
                    if (RightButtonDown != null)
                        RightButtonDown((WinAPI.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinAPI.MSLLHOOKSTRUCT)));
                if (WinAPI.MouseMessages.WM_RBUTTONUP == (WinAPI.MouseMessages)wParam)
                    if (RightButtonUp != null)
                        RightButtonUp((WinAPI.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinAPI.MSLLHOOKSTRUCT)));
                if (WinAPI.MouseMessages.WM_MOUSEMOVE == (WinAPI.MouseMessages)wParam)
                    if (MouseMove != null)
                        MouseMove((WinAPI.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinAPI.MSLLHOOKSTRUCT)));
                if (WinAPI.MouseMessages.WM_MOUSEWHEEL == (WinAPI.MouseMessages)wParam)
                    if (MouseWheel != null)
                        MouseWheel((WinAPI.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinAPI.MSLLHOOKSTRUCT)));
                if (WinAPI.MouseMessages.WM_LBUTTONDBLCLK == (WinAPI.MouseMessages)wParam)
                    if (DoubleClick != null)
                        DoubleClick((WinAPI.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinAPI.MSLLHOOKSTRUCT)));
                if (WinAPI.MouseMessages.WM_MBUTTONDOWN == (WinAPI.MouseMessages)wParam)
                    if (MiddleButtonDown != null)
                        MiddleButtonDown((WinAPI.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinAPI.MSLLHOOKSTRUCT)));
                if (WinAPI.MouseMessages.WM_MBUTTONUP == (WinAPI.MouseMessages)wParam)
                    if (MiddleButtonUp != null)
                        MiddleButtonUp((WinAPI.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WinAPI.MSLLHOOKSTRUCT)));
            }
            return WinAPI.CallNextHookEx(hookID, nCode, wParam, lParam);
        }
    }
}
