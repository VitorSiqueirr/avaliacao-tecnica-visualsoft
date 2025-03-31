using avaliacao_tecnica_visualsoft.Services;

namespace avaliacao_tecnica_visualsoft.Factories
{
    public class ServiceFactory : IServiceAbstractFactory
    {
        public ICnpjService CreateCnpjService()
        {
            return new CnpjService();
        }

        public IDatabaseService CreateDatabaseService()
        {
            return new DatabaseService();
        }
    }
}
