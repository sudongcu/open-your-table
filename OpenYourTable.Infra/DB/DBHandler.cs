using System.Data;

namespace OpenYourTable.Infra.DB
{
	internal abstract class DBHandler
	{
		public string connectionString;

		public void SetConnection(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public abstract IDbConnection GetConnection();
	}
}
