using System.Data.SqlClient;

namespace data_access.MSSql
{
    public class MSSql
    {
        string connectionString;
        SqlConnection conn;
        SqlDataReader reader;
        public MSSql()
        {
            connectionString = @"Data Source=DESKTOP-HSHM0PP;Database=octopus;Integrated Security=True";

            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        public string selectAccounts()
        {
            using (conn = new SqlConnection(connectionString))
            {
                string queryString = "SELECT dbo.accounts.email, dbo.accounts.username, dbo.passwords.password FROM dbo.accounts INNER JOIN dbo.passwords ON dbo.accounts.userId=dbo.passwords.userId;";
                SqlCommand command = new SqlCommand(queryString, conn);
                conn.Open();
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]));
                        return String.Format("{0}, {1}, {2}", reader[0], reader[1], reader[2]);
                    }
                }
                return null;
            }
        }
    }
}