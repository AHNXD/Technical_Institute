using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Technical_Institute
{
    public partial class allBranches : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = ConnectionToTheData.getAllBranches();
            B1.Text = data.Tables[0].Rows[0][1].ToString();
            B2.Text = data.Tables[0].Rows[1][1].ToString();
            B3.Text = data.Tables[0].Rows[2][1].ToString();
        }
        protected void Button_Click1(object sender, EventArgs e)
        {
            Response.Redirect("dataForSpecificBranch.aspx?branchID=1");
        }
        protected void Button_Click2(object sender, EventArgs e)
        {
            Response.Redirect("dataForSpecificBranch.aspx?branchID=2");
        }
        protected void Button_Click3(object sender, EventArgs e)
        {
            Response.Redirect("dataForSpecificBranch.aspx?branchID=3");
        }
    }
}