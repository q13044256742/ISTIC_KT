﻿using System;
using System.Windows.Forms;
using 数据采集档案管理系统___课题版.Properties;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Explain : Form
    {
        public Frm_Explain()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_Explain_Load(object sender, EventArgs e)
        {
            richTextBox1.AppendText(Resources.explain);
            richTextBox1.Select(0, 0);
        }
    }
}
