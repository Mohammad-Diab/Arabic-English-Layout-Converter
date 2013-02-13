using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Anti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string tmp;
        System.Windows.Forms.NotifyIcon notifyIcon;
        DispatcherTimer timer;
        DataObject saved;
        string savedText;
        uint sequence;
        int step, ticks;
        bool registered, hinted;

        const int WM_HOTKEY = 0x0312;
        const uint MOD_CONTROL = 0x0002;
        const uint MOD_SHIFT = 0x0004;
        const uint MOD_NOREPEAT = 0x4000;
        const uint KEYEVENTF_KEYUP = 0x0002;
        const byte VK_CONTROL = 0x11;
        const byte VK_SPACE = 0x20;

        [DllImport("user32.dll")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        static extern uint GetClipboardSequenceNumber();

        public MainWindow()
        {
            InitializeComponent();
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon(Application.GetResourceStream(new Uri("pack://application:,,,/Icon.ico")).Stream, System.Windows.Forms.SystemInformation.SmallIconSize);
            notifyIcon.Text = "Arabic-English Layout Converter";
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(new System.Windows.Forms.MenuItem[]
            {
                new System.Windows.Forms.MenuItem("Open", (s, e) => Restore()),
                new System.Windows.Forms.MenuItem("Exit", (s, e) => Close())
            });
            notifyIcon.DoubleClick += (s, e) => Restore();
            notifyIcon.Visible = true;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += Timer_Tick;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            source.AddHook(WndProc);
            registered = RegisterHotKey(source.Handle, 1, MOD_CONTROL | MOD_SHIFT | MOD_NOREPEAT, VK_SPACE);
            if (registered)
                notifyIcon.Text = "Arabic-English Layout Converter (Ctrl+Shift+Space)";
            else
                notifyIcon.ShowBalloonTip(5000, "Arabic-English Layout Converter", "Ctrl+Shift+Space is used by another program.", System.Windows.Forms.ToolTipIcon.Warning);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_HOTKEY && wParam.ToInt32() == 1)
            {
                if (!timer.IsEnabled)
                {
                    step = 0;
                    ticks = 0;
                    timer.Start();
                }
                handled = true;
            }
            return IntPtr.Zero;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (step == 0)
            {
                if (KeysDown())
                {
                    if (ticks > 250)
                        timer.Stop();
                    return;
                }
                SaveClipboard();
                sequence = GetClipboardSequenceNumber();
                Press(0x43);
                step = 1;
                ticks = 0;
            }
            else if (step == 1)
            {
                string text = null;
                if (GetClipboardSequenceNumber() != sequence)
                    text = GetText();
                if (text == null && ticks < 25)
                    return;
                if (string.IsNullOrEmpty(text))
                {
                    if (GetClipboardSequenceNumber() != sequence)
                        RestoreClipboard();
                    timer.Stop();
                    return;
                }
                try
                {
                    Clipboard.SetText(Layout.Auto(text));
                }
                catch
                {
                    RestoreClipboard();
                    timer.Stop();
                    return;
                }
                Press(0x56);
                step = 2;
                ticks = 0;
            }
            else if (ticks >= 20)
            {
                RestoreClipboard();
                timer.Stop();
            }
        }

        private bool KeysDown()
        {
            foreach (int key in new int[] { 0x10, 0x11, 0x12, 0x20, 0x5B, 0x5C })
                if ((GetAsyncKeyState(key) & 0x8000) != 0)
                    return true;
            return false;
        }

        private void Press(byte key)
        {
            keybd_event(VK_CONTROL, 0, 0, UIntPtr.Zero);
            keybd_event(key, 0, 0, UIntPtr.Zero);
            keybd_event(key, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        }

        private string GetText()
        {
            try
            {
                if (Clipboard.ContainsText())
                    return Clipboard.GetText();
            }
            catch
            {
            }
            return null;
        }

        private void SaveClipboard()
        {
            saved = new DataObject();
            savedText = GetText();
            try
            {
                IDataObject data = Clipboard.GetDataObject();
                if (data != null)
                    foreach (string format in data.GetFormats(false))
                        try
                        {
                            object value = data.GetData(format, false);
                            if (value != null)
                                saved.SetData(format, value, false);
                        }
                        catch
                        {
                        }
            }
            catch
            {
            }
        }

        private void RestoreClipboard()
        {
            try
            {
                if (saved.GetFormats(false).Length > 0)
                    Clipboard.SetDataObject(saved, true);
                else
                    Clipboard.Clear();
            }
            catch
            {
                try
                {
                    if (savedText != null)
                        Clipboard.SetText(savedText);
                }
                catch
                {
                }
            }
        }

        private void Restore()
        {
            Show();
            WindowState = WindowState.Normal;
            Activate();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                if (registered && !hinted)
                {
                    notifyIcon.ShowBalloonTip(3000, "Arabic-English Layout Converter", "Still running. Select text anywhere and press Ctrl+Shift+Space to convert it.", System.Windows.Forms.ToolTipIcon.Info);
                    hinted = true;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
            UnregisterHotKey(new WindowInteropHelper(this).Handle, 1);
            notifyIcon.Dispose();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tmp = TextBox1.Text;
            if (RadioButton1.IsChecked == true)
                English();
            else if (RadioButton2.IsChecked == true)
                Arabic();
            else if (RadioButton3.IsChecked == true)
                Capital();
            else if (RadioButton4.IsChecked == true)
                Small();
            TextBox2.Text = tmp;
        }

        private void English()
        {
            tmp = Layout.ToArabic(tmp);
        }

        private void Arabic()
        {
            tmp = Layout.ToEnglish(tmp);
        }

        private void Capital()
        {
            tmp = tmp.ToUpper();
        }

        private void Small()
        {
            tmp = tmp.ToLower();
        }
    }
}
