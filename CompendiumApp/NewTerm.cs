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
    public partial class NewTerm : Form
    {
        public NewTerm()
        {
            InitializeComponent();

            string[] temp = new string[DataController.topics.Count()];
            int indx = 0;
            for (int i = 0; i < DataController.topics.Count(); i++)
            {
                string name = DataController.topics[i].name;
                temp[i] = name;
            }

            topicComboBox.Items.AddRange(temp);
            topicComboBox.SelectedItem();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
