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
            Models.orderService orderService = new Models.orderService();
            var order = orderService.GetOrderById("111");
            ViewBag.CustId = order.CustId;
            ViewBag.CustName = order.CustName;
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
            Models.orderService orderService = new Models.orderService();
            orderService.InsertOrder(order);
            return View("Index");
        }
    }
}
