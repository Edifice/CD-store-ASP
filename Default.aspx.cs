using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    XmlDocument vidDocument = new XmlDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            vidDocument.Load(Server.MapPath("App_Data/data.xml"));

            XmlNodeList nodeList = vidDocument.GetElementsByTagName("album");

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Artist", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            XmlDocument xmldoc = new XmlDocument();
            foreach (XmlNode node in nodeList)
            {
                DataRow dtrow = dt.NewRow();
                dtrow["ID"] = node["id"].InnerText;
                dtrow["Title"] = node["title"].InnerText;
                dtrow["Artist"] = node["artist"].InnerText;
                dtrow["Price"] = node["price"].InnerText + " kr.";
                dt.Rows.Add(dtrow);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddToCart")
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            Boolean newCookie = true;
            HttpCookie cookie = null;

            if (Request.Cookies["cart_" + ID] != null)
                newCookie = false;


            if (newCookie) // Cookie already exist?
            {
                cookie = new HttpCookie("cart_" + ID);
                cookie["amount"] = "1";
                cookie["id"] = ID.ToString();
            }
            else
            {
                cookie = Request.Cookies["cart_" + ID];
                cookie["amount"] = (int.Parse(cookie["amount"]) + 1).ToString();
            }

            cookie.Expires = DateTime.Now.AddDays(30d);
            Response.Cookies.Add(cookie);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        XmlNode node = vidDocument.SelectNodes("/store")[0].LastChild;
        XmlNode newnode = node.CloneNode(true);

        newnode.SelectSingleNode("id").InnerText = (int.Parse(newnode.SelectSingleNode("id").InnerText) + 1).ToString();
        newnode.SelectSingleNode("title").InnerText = txtTitle.Text;
        newnode.SelectSingleNode("artist").InnerText = txtArtist.Text;
        newnode.SelectSingleNode("price").InnerText = txtPrice.Text;
        
        vidDocument.DocumentElement.AppendChild(newnode);

        XmlNodeList titles = vidDocument.GetElementsByTagName("title");
        GridView1.DataSource = titles;
        GridView1.DataBind();

        XmlTextWriter writer = new XmlTextWriter(Server.MapPath("App_Data/data.xml"), null);
        writer.Formatting = Formatting.Indented;
        vidDocument.Save(writer);
        writer.Close();
    }
}