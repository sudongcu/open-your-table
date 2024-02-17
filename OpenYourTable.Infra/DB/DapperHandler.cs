﻿using Dapper;
using OpenYourTable.Model;
using OpenYourTable.Model.Enums;

namespace OpenYourTable.Infra.DB
{
	public class DapperHandler
	{
		private readonly DBHandler _dbHandler;

		public DapperHandler()
		{
			if (DBConnectionInfo.dbType == DB_TYPE.MySQL)
			{
				_dbHandler = new MySqlHandler();
			}
			else if (DBConnectionInfo.dbType == DB_TYPE.MSSQL)
			{
				throw new Exception("MSSQL is not yet defined.");
			}
			else
			{
				throw new Exception("DB Type is somethign wrong.");
			}

			_dbHandler.SetConnection(DBConnectionInfo.connectionString);
		}

		public List<T> Query<T>(string sql, Dictionary<string, object>? parameters = null)
		{
			using (var connection = _dbHandler.GetConnection())
			{
				var queryResult = connection.Query<T>(sql, parameters);

				return queryResult.AsList();
			}
		}
	}
}