using System.Drawing;

namespace OpenYourTable.Obj.Models.Data
{
	public class TableGenerateOption
	{
		public string headerColor { get; set; }


		public static Color ToColor(string hexColor)
		{
			int red = Convert.ToInt32(hexColor.Substring(5, 2), 16);
			int green = Convert.ToInt32(hexColor.Substring(3, 2), 16);
			int blue = Convert.ToInt32(hexColor.Substring(1, 2), 16);
			
			return Color.FromArgb(blue, green, red);
		}
	}
}
