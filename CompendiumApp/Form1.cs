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
    public partial class Form1 : Form
    {
        string[,] terms;
        string[,] questions;

        public Form1()
        {
            InitializeComponent();
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\tsclient\S\,\CSDefs.accdb";
            OleDbConnection con = new OleDbConnection(connectionString);
            con.Open();

            OleDbCommand command = new OleDbCommand();
            command.CommandText = "SELECT * FROM terms";
            command.Connection = con;

            using (OleDbDataReader reader = command.ExecuteReader())
            {
                int lengthOfArray = 0;
                while (reader.Read())
                {
                    lengthOfArray++;
                    string[,] temp = new string[2,lengthOfArray];

                    string[] data = new string[2];
                    data[0] = reader.GetString(1);
                    data[1] = reader.GetString(2);

                    
                }
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string answer = answerBox.Text;
            answerBox.Text = "";


        }
    }
}
