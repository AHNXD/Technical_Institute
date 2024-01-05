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
            rptBranches.DataSource = data;
            rptBranches.DataBind();

            try
            {
                data = ConnectionToTheData.getSpecificUser(Request.QueryString["nb"].ToString(), Request.QueryString["pass"].ToString());
                if (data.Rows.Count == 0)
                {
                    username.Text = "Guest";
                    degree.Text = "0";
                }
                else
                {
                    username.Text = $"{data.Rows[0][2]}  {data.Rows[0][3]}";
                    degree.Text = data.Rows[0][6].ToString();
                }
            }
            catch
            {
                username.Text = "Guest";
                degree.Text = "0";
            }
           
        }
        protected void Button_Register(object sender, EventArgs e)
        {

        }
        protected void rptBranches_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "OpenBranch")
                Response.Redirect($"dataForSpecificBranch.aspx?branchID={e.CommandArgument}");
        }
    }
}