namespace OpenYourTable.Infra.Repositories
{
	public interface IRepository
	{
		public bool SelectHealthy();

		public List<string> SelectTables();

		public List<TEntity> SelectTableSpecification<TEntity>(List<string> tables);
	}
}