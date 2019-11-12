using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EktivaBankNetApp.Data;
using EktivaBankNetApp.Models;
using System.Security.Claims;
using EktivaBankNetApp.Models.ViewModel;

namespace EktivaBankNetApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly EBADbContext _context;
        public Random random = new Random();

        public AccountsController(EBADbContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var custExists = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            return View(await _context.Accounts.Where(a => a.CustomerId == custExists.Id).ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        public async Task<IActionResult> FailClosure()
        {
            return View();
        }
        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account.Balance > 0)
            {
                return RedirectToAction(nameof(FailClosure));
            }
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }

        // GET: Accounts/CreateChecking
        public IActionResult CreateChecking1()
        {
            Account account = new Account();
            account.openDate = DateTime.Now;
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChecking1([Bind("Balance,Id,CustomerId,AccountType,yearTerm,openDate,interestRate")] Account account)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var custExists = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();
            account.CustomerId = custExists.Id;
            account.AccountType = "Checking Account";
            account.interestRate = 2.5;
            account.yearTerm = 0;
            custExists.NumberOfAccount++;

            account.AccountNumber = random.Next(1000, 9999);

            //account.Tag = "Checking Account - " + account.Id + " --> $" + account.Balance;
            if (ModelState.IsValid)
            {
                account.Tag = "Checking Account - " + account.AccountNumber + " --> $" + account.Balance;
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/CreateChecking
        public IActionResult CreateBusiness()
        {
            Account account = new Account();
            account.openDate = DateTime.Now;
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBusiness([Bind("Balance,Id,CustomerId,AccountType,yearTerm,openDate")] Account account)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var custExists = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            account.CustomerId = custExists.Id;
            account.AccountType = "Business Account";
            account.yearTerm = 0;
            custExists.NumberOfAccount++;
            account.AccountNumber = random.Next(1000, 9999);

            if (ModelState.IsValid)
            {
                account.Tag = "Business Account - " + account.AccountNumber + " --> $" + account.Balance;
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        public IActionResult CreateLoan()
        {
            Account account = new Account();
            account.openDate = DateTime.Now;
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLoan([Bind("Balance,Id,CustomerId,AccountType,yearTerm,openDate,interestRate")] Account account)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var custExists = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();
            account.CustomerId = custExists.Id;
            account.AccountType = "Loan Account";
            custExists.NumberOfAccount++;
            
            if (account.yearTerm <= 5)
            {
                account.interestRate = 2;
            }
            else
            {
                account.interestRate = 5;
            }
            account.Balance += (account.Balance * account.interestRate)/100;
            account.AccountNumber = random.Next(1000, 9999);
            account.Tag = "Loan Account - " + account.AccountNumber + " --> $" + account.Balance;
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        public IActionResult CreateTD()
        {
            Account account = new Account();
            account.openDate = DateTime.Now;
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTD([Bind("Balance,Id,CustomerId,AccountType,yearTerm,openDate,interestRate")] Account account)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var custExists = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();
            account.CustomerId = custExists.Id;
            account.AccountType = "TD Account";
            custExists.NumberOfAccount++;

            account.AccountNumber = random.Next(1000, 9999);
            account.Tag = "TD Account - " + account.AccountNumber + " --> $" + account.Balance;
            if (account.yearTerm <= 5)
            {
                account.interestRate = 2;
            }
            else
            {
                account.interestRate = 5;
            }
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(account);
        }
    }
}
