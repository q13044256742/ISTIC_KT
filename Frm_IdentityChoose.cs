﻿using System;
using System.Data;
using System.Windows.Forms;

namespace 数据采集档案管理系统___加工版
{
    public partial class Frm_IdentityChoose : Form
    {
        private object uid;
        public Frm_IdentityChoose(object uid)
        {
            InitializeComponent();
            this.uid = uid;
        }

        private void Frm_IdentityChoose_Load(object sender, EventArgs e)
        {
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT * FROM special_info");
            cbo_ChooseIdentity.DataSource = table;
            cbo_ChooseIdentity.DisplayMember = "spi_name";
            cbo_ChooseIdentity.ValueMember = "spi_id";
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            object id = cbo_ChooseIdentity.SelectedValue;
            if(MessageBox.Show("选择后不可修改，确定要选择当前身份吗?", "确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                SQLiteHelper.ExecuteNonQuery($"UPDATE user_info SET ui_special_id='{id}' WHERE ui_id='{uid}'");
                MessageBox.Show("选择身份完毕。");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Frm_IdentityChoose_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("请选择您的身份");
            e.Cancel = true;
        }
    }
}
