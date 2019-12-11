using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CompendiumApp
{
    public partial class MainProgram : Form
    {
        Random rand = new Random();
        Term currentTerm;
        Topic currentTopic;

        public MainProgram(List<Topic> topics, Topic topic)
        {
            this.currentTopic = topic;
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(ProgramClosedHandler.FormClosed);
            topicString.Text = this.currentTopic.name;
            this.NextQuestion();
        }

        public void NextQuestion()
        {
            int random = this.rand.Next(0, DataController.terms.Count - 1);
            Term newTerm = DataController.terms[random];

            while (newTerm.topic.id != this.currentTopic.id)
            {
                random = this.rand.Next(0, DataController.terms.Count - 1);
                newTerm = DataController.terms[random];
            }
            this.currentTerm = newTerm;
            this.questionString.Text = this.currentTerm.definition;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string answer = answerBox.Text;
            answerBox.Text = "";

            foreach (string term in this.currentTerm.term)
            {
                if (answer.ToLower() == term.ToLower())
                {
                    this.NextQuestion();
                }
                else
                {
                    MessageBox.Show("Incorrect - " + term);
                }
            }
        }

        // Tool Strip Procedures
        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramClosedHandler.FormClosed(sender, e);
        }

        private void CheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string answerString = "Answer(s) are: " + string.Join(", ", this.currentTerm.term);
            MessageBox.Show(answerString);
        }

        private void NewQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] terms = new string[2];
            DataController.AddTerm(this.currentTopic, terms);
        }
    }
}
