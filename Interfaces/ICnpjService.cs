using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avaliacao_tecnica_visualsoft.Services
{
    public interface ICnpjService
    {
        string ConsultarCnpj(string cnpj);
    }
}
