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
        public NewTerm(Topic currentTopic = null)
        {
            InitializeComponent();
            this.terms = new TagHandler(this, timer1);

            /*string[] temp = new string[DataController.topics.Count()];
            int indx = 0;
            for (int i = 0; i < DataController.topics.Count(); i++)
            {
                string name = DataController.topics[i].name;
                temp[i] = name;
            }*/
            if (currentTopic is null)
            {
                //enable the dropdown
            }
            else
            {
                topicComboBox.Items.Add(currentTopic.name);
                topicComboBox.SelectedIndex = 0;
            }
        }

        private void AddTermClick(object sender, EventArgs e)
        {
            string newTerm = termInputBox.Text;
            termInputBox.Text = "";

            this.terms.AddTag(newTerm);
            termInputBox.Focus();
        }
    }

    public class TagHandler
    {
        Dictionary<string, Label> dict;
        Form parent;
        int x;
        int y;
        Color standard = Color.FromArgb(225, 236, 244);
        Color hovered = Color.FromArgb(175, 216, 254);
        int DEFAULTX = 210;
        int DEFAULTY = 313;

        Timer timer; // Reference to parent.timer1
        Label toChange; // The label to change
        int[] toHovered = { -5, -2, 1 }; // The changes in fade per iteration
        int iteration; // Marks how far into the fade it is
        bool changeTo; // True for changing to hovered, false for changing to standard
        bool changing; // Boolean to stop multiple timer calls from happening

        public TagHandler(Form parent, Timer timer)
        {
            this.parent = parent;
            this.timer = timer;
            this.timer.Tick += timer_Tick;
            x = DEFAULTX; y = DEFAULTY;

        }

        public void AddTag(string tagText)
        {
            Label label = new Label();
            Point location = new Point(x, y);
            Color fgColor = Color.FromArgb(36, 58, 69);
            Color bgColor = standard;
            Font font = new Font("Calibri", 15.0f);

            label.Location = location;
            label.Text = tagText;
            label.ForeColor = fgColor;
            label.BackColor = bgColor;
            label.Font = font;
            label.AutoSize = true;
            label.MouseHover += HoverOverTag;
            label.MouseLeave += StopHoverOverTag;

            parent.Controls.Add(label);
            int textWidth = TextRenderer.MeasureText(tagText, font).Width;

            if (x + textWidth + 4 > 660)
            {
                x = DEFAULTX; y = DEFAULTY;
            }

            Point location2 = new Point(x, y);
            label.Location = location2;
            parent.Controls.Add(label);

            x += textWidth + 4;
        }

        public void HoverOverTag(object sender, EventArgs e)
        {
            if (changing == false)
            {
                toChange = (Label)sender;
                changing = true;
                changeTo = true;
                iteration = 0;
                timer.Start();
            }
        }

        public void StopHoverOverTag(object sender, EventArgs e)
        {
            if (changing == false)
            {
                toChange = (Label)sender;
                changing = true;
                changeTo = false;
                iteration = 0;
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (iteration == 9)
            {
                //done
                changing = false;
                timer.Stop();
            }
            else
            {
                if (changeTo == true)
                {
                    // Change to hovered
                    Color oldColor = toChange.BackColor;
                    int newR = Convert.ToInt32(oldColor.R) + toHovered[0];
                    int newG = Convert.ToInt32(oldColor.G) + toHovered[1];
                    int newB = Convert.ToInt32(oldColor.B) + toHovered[2];
                    Color newColor = Color.FromArgb(newR, newG, newB);
                    toChange.BackColor = newColor;
                }
                else
                {
                    // Change to standard
                    Color oldColor = toChange.BackColor;

                    int newR = Convert.ToInt32(oldColor.R) - toHovered[0];
                    int newG = Convert.ToInt32(oldColor.G) - toHovered[1];
                    int newB = Convert.ToInt32(oldColor.B) - toHovered[2];
                    Color newColor = Color.FromArgb(newR, newG, newB);
                    toChange.BackColor = newColor;
                }
                iteration++;
            }
        }
    }
}
