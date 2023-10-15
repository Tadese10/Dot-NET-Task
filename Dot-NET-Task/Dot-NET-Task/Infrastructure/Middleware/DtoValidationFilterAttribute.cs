using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Http;
using ActionExecutedContext = Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext;
using ActionExecutingContext = Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;
using ContentResult = Microsoft.AspNetCore.Mvc.ContentResult;
using IActionFilter = Microsoft.AspNetCore.Mvc.Filters.IActionFilter;
using ModelStateDictionary = Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;
using DotNETTask.Domains.Dto;

namespace DotNETTask.Infrastructure.Middleware
{
    public class DtoValidationFilterAttribute : IActionFilter
    {
        private ILogger<DtoValidationFilterAttribute> _logger { get; }
        public DtoValidationFilterAttribute(ILogger<DtoValidationFilterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var param = context.ActionArguments
                .SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;
            if (param == null)
            {
                _logger.LogError($"Object sent from client is null. Controller: {controller},action: {action}");
                context.Result =
                    new BadRequestObjectResult($"Object is null. Controller:{controller}, action: {action}");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                _logger.LogError($"Invalid model state for the object. Controller: {controller}, action: {action}");
                context.Result = context.Result = new ContentResult { Content = GetErrors(context.ModelState), ContentType = "application/json" };
            }
        }


        private string GetErrors(ModelStateDictionary modelState)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new StringEnumConverter() }
            };

            return JsonConvert.SerializeObject(new Response<string>
            {
                Data = null,
                Errors = modelState.Values.SelectMany(v => v.Errors).Select(d => d.ErrorMessage).ToList(),
                Message = $"{String.Join(",", modelState.Values.SelectMany(v => v.Errors).Select(d => d.ErrorMessage).ToList())}",
                Code = (int)HttpStatusCode.BadRequest
            }, settings);
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
