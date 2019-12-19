using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Business.DomainClasses;

namespace MVC.Controllers
{
    public class TransactionsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Transactions
        /* Index view only provides the customer list view rest is loaded in dynamically using ajax */
        [Authorize(Roles = "Bank Manager")]
        public ActionResult Index(string customerId)
        {
            ViewBag.CustomerNames = new SelectList(db.Customers, "ID", "Name");
            return View();
        }

        /* Partial view for the account names. Loaded into the index page using ajax */
        public PartialViewResult _AccountNames(string customerId)
        {
            int parsedCustomerId = int.Parse(customerId);
            ViewBag.AccountNames = new SelectList(db.Accounts.Where(x => x.CustomerID == parsedCustomerId), "ID", "AccountName");
            return PartialView();
        }

        /* partial view to get transactions. Gives back a table of transactions. Used with ajax */
        public PartialViewResult _GetTransactions(string accountId)
        {
            if (accountId != null)
            {
                int parsedAccountId = int.Parse(accountId);

                var transactions = db.Transactions.Where(x => x.AccountID == parsedAccountId).ToList();
                return PartialView(transactions);
            }
            else
            {
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
