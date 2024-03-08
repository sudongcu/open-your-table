using OpenYourTable.Infra.DB;
using OpenYourTable.Obj.Enums;

namespace OpenYourTable.Infra.Repositories
{
	public class MSSQLRepository : DapperHandler, IDataRepository
	{
		public MSSQLRepository() : base(DB_TYPE.MSSQL) { }

		public bool SelectHealthy()
		{
			string queryStr = "SELECT 1 as is_healthy";

			var healthy = base.QueryFirstOrDefault<short?>(queryStr);

			return healthy is not null;
		}

		public List<string> SelectTables()
		{
			string queryStr = @"SELECT name
								FROM sys.tables
								ORDER BY name ASC;";

			var entityTableNames = base.Query<string>(queryStr);

			return entityTableNames;
		}

		public List<TEntity> SelectTableSpecification<TEntity>(List<string> tables)
		{
			var parameters = new Dictionary<string, object>()
			{
				{ "@tables", tables }
			};

			string queryStr = @"SELECT t.name AS table_name,
									c.name AS column_name,
									ty.name AS data_type,
									c.max_length,
									c.is_nullable,
									dc.definition AS default_value,
									ep.value AS comment,
									i.is_primary_key AS is_primary,
									i.name AS index_name,
									i.is_unique_constraint AS non_unique
								FROM  sys.tables AS t
									INNER JOIN  sys.columns c 
										ON t.object_id = c.object_id
									LEFT JOIN sys.index_columns ic 
										ON ic.object_id = c.object_id 
											AND ic.column_id = c.column_id
									LEFT JOIN sys.indexes i
										ON ic.object_id = i.object_id
											AND ic.index_id = i.index_id
									LEFT JOIN sys.types ty 
										ON c.user_type_id = ty.user_type_id
									LEFT JOIN sys.default_constraints dc
										ON c.default_object_id = dc.object_id
									LEFT JOIN sys.extended_properties ep 
										ON ep.major_id = c.object_id
											AND ep.minor_id = c.column_id
											AND ep.class = 1
								WHERE t.name IN @tables
								ORDER BY t.name ASC, c.column_id ASC;";

			var entityTableSpecification = base.Query<TEntity>(queryStr, parameters);

			return entityTableSpecification;
		}
	}
}
