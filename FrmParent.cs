using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class FrmParent : Form
    {
        public FrmParent()
        {
            InitializeComponent();
        }


        private void ToolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            // 新建
            FrmChild child = new FrmChild();
            // 设置主窗体的父窗体
            child.MdiParent = this;
            child.Show();
        }

        // 关闭所有窗体
        private void ToolStripMenuItemCloseAll_Click(object sender, EventArgs e)
        {
             
            foreach(Form form in this.MdiChildren)
            {   
                Form frm = this.ActiveMdiChild;
                frm.Close();
            }

        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItemClose_Click(object sender, EventArgs e)
        {   
            // 关闭当前激活的窗体
            Form frm = this.ActiveMdiChild;
            frm.Close();
        }
    }
}
