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
        Dictionary<int, Topic> dict = new Dictionary<int, Topic>();
        public TopicSelect()
        {
            //UI stuff
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(ProgramClosedHandler.FormClosed);

            RefreshData();
        }

        public void RefreshData()
        {
            this.topics = DataController.topics;
            this.dict = new Dictionary<int, Topic>();
            string[] topicStrings = new string[topics.Count];
            for (int i = 0; i < topics.Count; i++)
            {
                topicStrings[i] = topics[i].name;
                dict.Add(i, topics[i]);
            }
            topicBox.Items.Clear();
            topicBox.Items.AddRange(topicStrings);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (topicBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a topic to begin.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Topic topic = dict[topicBox.SelectedIndex];

            // If there are no items the program will infinitely loop, this should be checked
            /*if (DataController.terms.FindAll(t => t.topic.id == topic.id).Count() == 0)
            {
                MessageBox.Show("There are no terms in that topic, please choose another!");
            }
            else
            */{
                MainProgram main = new MainProgram(this.topics, topic);
                if (WindowController.main != null)
                {
                    // This removes all of the resources used by old versions of MainProgram - reduces memory usage over time
                    WindowController.main.Dispose();
                }
                if (main.cancel == false)
                {
                    WindowController.main = main;
                    WindowController.main.Show();
                    WindowController.topic.Hide();
                }
                else
                {
                    try
                    {
                        WindowController.main.Dispose();
                    }
                    catch
                    {
                        main.Dispose();
                    }
                    WindowController.topic.Show();
                    WindowController.topic.RefreshData();
                    main.Dispose();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewTopic newTopic = new NewTopic();
            newTopic.ShowDialog();

            // Get the newest made topic
            Topic topic = DataController.topics[DataController.topics.Count - 1];
            NewTerm newTerm = new NewTerm(topic);
            newTerm.ShowDialog();
        }
    }
}
