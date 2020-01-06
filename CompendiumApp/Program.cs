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
            TopicSelect topic = new TopicSelect();
            WindowController.topic = topic;
            Application.Run(WindowController.topic);
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
        public string colour;

        public Topic(int id, string name, string colour)
        {
            this.id = id;
            this.name = name;
            this.colour = colour;
        }
    }

    // Allows us to access the windows from any file
    public static class WindowController
    {
        public static TopicSelect topic;
        public static MainProgram main;
    }

    public static class DataController
    {
        public static List<Topic> topics = new List<Topic>();
        public static List<Term> terms = new List<Term>();
        readonly static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\tsclient\S\,\CompendiumAppData.accdb";
        static OleDbConnection con = new OleDbConnection(connectionString);

        public static void UpdateTopics()
        {
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
                    string colour = reader.GetString(2); //colour string
                    Topic topic = new Topic(id, name, colour);
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

        #region Terms
        public static void AddTerm(Topic topic, string[] terms, string definition)
        {
            string termString = string.Join(",", terms);
            int topicId = topic.id;
            // Add new term
            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            command.CommandText = "INSERT INTO terms (`Topic Number`, Term, Definition) values (?, ?, ?)";
            command.Parameters.AddWithValue("`Topic Number`", topicId);
            command.Parameters.AddWithValue("Term", termString);
            command.Parameters.AddWithValue("Definition", definition);
            
            con.Open();
            command.ExecuteNonQuery();
            command.Dispose();

            // Get ID of new term
            OleDbCommand command2 = new OleDbCommand();
            command2.CommandText = "SELECT MAX(ID) FROM terms";
            command2.Connection = con;
            int id = -1;
            using (OleDbDataReader reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
            con.Close();
            command2.Dispose();
            // Failsafe
            if (id == -1)
            {
                MessageBox.Show("Error whilst adding question. Restart app.", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            Term newTerm = new Term(id, topic, termString, definition);
            DataController.terms.Add(newTerm);
        }
        public static void EditTerm(Term term, string[] terms, string definition)
        {
            string termString = string.Join(",", terms);

            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            command.CommandText = "UPDATE terms SET `Term` = ?, `Definition` = ? WHERE `ID` = ?";
            command.Parameters.AddWithValue("`Term`", termString);
            command.Parameters.AddWithValue("`Definition`", definition);
            command.Parameters.AddWithValue("`ID`", term.id);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            command.Dispose();

            DataController.terms.Remove(term);
            Term newTerm = new Term(term.id, term.topic, termString, definition);
            DataController.terms.Add(newTerm);
        }
        public static void DeleteTerm(Term term)
        {
            int id = term.id;
            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            command.CommandText = "DELETE FROM terms WHERE `ID` = ?";
            command.Parameters.AddWithValue("`ID`", id);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            command.Dispose();

            DataController.terms.Remove(term);
        }
        #endregion

        #region Topics
        public static void AddTopic(string topicName, string colour)
        {
            // Add topic
            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            command.CommandText = "INSERT INTO topics (topic, colour) VALUES (?, ?)";
            command.Parameters.AddWithValue("topic", topicName);
            command.Parameters.AddWithValue("colour", colour);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            // Get ID of the newest topic so it can be added
            OleDbCommand command2 = new OleDbCommand();
            command2.CommandText = "SELECT MAX(ID) FROM topics";
            command2.Connection = con;
            int id = -1;
            con.Open();
            using (OleDbDataReader reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
            con.Close();
            command2.Dispose();

            Topic topic = new Topic(id, topicName, colour);
            DataController.topics.Add(topic);
        }
        public static void EditTopic(Topic topic)
        {
            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            command.CommandText = "UPDATE topics SET topic = ?, colour = ? WHERE id = ?";
            command.Parameters.AddWithValue("topic", topic.name);
            command.Parameters.AddWithValue("colour", topic.colour);
            command.Parameters.AddWithValue("id", topic.id);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
        public static void DeleteTopic(Topic toDelete)
        {
            // Delete from the Topics table
            OleDbCommand command = new OleDbCommand();
            command.Connection = con;
            command.CommandText = "DELETE FROM topics WHERE `ID` = ?";
            command.Parameters.AddWithValue("`ID`", toDelete.id);

            // Delete from terms table
            OleDbCommand command2 = new OleDbCommand();
            command2.Connection = con;
            command2.CommandText = "DELETE FROM terms WHERE `Topic Number` = ?";
            command2.Parameters.AddWithValue("`Topic Number`", toDelete.id);
            
            // Execute both commands
            con.Open();
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command.Dispose();
            command2.Dispose();
            con.Close();

            DataController.topics.RemoveAll(t => t.id == toDelete.id);
            DataController.terms.RemoveAll(t => t.topic.id == toDelete.id);

        }
        #endregion
    }

    // TODO: ConfigurationController

    // Ends the process of the application - otherwise it will continue to run in the background
    public static class ProgramClosedHandler
    {
        public static void FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
