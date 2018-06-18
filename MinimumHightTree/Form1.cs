using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinimumHightTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox1.Text);
            string str = textBox2.Text;
            str = str.Remove(str.Length - 2, 2).Remove(0, 2);
            string[] strings = str.Split(new string[] { "], [" }, StringSplitOptions.RemoveEmptyEntries);
            int[,] array=new int[strings.Length, 2];
            for (int i=0; i<strings.Length;++i)
            {
                string[] arr = strings[i].Split(',');
                array[i, 0] = int.Parse(arr[0]);
                array[i, 1] = int.Parse(arr[1]);
            }

            Tree tree = new Tree(num, array);
            List<int> list = tree.GetMinimumHeight();
            string result = "[";
            foreach (int n in list)
            {
                result += n.ToString()+",";
            }
            result = result.Remove(result.Length - 1, 1) + "]";
            textBox3.Text = result;
        }
    }
}
