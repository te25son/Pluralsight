using AutoMapper;
using CoreCodeCamp.Components;
using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampsController : AppController
    {
        public CampsController(ICampRepository repository, LinkGenerator linkGenerator)
            : base (repository, linkGenerator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<CampModel[]>> Get(bool includeTalks = false)
        {
            try
            {
                var results = await Repository.GetAllCampsAsync(includeTalks);

                return Mapper.Map<CampModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{moniker}")]
        public async Task<ActionResult<CampModel>> Get(string moniker)
        {
            try
            {
                var result = await Repository.GetCampAsync(moniker);

                if (result == null) return NotFound();

                return Mapper.Map<CampModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<CampModel[]>> SearchByDate(DateTime date, bool includeTalks = false)
        {
            try
            {
                var results = await Repository.GetAllCampsByEventDate(date, includeTalks);

                if (!results.Any()) return NotFound();

                return Ok(Mapper.Map<CampModel[]>(results));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CampModel>> Post(CampModel model)
        {
            try
            {
                var existing = await Repository.GetCampAsync(model.Moniker);

                if (existing != null)
                    return BadRequest("Moniker is being used");

                var location = LinkGenerator.GetPathByAction(
                    action: "Get",
                    controller: "Camps",
                    values: new { moniker = model.Moniker }
                );

                if (string.IsNullOrWhiteSpace(location))
                    return BadRequest("Could not use given moniker.");

                var camp = Mapper.Map<Camp>(model);
                Repository.Add(camp);

                if (await Repository.SaveChangesAsync())
                    return Created(location, Mapper.Map<CampModel>(camp));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

            return BadRequest();
        }

        [HttpPut("{moniker}")]
        public async Task<ActionResult<CampModel>> Put(string moniker, CampModel model)
        {
            try
            {
                var oldCamp = await Repository.GetCampAsync(moniker);

                if (oldCamp == null)
                    return NotFound($"Could not find moniker of {moniker}");

                Mapper.Map(model, oldCamp);

                if (await Repository.SaveChangesAsync())
                    return Mapper.Map<CampModel>(oldCamp);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

            return BadRequest();
        }

        [HttpDelete("{moniker}")]
        public async Task<IActionResult> Delete(string moniker)
        {
            try
            {
                var camp = await Repository.GetCampAsync(moniker);

                if (camp == null)
                    NotFound();

                Repository.Delete(camp);

                if (await Repository.SaveChangesAsync())
                    return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

            return BadRequest("Failed to delete camp");
        }
    }
}
