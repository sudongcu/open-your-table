using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using OpenYourTable.Core.Utils;
using OpenYourTable.Infra.Repositories;
using OpenYourTable.Obj;
using OpenYourTable.Obj.Entities;
using OpenYourTable.Obj.Models.Data;
using System.Collections.Generic;
using static Mysqlx.Expect.Open.Types;

namespace OpenYourTable.Core.Services
{
	public class DataFetchService
	{
		private readonly IDataRepository _dataRepository;

		public DataFetchService(IDataRepository dataRepository)
		{
			_dataRepository = dataRepository;
		}

		public void CheckDBConnection()
		{
			try
			{
				bool isHealthy = _dataRepository.SelectHealthy();

				if (isHealthy == false)
					throw new Exception("Connection Information is wrong.");
			}
			catch (Exception ex)
			{
#if DEBUG

				throw;

#endif

				throw new Exception("Connection Information is wrong.");
			}
		}

		public List<string> GetTableSchemas()
		{
			var entityTables = _dataRepository.SelectTables();

			if (entityTables.Count == 0)
				return Enumerable.Empty<string>().ToList();

			return entityTables;
		}

		public byte[]? GenerateSpecifications(List<string> tables, Dictionary<string, string[]> filterDic)
		{
			var entityTableSpecifications = _dataRepository.SelectTableSpecification<EntityTableSpecification>(tables);

			var filteredTableDic = this.DevideTableByFilter(tables, filterDic);

			var tableSpecificationDic = this.GetTableSpecification(filteredTableDic, entityTableSpecifications);

			byte[]? specificationBytes = ExcelHelper.CreateExcelFile(tableSpecificationDic);

			return specificationBytes;
		}

		private Dictionary<string, List<string>> DevideTableByFilter(List<string> tables, Dictionary<string, string[]> filterDic)
		{
			Dictionary<string, List<string>> filteredTables = [];

			foreach (var filter in filterDic)
			{
				List<string> filteredList = [];

				foreach (var condition in filter.Value)
				{
					if (condition.StartsWith('!'))
					{
						string exclude = condition[1..];
						if (exclude.Contains('*'))
						{
							if (exclude.StartsWith('*'))
							{
								string suffix = exclude.Trim('*');
								filteredList.RemoveAll(filter => filter.EndsWith(suffix));
							}
							else
							{
								string prefix = exclude.Trim('*');
								filteredList.RemoveAll(filter => filter.StartsWith(prefix));
							}
						}
						else
						{
							filteredList.RemoveAll(filter => filter.Equals(exclude, StringComparison.OrdinalIgnoreCase));
						}
					}
					else if (condition.Contains('*'))
					{
						if (condition.StartsWith('*'))
						{
							string suffix = condition.Trim('*');
							filteredList.AddRange(tables.Where(table => table.EndsWith(suffix)));
						}
						else
						{
							string prefix = condition.Trim('*');
							filteredList.AddRange(tables.Where(table => table.StartsWith(prefix)));
						}
					}
					else
					{
						if (tables.Contains(condition))
							filteredList.Add(condition);
					}
				}

				if (filter.Value.All(string.IsNullOrEmpty))
				{
					filteredList.AddRange(tables.Except(filteredTables.Values.SelectMany(x => x)));
				}

				filteredTables.Add(filter.Key, filteredList);
			}

			return filteredTables;
		}

		private Dictionary<string, List<TableSpecification>> GetTableSpecification(Dictionary<string, List<string>> filteredTableDic, List<EntityTableSpecification> entityTableSpecifications)
		{
			Dictionary<string, List<TableSpecification>> tableSpecificationDic = [];

			foreach (var filteredTable in filteredTableDic)
			{
				List<TableSpecification> tableSpecifications = [];
				foreach (var table in filteredTable.Value)
				{
					var entityItems = entityTableSpecifications.Where(w => w.table_name == table).Select(s => s).ToArray();
					if (entityItems is null || entityItems.Length == 0)
						continue;

					var tableSpecification = new TableSpecification
					{
						schema = DBConnectionInfo.schema,
						name = entityItems[0].table_name,
						comment = entityItems[0].table_comment,
						columns = []
					};

					foreach (var entityItem in entityItems)
					{
						tableSpecification.columns.Add(new ColumnSpecification()
						{
							name = entityItem.column_name,
							dataType = entityItem.data_type,
							maxLength = entityItem.max_length.ToString() ?? string.Empty,
							nullable = entityItem.is_nullable == 1 ? "Y" : string.Empty,
							index = DataHelper.GenerateIndexValue(entityItem.is_primary, entityItem.index_name, entityItem.non_unique),
							defaultValue = DataHelper.GenerateDefaultValue(entityItem.default_value, entityItem.default_extra),
							comment = entityItem.comment
						});
					}

					tableSpecifications.Add(tableSpecification);
				}

				tableSpecificationDic.Add(filteredTable.Key, tableSpecifications);
			}

			return tableSpecificationDic;
		}
	}
}