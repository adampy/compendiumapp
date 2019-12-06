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
        List<Topic> topics = new List<Topic>();
        List<Term> terms = new List<Term>();
        Random rand = new Random();
        Term currentTerm;
        int termsLength;

        public MainProgram()
        {
            InitializeComponent();
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\tsclient\S\,\CSDefs.accdb";
            OleDbConnection con = new OleDbConnection(connectionString);
            con.Open();

            // Get topics from DB
            OleDbCommand command = new OleDbCommand();
            command.CommandText = "SELECT * FROM topics";
            command.Connection = con;

            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    Topic topic = new Topic(id, name);
                    this.topics.Add(topic);
                }
            }
            command.Dispose();

            // Get terms from DB
            OleDbCommand command2 = new OleDbCommand();
            command2.CommandText = "SELECT * FROM terms";
            command2.Connection = con;

            using (OleDbDataReader reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    int termId = reader.GetInt32(0); //id
                    int topicId = reader.GetInt32(1); //topic number
                    string termString = reader.GetString(2); //term
                    string definition = reader.GetString(3); //definition
                    Term term = new Term(termId, topicId, termString, definition);

                    this.terms.Add(term);
                }
            }
            command2.Dispose();
            this.NextQuestion();
        }

        public void NextQuestion()
        {
            this.termsLength = this.terms.Count();
            // TODO: the code below throws an error if all questions have been asked
            int random = this.rand.Next(0, this.termsLength - 1);
            this.currentTerm = this.terms[random];
            this.terms.RemoveAt(random);
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
                    MessageBox.Show("Correct");
                }
                else
                {
                    MessageBox.Show("Incorrect - " + term);
                }
                this.NextQuestion();

                /*foreach (string[] data in this.topics)
                {
                
                }

                foreach (string[] data in this.terms)
                {

                }*/
            }
        }
    }

    public class Term
    {
        public string[] term; //answer
        public string definition; //question
        public int id;
        public int topicId;

        public Term(int id, int topicId, string answer, string question)
        {
            this.id = id;
            this.topicId = topicId;
            this.definition = question;
            //answer checks - multiple answers
            this.term = answer.Split(',');

        }
    }

    public class Topic
    {
        public int topicId;
        public string topicName;
        
        public Topic(int id, string name)
        {
            this.topicId = id;
            this.topicName = name;
        }
    }
}
