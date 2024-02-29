using OpenYourTable.Infra.DB;
using OpenYourTable.Obj;
using OpenYourTable.Obj.Enums;

namespace OpenYourTable.Infra.Repositories
{
	public class MySqlRepository : DapperHandler, IDataRepository
	{
		public MySqlRepository() : base(DB_TYPE.MySql) { }

		public bool SelectHealthy()
		{
			string queryStr = "SELECT 1 as is_healthy";

			var healthy = base.QueryFirstOrDefault<short?>(queryStr);

			return healthy is not null;
		}

		public List<string> SelectTables()
		{
			var parameters = new Dictionary<string, object>()
			{
				{ "@schema", DBConnectionInfo.schema }
			};

			string queryStr = @"SELECT TABLE_NAME AS table_name
								FROM INFORMATION_SCHEMA.TABLES
								WHERE TABLE_SCHEMA = @schema ;";

			var entityTableNames = base.Query<string>(queryStr, parameters);

			return entityTableNames;
		}

		public List<TEntity> SelectTableSpecification<TEntity>(List<string> tables)
		{
			var parameters = new Dictionary<string, object>()
			{
				{ "@schema", DBConnectionInfo.schema },
				{ "@tables", tables }
			};

			string queryStr = @"SELECT 
									t.TABLE_NAME AS table_name,
									t.TABLE_COMMENT as table_comment,
									c.COLUMN_NAME AS column_name,
									c.DATA_TYPE AS data_type,
									CASE WHEN c.NUMERIC_PRECISION IS NOT NULL THEN c.NUMERIC_PRECISION 
										 WHEN c.DATETIME_PRECISION IS NOT NULL THEN c.DATETIME_PRECISION 
	 									 ELSE c.CHARACTER_MAXIMUM_LENGTH
									END AS max_length,
									CASE WHEN c.IS_NULLABLE = 'YES' THEN 1 ELSE 0 END AS nullable,
									c.COLUMN_DEFAULT AS default_value,
									c.EXTRA AS default_extra,
									c.COLUMN_COMMENT AS comment,
									CASE WHEN s.INDEX_NAME = 'PRIMARY' THEN 1 ELSE 0 END AS is_primary,
									s.INDEX_NAME AS index_name,
									s.NON_UNIQUE AS non_unique
								FROM information_schema.tables t
									JOIN information_schema.columns c 
										ON t.TABLE_NAME = c.TABLE_NAME
									LEFT JOIN information_schema.statistics s 
										ON t.TABLE_NAME = s.TABLE_NAME 
											AND c.COLUMN_NAME = s.COLUMN_NAME
								WHERE t.TABLE_SCHEMA = @schema
									AND t.TABLE_NAME IN @tables
								ORDER BY t.TABLE_NAME ASC, c.ORDINAL_POSITION ASC ;";

			var entityTableSpecification = base.Query<TEntity>(queryStr, parameters);

			return entityTableSpecification;
		}
	}
}
