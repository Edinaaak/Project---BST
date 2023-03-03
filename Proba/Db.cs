using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba
{
    public class Db
    {
        public SqlConnection connetion = new SqlConnection();
        public SqlCommand command;

        public Db ()
        {
            connetion.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\edina\Downloads\Proba (1)\Proba\Proba\Algorithms.mdf;Integrated Security=True";
            command = connetion.CreateCommand();
        }

        public void Brojac (float a, float b)
        {
            connetion.Open ();
           command.CommandText = $"INSERT INTO BST (BrojCvorova, Sadrzaj) VALUES ({a}, {b})";
            command.ExecuteNonQuery();
            connetion.Close();
        }

        public void AlSearch (float a, float b)
        {
            connetion.Open();
            command.CommandText = $"INSERT INTO ASEARCH (Root, Value) VALUES ({a}, {b})";
            command.ExecuteNonQuery();
            connetion.Close();
        }
        public void AlDeLete (float a, float b)
        {
            connetion.Open();
            command.CommandText = $"INSERT INTO ADELETE (Root, Value) VALUES ({a}, {b})";
            command.ExecuteNonQuery();
            connetion.Close();
        }
        public void AlInsert (float a, float b)
        {
            connetion.Open();
            command.CommandText = $"INSERT INTO AINSERT (Root, Value) VALUES ({a}, {b})";
            command.ExecuteNonQuery();
            connetion.Close();
        }

    }
}
