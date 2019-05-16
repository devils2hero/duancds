using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EG.Graphql.Models;
using Microsoft.AspNetCore.Authentication;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EG.API.Controllers.Childev
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GraphController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        public GraphController(IDocumentExecuter _documentExecuter, ISchema _schema)
        {
            this._documentExecuter = _documentExecuter;
            this._schema = _schema;
        }
        [HttpPost]
        //[Authorize("AuthAPIChildDevelopSkills")]
        public async Task<IActionResult> Index([FromBody]GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions { Schema = _schema, Query = query.Query, Inputs =  query.Variables.ToInputs() };

            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}