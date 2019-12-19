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

        #region Tool Strip Procedures
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

        private void EditTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTerm editTerm = new NewTerm(this.currentTopic, this.currentTerm);
            editTerm.ShowDialog();
            this.NextQuestion();
        }

        private void NewTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTerm newterm = new NewTerm(this.currentTopic);
            newterm.ShowDialog();
        }
        #endregion

        private void AnswerBoxEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SubmitButton_Click(sender, e);
            }
        }
    }
}
