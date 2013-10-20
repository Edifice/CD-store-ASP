using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckoutSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblFirstName.Text = Request.QueryString["fn"];
        lblLastName.Text = Request.QueryString["ln"];
        lblStreetName.Text = Request.QueryString["sn"];
        lblCity.Text = Request.QueryString["city"];
        lblCountry.Text = Request.QueryString["country"];
        lblEmail.Text = Request.QueryString["email"];
    }
}