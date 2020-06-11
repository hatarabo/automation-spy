using HataRabo.Hook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace AutomationSpy
{
    public partial class Form1 : Form
    {
        private class Data
        {
            public string Title { get; private set; }
            public Rectangle Rectangle { get; private set; }

            public Data(string title, Rectangle rectangle)
            {
                this.Title = title;
                this.Rectangle = rectangle;
            }
        }

        private bool useAutomationElement = true;
        private PickUpWindow pickUpWindow = new PickUpWindow();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loadイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GlobalHook_Mouse.AddEvent(this.MouseHookProcedure);
        }

        /// <summary>
        /// Closedイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            GlobalHook_Mouse.ClearEvent();
        }

        /// <summary>
        /// AutomationElement＿チェック状態変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void automationElementRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            this.useAutomationElement = radioButton.Checked;
        }

        /// <summary>
        /// フックイベント
        /// </summary>
        /// <param name="state"></param>
        private void MouseHookProcedure(ref GlobalHook_Mouse.MouseState state)
        {
            if (state.button != GlobalHook_Mouse.MouseButton.Left)
            {
                return;
            }

            if (state.action != GlobalHook_Mouse.MouseAction.Down)
            {
                return;
            }

            GlobalHook_Mouse.IsPaused = true;

            try
            {
                int x = state.x;
                int y = state.y;

                bool visible = false;
                int left = 0;
                int top = 0;
                int width = 0;
                int height = 0;
                object target = null;

                if (this.useAutomationElement)
                {
                    var element = this.FindAutomationElement(x, y);
                    
                    if (null != element)
                    {
                        visible = true;
                        var rect = element.Current.BoundingRectangle;

                        left = (int)rect.Left;
                        top = (int)rect.Top;
                        width = (int)rect.Width;
                        height = (int)rect.Height;
                        target = element.Current;
                    }
                }
                else
                {
                    var handle = this.FindHandle(x, y);

                    if (IntPtr.Zero != handle)
                    {
                        var rect = new Win32.Rect();

                        bool result = true;
                        result &= Win32.GetWindowRect(handle, out rect);

                        if (result)
                        {
                            visible = true;
                            left = rect.Left;
                            top = rect.Top;
                            width = rect.Width;
                            height = rect.Height;
                        }

                        var length = Win32.GetWindowTextLength(handle);
                        var title = new string('\0', length + 1);
                        result &= 0 != Win32.GetWindowText(handle, title, title.Length);

                        if (result)
                        {
                            target = new Data(title, new Rectangle(rect.Location, rect.Size));
                        }
                    }
                }

                this.Invoke((MethodInvoker)delegate
                {
                    this.ChangeTarget(visible, left, top, width, height, target);
                });
            }
            finally
            {
                GlobalHook_Mouse.IsPaused = false;
            }
        }

        /// <summary>
        /// ターゲット変更
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="target"></param>
        private void ChangeTarget(bool visible, int left, int top, int width, int height, object target)
        {
            if (visible)
            {
                this.pickUpWindow.Left = left;
                this.pickUpWindow.Top = top;
                this.pickUpWindow.Width = width;
                this.pickUpWindow.Height = height;
            }

            this.pickUpWindow.Visible = visible;
            this.propertyGrid.SelectedObject = target;
        }

        /// <summary>
        /// XY座標位置のウィンドウを探す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private IntPtr FindHandle(int x, int y)
        {
            IntPtr handle = IntPtr.Zero;

            try
            {
                handle = Win32.WindowFromPoint(new Win32.Point(x, y));
            }
            catch (Exception)
            {
                // 無視
            }

            if (handle != IntPtr.Zero
                && this.Handle == handle)
            {
                return IntPtr.Zero;
            }

            return handle;
        }

        /// <summary>
        /// XY座標位置のAutomationElementを探す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private AutomationElement FindAutomationElement(int x, int y)
        {
            AutomationElement element = null;
            Process process = null;

            try
            {
                element = AutomationElement.FromPoint(new System.Windows.Point(x, y));
                process = Process.GetProcessById(element.Current.ProcessId);
            }
            catch (Exception)
            {
                // 以下のエラーが大量発生するけど、とりあえず無視
                // アプリケーションが入力同期呼び出しをディスパッチしているため、呼び出せません。 
                // (HRESULT からの例外:0x8001010D (RPC_E_CANTCALLOUT_ININPUTSYNCCALL))
            }

            if (null == process)
            {
                return null;
            }
            else if (Process.GetCurrentProcess().Id == process.Id)
            {
                return null;
            }

            return element;
        }

        /// <summary>
        /// 開始ボタン＿クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            this.startButton.Enabled = false;
            GlobalHook_Mouse.Start();
            this.stopButton.Enabled = true;
        }

        /// <summary>
        ///  停止ボタン＿クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            this.stopButton.Enabled = false;
            GlobalHook_Mouse.Stop();
            this.startButton.Enabled = true;
        }
    }
}
