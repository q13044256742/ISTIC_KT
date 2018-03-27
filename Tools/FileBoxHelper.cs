using System;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    class FileBoxHelper
    {
        public static void MoveFile(ListView leftView, ListView rightView, Button[] buttons)
        {
            foreach (Button btn in buttons)
            {
                if ("1".Equals(btn.Tag))
                {
                    btn.Click += new EventHandler(delegate
                    {
                        ListView.SelectedListViewItemCollection items = leftView.SelectedItems;
                        foreach (ListViewItem item in items)
                        {
                            rightView.Items.Add((ListViewItem)item.Clone());
                            leftView.Items.Remove(item);
                        }
                    });
                }
                else if ("2".Equals(btn.Tag))
                {
                    btn.Click += new EventHandler(delegate
                    {
                        foreach (ListViewItem item in leftView.Items)
                        {
                            rightView.Items.Add((ListViewItem)item.Clone());
                            leftView.Items.Remove(item);
                        }
                    });
                }
                else if ("3".Equals(btn.Tag))
                {
                    btn.Click += new EventHandler(delegate
                    {
                        ListView.SelectedListViewItemCollection items = rightView.SelectedItems;
                        foreach (ListViewItem item in items)
                        {
                            leftView.Items.Add((ListViewItem)item.Clone());
                            rightView.Items.Remove(item);
                        }
                    });
                }
                else if ("4".Equals(btn.Tag))
                {
                    btn.Click += new EventHandler(delegate
                    {
                        foreach (ListViewItem item in rightView.Items)
                        {
                            leftView.Items.Add((ListViewItem)item.Clone());
                            rightView.Items.Remove(item);
                        }
                    });
                }
            }
        }
    }
}
