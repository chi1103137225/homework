using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace homework.Models
{
    /// <summary>
    /// 訂單服務
    /// </summary>
    public class orderService
    {
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString.ToString();
        }
        /// <summary>
        /// 新增訂單
        /// </summary>
        public void InsertOrder(Models.Order order)
        {

        }
        /// <summary>
        /// 刪除訂單By Id
        /// </summary>
        public void DeleteOrderById()
        {

        }
        /// <summary>
        /// 更新訂單
        /// </summary>
        public void UpdateOrder()
        {

        }
        /// <summary>
        /// 取得訂單
        /// </summary>
        /// <param name="id">訂單ID</param>
        /// <returns></returns>
        public List<Models.Order> GetOrderById(string orderId)
        {
            Models.Order result = new Models.Order();
            DataTable dt = new DataTable();
            string sql = @"SELECT 
					A.OrderID As OrderId,A.CustomerID As CustId,B.Companyname As CustName,
					A.EmployeeID As EmpId,C.LastName+ C.FirstName As EmpName,
					A.OrderDate As OrderDate,A.RequiredDate As RequiredDate,A.ShippedDate As ShippedDate,
					A.ShipperID As ShipperId,D.CompanyName As ShipperName,A.Freight As Freight,
					A.ShipName As ShipName,A.ShipAddress As ShipAddress,A.ShipCity As ShipCity,A.ShipRegion As ShipRegion,A.ShipPostalCode As ShipPostalCode,A.ShipCountry As ShipCountry
					From Sales.Orders As A 
					INNER JOIN Sales.Customers As B ON A.CustomerID=B.CustomerID
					INNER JOIN HR.Employees As C On A.EmployeeID=C.EmployeeID
					inner JOIN Sales.Shippers As D ON A.ShipperID=D.ShipperID
					Where  A.OrderID=@OrderId";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@OrderId", orderId));

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapOrderDataToList(dt);
        }
        /// <summary>
        /// 取得訂單
        /// </summary>
        /// <returns></returns>
        public List<Models.Order> GetOrders()
        {
            List<Order> result = new List<Order>() ;
            result.Add(new Order() { CustId = "GSS", CustName = "叡揚資訊",EmpId = 1,EmpName="王小明",Orderdate=DateTime.Parse("2015/11/08") });
            result.Add(new Order() { CustId = "NPOIS", CustName = "網軟資訊",EmpId = 1,EmpName="王小華",Orderdate=DateTime.Parse("2015/11/01") });
            return result;
        }
    private List<Models.Order> MapOrderDataToList(DataTable orderData)
    {
        List<Models.Order> result = new List<Order>();


        foreach (DataRow row in orderData.Rows)
        {
            result.Add(new Order()
            {
                OrderId = (int)row["OrderId"],
                CustId = row["CustId"].ToString(),
                EmpId = (int)row["EmpId"],
                Orderdate = row["OrderDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["Orderdate"],
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