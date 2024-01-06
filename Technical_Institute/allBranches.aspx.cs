using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Technical_Institute
{
    public partial class allBranches : System.Web.UI.Page
    {
        DataTable Studentdata;
        DataTable Branchesdata;
        protected void Page_Load(object sender, EventArgs e)
        {
            Branchesdata = ConnectionToTheData.getAllBranches();
            rptBranches.DataSource = Branchesdata;
            rptBranches.DataBind();

            try
            {
                Studentdata = ConnectionToTheData.getSpecificUser(Request.QueryString["nb"].ToString(), Request.QueryString["pass"].ToString());
                if (Studentdata.Rows.Count == 0)
                {
                    username.Text = "Guest";
                    degree.Text = "0";
                }
                else
                {
                    username.Text = $"{Studentdata.Rows[0][2]}  {Studentdata.Rows[0][3]}";
                    degree.Text = Studentdata.Rows[0][6].ToString();
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
            var btn = (Button)sender;
            if(float.Parse(Studentdata.Rows[0][6].ToString()) >= float.Parse(Branchesdata.Rows[int.Parse(btn.CommandArgument)-1][3].ToString()))
            {
                bool state = ConnectionToTheData.ifTheStudentRegistered(int.Parse(Studentdata.Rows[0][0].ToString()), int.Parse(Branchesdata.Rows[int.Parse(btn.CommandArgument)-1][0].ToString()));
                if(state)
                {
                    regStatus.Text = "You are already registered.";
                }
                else
                {
                    bool status = ConnectionToTheData.studentRegister(int.Parse(Studentdata.Rows[0][0].ToString()), int.Parse(Branchesdata.Rows[int.Parse(btn.CommandArgument)-1][0].ToString()));
                    if(status) regStatus.Text = "Done.";
                    else regStatus.Text = "Some Thing Went Wrong.";
                }
            }
            else regStatus.Text = "Your degree dosn't met the minimum requirement.";
        }
        protected void rptBranches_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "OpenBranch")
                Response.Redirect($"dataForSpecificBranch.aspx?branchID={e.CommandArgument}");
        }
    }
}