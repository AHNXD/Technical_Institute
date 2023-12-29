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
        protected void Button_Click(object sender, EventArgs e)
        {
            try
            {
                var data = ConnectionToTheData.getSpecificUser(InputNationalNumber.Value, InputPassword.Value);
                if (data.Rows.Count == 0)
                {
                    LoginState.Text = "Check Your National Number And Password.";
                }
                else
                {
                    if (data.Rows[0][9].ToString() == InputPassword.Value)
                    {
                        Response.Redirect($"allBranches.aspx?nb={InputNationalNumber.Value}&pass={InputPassword.Value}");
                    }
                    else
                    {
                        LoginState.Text = "Check Your National Number And Password.";
                    }
                }
            }catch (Exception ex)
            {
                LoginState.Text = "Check Your National Number And Password.";
            }
           
            
        }
    }
}