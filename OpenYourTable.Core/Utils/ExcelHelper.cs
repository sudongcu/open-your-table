using NUnit.Framework.Internal.Execution;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OpenYourTable.Model.DataFetch;
using OpenYourTable.Model.Enums;
using System.Drawing;
using System.Reflection.PortableExecutable;

namespace OpenYourTable.Core.Utils
{
	public static class ExcelHelper
	{

		public static byte[] CreateExcelFile(List<TableSpecification> tableSpecifications)
		{
			byte[] files = null;

			using (var package = new ExcelPackage())
			{
				WriteTableSpecifications(package.Workbook.Worksheets.Add("tables"), tableSpecifications);


				using (var memoryStream = new MemoryStream(package.GetAsByteArray()))
				{
					files = memoryStream.ToArray();
				}
			}

			return files;
		}

		private static void WriteTableSpecifications(ExcelWorksheet worksheet, List<TableSpecification> tableSpecifications)
		{
			int startRow = 2;

			var cellWidthDic = GetColumnCellWidth();

			foreach (var table in tableSpecifications)
			{
				SetTableCell(worksheet, startRow, (int)TABLE_CELL.NAME_FROM, (int)TABLE_CELL.NAME_TO, isHeader: true);
				worksheet.Cells[startRow, (int)TABLE_CELL.NAME_FROM].Value = TABLE_CELL.NAME_FROM.GetDescription();
				SetTableCell(worksheet, startRow, (int)TABLE_CELL.COMMENT_FROM, (int)TABLE_CELL.COMMENT_TO, isHeader: true);
				worksheet.Cells[startRow, (int)TABLE_CELL.COMMENT_FROM].Value = TABLE_CELL.COMMENT_FROM.GetDescription();
				startRow++;

				SetTableCell(worksheet, startRow, (int)TABLE_CELL.NAME_FROM, (int)TABLE_CELL.NAME_TO);
				worksheet.Cells[startRow, (int)TABLE_CELL.NAME_FROM].Value = table.name;
				SetTableCell(worksheet, startRow, (int)TABLE_CELL.COMMENT_FROM, (int)TABLE_CELL.COMMENT_TO);
				worksheet.Cells[startRow, (int)TABLE_CELL.COMMENT_FROM].Value = table.comment;
				startRow++;

				worksheet.Column((int)COLUMN_CELL.NAME).Width = cellWidthDic[COLUMN_CELL.NAME];
				worksheet.Column((int)COLUMN_CELL.DATA_TYPE).Width = cellWidthDic[COLUMN_CELL.DATA_TYPE];
				worksheet.Column((int)COLUMN_CELL.LENGTH).Width = cellWidthDic[COLUMN_CELL.LENGTH];
				worksheet.Column((int)COLUMN_CELL.NULLABLE).Width = cellWidthDic[COLUMN_CELL.NULLABLE];
				worksheet.Column((int)COLUMN_CELL.INDEX).Width = cellWidthDic[COLUMN_CELL.INDEX];
				worksheet.Column((int)COLUMN_CELL.DEFAULT).Width = cellWidthDic[COLUMN_CELL.DEFAULT];
				worksheet.Column((int)COLUMN_CELL.COMMENT).Width = cellWidthDic[COLUMN_CELL.COMMENT];

				SetColumnCell(worksheet, startRow, (int)COLUMN_CELL.NAME, (int)COLUMN_CELL.COMMENT, isHeader: true);
				worksheet.Cells[startRow, (int)COLUMN_CELL.NAME].Value = COLUMN_CELL.NAME.GetDescription();
				worksheet.Cells[startRow, (int)COLUMN_CELL.DATA_TYPE].Value = COLUMN_CELL.DATA_TYPE.GetDescription();
				worksheet.Cells[startRow, (int)COLUMN_CELL.LENGTH].Value = COLUMN_CELL.LENGTH.GetDescription();
				worksheet.Cells[startRow, (int)COLUMN_CELL.NULLABLE].Value = COLUMN_CELL.NULLABLE.GetDescription();
				worksheet.Cells[startRow, (int)COLUMN_CELL.INDEX].Value = COLUMN_CELL.INDEX.GetDescription();
				worksheet.Cells[startRow, (int)COLUMN_CELL.DEFAULT].Value = COLUMN_CELL.DEFAULT.GetDescription();
				worksheet.Cells[startRow, (int)COLUMN_CELL.COMMENT].Value = COLUMN_CELL.COMMENT.GetDescription();
				startRow++;

				foreach (var column in table.columns)
				{
					SetColumnCell(worksheet, startRow, (int)COLUMN_CELL.NAME, (int)COLUMN_CELL.COMMENT);
					worksheet.Cells[startRow, (int)COLUMN_CELL.NAME].Value = column.name;
					worksheet.Cells[startRow, (int)COLUMN_CELL.DATA_TYPE].Value = column.dataType;
					worksheet.Cells[startRow, (int)COLUMN_CELL.LENGTH].Value = column.maxLength;
					worksheet.Cells[startRow, (int)COLUMN_CELL.NULLABLE].Value = column.nullable;
					worksheet.Cells[startRow, (int)COLUMN_CELL.INDEX].Value = column.index;
					worksheet.Cells[startRow, (int)COLUMN_CELL.DEFAULT].Value = column.defaultValue;
					worksheet.Cells[startRow, (int)COLUMN_CELL.COMMENT].Value = column.comment;;
					startRow++;
				}

				startRow += 3;
			}
		}

		private static void SetTableCell(ExcelWorksheet worksheet, int startRow, int from, int to, bool isHeader = false)
		{
			ExcelRange tableCellRange = worksheet.Cells[startRow, from, startRow, to];
			tableCellRange.Merge = true;
			tableCellRange.Style.Border.BorderAround(ExcelBorderStyle.Thin);

			if (isHeader)
			{
				tableCellRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
				tableCellRange.Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);
				tableCellRange.Style.Font.Bold = true;
				tableCellRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
			}
		}

		private static void SetColumnCell(ExcelWorksheet worksheet, int startRow, int from, int to, bool isHeader = false)
		{
			ExcelRange columnCellRange = worksheet.Cells[startRow, from, startRow, to]; 
			columnCellRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
			columnCellRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
			columnCellRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
			columnCellRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

			if (isHeader)
			{
				columnCellRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
				columnCellRange.Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);
				columnCellRange.Style.Font.Bold = true;
				columnCellRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
			}
		}

		private static Dictionary<COLUMN_CELL, int> GetColumnCellWidth()
		{
			return new Dictionary<COLUMN_CELL, int>()
			{
				{ COLUMN_CELL.NAME, 30 },
				{ COLUMN_CELL.DATA_TYPE, 10 },
				{ COLUMN_CELL.LENGTH, 10 },
				{ COLUMN_CELL.NULLABLE, 10 },
				{ COLUMN_CELL.INDEX, 10 },
				{ COLUMN_CELL.DEFAULT, 40 },
				{ COLUMN_CELL.COMMENT, 50 }
			};
		}
	}
}
