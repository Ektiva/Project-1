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
    public class TransactionRangesController : Controller
    {
        private readonly EBADbContext _context;

        public TransactionRangesController(EBADbContext context)
        {
            _context = context;
        }


        public IActionResult GetRangeTrans(int? Id)
        {
            TransactionRange trRange = new TransactionRange();
            trRange.AccountNumber = Convert.ToInt32(Id);
            trRange.transactionFrom = DateTime.Now;
            trRange.transactionTo = DateTime.Now;
            return View(trRange);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetRangeTrans([Bind("Id,AccountNumber,transactionFrom,transactionTo")] TransactionRange transactionRange)
        {
            var trList = await _context.Transactions.Where(t => (t.AccFromId == transactionRange.AccountNumber || t.AccToId == transactionRange.AccountNumber) && (t.transactionDate >= transactionRange.transactionFrom && t.transactionDate <= transactionRange.transactionTo)).ToListAsync();
    
            return View("Views/Transactions/DislayRangeTrans.cshtml",  trList);
        }

    }
}
