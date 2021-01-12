using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [ApiController]
    [Route("api/camps/{moniker}/talks")]
    public class TalksController : AppController
    {
        public TalksController(ICampRepository repository, LinkGenerator linkGenerator)
            : base(repository, linkGenerator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<TalkModel[]>> Get(string moniker)
        {
            try
            {
                var talks = await Repository.GetTalksByMonikerAsync(moniker);

                return Mapper.Map<TalkModel[]>(talks);
            }
            catch (Exception)
            {
                return RequestDatabaseFailure();
            }
        }
    }
}
