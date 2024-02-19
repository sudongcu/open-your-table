using MySql.Data.MySqlClient;
using System.Data;

namespace OpenYourTable.Infra.DB
{
	internal class MySqlHandler : DBHandler
	{
		public override IDbConnection GetConnection()
		{
			return new MySqlConnection(base.connectionString);
		}
	}
}
