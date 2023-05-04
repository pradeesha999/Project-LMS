using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Final
{
    
    internal class Class_File
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter; 

        public Class_File()
        {
          con =new SqlConnection("Data Source=.;Initial Catalog=Final;Integrated Security=True");
        } 

        public DataRow Getdata (string a,int currentIndex)
        {
            con.Open();
            adapter = new SqlDataAdapter(a, con);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (currentIndex < dataSet.Tables[0].Rows.Count)
            {
                DataRow row = dataSet.Tables[0].Rows[currentIndex];

                con.Close();
                return row;
            }
            else
            {
                con.Close();
                return null;
            }
        }

        public int Insert(string x)
        {
            con.Open();
            cmd = new SqlCommand(x, con);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}
