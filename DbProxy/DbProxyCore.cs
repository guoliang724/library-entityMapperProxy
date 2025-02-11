using Microsoft.Data.SqlClient;
using System.Reflection;

namespace DbProxy
{
    public class DbProxyCore
    {
        public T Find<T>(int id) where T : new() {

            //T model = new T();

            // using reflection to create an instance of the model
            Type type = typeof(T);
            object? oResult = Activator.CreateInstance(type);


            var connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=entitymapperproxy;Integrated Security=True;Connect Timeout=30;";

            using SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();  
            
            SqlCommand cmd = connection.CreateCommand();

            // sql should be dependent on the type T, dynamically generated sql based on T
            List<string> propNameList = type.GetProperties().Select(p => p.Name).ToList();
            string strProps = string.Join(",",propNameList);


            string sql = $"SELECT {strProps} FROM {type.Name}  Where Id=" + id;
            
            cmd.CommandText = sql;

            SqlDataReader reader =cmd.ExecuteReader();

            if (reader.Read()) { 
              foreach (var prop in type.GetProperties()) {
                    prop.SetValue(oResult, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                }
            }

            return (T)oResult;
        }
    }
}
