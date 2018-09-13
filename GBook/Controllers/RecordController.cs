using BotDetect.Web.UI.Mvc;
using GBook.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace GBook.Controllers
{
    public class RecordController : Controller
    {
        private DBContext db = new DBContext();
        public int PageSize = 25;

        public ActionResult Index(int page = 1, string column = "Created", bool descending = true)
        {
            IEnumerable<Record> query = db.Records;

            switch (column)
            {
                case "Created":
                    if (descending)
                    {
                        query = query.OrderByDescending(x => x.Created);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.Created);
                    }

                    break;

                case "UserName":
                    if (descending)
                    {
                        query = query.OrderByDescending(x => x.UserName);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.UserName);
                    }

                    break;

                case "EMail":
                    if (descending)
                    {
                        query = query.OrderByDescending(x => x.EMail);
                    }
                    else
                    {
                        query = query.OrderBy(x => x.EMail);
                    }

                    break;

                default:
                    query = query.OrderByDescending(x => x.Created);
                    break;

            };


            query = query.Skip((page - 1) * PageSize).Take(PageSize);

            RecordsListViewModel model = new RecordsListViewModel
            {
                Records = query,

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = db.Records.Count()
                },

                SortingInfo = new SortingInfo
                {
                    Column = column,
                    Descending = descending
                }
            };

            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "SampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult Create([Bind(Include = "UserName, EMail, Homepage, Text")] Record record)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    record.Browser = this.Request.Browser.Browser;
                    record.IP = this.Request.UserHostAddress;
                    record.Created = System.DateTime.Now;
                    db.Records.Add(record);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save the changes. Try again and if the problem persists, contact your system administrator.");
            }

            return View(record);
        }
    }
}