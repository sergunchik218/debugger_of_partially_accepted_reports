using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace XDoc_text1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XDocument text1;
        XDocument text2;
        XDocument text3;
        //XDocument text3 = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XML-файл |*.xml|All files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lable1.Text = openFileDialog1.FileName;
                text1 = XDocument.Load(lable1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XML-файл |*.xml|All files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lable2.Text = openFileDialog1.FileName;
                text2 = XDocument.Load(lable2.Text);
                text3 = text2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> cod = new List<string>();
            foreach (var o2 in text2.Descendants()?.Elements("sscc")) cod.Add(o2.Value);
            foreach (var o1 in text1.Descendants()?.Elements("object_id")) cod.Remove(o1.Value);
            var union3 = text3.Descendants()?.Elements("union");
            
            //MessageBox.Show(union3.ToString());
            //if (union3.ToString() !="")        //Условие на удаление Юниона
            
            foreach (var cod1 in cod)
            {
                foreach (var un in union3)
                {
                    if (un.Value.Contains(cod1))
                    {
                        un.Remove();
                        break;
                    }
                }
            } 
            //условие на удаление sscc
            //MessageBox.Show("Putin");
            var sscc3 = text3.Descendants()?.Elements("sscc");
            //foreach (var un1 in sscc3)
            //MessageBox.Show(un1.Value);
            foreach (var cod1 in cod)
            {
                foreach (var un in sscc3)
                {
                    if (un.Value.Contains(cod1))
                    {
                        un.Remove();
                        break;
                    }
                }
            }
            saveFileDialog1.Filter = "XML-файл |*.xml|All files|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                text3.Save(saveFileDialog1.FileName);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
