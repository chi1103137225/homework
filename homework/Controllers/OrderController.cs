using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            List<SelectListItem> custData = new List<SelectListItem>();
            custData.Add(new SelectListItem()
            {
                Text="叡揚資訊",
                Value = "1"
            });

            custData.Add(new SelectListItem()
            {
                Text = "網軟資訊",
                Value = "2"
            });
            ViewBag.custData = custData;
            return View();
        }

        public ActionResult Index2(string id)
        {
            ViewBag.id = id;
            return View();
        }
        /// <summary>
        /// 新增訂單畫面
        /// </summary>
        /// <returns></returns>
        public ActionResult Insertorder()
        {
            Models.Order order = new Models.Order();
            order.CustName = "叡揚資訊";
            return View();
        }

        /// <summary>
        /// 新增訂單存檔的Action
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult InsertOrder(Models.Order order)
        {
            ViewBag.Desc1 = "我是ViewBag";
            ViewData["Desc2"] = "我是ViewData";
            TempData["Desc3"] = "我是TempData";
            return RedirectToAction("Index");
        }

        [HttpGet()]
        public JsonResult TestJson()
        {
            //var result = new Models.Order();
            //result.CustId = "GSS";
            //result.CustName = "叡揚資訊";

            var result = new Models.Order() { CustId = "GSS", CustName = "叡揚資訊" };
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
