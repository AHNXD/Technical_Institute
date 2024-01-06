using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Technical_Institute
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button_Login(object sender, EventArgs e)
        {
            try
            {
                var data = ConnectionToTheData.checkUser(InputNationalNumber.Value, InputPassword.Value);
                if (data.Rows.Count == 0)
                {
                    LoginState.Text = "  Check Your National Number And Password.";
                }
                else
                {
                    if (data.Rows[0][1].ToString().ToLower() == "false")
                        Response.Redirect($"allBranches.aspx?nb={InputNationalNumber.Value}&pass={InputPassword.Value.GetHashCode()}");
                    else
                        Response.Redirect($"adminPage.aspx?nb={InputNationalNumber.Value}&pass={InputPassword.Value.GetHashCode()}");
                }
            }catch (Exception ex)
            {
                LoginState.Text = "  Check Your National Number And Password.";
            }
        }
    }
}