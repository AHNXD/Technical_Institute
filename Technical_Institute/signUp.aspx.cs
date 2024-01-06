using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Technical_Institute
{
    public partial class signUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            if (GenderFemale.Checked == false && GenderMale.Checked == false)
            {
                SignUpState.Text = "You Have to Set Your Gender.";
            }
            else if (float.Parse(InputDegree.Value) > 2100)
            {
                SignUpState.Text = "You Have to Set Your Degree Under Or Equal 2100.";
            }
            else
            {
                bool state = ConnectionToTheData.addUser(InputIsAdmin.Checked, InputFirstName.Value, InputLastName.Value, InputNationalNumber.Value, InputPhone.Value,
                                        GenderFemale.Checked ? 'F' : 'M', float.Parse(InputDegree.Value), Certificate_Type.Value, InputPassword.Value);
                if (state)
                {
                    if(InputIsAdmin.Checked) Response.Redirect($"adminPage.aspx?nb={InputNationalNumber.Value}&pass={InputPassword.Value.GetHashCode()}");
                    else Response.Redirect($"allBranches.aspx?nb={InputNationalNumber.Value}&pass={InputPassword.Value.GetHashCode()}");
                }
                else
                {
                    SignUpState.Text = "Check Your Data.";
                }
            }
        }
    }
}