using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoolApi.Data;
using CoolApi.DTOs;
using CoolApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CoolApi.Controllers
{
    [ApiController]
    [Route("api/commands")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Commented below line because its handled inside Startup.cs (inside ConfigureServices)
        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if(commandItem == null) 
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDTO>(commandItem));
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDTO.CommandId}, commandReadDTO);
            //return Ok(commandReadDTO);
        }

        // PUT api/commands
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);

            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);

            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);

            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}