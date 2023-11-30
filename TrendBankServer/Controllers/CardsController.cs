using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using TrendBankServer.Models.DataTransferObjects;
using TrendBankServer.Repository;

namespace TrendBankServer.Controllers
{
    [Route("api/users/{userId}/cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CardsController(IRepositoryManager repository, ILoggerManager logger,
       IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetcCardsForUser(Guid userId)
        {
            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {userId} doesn't exist in the database.");
            return NotFound();
            }
            var cardsFromDb = _repository.Card.GetCards(userId, trackChanges: false);
            var cardsDto = _mapper.Map<IEnumerable<CardDto>>(cardsFromDb);
            return Ok(cardsDto);
        }

        [HttpGet("{id}", Name = "GetCardForUser")]
        public IActionResult GetCardForUser(Guid userId, Guid id)
        {
            var user = _repository.User.GetUser(userId, trackChanges: false);
            if(user == null)
            {
                _logger.LogInfo($"User with id: {userId} doesn't exist in the database.");
                return NotFound();
            }

            var cardDb = _repository.Card.GetCard(userId, id, trackChanges: false);
            if(cardDb == null)
            {
                _logger.LogInfo($"Card with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var card = _mapper.Map<CardDto>(cardDb);
            return Ok(card);
        }

        [HttpPost]
        public IActionResult CreateCardForUser(Guid userId, [FromBody]CardForCreationDto card)
        {
            if(card == null)
            {
                _logger.LogError("CardForCreationDto object sent from client is null.");
                return BadRequest("CardForCreationDto object is null");
            }

            var user = _repository.User.GetUser(userId, trackChanges: false);
            if(user == null)
            {
                _logger.LogInfo($"User with id: {userId} doesn't exist in the database.");
                return NotFound();
            }

            var cardEntity = _mapper.Map<Models.Card>(card);
            _repository.Card.CreateCardForUser(userId, cardEntity);
            _repository.Save();
            var cardToReturn = _mapper.Map<CardDto>(cardEntity);
            return CreatedAtRoute("GetCardForUser", new { userId, id = cardToReturn.Id}, cardToReturn);

        }
    }

}
