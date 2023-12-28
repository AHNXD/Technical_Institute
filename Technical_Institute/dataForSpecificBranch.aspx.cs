using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Technical_Institute
{
    public partial class dataForSpecificBranch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = StateData.branchID;
            var branchName = ConnectionToTheData.getBranch(id);
            BranchName.Text = branchName.Tables[0].Rows[0][1].ToString();

            var data = ConnectionToTheData.getSubjectFromBranchForSpecificYearForSpecificSemester(id, 1, 1);
            FirstYearSemesterOne.DataSource = data;
            FirstYearSemesterOne.DataBind();

            data = ConnectionToTheData.getSubjectFromBranchForSpecificYearForSpecificSemester(id, 1, 2);
            FirstYearSemesterTwo.DataSource = data;
            FirstYearSemesterTwo.DataBind();

            data = ConnectionToTheData.getSubjectFromBranchForSpecificYearForSpecificSemester(id, 2, 1);
            SecondYearSemesterOne.DataSource = data;
            SecondYearSemesterOne.DataBind();

            data = ConnectionToTheData.getSubjectFromBranchForSpecificYearForSpecificSemester(id, 2, 2);
            SecondYearSemesterTwo.DataSource = data;
            SecondYearSemesterTwo.DataBind();
        }
    }
}