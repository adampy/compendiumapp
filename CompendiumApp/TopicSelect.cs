using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompendiumApp
{
    public partial class TopicSelect : Form
    {
        public TopicSelect()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MainProgram main = new MainProgram();
            main.Show();
            this.Hide();
        }
    }
}
