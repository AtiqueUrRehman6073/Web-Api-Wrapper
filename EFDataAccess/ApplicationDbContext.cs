using EFUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        private readonly ConnectionStrings _context;
        public ApplicationDbContext(IConfiguration context)
        {
            _context = new ConnectionStrings();
            _context.ConnectionString = context.GetConnectionString("DefaultCon");
        }
        public async Task<DataTable> SELECT_DATA(string QUERY, System.Collections.Hashtable PARAM)
        {
            DataTable dt = new DataTable();
            using (SqlConnection SQL_CON = new SqlConnection(_context.ConnectionString))
            {
                using (SqlCommand SQL_COM = new SqlCommand())
                {
                    using (SqlDataAdapter SDA = new SqlDataAdapter())
                    {
                        if (SQL_CON != null && SQL_CON.State == 0)
                        {
                            await SQL_CON.OpenAsync();
                        }
                        else if (SQL_CON != null && SQL_CON.State.Equals(ConnectionState.Connecting))
                        {
                            SQL_CON.Dispose();
                            await SQL_CON.OpenAsync();
                        }
                        SQL_COM.Connection = SQL_CON;
                        SQL_COM.CommandText = QUERY;
                        SQL_COM.CommandType = CommandType.StoredProcedure;
                        SQL_COM.Parameters.Clear();
                        SQL_COM.CommandTimeout = 99999;
                        foreach (string item in PARAM.Keys)
                        {
                            SQL_COM.Parameters.AddWithValue(item, PARAM[item]);
                        }
                        SDA.SelectCommand = SQL_COM;
                        await Task.Run(()=> SDA.Fill(dt));
                        SDA.Dispose();
                        return dt;
                    }
                }
            }
        }
    }
}