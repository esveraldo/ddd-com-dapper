using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ExemploDDD.Repository.Connection
{
    public static class DbHelper
    {
        private const string stringDeConexao=
                    @"Data Source=(localdb)\mssqllocaldb;
                      Initial Catalog = MeExpressDB; 
                      User ID=sa;
                      Password=esve6140
                     Integrated Security = True; 
                     Pooling=False";

        public static SqlConnection obterConexao()
        {
            return new SqlConnection(stringDeConexao);
        } 

        public static int Execute(string sql, object parametro)
        {
            using (var db = obterConexao())
            {
                return db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
            }
        }

        public static List<T> Query<T>(string sql, object parametro)
        {
            using (var db = obterConexao())
            {
                return db.Query<T>(sql, parametro, commandType: CommandType.StoredProcedure).ToList();
            }

        }

        public static T QueryFirstOrDefault<T>(string sql, object parametro)
        {
            using (var db = obterConexao())
            {
                return db.QueryFirstOrDefault<T>(sql, parametro, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
