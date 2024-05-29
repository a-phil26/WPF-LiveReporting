//File:         DatabaseWriter.cs
//Project:      BI-A02
//Programmer:   Addison Phillips
//Initial Date: January 25, 2024
//Description:  This file contains the DatabasWriter class that writes a message to the database

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace MsgQueueReader
{
    internal class DatabaseWriter
    {
        private string ConnectionString { get; set; }
        //Function:     DatabaseWriter  
        //Description:  Constructor that intilailizes the connection string
        public DatabaseWriter() 
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        //Function:     WriteToDatabase
        //Description:  Writes 1 line at a time to the databse. Uses store procedure to excute the insert. 
        public void WriteToDatabase(string message)
        {
            string cmdText = "RawDataDumpProcedure";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter newData = cmd.Parameters.AddWithValue("@NewData", message);

                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show("Error writing to the Database");
                }  
            }  
        }
    }
}
