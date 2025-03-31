using avaliacao_tecnica_visualsoft.Services;

namespace avaliacao_tecnica_visualsoft.Factories
{
    public interface IServiceAbstractFactory
    {
        ICnpjService CreateCnpjService();
        IDatabaseService CreateDatabaseService();
    }
}
