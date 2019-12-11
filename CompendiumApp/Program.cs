using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CompendiumApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Get starting data
            DataController.UpdateTopics();
            DataController.UpdateTerms();

            // Start program
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TopicSelect());
        }
    }
    public class Term
    {
        public string[] term; //answer
        public string definition; //question
        public int id;
        public Topic topic;

        public Term(int id, Topic topic, string answer, string question)
        {
            this.id = id;
            this.topic = topic;
            this.definition = question;
            //answer checks - multiple answers
            this.term = answer.Split(',');

        }
    }

    public class Topic
    {
        public int id;
        public string name;

        public Topic(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }

    public static class DataController
    {
        public static List<Topic> topics = new List<Topic>();
        public static List<Term> terms = new List<Term>();
        static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\tsclient\S\,\CSDefs.accdb";
        static OleDbConnection con = new OleDbConnection(connectionString);

        public static void UpdateTopics()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\tsclient\S\,\CSDefs.accdb";
            OleDbConnection con = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand();
            command.CommandText = "SELECT * FROM topics";
            command.Connection = con;

            con.Open();
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0); //topic id
                    string name = reader.GetString(1); //topic name
                    Topic topic = new Topic(id, name);
                    topics.Add(topic);
                }
            }
            command.Dispose();
            con.Close();
        }

        public static void UpdateTerms(int argTopicId = -1)
        {
            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            if (argTopicId != -1)
            {
                //Not changed - get all topics
                command.CommandText = "SELECT * FROM terms WHERE `Topic Number` = " + argTopicId.ToString();
            }
            else
            {
                command.CommandText = "SELECT * FROM terms";
            }

            con.Open();
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int termId = reader.GetInt32(0); //id
                    int topicId = reader.GetInt32(1); //topic number
                    Topic topic = DataController.topics.Find(t => t.id == topicId);

                    string termString = reader.GetString(2); //term
                    string definition = reader.GetString(3); //definition
                    Term term = new Term(termId, topic, termString, definition);

                    terms.Add(term);
                }
            }
            con.Close();
            command.Dispose();
        }

        public static void AddTerm(Topic topic, string[] terms, string definition)
        {
            string termString = string.Join(",", terms);
            int topicId = topic.id;
            OleDbCommand command = new OleDbCommand();
            command.Connection = DataController.con;
            command.CommandText = "INSERT INTO terms (`Topic Number`, Term, Definition) values (?, ?, ?)";
            command.Parameters.AddWithValue("`Topic Number`", topicId);
            command.Parameters.AddWithValue("Term", termString);
            command.Parameters.AddWithValue("Definition", definition);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
    }

    // Ends the process of the application - otherwise it will continue to run in the background
    public static class ProgramClosedHandler
    {
        public static void FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
