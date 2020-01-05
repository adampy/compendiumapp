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
        TagHandler terms;
        Topic currentTopic = null;
        Term currentTerm = null;
        bool editMode;
        Dictionary<int, Topic> dict = new Dictionary<int, Topic>(); // Used to convert the topic in topicComboBox (its index inside the combobox as a key) into its ID
        public NewTerm(Topic currentTopic = null, Term currentTerm = null)
        {
            // currentTopic is passed when called from NewTerm
            // currentTopic AND currentTerm are passed when called from EditTerm

            InitializeComponent();
            this.terms = new TagHandler(this);

            this.currentTopic = currentTopic;
            for (int i = 0; i < DataController.topics.Count; i++)
            {
                Topic topic = DataController.topics[i];
                topicComboBox.Items.Add(topic.name);
                this.dict.Add(i, topic);
            }
            topicComboBox.SelectedIndex = DataController.topics.FindIndex(t => t.id == currentTopic.id);

            if (currentTerm != null)
            {
                // Called from EditTerm
                editMode = true;
                label1.Text = "Edit Term";
                textBox1.Text = currentTerm.definition;
                termId.Text = "Term: #" + currentTerm.id.ToString();
                topicComboBox.Enabled = false; // Disables the dropdown

                this.currentTerm = currentTerm;
                foreach (string term in currentTerm.term)
                {
                    terms.AddTag(term);
                }
                createTerm.Text = "Edit";
            }
            else
            {
                // Called from NewTerm
                termId.Hide();
            }
        }

        private void AddTermClick(object sender, EventArgs e)
        {
            this.terms.AddTag(termInputBox.Text);
            termInputBox.Text = "";
            termInputBox.Focus();
        }

        private void TermInputPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.terms.AddTag(termInputBox.Text);
                termInputBox.Text = "";
            }
        }

        private void CreateTerm_Click(object sender, EventArgs e)
        {
            string definition = textBox1.Text;
            string[] terms = new string[this.terms.tagList.Count()];
            for (int i = 0; i < this.terms.tagList.Count(); i++)
            {
                terms[i] = this.terms.tagList[i].Text;
            }

            if (!editMode)
            {
                // Get the topic object that's in topicComboBox
                Topic topic = this.dict[topicComboBox.SelectedIndex];
                DataController.AddTerm(topic, terms, definition);
                MessageBox.Show("This term has been added successfully");
            }
            else
            {
                DataController.EditTerm(this.currentTerm, terms, definition);
                MessageBox.Show("Term #" + this.currentTerm.id.ToString() + " has been edited accordingly.");
            }
            this.Close();
        }
    }

    public class TagHandler
    {
        public List<Label> tagList = new List<Label>();
        Form parent;
        int x;
        int y;
        readonly Color standard = Color.FromArgb(225, 236, 244);
        readonly Color hovered = Color.FromArgb(175, 216, 254);
        readonly Color fgColor = Color.FromArgb(36, 58, 69);
        readonly Font font = new Font("Calibri", 15.0f);
        readonly int DEFAULTX = 210;
        readonly int DEFAULTY = 313;

        public TagHandler(Form parent)
        {
            this.parent = parent;
            x = DEFAULTX; y = DEFAULTY;

        }

        public void AddTag(string tagText)
        {
            Label label = new Label();
            Point location = new Point(x, y);

            label.Location = location;
            label.Text = tagText;
            label.ForeColor = fgColor;
            label.BackColor = standard;
            label.Font = font;
            label.AutoSize = true;
            label.MouseHover += HoverOverTag;
            label.MouseLeave += StopHoverOverTag;
            label.Cursor = Cursors.Hand;
            label.Click += TagClick;

            //parent.Controls.Add(label);
            int textWidth = TextRenderer.MeasureText(tagText, font).Width;

            if (x + textWidth + 4 > 660)
            {
                x = DEFAULTX; y = DEFAULTY;
            }

            Point location2 = new Point(x, y);
            label.Location = location2;
            parent.Controls.Add(label);
            tagList.Add(label);

            x += textWidth + 4;
        }

        private void HoverOverTag(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = hovered;
        }

        private void StopHoverOverTag(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = standard;
        }
        private void TagClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            tagList.Remove(label);
            parent.Controls.Remove(label);
            RefreshTags();
        }

        private void RefreshTags()
        {
            x = DEFAULTX; y = DEFAULTY;
            foreach (Label label in tagList)
            {
                int textWidth = TextRenderer.MeasureText(label.Text, font).Width;
                
                if (x + textWidth + 4 > 660)
                {
                    x = DEFAULTX; y = DEFAULTY;
                }

                parent.Controls.Remove(label);

                Point location2 = new Point(x, y);
                label.Location = location2;
                parent.Controls.Add(label);

                x += textWidth + 4;
            }
        }
    }
}
