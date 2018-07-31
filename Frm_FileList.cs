using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_FileList : Form
    {
        public Frm_FileList(string[] items)
        {
            InitializeComponent();
            foreach(string item in items)
            {
                if(!string.IsNullOrEmpty(item))
                {
                    listBox1.Items.Add(new EntityList()
                    {
                        Name = System.IO.Path.GetFileName(item),
                        Path = item,
                    });
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            EntityList item = (EntityList)listBox1.SelectedItem;

            if(MessageBox.Show("是否打开文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                if(System.IO.File.Exists(item.Path))
                {
                    Hide();
                    WinFormOpenHelper.OpenWinForm(0, "open", item.Path, null, null, ShowWindowCommands.SW_NORMAL);
                }
                else
                    MessageBox.Show("文件不存在。");
            }
        }

        private void Frm_FileList_Load(object sender, System.EventArgs e)
        {
            //listBox1.DrawMode = DrawMode.OwnerDrawVariable;
        }

    }

    class EntityList
    {
        private string name;
        private string path;

        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }

        public override string ToString()
        {
            return Name;
        }
    }
}
