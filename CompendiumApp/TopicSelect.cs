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
        List<Topic> topics;
        Dictionary<string, Topic> dict = new Dictionary<string, Topic>();
        public TopicSelect()
        {
            // Data stuff
            this.topics = DataController.topics;
            string[] topicStrings = new string[topics.Count];
            for (int i = 0; i < topics.Count; i++)
            {
                topicStrings[i] = topics[i].name;
                dict.Add(topics[i].name, topics[i]);
            }
            
            //UI stuff
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(ProgramClosedHandler.FormClosed);
            topicBox.Items.AddRange(topicStrings);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Topic topic = dict[topicBox.SelectedItem.ToString()];

            // If there are no items the program will infinitely loop, this should be checked
            if (DataController.terms.FindAll(t => t.topic.id == topic.id).Count() == 0)
            {
                MessageBox.Show("There are no terms in that topic, please choose another!");
            }
            else
            {
                MainProgram main = new MainProgram(this.topics, topic);
                main.Show();
                this.Hide();
            }
        }
    }
}
