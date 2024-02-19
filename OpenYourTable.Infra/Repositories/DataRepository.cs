using OpenYourTable.Infra.DB;
using OpenYourTable.Model;
using OpenYourTable.Model.Entities;

namespace OpenYourTable.Infra.Repositories
{
	public class DataRepository
	{
		public DataRepository()
		{

		}

		public bool SelectHealthy()
		{
			var dapperHandler = new DapperHandler();

			string queryStr = "SELECT true as is_healthy";

			var healthy = dapperHandler.QueryFirstOrDefault<bool>(queryStr);

			return healthy;
		}


		public List<string> SelectTableList()
		{
			var dapperHandler = new DapperHandler();
			
			var parameters = new Dictionary<string, object>()
			{
				{ "@schema", DBConnectionInfo.schema }
			};

			string queryStr = @"SELECT TABLE_NAME AS table_name
								FROM INFORMATION_SCHEMA.TABLES
								WHERE TABLE_SCHEMA = @schema ; ";

			var entityTableNames = dapperHandler.Query<string>(queryStr, parameters);

			return entityTableNames;
		}

		public List<EntityTableSpecification> SelectTableSpecification(List<string> tableList)
		{
			var dapperHandler = new DapperHandler();

			var parameters = new Dictionary<string, object>()
			{
				{ "@schema", DBConnectionInfo.schema },
				{ "@table_list", tableList }
			};

			string queryStr = @"SELECT 
									t.TABLE_NAME AS table_name,
									t.TABLE_COMMENT as table_comment,
									c.COLUMN_NAME AS column_name,
									c.DATA_TYPE AS data_type,
									c.CHARACTER_MAXIMUM_LENGTH AS max_length,
									c.COLUMN_KEY AS column_key,
									CASE WHEN c.IS_NULLABLE = 'YES' THEN TRUE ELSE FALSE END AS is_nullable,
									c.COLUMN_DEFAULT AS default_value,
									c.EXTRA AS default_extra,
									c.COLUMN_COMMENT AS comment,
									s.INDEX_NAME AS index_name,
									s.SEQ_IN_INDEX AS seq_in_index,
									s.NON_UNIQUE AS non_unique
								FROM information_schema.tables t
									JOIN information_schema.columns c 
										ON t.TABLE_NAME = c.TABLE_NAME
									LEFT JOIN information_schema.statistics s 
										ON t.TABLE_NAME = s.TABLE_NAME 
											AND c.COLUMN_NAME = s.COLUMN_NAME
								WHERE t.TABLE_SCHEMA = @schema
									AND t.TABLE_NAME IN @table_list
								ORDER BY t.TABLE_NAME ASC, c.ORDINAL_POSITION ASC ; ";

			var entityTableSpecification = dapperHandler.Query<EntityTableSpecification>(queryStr, parameters);

			return entityTableSpecification;
		}
	}
}
