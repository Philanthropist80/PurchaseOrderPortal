using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoQueryable.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Obermind.Operation.Business.Model.Common;
using AutoQueryable.Extensions;
using AutoQueryable.Helpers;
using AutoQueryable.Models;


namespace Obermind.Operation.Server.Filters
{
    public class QueryableResult : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null) return;

            dynamic query = ((ObjectResult)context.Result).Value;
            if (query == null) throw new Exception("Unable to retreive value of IQueryable from context result.");
            Type entityType = query.GetType().GenericTypeArguments[0];

            var commands = context.HttpContext.Request.Query.ContainsKey("commands") ? context.HttpContext.Request.Query["commands"] : new StringValues();

            var data = query; //QueryableHelper.GetAutoQuery(commands, entityType, query,
            //    new AutoQueryableProfile { UnselectableProperties = new string[0] });

            var toArray = typeof(Enumerable).GetMethod("ToArray").MakeGenericMethod(typeof(object));

            var fetchedData = toArray.Invoke(null, new object[] { data });

            var total = System.Linq.Queryable.Count(query);
            context.Result = new OkObjectResult(new DataResult { Data = fetchedData, Total = total });
        }
    }
}
