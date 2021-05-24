using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{


    [Route("Api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommanderRepo _repo;
        public CommandsController(ICommanderRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> getAllCommands()
        {
            var commandItems = _repo.getAppCommands();

            return Ok(commandItems);
        }

        //accept http params emp GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Command>> getCommandById(int id)
        {
            var commandItem = _repo.getCommandById(id);

            return Ok(commandItem);
        }

    }
}