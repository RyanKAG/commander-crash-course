using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{


    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommanderRepo _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> getAllCommands()
        {
            var commandItems = _repo.getAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //accept http params emp GET api/commands/{id}
        [HttpGet("{id}", Name = "getCommandById")]
        public ActionResult<CommandReadDto> getCommandById(int id)
        {
            var commandItem = _repo.getCommandById(id);

            if (commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> createCommand(CommandCreateDto commandCreateDto)
        {
            //mapping CMDTO to Command Model
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repo.createCommand(commandModel);
            _repo.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            //adds the location header. Uri to locate the record
            // return CreatedAtRoute(nameof(getCommandById), new {Id = commandReadDto.Id});
            return Ok(commandModel);
        }
        [HttpPut("{id}")]
        public ActionResult updateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModel = _repo.getCommandById(id);

            if (commandModel != null)
            {
                _mapper.Map(commandUpdateDto, commandModel);
                _repo.updateCommand(commandModel);
                _repo.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult deleteCommand(int id)
        {
            var commandModel = _repo.getCommandById(id);

            if (commandModel != null)
            {
                _repo.deleteCommand(commandModel);
                _repo.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }
    }
}

