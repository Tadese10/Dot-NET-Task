using System.Net;
using DotNETTask.Domains.Dto;
using DotNETTask.Domains.Enum;
using DotNETTask.Domains.Models;
using DotNETTask.Persistence.Interfaces.Repositories;
using DotNETTask.Persistence.Interfaces.Services;

namespace DotNETTask.Core.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _taskRepository;
        public ProviderService(IProviderRepository taskRepository) => _taskRepository = taskRepository;

        public async Task<ProgramEntity> AddProvider(ProgramEntity family)
        {
            return await this._taskRepository.AddAsync(family);
        }

        public async Task<Response<IReadOnlyList<ProgramEntity>>> ListAllProviders()
        {
            var data =  await this._taskRepository.ListAllAsync();
            return new Response<IReadOnlyList<ProgramEntity>>
            {
                Data = data,
                Code = (int)HttpStatusCode.OK,
                Successful = true,
                Message = "Successful"
            };
        }

        public async Task<Response<ProgramEntity>> GetProvider(Guid taskId)
        {
            return new Response<ProgramEntity>
            {
                Data = await this._taskRepository.GetByIdAsync(taskId),
                Code = (int)HttpStatusCode.OK,
                Successful = true
            };
        }

        public async Task UpdateProvider(ProgramEntity data)
        {
            await this._taskRepository.UpdateAsync(data);
        }

        public async Task DeleteProvider(Guid taskId)
        {
            var family = await this._taskRepository.GetByIdAsync(taskId);
            await this._taskRepository.DeleteAsync(family);
        }

        public async Task<Response<object>> LookUpAsync()
        {
            return new Response<object>
            {
                Code = (int)HttpStatusCode.OK,
                Successful = true,
                Message = "Successful",
                Data = new
                {
                    skills = Enum.GetValues(typeof(SkillsEnum))
                                   .Cast<int>()
                                   .Select(x => new KeyValuePair<string, int>(value: x, key: Enum.GetName(typeof(SkillsEnum), x)))
                                   .ToList(),
                    Durations = Enum.GetValues(typeof(DurationEnum))
                                   .Cast<int>()
                                   .Select(x => new KeyValuePair<string, int>(value: x, key: Enum.GetName(typeof(DurationEnum), x)))
                                   .ToList(),
                    QuestionTypes = Enum.GetValues(typeof(QuestionTypesEnum))
                                   .Cast<int>()
                                   .Select(x => new KeyValuePair<string, int>(value: x, key: Enum.GetName(typeof(QuestionTypesEnum), x)))
                                   .ToList(),
                    ProgramTypes = Enum.GetValues(typeof(TypeEnum))
                                   .Cast<int>()
                                   .Select(x => new KeyValuePair<string, int>(value: x, key: Enum.GetName(typeof(TypeEnum), x)))
                                   .ToList(),
                }
            };
        }
    }
}
