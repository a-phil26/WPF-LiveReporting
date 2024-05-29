//File:         DataReader.cs
//Project:      BI-A02
//Programmer:   Addison Phillips
//Initial Date: January 25, 2024
//Description:  This file contains the DataReader Class focused on cons

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace YoYoLiveReporting
{
    internal class DataReader
    {
        public DataTable DefectTable { get; set; }
        public DataTable LineData {  get; set; }
        private string ConnectionString { get; set; }
        public List<string> ProductNames {  get; set; } 
        public List<KeyValuePair<int, string>> ProductInfo { get; set; }
       
        //Function:     DataReader
        //Description:  This is the constructor that initializes the datatables and lists used to hold data. 
        public DataReader() 
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            ProductInfo = new List<KeyValuePair<int, string>>();
            ProductNames = new List<string>();  
            ReadProductId();
            DefectTable = new DataTable();
            LineData = new DataTable();
        }

        //Function:     ReadProductId
        //Description:  This function reads the product table to get the products and their ID to populate the combobox
        public void ReadProductId()
        {
            string cmdText = "SELECT * FROM Products";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    ProductNames.Add("All");
                    ProductInfo.Add(new KeyValuePair<int, string>(0, "All"));
                    while (dr.Read())
                    {
                        int id =dr.GetInt32(0);
                        string name = dr.GetString(1);
                        ProductNames.Add(name);

                        ProductInfo.Add(new KeyValuePair<int, string>(id, name));
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }


        //Function:     ReadLineData
        //Description:  The function gets all data about yield and parts of the yoyo production
        public void ReadLineData(string productName)
        {
            string cmdText;
            int productId = MatchProductId(productName);
            LineData.Clear();   
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetLineData", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = cmd.Parameters.AddWithValue("@Product_id", productId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    conn.Open();

                    adapter.Fill(LineData);

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                 
            }
        }


        //Function:     MatchProductId
        //Description:  This function matches the product name in the combo box to the ID of the product
        public int MatchProductId(string productName)
        {
            var res = ProductInfo.FirstOrDefault(pair => pair.Value == productName);

            int productId = res.Key;

            return productId;
        }

        //Function:     ReadDefectTable
        //Description:  This function executes a stored procedure that returns all the defect reasons. 
        public void ReadDefectTable(string productName) 
        {
            string cmdText;
            int productId = MatchProductId(productName);

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("DefectReasons", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = cmd.Parameters.AddWithValue("@Product_id", productId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    conn.Open();
                    
                    adapter.Fill(DefectTable);

                    conn.Close();   
                }
            } 
            catch (Exception ex)
            {

            } 
        }
    }
}
