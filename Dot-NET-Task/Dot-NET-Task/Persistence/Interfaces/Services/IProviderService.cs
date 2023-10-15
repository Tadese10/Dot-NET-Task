using System.Collections.Generic;
using System.Threading.Tasks;
using DotNETTask.Domains.Dto;
using DotNETTask.Domains.Models;

namespace TestAssignment.Persistence.Interfaces.Services
{
    public interface IProviderService
    {
        Task<Response<ProgramEntity>> GetProvider(Guid providerId);
        Task<ProgramEntity> AddProvider(ProgramEntity provider);
        Task<Response<IReadOnlyList<ProgramEntity>>> ListAllProviders();
        Task DeleteProvider(Guid providerId);
        Task UpdateProvider(ProgramEntity provider);
        Task<Response<object>> LookUpAsync();
    }
}
