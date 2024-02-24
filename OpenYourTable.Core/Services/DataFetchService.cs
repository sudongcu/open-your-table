using NUnit.Framework;
using OpenYourTable.Core.Utils;
using OpenYourTable.Infra.Repositories;
using OpenYourTable.Obj;
using OpenYourTable.Obj.Entities;
using OpenYourTable.Obj.Models.Data;

namespace OpenYourTable.Core.Services
{
	public class DataFetchService
	{
		private readonly IRepository _dataRepository;

		public DataFetchService(IRepository dataRepository)
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

		public byte[]? GenerateSpecifications(List<string> tableList)
		{
			var entityTableSpecifications = _dataRepository.SelectTableSpecification<EntityTableSpecification>(tableList);

			var tableSpecifications = this.GetTableSpecificationList(tableList, entityTableSpecifications);

			byte[]? specificationBytes = ExcelHelper.CreateExcelFile(tableSpecifications);

			return specificationBytes;
		}

		private List<TableSpecification> GetTableSpecificationList(List<string> tableList, List<EntityTableSpecification> entityTableSpecifications)
		{
			var tableSpecifications = new List<TableSpecification>();

			foreach (var table in tableList)
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

			return tableSpecifications;
		}
	}
}