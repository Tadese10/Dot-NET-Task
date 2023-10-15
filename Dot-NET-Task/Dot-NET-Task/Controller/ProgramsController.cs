using Humanizer;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DotNETTask.Domains.Dto;
using DotNETTask.Domains.Models;
using DotNETTask.Infrastructure.Middleware;
using DotNETTask.Persistence.Interfaces.Services;

namespace DotNETTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProgramsController(IProviderService providerService) => _providerService = providerService;

        [HttpPost, Route("add-program")]
        [ServiceFilter(typeof(DtoValidationFilterAttribute))]
        public async Task<IActionResult> AddProgramAsycn([FromBody] AddNewProgramDto data)
        {
            var program = data.Adapt<ProgramEntity>();
            var savedProgram = await this._providerService.AddProvider(program);

            return Ok(savedProgram);
        }

        [HttpPut, Route("add-form/{providerId}")]
        public async Task<IActionResult> AddApplicatioFormAsync([FromRoute] Guid providerId, [FromForm] ApplicationFormDto data)
        {
            var provider = await this._providerService.GetProvider(providerId);
            if(provider.Data == null)
            {
                return Ok(new Response<string>
                {
                    Code = (int)HttpStatusCode.NotFound,
                    Message = "Not found.",
                    Successful = false
                });
            }

            provider.Data.ApplicationForm = data.Adapt<ApplicationForm>();

            //Get Upload folder path
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory  +  "\\UploadedFiles");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = folderPath + "\\" + providerId + "\\" + Guid.NewGuid().ToString() + "\\" + data.ImageFile.FileName;

            using (FileStream filestream = System.IO.File.Create(filePath))
            {
                data.ImageFile.CopyTo(filestream);
                filestream.Flush();
            }

           
            provider.Data.ApplicationForm.CoverImagePath = filePath;
            await this._providerService.UpdateProvider(provider.Data);

            return Ok(new Response<string>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Added application form successfully.",
                Successful = true
            });
        }

        [HttpGet, Route("all")]
        public async Task<IActionResult> AllProgramAsync()
        {
            return Ok(await this._providerService.ListAllProviders());
        }

        [HttpGet, Route("{providerId}")]
        public async Task<IActionResult> GetProgramByIdAsync([FromRoute] Guid providerId)
        {
            return Ok(await this._providerService.GetProvider(providerId));
        }

        [HttpPut, Route("add-workflow/{providerId}")]
        public async Task<IActionResult> AddWorkFlowAsync([FromRoute] Guid providerId, [FromForm] WorkFlowDto data)
        {
            var provider = await this._providerService.GetProvider(providerId);
            if (provider.Data == null)
            {
                return Ok(new Response<string>
                {
                    Code = (int)HttpStatusCode.NotFound,
                    Message = "Not found.",
                    Successful = false
                });
            }

            provider.Data.WorkFLow = data.Adapt<WorkFlow>();

            await this._providerService.UpdateProvider(provider.Data);

            return Ok(new Response<string>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Added Workflow successfully.",
                Successful = true
            });

        }
        
    }
}
