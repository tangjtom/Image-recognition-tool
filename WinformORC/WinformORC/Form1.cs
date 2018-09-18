using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LitJson;
using Entity;
using System.Collections;

namespace WinformORC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择文件夹";
            dialog.Multiselect = true;
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                string string64 = APICALL.Utility.ImgToBase64String(file);//.Replace('+', '-').Replace('/', '_').TrimEnd('='); ;
                string token = APICALL.AccessToken.getAccessToken();
                Token access_token = JsonMapper.ToObject<Token>(token);
                string str = APICALL.General.general(access_token.access_token, string64);

                Return returnstr = JsonMapper.ToObject<Return>(str);
                
                List<words_result> words = returnstr.words_result;
                string txtstr = "识别文本为：";
                for (int i = 0; i < words.Count; i++)
                {
                    txtstr += words[i].words.ToString() + "\r\n";
                }
                txtcontent.Text= txtstr;
            }
            MessageBox.Show("识别成功！");
        }
    }
}
