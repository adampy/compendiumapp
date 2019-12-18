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
        public Term currentTerm;
        public Topic currentTopic;

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
            List<Term> availableTerms = DataController.terms.FindAll(t => t.topic.id == this.currentTopic.id);
            int length = availableTerms.Count;

            // TODO: Not repeat the same question once after the other
            if (length > 1)
            {
                while (true)
                {
                    int random = this.rand.Next(0, availableTerms.Count);
                    Term newTerm = availableTerms[random];
                    if (newTerm != this.currentTerm)
                    {
                        this.currentTerm = newTerm;
                        this.questionString.Text = newTerm.definition;
                        break;
                    }
                }
            }
            else
            {
                this.currentTerm = availableTerms[0];
                this.questionString.Text = this.currentTerm.definition;
                return;

            }
            /*int random = this.rand.Next(0, availableTerms.Count - 1);
            //Term newTerm = availableTerms[random];

            this.currentTerm = newTerm;
            this.questionString.Text = newTerm.definition;*/
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string answer = answerBox.Text;

            foreach (string term in this.currentTerm.term)
            {
                if (answer.ToLower() == term.ToLower())
                {
                    this.NextQuestion();
                    answerBox.Text = "";
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
            answerBox.Text = this.currentTerm.term[0];
        }

        private void NewTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*string[] terms = new string[2];
            string definition = "Test defintion";
            terms[0] = "Test answer 1";
            terms[1] = "Test answer 2";
            DataController.AddTerm(this.currentTopic, terms, definition);*/
            NewTerm newterm = new NewTerm(this.currentTopic);
            newterm.ShowDialog();
        }
    }
}
