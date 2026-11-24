using LoanApi.Data;
using LoanApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    private readonly LoanDbContext _db;

    public LoansController(LoanDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Loan>>> GetAll()
    {
        return await _db.Loans.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Loan>> GetById(int id)
    {
        var loan = await _db.Loans.FindAsync(id);
        if (loan == null) return NotFound();
        return loan;
    }

    [HttpPost]
    public async Task<ActionResult<Loan>> Create(Loan loan)
    {
        loan.MonthlyPayment = CalculatePayment(loan.Amount, loan.InterestRate, loan.Months);
        _db.Loans.Add(loan);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loan);
    }

    private static decimal CalculatePayment(decimal amount, decimal annualRate, int months)
    {
        if (months <= 0) return 0;
        double r = (double)annualRate / 100.0 / 12.0;
        if (r == 0) return Math.Round(amount / months, 2);
        double factor = Math.Pow(1 + r, months);
        return Math.Round(amount * (decimal)(r * factor / (factor - 1)), 2);
    }
}