using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Technical_Institute
{
    public partial class dataForSpecificBranch : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["branchID"]);
            var brancData = ConnectionToTheData.getBranch(id);
            BranchName.Text = brancData.Rows[0][1].ToString();

            Repeater_Years.DataSource = ConnectionToTheData.getYearsAndSemesters(id);
            Repeater_Years.DataBind();

        }

        protected DataTable GetSubjects(string year, string semester)
        {
            var data = ConnectionToTheData.getSubjectFromBranchForSpecificYearForSpecificSemester(id, int.Parse(year), int.Parse(semester));
            return data;
        }
    }
}