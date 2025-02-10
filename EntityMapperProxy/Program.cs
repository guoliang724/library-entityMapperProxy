using System.Data.SqlClient;


try 
{
    Console.WriteLine("Hello World!");
    var connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=entitymapperproxy;Integrated Security=True;Connect Timeout=30;";
   using (SqlConnection connection = new SqlConnection(connectionString)) 
    {
        Console.WriteLine($"Connection status: {connection.State}");
        connection.Open();
        Console.WriteLine($"Connection status: {connection.State}");

        SqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = @"Insert into  ";


        // CDU operations: cmd.ExecuteNonQuery  ==> affcted rows
        // R operations:  cmd.ExecuteReader   ==> data reader
        // Parameterized query: cmd.Parameters.AddWithValue("@name", "value");
        // 

    }
}
catch (SqlException ex) {
    Console.WriteLine("An error occurred: " + ex.Message);
}
catch (Exception ex) {
    Console.WriteLine("An error occurred: " + ex.Message);
}
finally {
    Console.WriteLine("Goodbye World!");
}

Console.ReadLine();