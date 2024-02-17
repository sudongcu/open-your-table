using OpenYourTable.Model.Enums;

namespace OpenYourTable.Model
{
	public class ConnectionInfo
	{
		public required string host { get; set; }

		public required string port { get; set; }

		public required string id { get; set; }

		public required string password { get; set; }

		public required DBInfo dbInfo { get; set; }

		public override string ToString()
		{
			return $"server={host};port={port};user id={id};password={password};database={dbInfo.schema};";
		}
	}

	public class DBInfo()
	{
		public required DB_TYPE type { get; set; }

		public required string schema { get; set; }
	}
}
