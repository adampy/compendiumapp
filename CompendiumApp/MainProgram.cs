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
using static System.Math;

namespace CompendiumApp
{
    public partial class MainProgram : Form
    {
        Random rand = new Random();
        public Term currentTerm;
        public Topic currentTopic;
        public bool cancel;

        public MainProgram(List<Topic> topics, Topic topic)
        {
            this.currentTopic = topic;
            this.cancel = false;
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(ProgramClosedHandler.FormClosed);

            this.UpdateTopicString();
            this.NextQuestion();
        }

        public void NextQuestion()
        {
            List<Term> availableTerms = DataController.terms.FindAll(t => t.topic.id == this.currentTopic.id);
            int length = availableTerms.Count;

            if (length == 0)
            {
                DialogResult result = MessageBox.Show("There are no questions in this topic; you need to add at least one. Would you like to add one (Yes), delete the topic (No), or do nothing & change to another topic for now (Cancel)?", "Critical Error", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    // Make a new term - loop until a new term is made
                    while (length == 0)
                    {
                        NewTerm newTerm = new NewTerm(this.currentTopic);
                        newTerm.ShowDialog();
                        availableTerms.RemoveAll(t => t != null); //Removes all terms
                        availableTerms = DataController.terms.FindAll(t => t.topic.id == this.currentTopic.id);
                        length = availableTerms.Count;
                    }
                    Term justMade = availableTerms[0];
                    this.currentTerm = justMade;
                    this.questionString.Text = justMade.definition;
                    UpdateLabelPos(this.questionString, justMade.definition);
                }
                else if (result == DialogResult.No)
                {
                    // Delete topic
                    DataController.DeleteTopic(this.currentTopic);
                    this.cancel = true;
                    WindowController.topic.Show();
                    WindowController.topic.RefreshData();
                    this.Dispose();
                }
                else if (result == DialogResult.Cancel)
                {
                    this.cancel = true;
                    try
                    {
                        WindowController.main.Hide();
                    }
                    catch { }
                    WindowController.topic.Show();
                    return;
                }
            }
            else if (length > 1)
            {
                while (true)
                {
                    int random = this.rand.Next(0, availableTerms.Count);
                    Term newTerm = availableTerms[random];
                    if (newTerm != this.currentTerm)
                    {
                        this.currentTerm = newTerm;
                        this.questionString.Text = newTerm.definition;
                        UpdateLabelPos(this.questionString, newTerm.definition);
                        break;
                    }
                }
            }
            else
            {
                this.currentTerm = availableTerms[0];
                this.questionString.Text = this.currentTerm.definition;
                UpdateLabelPos(this.questionString, this.currentTerm.definition);
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
            NewTerm newTerm = new NewTerm(this.currentTopic);
            newTerm.ShowDialog();
        }
        private void DifferentTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.NextQuestion();
        }

        private void changeTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowController.main.Hide();
            WindowController.topic.Show();
            WindowController.topic.RefreshData();
        }

        private void newTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTopic newTopic = new NewTopic();
            newTopic.ShowDialog();

            // Get the newest made topic
            Topic topic = DataController.topics[DataController.topics.Count - 1];
            NewTerm newTerm = new NewTerm(topic);
            newTerm.ShowDialog();
        }

        private void deleteTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult affirm = MessageBox.Show("This action cannot be reverted. Are you sure you want to delete this term?", "Delete Term", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (affirm == DialogResult.Yes)
            {
                DataController.DeleteTerm(this.currentTerm);
                this.NextQuestion();
            }
        }

        private void deleteTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult affirm = MessageBox.Show("This action cannot be reverted. Are you sure you want to delete this topic?", "Delete Topic", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (affirm == DialogResult.Yes)
            {
                DataController.DeleteTopic(this.currentTopic);
                WindowController.main.Hide();
                WindowController.topic.Show();
                WindowController.topic.RefreshData();
            }
        }
        private void editTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTopic editTopic = new NewTopic(this.currentTopic);
            editTopic.ShowDialog();
            this.currentTopic = DataController.topics.Find(t => t.id == this.currentTopic.id); // Gets the updated topic of the version
            UpdateTopicString();
            MessageBox.Show("Your changed have been saved.", "Changed saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void AnswerBoxEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SubmitButton_Click(sender, e);
            }
        }

        private void UpdateTopicString()
        {
            // Updates `topicString` for the given topic, this is ran on each change of `MainProgram`
            UpdateLabelPos(topicString, this.currentTopic.name);
            topicString.Text = this.currentTopic.name;
            topicString.ForeColor = System.Drawing.ColorTranslator.FromHtml("#" + this.currentTopic.colour); ;
        }
        private void UpdateLabelPos(Label label, string text)
        {
            // Centres the position of a `label` inside of `MainProgram`. Uses the `text` variable given to determine the centre.
            int textWidth = TextRenderer.MeasureText(text, label.Font).Width;
            int x = (this.Size.Width / 2) - (textWidth / 2);
            label.Location = new Point(x, label.Location.Y);
        }

    }
}
