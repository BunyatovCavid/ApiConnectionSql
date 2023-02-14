using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;

namespace ApiConnectionSql.code
{
    public class Connect
    {
        static public DataTable Get()
        { 
            using (SqlConnection connection = new SqlConnection("Data Source=WIN-PFGV5N8DK24;Initial Catalog=ApiConnect;Integrated Security=True"))
            {

                using (SqlCommand cmd1 = new SqlCommand("ViewPeople", connection))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd1;
                        DataTable table = new DataTable();
                        da.Fill(table);
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                        return table;
                    }
                }

            }
        }

        static public void Post(string name,string life)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=WIN-PFGV5N8DK24;Initial Catalog=ApiConnect;Integrated Security=True"))
            {

                using (SqlCommand cmd1 = new SqlCommand("InsertPerson", connection))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.AddWithValue("@name", name);
                    cmd1.Parameters.AddWithValue("@life", life);
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    cmd1.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }

            }
        }
        static public void Put(int id, string name, string life)
        {

            using (SqlConnection connection = new SqlConnection("Data Source=WIN-PFGV5N8DK24;Initial Catalog=ApiConnect;Integrated Security=True"))
            {

                using (SqlCommand cmd1 = new SqlCommand("UpdatePerson", connection))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.AddWithValue("@id", id);
                    cmd1.Parameters.AddWithValue("@name", name);
                    cmd1.Parameters.AddWithValue("@life", life);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    cmd1.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }

            }
        }
        static public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=WIN-PFGV5N8DK24;Initial Catalog=ApiConnect;Integrated Security=True"))
            {

                using (SqlCommand cmd1 = new SqlCommand("DeletePerson", connection))
                {
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.AddWithValue("@id", id);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    cmd1.ExecuteNonQuery();
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }

            }
        }
    }
}
