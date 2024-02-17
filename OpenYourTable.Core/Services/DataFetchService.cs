using OpenYourTable.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenYourTable.Core.Services
{
	public class DataFetchService
	{
		private readonly DataRepository _dataRepository;

		public DataFetchService(DataRepository dataRepository) 
		{
			_dataRepository = dataRepository;
		}

	}
}
