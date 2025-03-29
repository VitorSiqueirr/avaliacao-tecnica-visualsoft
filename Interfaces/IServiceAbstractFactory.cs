using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using avaliacao_tecnica_visualsoft.Services;

namespace avaliacao_tecnica_visualsoft.Factories
{
    public interface IServiceAbstractFactory
    {
        ICnpjService CreateCnpjService();
        IDatabaseService CreateDatabaseService();
    }
}
