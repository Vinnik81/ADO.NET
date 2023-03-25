using Microsoft.Data.SqlClient;
using System;

namespace DB
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            var query1 = @"UPDATE CreditCard
			SET Money = Money - 4000
			WHERE CardNumber = '1234-1234-1234-1234'";

            var command1 = new SqlCommand(query1, connection);
            command1.Transaction = transaction;

            var query2 = @"UPDATE CreditCard
			SET Money = Money + 4000
			WHERE CardNumber = '4321-4321-4321-4321'";

            var command2 = new SqlCommand(query2, connection);
            command2.Transaction = transaction;

            try
            {
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }

            ///////////////////////////////////////////////////////////////////////////////


        }
    }
}
