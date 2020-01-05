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
    public partial class NewTopic : Form
    {
        Topic topic = null;
        public NewTopic(Topic topic = null)
        {
            InitializeComponent();
            if (topic != null)
            {
                // Edit mode
                this.topic = topic;
                this.Text = "Edit Topic";
                label2.Text = "Edit Topic";
                label3.Dispose();
                button1.Text = "Save Changes";
                button1.Click -= button1_Click;
                button1.Click += button1_EditTopic;

                topicNameBox.Text = topic.name;
                textBox2.Text = topic.colour;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: Validate colour input
            /* Make textBox2 contain '000000'
             * Change the label colour as the text gets changed according to its hex code*/

            DataController.AddTopic(topicNameBox.Text, textBox2.Text);
            MessageBox.Show("Topic created! Now let's add the first term.");
            WindowController.topic.RefreshData();
            this.Close();
            this.Dispose();
        }
        private void button1_EditTopic(object sender, EventArgs e)
        {
            // TODO: Ensure ALL textbox inputs don't have only whitespace - prevents the user typing nothing
            this.topic.name = topicNameBox.Text;
            this.topic.colour = textBox2.Text;
            DataController.EditTopic(this.topic);
            this.Close();
            this.Dispose();
        }
    }
}
