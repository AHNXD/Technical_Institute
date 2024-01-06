using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Technical_Institute
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable data = ConnectionToTheData.getSpecificUser(Request.QueryString["nb"].ToString(), Request.QueryString["pass"].ToString());
            lblAdminName.Text = $"{data.Rows[0][2]}  {data.Rows[0][3]}";
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            Button btn = (Button)sender;
            string status = btn.CommandArgument.ToString();

            if (branchesList.SelectedValue == "0")
            {
                if (status == "all")
                {
                    data = ConnectionToTheData.getAllRegisteredStudentsFromAllBranches();
                }else
                {
                    int state = status == "accepted" ? 1 : status == "rejected" ? 0 : -1;
                    data = ConnectionToTheData.getAllRegisteredStudentsWithSpecificStatusFromAllBranches(state);
                }
            }
            else
            {
                if(status == "all")
                {
                    data = ConnectionToTheData.getAllRegisteredStudentsInSpecificBranch(int.Parse(branchesList.SelectedValue));
                }else
                {
                    int state = status == "accepted" ? 1 : status == "rejected" ? 0 : -1;
                    data = ConnectionToTheData.getAllRegisteredStudentsWithSpecificStatusInSpecificBranch(int.Parse(branchesList.SelectedValue),state);
                }
            }
            viewStudents.DataSource = data;
            viewStudents.DataBind();
        }
    }
}