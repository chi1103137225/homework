using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ASP_NET.Areas.Order.Models
{
    public class SearchOrderService
    {
        private static string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBconnect"].ConnectionString.ToString();
        }
        /// <summary>
        /// 查詢負責員工(EmpId & EmpName)
        /// </summary>
        /// <returns>List<Models.Order></returns>
        public static List<Models.Order> GetEmployee_Id_Name()
        {
            Models.Order result = new Models.Order();
            DataTable dt = new DataTable();
            string sql = "SELECT EmployeeID As EmpId , LastName + ' ' + FirstName As EmpName FROM HR.Employees";

            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }


            List<Models.Order> result_Order = new List<Order>();

            foreach (DataRow row in dt.Rows)
            {
                result_Order.Add(new Order()
                {
                    EmpId = (int)row["EmpId"],
                    EmpName = row["EmpName"].ToString()
                });
            }
            return result_Order;
        }
        /// <summary>
        /// 查詢出貨公司(ShipperId & ShipperName)
        /// </summary>
        /// <returns>List<Models.Order></returns>
        public static List<Models.Order> GetShipper_Id_Name()
        {
            Models.Order result = new Models.Order();
            DataTable dt = new DataTable();
            string sql = "SELECT ShipperID As ShipperId , CompanyName As ShipperName FROM Sales.Shippers";

            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }


            List<Models.Order> result_Order = new List<Order>();

            foreach (DataRow row in dt.Rows)
            {
                result_Order.Add(new Order()
                {
                    ShipperId = (int)row["ShipperId"],
                    ShipperName = row["ShipperName"].ToString()
                });
            }
            return result_Order;
        }
        public List<Models.Order> GetSearchOrder(string sql)
        {
            Models.Order result = new Models.Order();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }


            List<Models.Order> result_Order = new List<Order>();

            foreach (DataRow row in dt.Rows)
            {
                result_Order.Add(new Order()
                {
                    OrderId = (int)row["OrderId"],
                    CustName = row["CustName"].ToString(),
                    OrderDate = row["OrderDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["Orderdate"],
                    ShippedDate = row["ShippedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ShippedDate"]
                });
            }
            return result_Order;
        }
    }
}