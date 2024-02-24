using Dapper;
using OpenYourTable.Obj;
using OpenYourTable.Obj.Enums;

namespace OpenYourTable.Infra.DB
{
	public class DapperHandler
	{
		private readonly DBHandler _dbHandler;

		protected DapperHandler(DB_TYPE dbType)
		{
			_dbHandler = dbType switch
			{
				DB_TYPE.MSSQL => new MSSQLHandler(),
				DB_TYPE.MySql => new MySqlHandler(),
				_ => new MySqlHandler()
			};

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

		public T? QueryFirstOrDefault<T>(string sql, Dictionary<string, object>? parameters = null)
		{
			using (var connection = _dbHandler.GetConnection())
			{
				var queryResult = connection.QueryFirstOrDefault<T>(sql, parameters);

				return queryResult;
			}
		}
	}
}
