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


		public List<EntityTableSchema> SelectTableSchema()
		{
			var dapperHandler = new DapperHandler();
			
			var parameters = new Dictionary<string, object>()
			{
				{ "@schema", DBConnectionInfo.schema }
			};

			string queryStr = @"SELECT TABLE_NAME AS table_name, TABLE_COMMENT AS table_comment
								FROM INFORMATION_SCHEMA.TABLES
								WHERE TABLE_SCHEMA = @schema ; ";

			var entityTableSchemas = dapperHandler.Query<EntityTableSchema>(queryStr, parameters);

			return entityTableSchemas;
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
									c.COLUMN_NAME AS column_name,
									c.DATA_TYPE AS data_type,
									c.COLUMN_KEY AS column_key,
									CASE WHEN c.IS_NULLABLE = 'YES' THEN TRUE ELSE FALSE END AS is_nullable,
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
