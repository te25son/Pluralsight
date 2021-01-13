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
        public async Task<ActionResult<TalkModel[]>> Get(string moniker, bool includeSpeakers = true)
        {
            try
            {
                var talks = await Repository.GetTalksByMonikerAsync(moniker, includeSpeakers);

                return Mapper.Map<TalkModel[]>(talks);
            }
            catch (Exception)
            {
                return RequestDatabaseFailure();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TalkModel>> Get(string moniker, int id, bool includeSpeakers = true)
        {
            try
            {
                var talk = await Repository.GetTalkByMonikerAsync(moniker, id, includeSpeakers);

                if (talk == null)
                    return NotFound($"Talk with id '{id}' not found.");

                return Mapper.Map<TalkModel>(talk);
            }
            catch (Exception)
            {
                return RequestDatabaseFailure();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TalkModel>> Post(string moniker, TalkModel model)
        {
            try
            {
                var camp = await Repository.GetCampAsync(moniker);

                if (camp == null)
                    return BadRequest("Camp does not exist.");

                var talk = Mapper.Map<Talk>(model);
                talk.Camp = camp;

                if (model.Speaker == null)
                    return BadRequest("Speaker Id is required.");

                var speaker = await Repository.GetSpeakerAsync(model.Speaker.SpeakerId);

                if (speaker == null)
                    return BadRequest("Speaker could not be found.");

                talk.Speaker = speaker;

                Repository.Add(talk);

                if (await Repository.SaveChangesAsync())
                {
                    var url = LinkGenerator.GetPathByAction(
                        httpContext: HttpContext,
                        action: "Get",
                        values: new { moniker, id = talk.TalkId }
                    );

                    return Created(url, Mapper.Map<TalkModel>(talk));
                }
            }
            catch (Exception)
            {
                return RequestDatabaseFailure();
            }

            return BadRequest("Unable to save talk.");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TalkModel>> Put(string moniker, int id, TalkModel model, bool includeSpeakers = true)
        {
            try
            {
                var talk = await Repository.GetTalkByMonikerAsync(moniker, id, includeSpeakers);

                if (talk == null)
                    return NotFound($"Talk with id '{id}' not found.");

                if (model.Speaker != null)
                {
                    var speaker = await Repository.GetSpeakerAsync(model.Speaker.SpeakerId);
                    if (speaker != null)
                    {
                        talk.Speaker = speaker;
                    }
                }

                Mapper.Map(model, talk);

                if (await Repository.SaveChangesAsync())
                    return Mapper.Map<TalkModel>(talk);
            }
            catch (Exception)
            {
                return RequestDatabaseFailure();
            }

            return BadRequest("Unable to update talk.");
        }
    }
}
