using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data.Sql;
namespace lmstask
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CreditScore { get; set; }

        public Customer() { }
        public Customer(int id, string name, string email, string phone, string address, int creditScore)
        {
            CustomerID = id; Name = name; EmailAddress = email;
            PhoneNumber = phone; Address = address; CreditScore = creditScore;
        }

        public void PrintInfo() { 
            Console.WriteLine($"ID:{CustomerID}, Name:{Name}, Email:{EmailAddress}, Phone:{PhoneNumber}, Address:{Address}, Score:{CreditScore}");
    }

    public class Loan
    {
        public int LoanId { get; set; }
        public Customer Customer { get; set; }
        public double PrincipalAmount { get; set; }
        public double InterestRate { get; set; }
        public int LoanTerm { get; set; }
        public string LoanType { get; set; }
        public string LoanStatus { get; set; }

        public Loan() { }
        public Loan(int id, Customer cust, double amount, double rate, int term, string type, string status)
        {
            LoanId = id; 
            Customer = cust; 
            PrincipalAmount = amount;
            InterestRate = rate;
            LoanTerm = term; 
            LoanType = type;
            LoanStatus = status;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"LoanID:{LoanId}, Type:{LoanType}, Status:{LoanStatus}, Amount:{PrincipalAmount}, Rate:{InterestRate}, Term:{LoanTerm}");
            Customer.PrintInfo();
        }
    }

    public class HomeLoan : Loan
    {
        public string PropertyAddress { get; set; }
        public int PropertyValue { get; set; }

        public HomeLoan() { }
        public HomeLoan(int id, Customer cust, double amount, double rate, int term, string status, string address, int value)
            : base(id, cust, amount, rate, term, "HomeLoan", status)
        {
            PropertyAddress = address; 
            PropertyValue = value;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Property Address: {PropertyAddress}, Value: {PropertyValue}");
        }
    }

    public class CarLoan : Loan
    {
        public string CarModel { get; set; }
        public int CarValue { get; set; }

        public CarLoan() { }
        public CarLoan(int id, Customer cust, double amount, double rate, int term, string status, string model, int value)
            : base(id, cust, amount, rate, term, "CarLoan", status)
        {
            CarModel = model; 
            CarValue = value;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Car Model: {CarModel}, Value: {CarValue}");
        }
    }

    public class InvalidLoanException : Exception
    {
        public InvalidLoanException(string message) : base(message) { }
    }

    public static class DBUtil
    {
        public static SqlConnection GetDBConn()
        {
            return new SqlConnection("data source=DESKTOP-M8CA3K9\\SQLEXPRESS;initial catalog=loanmanagementsystem;integrated security=true;");
        }
    }

    public interface ILoanRepository
    {
        void ApplyLoan(Loan loan);
        double CalculateInterest(int loanId);
        double CalculateInterest(double amount, double rate, int term);
        void LoanStatus(int loanId);
        double CalculateEMI(int loanId);
        double CalculateEMI(double principal, double rate, int term);
        void LoanRepayment(int loanId, double amount);
        List<Loan> GetAllLoan();
        Loan GetLoanById(int loanId);
    }

    public class LoanRepositoryImpl : ILoanRepository
    {
        public void ApplyLoan(Loan loan)
        {
            Console.Write("Confirm loan application? (Yes/No): ");
            if (Console.ReadLine().ToLower() != "yes") return;

            using var conn = DBUtil.GetDBConn();
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO loan VALUES (@id, @cust, @amount, @rate, @term, @type, 'Pending')", conn);
            cmd.Parameters.AddWithValue("@id", loan.LoanId);
            cmd.Parameters.AddWithValue("@cust", loan.Customer.CustomerID);
            cmd.Parameters.AddWithValue("@amount", loan.PrincipalAmount);
            cmd.Parameters.AddWithValue("@rate", loan.InterestRate);
            cmd.Parameters.AddWithValue("@term", loan.LoanTerm);
            cmd.Parameters.AddWithValue("@type", loan.LoanType);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Loan applied successfully.");
        }

        public double CalculateInterest(int loanId)
        {
            var loan = GetLoanById(loanId);
            return CalculateInterest(loan.PrincipalAmount, loan.InterestRate, loan.LoanTerm);
        }

        public double CalculateInterest(double amount, double rate, int term)
        {
            return (amount * rate * term) / 12;
        }

        public void LoanStatus(int loanId)
        {
            try
            {
                using var conn = DBUtil.GetDBConn();
                conn.Open();

                string selectQuery = @"
                    SELECT c.creditscore 
                    FROM loan l 
                    JOIN customer c ON l.customerid = c.customerid 
                    WHERE l.loanid = @loanId";

                int creditScore = 0;
                using (var selectCmd = new SqlCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@loanId", loanId);
                    var result = selectCmd.ExecuteScalar();
                    if (result == null)
                        throw new InvalidLoanException("Loan not found.");

                    creditScore = Convert.ToInt32(result);
                }

                string status = creditScore > 650 ? "Approved" : "Rejected";
                Console.WriteLine($"Loan {loanId} is {status} based on credit score: {creditScore}");

                string updateQuery = "UPDATE loan SET loanstatus = @status WHERE loanid = @loanId";
                using (var updateCmd = new SqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@status", status);
                    updateCmd.Parameters.AddWithValue("@loanId", loanId);
                    updateCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while checking loan status: " + ex.Message);
            }
        }

        public double CalculateEMI(int loanId)
        {
            var loan = GetLoanById(loanId);
            return CalculateEMI(loan.PrincipalAmount, loan.InterestRate, loan.LoanTerm);
        }

        public double CalculateEMI(double P, double annualRate, int N)
        {
            double R = annualRate / 12 / 100;
            return (P * R * Math.Pow(1 + R, N)) / (Math.Pow(1 + R, N) - 1);
        }

        public void LoanRepayment(int loanId, double amount)
        {
            var emi = CalculateEMI(loanId);
            if (amount < emi)
            {
                Console.WriteLine("Amount too low for even one EMI.");
                return;
            }
            int count = (int)(amount / emi);
            Console.WriteLine($"{count} EMI(s) paid.");
        }
        public List<Loan> GetAllLoan()
        {
            return new List<Loan>(); 
        }

        public Loan GetLoanById(int loanId)
        {
            if (loanId <= 0) throw new InvalidLoanException("Loan not found.");

            return new Loan
            {
                LoanId = loanId,
                Customer = new Customer(1, "John", "john@mail.com", "1234567896", "Coimbatore", 700),
                PrincipalAmount = 100000,
                InterestRate = 7.5,
                LoanTerm = 12,
                LoanType = "HomeLoan",
                LoanStatus = "Pending"
            };
        }
    }
    class LoanManagement
    {
        static void Main()
        {
            ILoanRepository repo = new LoanRepositoryImpl();

            while (true)
            {
                Console.WriteLine("\n1. Apply Loan\n2. Get All Loans\n3. Get Loan By ID\n4. Loan Repayment\n5. Loan Status\n6. Exit");
                Console.Write("Choose: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var cust = new Customer(1, "Keerthana", "keerth@egmail.com", "987654321", "Erode", 720);
                        var loan = new HomeLoan(101, cust, 500000, 6.5, 24, "Pending", "123 Street", 800000);
                        repo.ApplyLoan(loan);
                        break;
                    case "2":
                        var all = repo.GetAllLoan();
                        foreach (var l in all) l.PrintInfo();
                        break;
                    case "3":
                        Console.Write("Enter Loan ID: ");
                        int id = int.Parse(Console.ReadLine());
                        try { repo.GetLoanById(id).PrintInfo(); }
                        catch (InvalidLoanException e) { Console.WriteLine(e.Message); }
                        break;
                    case "4":
                        Console.Write("Enter Loan ID and Amount: ");
                        var parts = Console.ReadLine().Split();
                        repo.LoanRepayment(int.Parse(parts[0]), double.Parse(parts[1]));
                        break;
                    case "5":
                        Console.Write("Enter Loan ID: ");
                        int lid = int.Parse(Console.ReadLine());
                        repo.LoanStatus(lid);
                        break;
                    case "6":
                        return;
                }
            }
        }
    }
}
