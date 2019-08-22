using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Text;
using System.Collections;
using System.IO;

namespace notepad
{
    public partial class FrmChild : Form
    {
        public FrmChild()
        {
            InitializeComponent();
        }


        // 窗体加载事件
        private void FrmChild_Load(object sender, EventArgs e)
        {
            mark.Text = "";
            // 加载系统字体
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            // 获取installedFontCollection 对象的数组
            FontFamily[] ff = installedFontCollection.Families;
            ArrayList list = new ArrayList();
            int count = ff.Length;
            for (int i = 0; i < count; i++)
            {
                string FontName = ff[i].Name;
                scbFont.Items.Add(FontName);
            }

        }

        // 加粗
        private void BtnBold_Click(object sender, EventArgs e)
        {
            if (!textBoxNote.Font.Bold)
            {
                textBoxNote.Font = new Font(textBoxNote.Font, FontStyle.Bold);
            }
            else
            {
                textBoxNote.Font = new Font(textBoxNote.Font, FontStyle.Regular);
            }

        }

        // 倾斜
        private void BtnTilt_Click(object sender, EventArgs e)
        {
            if (!textBoxNote.Font.Italic)
            {
                textBoxNote.Font = new Font(textBoxNote.Font, FontStyle.Italic);
            }
            else
            {
                textBoxNote.Font = new Font(textBoxNote.Font, FontStyle.Regular);
            }
        }

        // 改变字体
        private void ScbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontName = scbFont.Text;
            float fontSize = float.Parse(scbSize.Text);
            textBoxNote.Font = new Font(fontName, fontSize);

        }


        // 改变字体
        private void ScbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fontSize = float.Parse(scbSize.Text);
            string fontName = scbFont.Text;
            textBoxNote.Font = new Font(fontName, fontSize);
        }

        private void ScbSize_TextChanged(object sender, EventArgs e)
        {
            float fontSize = float.Parse(scbSize.Text);
            string fontName = scbFont.Text;
            textBoxNote.Font = new Font(fontName, fontSize);
        }

        // 保存文档
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.Text == "记事本")
            {
                if (textBoxNote.Text.Trim() != "")
                {
                    // 显示保存对话框, 创建文件类型筛选器
                    saveFileDialog1.Filter = ("文本文档(*.txt)|*.txt");
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        // 获取用户选择的文件路径
                        string path = saveFileDialog1.FileName;
                        // 保存文件到指定路径
                        StreamWriter sw = new StreamWriter(path, false);
                        sw.WriteLine(textBoxNote.Text.Trim());
                        sw.Flush(); // 清理缓存
                        sw.Close();
                        this.Text = path;
                        mark.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("当前内容为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string path = this.Text;
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(textBoxNote.Text.Trim());
                sw.Flush(); // 清理缓存
                sw.Close();
                mark.Text = "";
            }

        }


        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ("文本文档(*.txt) | *.txt");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 获取打开文档的路径
                string path = openFileDialog1.FileName;
                // 读取文件并设置编码
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                // 读取文档中的数据流
                string text = sr.ReadToEnd();
                textBoxNote.Text = text;
                this.Text = path;
                sr.Close();
            }
        }

        private void TextBoxNote_TextChanged(object sender, EventArgs e)
        {
            mark.Text = "*";
        }

        private void FrmChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mark.Text == "*")
            {
                DialogResult dialogResult = MessageBox.Show("文档尚未保存,是否关闭?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult== DialogResult.Yes)
                {
                    Dispose();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
