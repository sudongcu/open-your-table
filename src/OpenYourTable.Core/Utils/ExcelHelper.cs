using Google.Protobuf.WellKnownTypes;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OpenYourTable.Obj;
using OpenYourTable.Obj.Enums;
using OpenYourTable.Obj.Models.Data;
using System.Drawing;

namespace OpenYourTable.Core.Utils
{
    public static class ExcelHelper
	{
		private static Color headerColor;

		public static byte[] CreateExcelFile(Dictionary<string, List<TableSpecification>> tableSpecificationDic, TableGenerateOption option)
		{
			headerColor = TableGenerateOption.ToColor(option.headerColor);

			byte[] files;

			using (var package = new ExcelPackage())
			{
				foreach (var tableSpecifications in tableSpecificationDic)
				{
					WriteTableSpecifications(
						worksheet: package.Workbook.Worksheets.Add(string.IsNullOrEmpty(tableSpecifications.Key) ? DBConnectionInfo.schema : tableSpecifications.Key),
						tableSpecifications: tableSpecifications.Value);
				}

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
				SetTableCell(worksheet, startRow, (int)TABLE_CELL.SCHEMA, (int)TABLE_CELL.SCHEMA, isHeader: true);
				SetTableCell(worksheet, startRow, (int)TABLE_CELL.NAME_FROM, (int)TABLE_CELL.NAME_TO, isHeader: true);
				SetTableCell(worksheet, startRow, (int)TABLE_CELL.COMMENT_FROM, (int)TABLE_CELL.COMMENT_TO, isHeader: true);
				worksheet.Cells[startRow, (int)TABLE_CELL.SCHEMA].Value = TABLE_CELL.SCHEMA.GetDescription();
				worksheet.Cells[startRow, (int)TABLE_CELL.NAME_FROM].Value = TABLE_CELL.NAME_FROM.GetDescription();
				worksheet.Cells[startRow, (int)TABLE_CELL.COMMENT_FROM].Value = TABLE_CELL.COMMENT_FROM.GetDescription();
				startRow++;

				SetTableCell(worksheet, startRow, (int)TABLE_CELL.SCHEMA, (int)TABLE_CELL.SCHEMA);
				SetTableCell(worksheet, startRow, (int)TABLE_CELL.NAME_FROM, (int)TABLE_CELL.NAME_TO);
				SetTableCell(worksheet, startRow, (int)TABLE_CELL.COMMENT_FROM, (int)TABLE_CELL.COMMENT_TO);
				worksheet.Cells[startRow, (int)TABLE_CELL.SCHEMA].Value = table.schema;
				worksheet.Cells[startRow, (int)TABLE_CELL.NAME_FROM].Value = table.name;
				worksheet.Cells[startRow, (int)TABLE_CELL.COMMENT_FROM].Value = table.comment;
				startRow++;

				SetColumnCell(worksheet, startRow, (int)COLUMN_CELL.SEQ, (int)COLUMN_CELL.SEQ, ExcelHorizontalAlignment.Right, isHeader: true);
				SetColumnCell(worksheet, startRow, (int)COLUMN_CELL.NAME, (int)COLUMN_CELL.COMMENT, ExcelHorizontalAlignment.Center, isHeader: true);
				foreach (var cellWidthKv in cellWidthDic)
				{
					worksheet.Column((int)cellWidthKv.Key).Width = cellWidthKv.Value;
					worksheet.Cells[startRow, (int)cellWidthKv.Key].Value = cellWidthKv.Key.GetDescription();
				}
				startRow++;

				int seq = 1;
				foreach (var column in table.columns)
				{
					SetColumnCell(worksheet, startRow, (int)COLUMN_CELL.SEQ, (int)COLUMN_CELL.SEQ, ExcelHorizontalAlignment.Right);
					SetColumnCell(worksheet, startRow, (int)COLUMN_CELL.NAME, (int)COLUMN_CELL.COMMENT, ExcelHorizontalAlignment.Center);
					worksheet.Cells[startRow, (int)COLUMN_CELL.SEQ].Value = seq++;
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
			tableCellRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

			if (isHeader)
			{
				tableCellRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
				tableCellRange.Style.Fill.BackgroundColor.SetColor(headerColor);
				tableCellRange.Style.Font.Bold = true;
			}
		}

		private static void SetColumnCell(ExcelWorksheet worksheet, int startRow, int from, int to, ExcelHorizontalAlignment horizontalAlign, bool isHeader = false)
		{
			ExcelRange columnCellRange = worksheet.Cells[startRow, from, startRow, to]; 
			columnCellRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
			columnCellRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
			columnCellRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
			columnCellRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
			columnCellRange.Style.HorizontalAlignment = horizontalAlign;

			if (isHeader)
			{
				columnCellRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
				columnCellRange.Style.Fill.BackgroundColor.SetColor(headerColor);
				columnCellRange.Style.Font.Bold = true;
			}
		}

		private static Dictionary<COLUMN_CELL, int> GetColumnCellWidth()
		{
			return new Dictionary<COLUMN_CELL, int>()
			{
				{ COLUMN_CELL.SEQ, 10 },
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
