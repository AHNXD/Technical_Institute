using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Technical_Institute
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = ConnectionToTheData.getAllBranches();
            gvGetAllBranches.DataSource = data;
            gvGetAllBranches.DataBind();

            data = ConnectionToTheData.getBranch(1);
            gvGetBranch.DataSource = data;
            gvGetBranch.DataBind();

            data = ConnectionToTheData.getSubjectFromBranch(1);
            gvgetSubjectFromBranch.DataSource = data;
            gvgetSubjectFromBranch.DataBind();

            data = ConnectionToTheData.getSubjectFromBranchForSpecificYear(1,2);
            gvgetSubjectFromBranchForSpecificYear.DataSource = data;
            gvgetSubjectFromBranchForSpecificYear.DataBind();

            data = ConnectionToTheData.getSubjectFromBranchForSpecificYearForSpecificSemester(1, 2 ,1);
            gvgetSubjectFromBranchForSpecificYearForSpecificSemester.DataSource = data;
            gvgetSubjectFromBranchForSpecificYearForSpecificSemester.DataBind();
        }
    }
}