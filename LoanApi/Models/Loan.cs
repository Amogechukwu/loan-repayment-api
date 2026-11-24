namespace LoanApi.Models;

public class Loan
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = "";
    public decimal Amount { get; set; }
    public decimal InterestRate { get; set; }
    public int Months { get; set; }
    public decimal MonthlyPayment { get; set; }
}