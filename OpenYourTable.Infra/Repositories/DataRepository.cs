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

			string queryStr = @"SELECT TABLE_NAME, TABLE_COMMENT
								FROM INFORMATION_SCHEMA.TABLES
								WHERE TABLE_SCHEMA = @schema ; ";

			var entityTableSchemas = dapperHandler.Query<EntityTableSchema>(queryStr, parameters);

			return entityTableSchemas;
		}

		public object SelectSpecification()
		{

			return null;
		}
	}
}
