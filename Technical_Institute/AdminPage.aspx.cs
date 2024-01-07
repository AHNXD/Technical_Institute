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
        protected void Button_Update(object sender, EventArgs e)
        {
            try
            {
                DataTable data = new DataTable();
                int idStd = int.Parse(InputStdID.Value);
                int idBranch = int.Parse(inputBranchID.Value);
                string status = InputListStatus.Value;

                bool isRegistered = ConnectionToTheData.ifTheStudentRegistered(idStd, idBranch);
                if (isRegistered)
                {
                    bool updater = ConnectionToTheData.updateStudentStatus(idStd, idBranch, status);
                    if (updater) lblState.Text = "Done.";
                    else lblState.Text = "Some Thing Went Wrong.";
                }
                else lblState.Text = "Check the Student ID and The Branch ID.";
            }
            catch
            {
                lblState.Text = "Fill all the data.";
            }
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            Button btn = (Button)sender;
            string status = btn.CommandArgument.ToString();

            if (branchesList.SelectedValue == "0")//All branches
            {
                if (status == "all")//all std
                {
                    data = ConnectionToTheData.getAllRegisteredStudentsFromAllBranches();
                }else//all std with specific status
                {
                    int state = status == "accepted" ? 1 : status == "rejected" ? 0 : -1;
                    data = ConnectionToTheData.getAllRegisteredStudentsWithSpecificStatusFromAllBranches(state);
                }
            }
            else//specific branch
            {
                if(status == "all")//all std
                {
                    data = ConnectionToTheData.getAllRegisteredStudentsInSpecificBranch(int.Parse(branchesList.SelectedValue));
                }
                else//all std with specific status
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