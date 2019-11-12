using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EktivaBankNetApp.Models;
using EktivaBankNetApp.Models.ViewModel;
using System.Security.Claims;

namespace EktivaBankNetApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly EBADbContext _context;
        #region
        public TransactionsController(EBADbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var custExists = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            List<Transaction> tList = await _context.Transactions.Where(t => t.CustomerId == custExists.Id).ToListAsync();
            return View(tList);
        }

        // GETAll:  Transactions
        public async Task<IActionResult> GetAll(int? Id)
        {
            var tList = await _context.Transactions.Where(t => t.AccFromId == Id || t.AccToId == Id).ToListAsync();

            return View(tList);
        }

        // GETLasts:  Transactions
        public async Task<IActionResult> GetLasts(int? Id)
        {
            int i = 0;
            var tList = await _context.Transactions.Where(t => t.AccFromId == Id || t.AccToId == Id).ToListAsync();
            var Last10 = new List<Transaction>();
            int n = tList.Count;
            while (i <= 9 && i <= n - 1)
            {
                Last10.Add(tList[n - 1 - i]);
                i++;
            }
            return View(Last10);
        }

        public async Task<IActionResult> RangeTrans(int? Id, DateTime tmin, DateTime tmax)
        {
            var tList = await _context.Transactions.Where(t => t.AccFromId == Id || t.AccToId == Id && t.transactionDate >= tmin && t.transactionDate <= tmax).ToListAsync();
            return View(tList);
        }

        public async Task<IActionResult> DislayRangeTrans(List<Transaction> tList)
        {
            //int Id = tList.
            //List of current Customer Account
            //var account = await _context.Accounts.Where(a => a.AccountNumber == currentCust.Id && a.AccountType != "Loan Account" && a.AccountType != "TD Account").ToListAsync();
            //List<Account> AccountList;
            //ViewBag.Accounts = new SelectList(account, "AccountNumber", "Tag");
            return View(tList);
        }



        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }



        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Type,transactionDate")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
        #endregion
        // GET: Transactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Type,transactionDate")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        #region Deposit
        // GET: Transactions/DepositAsyn
        public async Task<IActionResult> DepositAsyn()
        {
            //Current Customer
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var currentCust = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            var depTransaction = new Transaction();
            depTransaction.transactionDate = DateTime.Now;

            //List of current Customer Account
            var account = await _context.Accounts.Where(a => a.CustomerId == currentCust.Id && (a.AccountType != "Loan Account" && a.AccountType != "TD Account")).ToListAsync();
            ViewBag.Accounts = new SelectList(account, "AccountNumber", "Tag");
            depTransaction.CustomerId = currentCust.Id;

            return View(depTransaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DepositAsyn(Transaction depTransaction)
        {
            //Current Customer
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var currentCust = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            var acc = await _context.Accounts.ToListAsync();
            var currentAcc = acc.Where(a => a.AccountNumber == depTransaction.AccToId).SingleOrDefault();

            depTransaction.Type = "Deposit";
            depTransaction.CustomerId = currentCust.Id;

            //Deposit
            depTransaction.BalBefore = currentAcc.Balance;
            currentAcc.Balance += depTransaction.Amount;
            depTransaction.BalAfter = currentAcc.Balance;

            currentAcc.Tag = currentAcc.AccountType + " - " + currentAcc.AccountNumber + " --> $" + currentAcc.Balance;



            if (ModelState.IsValid)
            {
                _context.Update(currentAcc);
                await _context.SaveChangesAsync();

                _context.Add(depTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(depTransaction);
        }
        #endregion

        #region Withdraw
        public async Task<IActionResult> WithdrawAsyn()
        {
            //Current Customer
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var currentCust = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            var depTransaction = new Transaction();
            depTransaction.transactionDate = DateTime.Now;

            //List of current Customer Account
            var account = await _context.Accounts.Where(a => a.CustomerId == currentCust.Id && a.AccountType != "Loan Account").ToListAsync();
            //List<Account> AccountList;
            ViewBag.Accounts = new SelectList(account, "AccountNumber", "Tag");
            depTransaction.CustomerId = currentCust.Id;

            return View(depTransaction);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WithdrawAsyn(Transaction depTransaction)
        {
            //Current Customer
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var currentCust = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            depTransaction.Type = "Withdraw";

            depTransaction.CustomerId = currentCust.Id;
            var acc = await _context.Accounts.ToListAsync();
            var currentAcc = acc.Where(a => a.AccountNumber == depTransaction.AccFromId).SingleOrDefault();

            #region Define the withdraw according to the account Type
            if (currentAcc.AccountType == "Business Account")
            {
                if (currentAcc.Balance < depTransaction.Amount)
                {
                    //currentAcc.Balance -= depTransaction.Amount;
                    //Withdraw
                    depTransaction.BalBefore = currentAcc.Balance;
                    currentAcc.Balance = -((depTransaction.Amount - currentAcc.Balance) * 1.05);
                    depTransaction.BalAfter = currentAcc.Balance;
                }
                else
                {
                    //Withdraw
                    depTransaction.BalBefore = currentAcc.Balance;
                    currentAcc.Balance -= depTransaction.Amount;
                    depTransaction.BalAfter = currentAcc.Balance;
                }
            } else if (currentAcc.AccountType == "Checking Account")
            {
                if (currentAcc.Balance < depTransaction.Amount)
                {
                    return RedirectToAction("TransactionFail");
                }
                else
                {
                    //Withdraw
                    depTransaction.BalBefore = currentAcc.Balance;
                    currentAcc.Balance -= depTransaction.Amount;
                    depTransaction.BalAfter = currentAcc.Balance;
                }
            }
            else if (currentAcc.AccountType == "TD Account")
            {
                if (currentAcc.Balance < depTransaction.Amount)
                {
                    return RedirectToAction("TransactionFail");
                }
                else
                {
                    if (DateTime.Now.Year - depTransaction.transactionDate.Year < currentAcc.yearTerm)
                    {
                        return RedirectToAction("TransactionFail");
                    }
                    //Withdraw
                    depTransaction.BalBefore = currentAcc.Balance;
                    currentAcc.Balance -= depTransaction.Amount;
                    depTransaction.BalAfter = currentAcc.Balance;
                }
            }
            #endregion

            currentAcc.Tag = currentAcc.AccountType + " - " + currentAcc.AccountNumber + " --> $" + currentAcc.Balance;

            if (ModelState.IsValid)
            {
                _context.Update(currentAcc);
                await _context.SaveChangesAsync();

                _context.Add(depTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(depTransaction);
        }
        #endregion

        #region Transfer
        public async Task<IActionResult> Transfer()
        {
            //Current Customer
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var currentCust = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            var depTransaction = new Transaction();
            depTransaction.transactionDate = DateTime.Now;

            //List of current Customer Account
            var account = await _context.Accounts.Where(a => a.CustomerId == currentCust.Id && a.AccountType != "Loan Account" && a.AccountType != "TD Account").ToListAsync();
            //List<Account> AccountList;
            ViewBag.Accounts = new SelectList(account, "AccountNumber", "Tag");
            depTransaction.CustomerId = currentCust.Id;

            return View(depTransaction);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer(Transaction Transaction)
        {
            Transaction TransactionFrom = new Transaction();
            Transaction TransactionTo = new Transaction();
            //Current Customer
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var currentCust = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            TransactionFrom.Type = "Transfer To " + Transaction.AccToId;
            TransactionTo.Type = "Transfer From " + Transaction.AccFromId;

            TransactionFrom.CustomerId = currentCust.Id;
            TransactionTo.CustomerId = currentCust.Id;

            TransactionFrom.AccFromId = Transaction.AccFromId;
            TransactionFrom.AccToId = 0;

            TransactionTo.AccFromId = 0;
            TransactionTo.AccToId = Transaction.AccToId;

            TransactionFrom.Amount = Transaction.Amount;
            TransactionTo.Amount = Transaction.Amount;

            var acc = await _context.Accounts.ToListAsync();
            var AccFrom = acc.Where(a => a.AccountNumber == Transaction.AccFromId).SingleOrDefault();
            var AccTo = acc.Where(a => a.AccountNumber == Transaction.AccToId).SingleOrDefault();
            if (AccFrom == AccTo)
            {
                return RedirectToAction("TransactionFail");
            } else
            {
                #region Make the Transfer 
                if (AccFrom.AccountType == "Business Account")
                {
                    if (AccFrom.Balance < Transaction.Amount)
                    {
                        //Withdraw  into Account From
                        TransactionFrom.BalBefore = AccFrom.Balance;
                        AccFrom.Balance = -((Transaction.Amount - AccFrom.Balance) * 1.05);
                        TransactionFrom.BalAfter = AccFrom.Balance;

                        //Deposit into Account To
                        TransactionTo.BalBefore = AccTo.Balance;
                        AccTo.Balance += Transaction.Amount;
                        TransactionTo.BalAfter = AccTo.Balance;
                    }
                    else
                    {
                        //Withdraw into Account From
                        TransactionFrom.BalBefore = AccFrom.Balance;
                        AccFrom.Balance -= Transaction.Amount;
                        TransactionFrom.BalAfter = AccFrom.Balance;

                        //Deposit into Account To
                        TransactionTo.BalBefore = AccTo.Balance;
                        AccTo.Balance += Transaction.Amount;
                        TransactionTo.BalAfter = AccTo.Balance;
                    }
                }
                else if (AccFrom.AccountType == "Checking Account")
                {
                    if (AccFrom.Balance < Transaction.Amount)
                    {
                        return RedirectToAction("TransactionFail");
                    }
                    else
                    {
                        //Withdraw into Account From
                        TransactionFrom.BalBefore = AccFrom.Balance;
                        AccFrom.Balance -= Transaction.Amount;
                        TransactionFrom.BalAfter = AccFrom.Balance;

                        //Deposit into Account To
                        TransactionTo.BalBefore = AccTo.Balance;
                        AccTo.Balance += Transaction.Amount;
                        TransactionTo.BalAfter = AccTo.Balance;
                    }
                }
                else if (AccFrom.AccountType == "TD Account")
                {
                    if (AccFrom.Balance < Transaction.Amount)
                    {
                        return RedirectToAction("TransactionFail");
                    }
                    else
                    {
                        if (DateTime.Now.Year - Transaction.transactionDate.Year < AccFrom.yearTerm)
                        {
                            return RedirectToAction("TransactionFail");
                        }
                        //Withdraw into Account From
                        TransactionFrom.BalBefore = AccFrom.Balance;
                        AccFrom.Balance -= Transaction.Amount;
                        TransactionFrom.BalAfter = AccFrom.Balance;

                        //Deposit into Account To
                        TransactionTo.BalBefore = AccTo.Balance;
                        AccTo.Balance += Transaction.Amount;
                        TransactionTo.BalAfter = AccTo.Balance;
                    }
                }
                #endregion
            }


            AccFrom.Tag = AccFrom.AccountType + " - " + AccFrom.AccountNumber + " --> $" + AccFrom.Balance;
            AccTo.Tag = AccTo.AccountType + " - " + AccTo.AccountNumber + " --> $" + AccTo.Balance;

            if (ModelState.IsValid)
            {
                _context.Update(AccFrom);
                await _context.SaveChangesAsync();

                _context.Update(AccTo);
                await _context.SaveChangesAsync();

                _context.Add(TransactionFrom);
                await _context.SaveChangesAsync();

                _context.Add(TransactionTo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View();
        }
        #endregion

        #region Pay Loan

        public async Task<IActionResult> PayLoan()
        {
            //Current Customer
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var currentCust = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            var depTransaction = new Transaction();
            depTransaction.transactionDate = DateTime.Now;

            //List of current Customer Account
            var account = await _context.Accounts.Where(a => a.CustomerId == currentCust.Id).ToListAsync();
            //List<Account> AccountList;
            ViewBag.Accounts = new SelectList(account, "AccountNumber", "Tag");
            //ViewBag.AccToId = AccToNumber;
            depTransaction.CustomerId = currentCust.Id;
            return View(depTransaction);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayLoan(Transaction Transaction)
        {
            Transaction TransactionFrom = new Transaction();
            Transaction LoanTo = new Transaction();

            //Current Customer
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cust = await _context.Customers.ToListAsync();
            var currentCust = cust.Where(c => c.RegistrationId == userId).SingleOrDefault();

            LoanTo.Type = "Payment From " + Transaction.AccFromId;
            TransactionFrom.Type = "Loan " + Transaction.AccToId + " Payment";

            TransactionFrom.CustomerId = currentCust.Id;
            LoanTo.CustomerId = currentCust.Id;

            TransactionFrom.AccFromId = Transaction.AccFromId;
            TransactionFrom.AccToId = 0;

            LoanTo.AccFromId = 0;
            LoanTo.AccToId = Transaction.AccToId;

            TransactionFrom.Amount = Transaction.Amount;
            LoanTo.Amount = Transaction.Amount;

            var acc = await _context.Accounts.ToListAsync();
            var AccFrom = acc.Where(a => a.AccountNumber == Transaction.AccFromId).SingleOrDefault();
            var AccTo = acc.Where(a => a.AccountNumber == Transaction.AccToId).SingleOrDefault();

            if (Transaction.Amount > AccFrom.Balance || Transaction.Amount > AccTo.Balance)
            {
                return RedirectToAction("TransactionFail");
            }
            if (AccTo.AccountType != "Loan Account" || AccFrom == AccTo || AccFrom.AccountType == "Loan Account" || AccFrom.AccountType == "TD Account")
            {
                return RedirectToAction("TransactionFail");
            } else 
            {
                //Withdraw into Account From
                TransactionFrom.BalBefore = AccFrom.Balance;
                AccFrom.Balance -= Transaction.Amount;
                TransactionFrom.BalAfter = AccFrom.Balance;

                //Deposit into Account To
                LoanTo.BalBefore = AccTo.Balance;
                AccTo.Balance += Transaction.Amount;
                LoanTo.BalAfter = AccTo.Balance;
            }

            AccFrom.Tag = AccFrom.AccountType + " - " + AccFrom.AccountNumber + " --> $" + AccFrom.Balance;
            AccTo.Tag = AccTo.AccountType + " - " + AccTo.AccountNumber + " --> $" + AccTo.Balance;

            if (ModelState.IsValid)
            {
                _context.Update(AccFrom);
                await _context.SaveChangesAsync();

                _context.Update(AccTo);
                await _context.SaveChangesAsync();

                _context.Add(TransactionFrom);
                await _context.SaveChangesAsync();

                _context.Add(LoanTo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View();
     }
        #endregion
        public IActionResult TransactionFail()
        {
            return View();
        }
    }
}
