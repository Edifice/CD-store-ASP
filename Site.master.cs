using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
        // -- OUR CODE

        // Cookie reading
        DataTable cartTable = new DataTable();
        cartTable.Columns.Add("Albums", typeof(string));
        XmlDocument xmldoc2 = new XmlDocument();
        foreach (string cookieName in Request.Cookies.AllKeys)
        {
            HttpCookie cookie = Request.Cookies[cookieName];
            if (cookie.Name.Contains("cart_"))
            {
                int amount = int.Parse(cookie["amount"]);
                Album album = new Album();
                album = album.findById(int.Parse(cookie["id"]), Server);

                DataRow dtrow = cartTable.NewRow();
                dtrow["Albums"] = album.Artist + " - " + album.Title + " (" + amount + " x " + album.Price + " kr.)";
                cartTable.Rows.Add(dtrow);
            }
        }
        GridViewCart.DataSource = cartTable;
        GridViewCart.DataBind();

        // -- OUR CODE END

        // The code below helps to protect against XSRF attacks
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool showCart()
    {
        foreach (string c in Request.Cookies.AllKeys)
        {
            if (c.Contains("cart_"))
            {
                return true;
            }
        }
        return false;
    }
}