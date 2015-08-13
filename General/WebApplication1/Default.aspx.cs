using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //t_Orders_100 aa = new t_Orders_100();

            AccountDataContext accountDB = new AccountDataContext();

            t_Account_100 _t_Account_100 = new t_Account_100
            {
                UserID = 789789,
                Point = 10,
                svPoint = 10,
                Score = 20
            };
            accountDB.t_Account_100.InsertOnSubmit(_t_Account_100);
            accountDB.SubmitChanges();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            AccountDataContext accountDB = new AccountDataContext();
            var result = from o in accountDB.t_Orders_100
                             select o;
                         //group o by o.roomid;
                         //select new
                         //{
                         //    newOrder.Key,
                         //    MostExpensiveProducts = from o2 in newOrder
                         //                            where o2.payAmount == newOrder.Max(o3 => o3.payAmount)
                         //                            select o2
                         //};

            //List<t_Orders_100> list = (List<t_Orders_100>)result;

            foreach (t_Orders_100 v in result)
            {
                string sss = v.payAmount.ToString();
            }


        }

    }
}
