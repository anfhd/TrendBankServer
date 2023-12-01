using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.Design;
using TrendBankServer.Models.DataTransferObjects;
using TrendBankServer.Repository;

namespace TrendBankServer.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public UsersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _repository.User.GetAllUsers(trackChanges: false);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(users);
        }

        [HttpGet("{id}", Name = "UserById")]
        public IActionResult GetUser(Guid id)
        {
            var user = _repository.User.GetUser(id, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]UserForCreationDto user)
        {
            if(user == null)
            {
                _logger.LogError("UserForCreationDto object sent from client is null.");
                return BadRequest("UserForCreationDto object is null.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the UserForCreationDto object");
                return UnprocessableEntity(ModelState);
            }


            var userEntity = _mapper.Map<Models.User>(user);

            _repository.User.CreateUser(userEntity);
            _repository.Save();

            var userToReturn = _mapper.Map<Models.DataTransferObjects.UserDto>(userEntity);
            return CreatedAtRoute("UserById", new { id = userToReturn.Id }, userToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserForCompany(Guid id, [FromBody]UserForUpdateDto user)
        {
            if(user == null)
            {
                _logger.LogError("UserForUpdateDto object sent from client is null.");
                return BadRequest("UserForUpdateDto object is null");
            }
            var userEntity = _repository.User.GetUser(id, trackChanges: true);
            if(userEntity == null)
            {
                _logger.LogInfo($"User with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(user, userEntity);
            _repository.Save();
            return NoContent();
        }

    }
}
