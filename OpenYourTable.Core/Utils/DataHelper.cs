using OpenYourTable.Obj.Enums;

namespace OpenYourTable.Core.Utils
{
	public static class DataHelper
	{
		public static string GenerateIndexValue(int isPrimary, string? indexName, int? nonUnique)
		{
			if (isPrimary == 1)
				return INDEX_NAME.PRIMARY.GetDescription();
			else
			{
				if (nonUnique == 0)
					return INDEX_NAME.UNIQUE.GetDescription();

				if (string.IsNullOrEmpty(indexName) == false)
					return INDEX_NAME.INDEX.GetDescription();
			}

			return string.Empty;
		}

		public static string GenerateDefaultValue(string? defaultValue, string? defaultExtra)
		{
			if (string.IsNullOrWhiteSpace(defaultValue) == false)
				return defaultValue;

			if (defaultValue is null && string.IsNullOrWhiteSpace(defaultExtra) == false)
			{
				if (string.Equals(defaultExtra, nameof(COLUMN_DEFAULT_EXTRA.AUTO_INCREMENT), StringComparison.OrdinalIgnoreCase))
					return defaultExtra.ToUpper();
				else
					return $"NULL {defaultExtra.ToUpper()}";
			}
			
			return string.Empty;
		}
	}
}
