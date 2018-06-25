﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    [ToolboxItem(true)]
    class KyoProgressBar : ProgressBar
    {
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private Color _TextColor = Color.Black;
        private Font _TextFont = new Font("SimSun ", 12);

        public Color TextColor
        {
            get { return _TextColor; }
            set { _TextColor = value; this.Invalidate(); }
        }

        public Font TextFont
        {
            get { return _TextFont; }
            set { _TextFont = value; this.Invalidate(); }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0)
                {
                    return;
                }
                //base.OnPaint(e);
                if (Value <= Maximum)
                {
                    Graphics g = Graphics.FromHdc(hDC);
                    SolidBrush brush = new SolidBrush(_TextColor);
                    string s = string.Format("{0}%", Value * 100 / Maximum);
                    SizeF size = g.MeasureString(s, _TextFont);
                    float x = (Width - size.Width) / 2;
                    float y = (Height - size.Height) / 2;
                    g.DrawString(s, _TextFont, brush, x, y);
                    //返回结果  
                    m.Result = IntPtr.Zero;
                    //释放  
                    ReleaseDC(m.HWnd, hDC);
                }
            }
        }

    }
}
