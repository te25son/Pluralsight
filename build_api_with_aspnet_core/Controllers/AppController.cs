using AutoMapper;
using CoreCodeCamp.Components;
using CoreCodeCamp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CoreCodeCamp.Controllers
{
    public abstract partial class AppController : ControllerBase
    {
        protected AppController(ICampRepository repository, LinkGenerator linkGenerator)
        {
            Repository = repository;
            LinkGenerator = linkGenerator;
        }

        protected ICampRepository Repository { get; private set; }

        protected LinkGenerator LinkGenerator { get; private set; }

        protected static IMapper Mapper => Mapping.CreateMapper();

        public ActionResult RequestDatabaseFailure()
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
        }
    }
}
