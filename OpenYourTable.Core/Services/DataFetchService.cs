﻿using OpenYourTable.Infra.Repositories;
using OpenYourTable.Model.DataFetch;

namespace OpenYourTable.Core.Services
{
	public class DataFetchService
	{
		private readonly DataRepository _dataRepository;

		public DataFetchService(DataRepository dataRepository)
		{
			_dataRepository = dataRepository;
		}

		public List<TableSchema> GetTableSchemas()
		{
			var entityTableSchemas = _dataRepository.SelectTableSchema();

			if (entityTableSchemas.Count == 0)
				return Enumerable.Empty<TableSchema>().ToList();

			var tableSchemas = entityTableSchemas.Select(schema => new TableSchema(schema.TABLE_NAME, schema.TABLE_COMMENT)).ToList();

			return tableSchemas;
		}

		public byte[]? GenerateSpecifications(List<string> tableList)
		{
			byte[]? specificationBytes = null;


			return specificationBytes;
		}
	}
}
