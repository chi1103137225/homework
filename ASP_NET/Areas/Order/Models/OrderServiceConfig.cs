using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ASP_NET.Areas.Order.Models
{
    public class OrderServiceConfig
    {
        public static List<Models.Order> MapOrderDataToList(DataTable orderData)
        {
            List<Models.Order> result = new List<Order>();
            
            foreach (DataRow row in orderData.Rows)
            {
                result.Add(new Order()
                {
                    OrderId = (int)row["OrderId"],
                    CustId = row["CustId"].ToString(),
                    EmpId = (int)row["EmpId"],
                    OrderDate = row["OrderDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["Orderdate"],
                    RequireDdate = row["RequiredDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["RequireDdate"],
                    ShippedDate = row["ShippedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ShippedDate"],
                    CustName = row["CustName"].ToString(),
                    EmpName = row["EmpName"].ToString(),
                    ShipAddress = row["ShipAddress"].ToString(),
                    ShipCity = row["ShipCity"].ToString(),
                    ShipCountry = row["ShipCountry"].ToString(),
                    ShipName = row["ShipName"].ToString(),
                    ShipperId = (int)row["ShipperId"],
                    Freight = (decimal)row["Freight"],
                    ShipperName = row["ShipperName"].ToString(),
                    ShipPostalCode = row["ShipPostalCode"].ToString(),
                    ShipRegion = row["ShipRegion"].ToString()
                });
            }
            return result;
        }
    }
}