using System.Data;
using System.Data.SqlClient;

namespace OpenYourTable.Infra.DB
{
	internal sealed class MSSQLHandler : DBHandler
	{
		public override IDbConnection GetConnection()
		{
			return new SqlConnection(base.connectionString);
		}
	}
}
