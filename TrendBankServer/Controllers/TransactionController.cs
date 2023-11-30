using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TrendBankServer.Models;
using TrendBankServer.Models.DataTransferObjects;
using TrendBankServer.Repository;

namespace TrendBankServer.Controllers
{
        [Route("api/users/{userId}/cards/{cardId}/transactions")]
        [ApiController]
        public class TransactionsController : ControllerBase
        {
            private readonly IRepositoryManager _repository;
            private readonly ILoggerManager _logger;
            private readonly IMapper _mapper;
            public TransactionsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
            {
                _repository = repository;
                _logger = logger;
                _mapper = mapper;
            }

        [HttpGet]
        public IActionResult GetTransactionsForCard(Guid userId, Guid cardId, bool trackChanges)
        {
            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {userId} doesn't exist in the database.");
                return NotFound();
            }

            var card = _repository.Card.GetCard(userId, cardId, trackChanges: false);
            if (card == null)
            {
                _logger.LogInfo($"Card with id: {cardId} doesn't exist in the database.");
                return NotFound();
            }
            var transactionsFromDb = _repository.Transaction.GetTransactions(cardId, trackChanges: false);
            var transactionsDto = _mapper.Map<IEnumerable<TransactionDto>>(transactionsFromDb);
            return Ok(transactionsDto);
        }

        [HttpGet("{id}", Name = "GetTransactionForCard")]
        public IActionResult GetTransactionForCard(Guid userId, Guid cardId, Guid id, bool trackChanges)
        {
            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {userId} doesn't exist in the database.");
                return NotFound();
            }

            var card = _repository.Card.GetCard(userId, cardId, trackChanges: false);
            if (card == null)
            {
                _logger.LogInfo($"Card with id: {cardId} doesn't exist in the database.");
                return NotFound();
            }

            var transactionDb = _repository.Transaction.GetTransaction(cardId, id, trackChanges: false);
            if (transactionDb == null)
            {
                _logger.LogInfo($"Transaction with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var transactionDto = _mapper.Map<TransactionDto>(transactionDb);
            return Ok(transactionDto);
        }

        //перевірити чи кардту існує
        [HttpPost]
        public IActionResult CreateTransactionForCard(Guid userId, Guid cardId, [FromBody] TransactionForCreationDto transaction)
        {
            if (transaction == null)
            {
                _logger.LogError("TransactionForCreationDto object sent from client is null.");
                return BadRequest("TransactionForCreationDto object is null");
            }

            var card = _repository.Card.GetCardForAll(transaction.CardToId, trackChanges: false);
            if (card == null)
            {
                _logger.LogInfo($"Card with id: {transaction.CardToId} doesn't exist in the database.");
                return NotFound();
            }

            var user = _repository.User.GetUser(userId, trackChanges: false);
            if (user == null)
            {
                _logger.LogInfo($"User with id: {userId} doesn't exist in the database.");
                return NotFound();
            }

            var card2 = _repository.Card.GetCard(userId, cardId, trackChanges: false);
            if (card2 == null)
            {
                _logger.LogInfo($"Card with id: {cardId} doesn't exist in the database.");
                return NotFound();
            }

            var transactionEntity = _mapper.Map<Models.Transaction>(transaction);
            _repository.Transaction.CreateTransactionForCard(cardId, transactionEntity);
            _repository.Save();
            var transactionToReturn = _mapper.Map<TransactionDto>(transactionEntity);
            return CreatedAtRoute("GetTransactionForCard", new { userId, cardId, id = transactionToReturn.Id }, transactionToReturn);

        }
    }
}
