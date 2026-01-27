using FluentValidation;
using LoanSystem.Application.DTOs;
using LoanSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;
        private readonly IValidator<CreateLoanRequest> _validator;

        public LoansController(ILoanService loanService, IValidator<CreateLoanRequest> validator)
        {
            _loanService = loanService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<LoanDto>> CreateLoan([FromBody] CreateLoanRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var loanDto = await _loanService.CreateLoanAsync(request);
            return CreatedAtAction(nameof(CreateLoan), loanDto);
        }
    }
}
