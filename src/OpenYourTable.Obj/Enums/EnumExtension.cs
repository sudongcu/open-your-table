using System.ComponentModel;

namespace OpenYourTable.Obj.Enums
{
	public static class EnumExtension
	{
		public static string GetDescription(this Enum value)
		{
			var field = value.GetType().GetField(value.ToString());

			if (field is not null)
			{
				if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
				{
					return attribute.Description;
				}
			}
			return value.ToString();
		}
	}
}
