using OpenYourTable.Obj.Enums;

namespace OpenYourTable.Obj
{
	public class ConnectionInfo
	{
		public required string host { get; set; }

		public required string id { get; set; }

		public required string password { get; set; }

		public required string schema { get; set; }

		public required DB_TYPE dbType { get; set; }

		public string? port { get; set; }

		
		public override string ToString()
		{
			string portStr = string.Empty;
			if (string.IsNullOrWhiteSpace(port) == false)
			{
				if (dbType == DB_TYPE.MSSQL)
					portStr = $", {port}";
				else
					portStr = $"port={port};";
			}

			if (dbType == DB_TYPE.MSSQL)
				return $"server={host}{portStr};user id={id};password={password};database={schema};";
			else
				return $"server={host};{portStr};user id={id};password={password};database={schema};";
		}
	}
}
