using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace avaliacao_tecnica_visualsoft.Services
{
    public interface ICnpjService
    {
        Task<JObject> ConsultarCnpj(string cnpj);
    }
}
