using OpenYourTable.Obj.Enums;

namespace OpenYourTable.Obj
{
	public class ConnectionInfo
	{
		public required string host { get; set; }

		public required string port { get; set; }

		public required string id { get; set; }

		public required string password { get; set; }

		public required string schema { get; set; }

		public override string ToString()
		{
			return $"server={host};port={port};user id={id};password={password};database={schema};";
		}
	}
}
