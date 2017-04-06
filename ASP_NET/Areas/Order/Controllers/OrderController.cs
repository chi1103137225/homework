using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET.Areas.Order.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order/Order
        [HttpGet()]
        public ActionResult Index()
        {
                List<SelectListItem> Employee_select = new List<SelectListItem>();
                List<Models.Order> Employee_data = Models.SearchOrderService.GetEmployee_Id_Name();
                Employee_select.Add(new SelectListItem()
                {
                    Text = "",
                    Value = "",
                    Selected= true
                });
                foreach (var item in Employee_data)
                {
                    Employee_select.Add(new SelectListItem()
                    {
                        Text = item.EmpName,
                        Value = item.EmpId.ToString()
                    });
                }
                List<SelectListItem> Shipper_select = new List<SelectListItem>();
                List<Models.Order> Shipper_data = Models.SearchOrderService.GetShipper_Id_Name();
                Shipper_select.Add(new SelectListItem()
                {
                    Text = "",
                    Value = "",
                    Selected = true
                });
                foreach (var item in Shipper_data)
                {
                    Shipper_select.Add(new SelectListItem()
                    {
                        Text = item.ShipperName,
                        Value = item.ShipperId.ToString()
                    });
                }
                ViewBag.Employee_select = Employee_select;
                ViewBag.Shipper_select = Shipper_select;
            return View();
        }

        [HttpGet()]
        public ActionResult Search(String OrderId = "", String CustName = "", String EmpId = "", String ShipperId = "", String OrderDate = "", String ShippedDate = "", String RequireDdate = "")
        {
            Boolean filter = false;
            string sql = @"SELECT salesorder.OrderID As OrderId , customers.CompanyName As CustName ,
                               CONVERT(DATETIME, salesorder.OrderDate, 111) As OrderDate, CONVERT(DATETIME, salesorder.ShippedDate, 111) As ShippedDate
                               FROM Sales.Orders As salesorder
                               INNER JOIN Sales.Customers As customers On salesorder.CustomerID = customers.CustomerID WHERE ";
            if (OrderId != "")
            {
                sql += "salesorder.OrderID = '" + OrderId + "' AND "; filter = true;
            }
            if (CustName != "")
            {
                sql += "customers.CompanyName LIKE '*" + CustName + "*' AND "; filter = true;
            }
            if (EmpId != "")
            {
                sql += "salesorder.EmployeeID = '" + EmpId + "' AND "; filter = true;
            }
            if (ShipperId != "")
            {
                sql += "salesorder.ShipperID = '" + ShipperId + "' AND "; filter = true;
            }
            if (OrderDate != "")
            {
                sql += "CONVERT(CHAR(10), salesorder.OrderDate, 120) = '" + OrderDate + "' AND "; filter = true;
            }
            if (ShippedDate != "")
            {
                sql += "CONVERT(CHAR(10), salesorder.ShippedDate, 120) = '" + ShippedDate + "' AND "; filter = true;
            }
            if (RequireDdate != "")
            {
                sql += "CONVERT(CHAR(10), salesorder.RequireDdate, 120) = '" + RequireDdate + "' AND "; filter = true;
            }

            if (filter)
            {
                sql = sql.Substring(0, sql.Length - 5);
            }
            else
            {
                sql = sql.Substring(0, sql.Length - 7);
            }
            Models.SearchOrderService SearchOrder = new Models.SearchOrderService();
            ViewBag.SearchResult = SearchOrder.GetSearchOrder(sql);
            return View();
        }
    }
}