using System;
using System.Collections.Generic;
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
            brunchesList.Items.Add(new ListItem("Computer Engineering", "1"));
            brunchesList.Items.Add(new ListItem("Network Engineering", "2"));
            brunchesList.Items.Add(new ListItem("Software Engineering", "3"));
        }
        protected void Button_Click1(object sender, EventArgs e)
        {
            Response.Redirect("showStudents.aspx");
        }
        protected void Button_Click2(object sender, EventArgs e)
        {
            Response.Redirect("showStudents.aspx?status=1");
        }
        protected void Button_Click3(object sender, EventArgs e)
        {
            Response.Redirect("showStudents.aspx?status=0");
        }
        protected void Button_Click4(object sender, EventArgs e)
        {
            Response.Redirect("showStudents.aspx?status=2");
        }
    }
}