using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Technical_Institute
{
    public partial class showStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int st = Convert.ToInt32(Request.QueryString["status"]);
          
            var data = ConnectionToTheData.getRegisteredStudents(st);
            viewStudents.DataSource = data;
            viewStudents.DataBind();
            
            var d = ConnectionToTheData.getAllStudents();
            viewStudents.DataSource = d;
            viewStudents.DataBind();
            
        }
    }
}