﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMDataManager.Library.Internal.DataAccess
{
   internal class SqlDataAccess
    {


        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedprocedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new  SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedprocedure, parameters, 
                    commandType: CommandType.StoredProcedure).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string storedprocedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedprocedure, parameters,
                   commandType: CommandType.StoredProcedure);
              
            }
        }
    }
}
