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
            var transactionsDto = _mapper.Map<IEnumerable<CardDto>>(transactionsFromDb);
            return Ok(transactionsDto);
        }

        [HttpGet]
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

            var transactionFromDb = _repository.Transaction.GetTransactions(cardId, trackChanges: false);
            var transactionDto = _mapper.Map<IEnumerable<CardDto>>(transactionFromDb);
            return Ok(transactionDto);
        }
    }
}
