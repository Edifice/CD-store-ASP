using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void sub(object sender, EventArgs e)
    {
        String userText = "fn=" + FirstName.Text;
        String userText1 = "ln=" + LastName.Text;
        String userText2 = "sn=" + StreetName.Text;
        String userText3 = "city=" + City.Text;
        String userText4 = "country=" + Country.Text;
        String userText5 = "email=" + Email.Text;

        string query = userText + "&" + userText1 + "&" + userText2 + "&" + userText3 + "&" + userText4 + "&" + userText5;

        Server.Transfer("CheckoutSummary.aspx?" + query, true);
    }
}
