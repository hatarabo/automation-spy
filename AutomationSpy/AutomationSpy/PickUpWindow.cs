using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomationSpy
{
    public partial class PickUpWindow : Form
    {
        /// <summary>
        /// フレーム幅
        /// </summary>
        public int FrameWidth { get; set; } = 4;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PickUpWindow()
        {
            InitializeComponent();
            this.Width = 10;
            this.Height = 10;

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Red;
            this.Opacity = 0.5;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var param = base.CreateParams;
                //param.Style = param.Style ^ (int)Win32.WindowStyle.WS_BORDER;
                //param.Style = param.Style ^ (int)Win32.WindowStyle.WS_CAPTION;

                param.Style = 0;

                const int WS_EX_NOACTIVATE = 0x08000000;
                const int WS_EX_TOPMOST = 0x00000008;
                const int WS_EX_APPWINDOW = 0x00040000;

                param.ExStyle = param.ExStyle | WS_EX_NOACTIVATE;
                param.ExStyle = param.ExStyle | WS_EX_TOPMOST;
                param.ExStyle = param.ExStyle ^ WS_EX_APPWINDOW;

                return param;
            }
        }

        /// <summary>
        /// サイズ変更イベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            RectangleF rect = new RectangleF(0, 0, this.Width, this.Height);
            path.AddRectangle(rect);

            rect.X += FrameWidth;
            rect.Y += FrameWidth;
            rect.Width -= FrameWidth * 2;
            rect.Height -= FrameWidth * 2;
            path.AddRectangle(rect);

            this.Region = new Region(path);

        }
    }
}
