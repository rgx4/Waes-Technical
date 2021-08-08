using System.Threading.Tasks;
using WaesTechnical.Domain.Models;

namespace WaesTechnical.Application.UseCases.Interfaces
{
    public interface IDiffUseCases
    {
        Task<CreateResponse> CreateData(DataModel input);
        Task<GetResponse> GetDiffById(int id);
    }
}