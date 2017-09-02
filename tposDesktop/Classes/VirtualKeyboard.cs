using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace VirtualKeyboard
{
    
    public partial class FormKeyBoard : Form
    {

        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOREDRAW = 0x0008;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const uint SWP_HIDEWINDOW = 0x0080;
        private const uint SWP_NOCOPYBITS = 0x0100;
        private const uint SWP_NOOWNERZORDER = 0x0200;
        private const uint SWP_NOSENDCHANGING = 0x0400;
        private int handle;
        #region SendMessage Constants

        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_LBUTTONDBLCLK = 0x0203;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;
        private const int WM_RBUTTONDBLCLK = 0x0206;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x0101;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btn5;
        private Button btn6;
        private Button btn4;
        private Label label1;
        private Button btnsolshift;
        private Button btnsagshift;
        private Button btnsagaltgr;
        private Button btnsolalt;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private const int WM_CHAR = 0x0102;
        #endregion SendMessage Constants
        #region API fonction
        //Public Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As Long 
        //this function gets active window identify number == (8975651603260375040) 
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SetActiveWindow", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]

        public static extern long SetActiveWindow(long hwnd);
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "keybd_event", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        public static extern long keybd_event(byte bVk, byte bScan, long dwFlags, long dwExtraInfo);

        #endregion
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        #region Virtual Keys Constants
        private const int VK_LBUTTON = 0X1; //Left mouse button. 
        private const int VK_RBUTTON = 0X2; //Right mouse button. 
        private const int VK_CANCEL = 0X3; //Used for control-break processing. 
        private const int VK_MBUTTON = 0X4; //''Middle mouse button (3-button mouse). 
        private const int KEYEVENTF_KEYUP = 0X2; // Release key 
        private const int VK_OEM_PERIOD = 0XBE; //.
        private const int KEYEVENTF_EXTENDEDKEY = 0X1;
        private const int VK_STARTKEY = 0X5B; //Start Menu key 
        private bool lockbool;
        private bool numlockbool;
        private bool ctrlbool;
        private bool onoff;
        private const int VK_OEM_COMMA = 0XBC; //, comma 
        public const int VK_0 = 0x30;
        public const int VK_1 = 0x31;
        public const int VK_2 = 0x32;
        public const int VK_3 = 0x33;
        public const int VK_4 = 0x34;
        public const int VK_5 = 0x35;
        public const int VK_6 = 0x36;
        public const int VK_7 = 0x37;
        public const int VK_8 = 0x38;
        public const int VK_9 = 0x39;
        public const int VK_A = 0x41;
        public const int VK_B = 0x42;
        public const int VK_C = 0x43;
        public const int VK_D = 0x44;
        public const int VK_E = 0x45;
        public const int VK_F = 0x46;
        public const int VK_G = 0x47;
        public const int VK_H = 0x48;
        public const int VK_I = 0x49;
        public const int VK_J = 0x4A;
        public const int VK_K = 0x4B;
        public const int VK_L = 0x4C;
        public const int VK_M = 0x4D;
        public const int VK_N = 0x4E;
        public const int VK_O = 0x4F;
        public const int VK_P = 0x50;
        public const int VK_Q = 0x51;
        public const int VK_R = 0x52;
        public const int VK_S = 0x53;
        public const int VK_T = 0x54;
        public const int VK_U = 0x55;
        public const int VK_V = 0x56;
        public const int VK_W = 0x57;
        public const int VK_X = 0x58;
        public const int VK_Y = 0x59;
        public const int VK_Z = 0x5A;
        public const int VK_BACK = 0x08;
        public const int VK_TAB = 0x09;
        public const int VK_CLEAR = 0x0C;
        public const int VK_RETURN = 0x0D;
        public const int VK_SHIFT = 0x10;
        public const int VK_CONTROL = 0x11;
        public const int VK_MENU = 0x12;
        public const int VK_PAUSE = 0x13;
        public const int VK_CAPITAL = 0x14;
        public const int VK_KANA = 0x15;
        public const int VK_HANGEUL = 0x15;
        public const int VK_HANGUL = 0x15;
        public const int VK_JUNJA = 0x17;
        public const int VK_FINAL = 0x18;
        public const int VK_HANJA = 0x19;
        public const int VK_KANJI = 0x19;
        public const int VK_ESCAPE = 0x1B;
        public const int VK_CONVERT = 0x1C;
        public const int VK_NONCONVERT = 0x1D;
        public const int VK_ACCEPT = 0x1E;
        public const int VK_MODECHANGE = 0x1F;
        public const int VK_SPACE = 0x20;
        public const int VK_PRIOR = 0x21;
        public const int VK_NEXT = 0x22;
        public const int VK_END = 0x23;
        public const int VK_HOME = 0x24;
        public const int VK_LEFT = 0x25;
        public const int VK_UP = 0x26;
        public const int VK_RIGHT = 0x27;
        public const int VK_DOWN = 0x28;
        public const int VK_SELECT = 0x29;
        public const int VK_PRINT = 0x2A;
        public const int VK_EXECUTE = 0x2B;
        public const int VK_SNAPSHOT = 0x2C;
        public const int VK_INSERT = 0x2D;
        public const int VK_DELETE = 0x2E;
        public const int VK_HELP = 0x2F;
        public const int VK_LWIN = 0x5B;
        public const int VK_RWIN = 0x5C;
        public const int VK_APPS = 0x5D;
        public const int VK_SLEEP = 0x5F;
        public const int VK_NUMPAD0 = 0x60;
        public const int VK_NUMPAD1 = 0x61;
        public const int VK_NUMPAD2 = 0x62;
        public const int VK_NUMPAD3 = 0x63;
        public const int VK_NUMPAD4 = 0x64;
        public const int VK_NUMPAD5 = 0x65;
        public const int VK_NUMPAD6 = 0x66;
        public const int VK_NUMPAD7 = 0x67;
        public const int VK_NUMPAD8 = 0x68;
        public const int VK_NUMPAD9 = 0x69;
        public const int VK_MULTIPLY = 0x6A;
        public const int VK_ADD = 0x6B;
        public const int VK_SEPARATOR = 0x6C;
        public const int VK_SUBTRACT = 0x6D;
        public const int VK_DECIMAL = 0x6E;
        public const int VK_DIVIDE = 0x6F;
        public const int VK_F1 = 0x70;
        public const int VK_F2 = 0x71;
        public const int VK_F3 = 0x72;
        public const int VK_F4 = 0x73;
        public const int VK_F5 = 0x74;
        public const int VK_F6 = 0x75;
        public const int VK_F7 = 0x76;
        public const int VK_F8 = 0x77;
        public const int VK_F9 = 0x78;
        public const int VK_F10 = 0x79;
        public const int VK_F11 = 0x7A;
        public const int VK_F12 = 0x7B;
        public const int VK_F13 = 0x7C;
        public const int VK_F14 = 0x7D;
        public const int VK_F15 = 0x7E;
        public const int VK_F16 = 0x7F;
        public const int VK_F17 = 0x80;
        public const int VK_F18 = 0x81;
        public const int VK_F19 = 0x82;
        public const int VK_F20 = 0x83;
        public const int VK_F21 = 0x84;
        public const int VK_F22 = 0x85;
        public const int VK_F23 = 0x86;
        public const int VK_F24 = 0x87;
        public const int VK_NUMLOCK = 0x90;
        public const int VK_SCROLL = 0x91;
        #endregion Virtual Keys Constants

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)] // used for button-down & button-up 
        private static extern int PostMessage(int hWnd, int msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        public FormKeyBoard()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void SetFocus()
        {

            SetForegroundWindow(new IntPtr(this.handle));

        }

        public void SendLeftButtonDown(int x, int y)
        {

            PostMessage(handle, WM_LBUTTONDOWN, 0, new IntPtr(y * 0x10000 + x));

        }
        public void SendLeftButtonUp(int x, int y)
        {
            PostMessage(handle, WM_LBUTTONUP, 0, new IntPtr(y * 0x10000 + x));

        }
        public void SendLeftButtondblclick(int x, int y)
        {
            PostMessage(handle, WM_LBUTTONDBLCLK, 0, new IntPtr(y * 0x10000 + x));

        }
        public void SendRightButtonDown(int x, int y)
        {

            PostMessage(handle, WM_RBUTTONDOWN, 0, new IntPtr(y * 0x10000 + x));

        }
        public void SendRightButtonUp(int x, int y)
        {
            PostMessage(handle, WM_RBUTTONUP, 0, new IntPtr(y * 0x10000 + x));

        }
        public void SendRightButtondblclick(int x, int y)
        {

            PostMessage(handle, WM_RBUTTONDBLCLK, 0, new IntPtr(y * 0x10000 + x));

        }
        public void SendMouseMove(int x, int y)
        {
            PostMessage(handle, WM_MOUSEMOVE, 0, new IntPtr(y * 0x10000 + x));

        }
        public void SendKeyDown(int key)
        {
            PostMessage(handle, WM_KEYDOWN, key, IntPtr.Zero);
        }
        public void SendKeyUp(int key)
        {

            PostMessage(handle, WM_KEYUP, key, new IntPtr(1));

        }
        public void SendChar(char c)
        {

            SendMessage(handle, WM_CHAR, c, IntPtr.Zero);
        }

        public void SendString(string s)
        {

            foreach (char c in s) SendChar(c);
        }

        // forcus 
        public void MouseMoved(object sender, MouseEventArgs e)
        {
            label1.Text = String.Format("x={0} y={1}", e.X, e.Y);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Text = "You Clicked on this button";
            SendKeys.Send("{CAPSLOCK}");

        }
        private void Form1_Activated(object sender, EventArgs e)
        {

            SendKeys.Send("{CAPSLOCK}");
        }
        // end 
        // function key 
        #region which button pushed function
        //INSTANT C# NOTE: These were formerly VB static local variables:
        private int screenshot_i;
        public string whichbuttonpushed(string _sender)
        {
            try
            {
                SetActiveWindow(8975651603260375040); //Set focus Active window 
                //I found this number("8975651603260375040") via getactivewindow method. 
                switch (_sender)
                {
                    case "btna":
                        keybd_event(VK_A, 0, 0, 0);
                        keybd_event(VK_A, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnb":
                        keybd_event(VK_B, 0, 0, 0);
                        keybd_event(VK_B, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnc":
                        keybd_event(VK_C, 0, 0, 0);
                        keybd_event(VK_C, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btn_c":
                        keybd_event(VK_C, 0, 0, 0);
                        keybd_event(VK_C, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnd":
                        keybd_event(VK_D, 0, 0, 0);
                        keybd_event(VK_D, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btne":
                        keybd_event(VK_E, 0, 0, 0);
                        keybd_event(VK_E, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnf":
                        keybd_event(VK_F, 0, 0, 0);
                        keybd_event(VK_F, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btng":
                        keybd_event(VK_G, 0, 0, 0);
                        keybd_event(VK_G, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btn_g":
                        keybd_event(VK_G, 0, 0, 0);
                        keybd_event(VK_G, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnh":
                        keybd_event(VK_H, 0, 0, 0);
                        keybd_event(VK_H, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btn_i":
                        keybd_event(VK_I, 0, 0, 0);
                        keybd_event(VK_I, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btni":
                        keybd_event(VK_I, 0, 0, 0);
                        keybd_event(VK_I, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnj":
                        keybd_event(VK_J, 0, 0, 0);
                        keybd_event(VK_J, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnk":
                        keybd_event(VK_K, 0, 0, 0);
                        keybd_event(VK_K, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnl":
                        keybd_event(VK_L, 0, 0, 0);
                        keybd_event(VK_L, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnm":
                        keybd_event(VK_M, 0, 0, 0);
                        keybd_event(VK_M, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnn":
                        keybd_event(VK_N, 0, 0, 0);
                        keybd_event(VK_N, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btno":
                        keybd_event(VK_O, 0, 0, 0);
                        keybd_event(VK_O, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btn_o":
                        keybd_event(VK_O, 0, 0, 0);
                        keybd_event(VK_O, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnp":
                        keybd_event(VK_P, 0, 0, 0);
                        keybd_event(VK_P, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnr":
                        keybd_event(VK_R, 0, 0, 0);
                        keybd_event(VK_R, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btns":
                        keybd_event(VK_S, 0, 0, 0);
                        keybd_event(VK_S, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btn_s":
                        keybd_event(VK_S, 0, 0, 0);
                        keybd_event(VK_S, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnt":
                        keybd_event(VK_T, 0, 0, 0);
                        keybd_event(VK_T, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnu":
                        keybd_event(VK_U, 0, 0, 0);
                        keybd_event(VK_U, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btn_u":
                        keybd_event(VK_U, 0, 0, 0);
                        keybd_event(VK_U, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnv":
                        keybd_event(VK_V, 0, 0, 0);
                        keybd_event(VK_V, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btny":
                        keybd_event(VK_Y, 0, 0, 0);
                        keybd_event(VK_Y, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnz":
                        keybd_event(VK_Z, 0, 0, 0);
                        keybd_event(VK_Z, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnw":
                        keybd_event(VK_W, 0, 0, 0);
                        keybd_event(VK_W, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnq":
                        keybd_event(VK_Q, 0, 0, 0);
                        keybd_event(VK_Q, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnx":
                        keybd_event(VK_X, 0, 0, 0);
                        keybd_event(VK_X, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        //*************************************************************************************** 
                        break;
                    case "btnnokta": //"." 
                        keybd_event(VK_OEM_PERIOD, 0, 0, 0);
                        keybd_event(VK_OEM_PERIOD, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnesc":
                        keybd_event(VK_ESCAPE, 0, 0, 0);
                        keybd_event(VK_ESCAPE, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnf1":
                        keybd_event(VK_F1, 0, 0, 0);
                        keybd_event(VK_F1, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnf2":
                        keybd_event(VK_F2, 0, 0, 0);
                        keybd_event(VK_F2, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnf3":
                        keybd_event(VK_F3, 0, 0, 0);
                        keybd_event(VK_F3, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnf4":
                        keybd_event(VK_F4, 0, 0, 0);
                        keybd_event(VK_F4, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnf5":
                        keybd_event(VK_F5, 0, 0, 0);
                        keybd_event(VK_F5, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnf6":
                        keybd_event(VK_F6, 0, 0, 0);
                        keybd_event(VK_F6, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnf7":
                        keybd_event(VK_F7, 0, 0, 0);
                        keybd_event(VK_F7, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btnf8":
                        keybd_event(VK_F8, 0, 0, 0);
                        keybd_event(VK_F8, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btn9":
                        keybd_event(VK_9, 0, 0, 0);
                        keybd_event(VK_9, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btncarpi": // *                //  
                        keybd_event(VK_MULTIPLY, 0, 0, 0);
                        keybd_event(VK_MULTIPLY, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;
                    case "btneksi": // - 
                        keybd_event(VK_SUBTRACT, 0, 0, 0);
                        keybd_event(VK_SUBTRACT, 0, KEYEVENTF_KEYUP, 0);
                        shiftrelease();
                        altrelease();
                        leftaltrelease();
                        break;

                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            return null;
        }

        #endregion
        // alt          
        #region shift ,altgr and alt release sub
        public void shiftrelease()
        {
            btnsolshift.BackColor = Color.FromArgb(224, 224, 224);
            btnsagshift.BackColor = Color.FromArgb(224, 224, 224);
            keybd_event(VK_SHIFT, 0, 2, 0);
        }
        public void altrelease()
        {
            keybd_event(VK_MENU, 0, KEYEVENTF_EXTENDEDKEY | 2, 0);
            btnsagaltgr.BackColor = Color.FromArgb(224, 224, 224);
        }
        public void leftaltrelease()
        {
            keybd_event(VK_MENU, 0, KEYEVENTF_KEYUP, 0);
            btnsolalt.BackColor = Color.FromArgb(224, 224, 224);
        }
        #endregion
        // numlock 
        #region numlock function
        public string numlockfunc(string numlock_tus, bool open_close)
        {
            try
            {
                if (open_close == false) //numlock opened 
                {
                    switch (numlock_tus)
                    {
                        case "btnnumlockbolu":
                            keybd_event(VK_DIVIDE, 0, 0, 0);
                            keybd_event(VK_DIVIDE, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlockcarpi":
                            keybd_event(VK_MULTIPLY, 0, 0, 0);
                            keybd_event(VK_MULTIPLY, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlockeksi":
                            keybd_event(VK_SUBTRACT, 0, 0, 0);
                            keybd_event(VK_SUBTRACT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlockarti":
                            keybd_event(VK_ADD, 0, 0, 0);
                            keybd_event(VK_ADD, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlockenter":
                            keybd_event(VK_RETURN, 0, 0, 0);
                            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlocknokta":
                            keybd_event(VK_DECIMAL, 0, 0, 0);
                            keybd_event(VK_DECIMAL, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock0":
                            keybd_event(VK_NUMPAD0, 0, 0, 0);
                            keybd_event(VK_NUMPAD0, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock1":
                            keybd_event(VK_NUMPAD1, 0, 0, 0);
                            keybd_event(VK_NUMPAD1, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock2":
                            keybd_event(VK_NUMPAD2, 0, 0, 0);
                            keybd_event(VK_NUMPAD2, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock3":
                            keybd_event(VK_NUMPAD3, 0, 0, 0);
                            keybd_event(VK_NUMPAD3, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock4":
                            keybd_event(VK_NUMPAD4, 0, 0, 0);
                            keybd_event(VK_NUMPAD4, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock5":
                            keybd_event(VK_NUMPAD5, 0, 0, 0);
                            keybd_event(VK_NUMPAD5, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock6":
                            keybd_event(VK_NUMPAD6, 0, 0, 0);
                            keybd_event(VK_NUMPAD6, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock7":
                            keybd_event(VK_NUMPAD7, 0, 0, 0);
                            keybd_event(VK_NUMPAD7, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock8":
                            keybd_event(VK_NUMPAD8, 0, 0, 0);
                            keybd_event(VK_NUMPAD8, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock9":
                            keybd_event(VK_NUMPAD9, 0, 0, 0);
                            keybd_event(VK_NUMPAD9, 0, KEYEVENTF_KEYUP, 0);
                            break;
                    }
                }
                else //numlock closed 
                {
                    switch (numlock_tus)
                    {
                        case "btnnumlockbolu":
                            keybd_event(VK_DIVIDE, 0, 0, 0);
                            keybd_event(VK_DIVIDE, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlockcarpi":
                            keybd_event(VK_MULTIPLY, 0, 0, 0);
                            keybd_event(VK_MULTIPLY, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlockeksi":
                            keybd_event(VK_SUBTRACT, 0, 0, 0);
                            keybd_event(VK_SUBTRACT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlockarti":
                            keybd_event(VK_ADD, 0, 0, 0);
                            keybd_event(VK_ADD, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlockenter":
                            keybd_event(VK_RETURN, 0, 0, 0);
                            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlocknokta":
                            keybd_event(VK_DELETE, 0, 0, 0);
                            keybd_event(VK_DELETE, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock0":
                            keybd_event(VK_INSERT, 0, 0, 0);
                            keybd_event(VK_INSERT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock1":
                            keybd_event(VK_END, 0, 0, 0);
                            keybd_event(VK_END, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock2":
                            keybd_event(VK_DOWN, 0, 0, 0);
                            keybd_event(VK_DOWN, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock3":
                            keybd_event(VK_NEXT, 0, 0, 0);
                            keybd_event(VK_NEXT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock4":
                            keybd_event(VK_LEFT, 0, 0, 0);
                            keybd_event(VK_LEFT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock5":
                            break;
                        case "btnnumlock6":
                            keybd_event(VK_RIGHT, 0, 0, 0);
                            keybd_event(VK_RIGHT, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock7":
                            keybd_event(VK_HOME, 0, 0, 0);
                            keybd_event(VK_HOME, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock8":
                            keybd_event(VK_UP, 0, 0, 0);
                            keybd_event(VK_UP, 0, KEYEVENTF_KEYUP, 0);
                            break;
                        case "btnnumlock9":
                            keybd_event(VK_PRIOR, 0, 0, 0);
                            keybd_event(VK_PRIOR, 0, KEYEVENTF_KEYUP, 0);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            return null;

        }

        #endregion
        private void btn1_Click(object sender, EventArgs e)
        {

            try
            {
                Button key = (Button)sender;
                whichbuttonpushed(key.Name);
                SetActiveWindow(8975651603260375040); //This Line Very Impportant
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;

            }
            finally
            {
                SetActiveWindow(8975651603260375040);
            }

        }
        private void btnlock_Click(object sender, EventArgs e)
        {
            try
            {
                Button key = (Button)sender;
                whichbuttonpushed(key.Name);
                SetActiveWindow(8975651603260375040); //This Line Very Impportant 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {

                SetActiveWindow(8975651603260375040);
            }
        }
        private void btnsolwindows_Click(object sender, EventArgs e)
        {
            try
            {
                Button key = (Button)sender;
                whichbuttonpushed(key.Name);
                SetActiveWindow(8975651603260375040); //This Line Very Impportant 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            finally
            {
                SetActiveWindow(8975651603260375040);
            }

        }
        private void btnsolshift_Click(object sender, EventArgs e)
        {

            try
            {
                Button key = (Button)sender;
                whichbuttonpushed(key.Name);
                SetActiveWindow(8975651603260375040); //This Line Very Impportant 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                SetActiveWindow(8975651603260375040);
            }
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                Button key = (Button)sender;
                whichbuttonpushed(key.Name);
                SetActiveWindow(8975651603260375040); //This Line Very Impportant 

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                SetActiveWindow(8975651603260375040);
            }

        }

        private void InitializeComponent()
        {
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsolshift = new System.Windows.Forms.Button();
            this.btnsagshift = new System.Windows.Forms.Button();
            this.btnsagaltgr = new System.Windows.Forms.Button();
            this.btnsolalt = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(23, 81);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 53);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(104, 81);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 53);
            this.btn2.TabIndex = 0;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(185, 81);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 53);
            this.btn3.TabIndex = 0;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(23, 199);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(75, 53);
            this.btn7.TabIndex = 0;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(104, 199);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(75, 53);
            this.btn8.TabIndex = 0;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(185, 199);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(75, 53);
            this.btn9.TabIndex = 0;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(104, 140);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 53);
            this.btn5.TabIndex = 0;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(185, 140);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 53);
            this.btn6.TabIndex = 0;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(23, 140);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 53);
            this.btn4.TabIndex = 0;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // btnsolshift
            // 
            this.btnsolshift.Location = new System.Drawing.Point(384, 119);
            this.btnsolshift.Name = "btnsolshift";
            this.btnsolshift.Size = new System.Drawing.Size(75, 62);
            this.btnsolshift.TabIndex = 2;
            this.btnsolshift.Text = "ShiftLeft";
            this.btnsolshift.UseVisualStyleBackColor = true;
            // 
            // btnsagshift
            // 
            this.btnsagshift.Location = new System.Drawing.Point(481, 119);
            this.btnsagshift.Name = "btnsagshift";
            this.btnsagshift.Size = new System.Drawing.Size(93, 62);
            this.btnsagshift.TabIndex = 2;
            this.btnsagshift.Text = "ShiftRight";
            this.btnsagshift.UseVisualStyleBackColor = true;
            // 
            // btnsagaltgr
            // 
            this.btnsagaltgr.Location = new System.Drawing.Point(384, 199);
            this.btnsagaltgr.Name = "btnsagaltgr";
            this.btnsagaltgr.Size = new System.Drawing.Size(75, 62);
            this.btnsagaltgr.TabIndex = 2;
            this.btnsagaltgr.Text = "Alt";
            this.btnsagaltgr.UseVisualStyleBackColor = true;
            // 
            // btnsolalt
            // 
            this.btnsolalt.Location = new System.Drawing.Point(481, 199);
            this.btnsolalt.Name = "btnsolalt";
            this.btnsolalt.Size = new System.Drawing.Size(93, 62);
            this.btnsolalt.TabIndex = 2;
            this.btnsolalt.Text = "Alt R";
            this.btnsolalt.UseVisualStyleBackColor = true;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(185, 24);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(389, 101);
            this.elementHost1.TabIndex = 3;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // FormKeyBoard
            // 
            this.ClientSize = new System.Drawing.Size(732, 273);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.btnsolalt);
            this.Controls.Add(this.btnsagshift);
            this.Controls.Add(this.btnsagaltgr);
            this.Controls.Add(this.btnsolshift);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Name = "FormKeyBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}