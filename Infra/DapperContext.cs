using Microsoft.Data.SqlClient;
using System;

namespace Infra
{
    public class DapperContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DapperContext()
        {
            Connection = new SqlConnection("Server=DESKTOP-03T36MT\\SQLEXPRESS; Database = DesafioMvc; Trusted_Connection=True;");
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != System.Data.ConnectionState.Closed);
        } 
    } 
}
