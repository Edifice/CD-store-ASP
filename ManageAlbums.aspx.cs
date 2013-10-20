using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Data;

public partial class Default4 : System.Web.UI.Page
{

    XmlDocument vidDocument = new XmlDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            vidDocument.Load(Server.MapPath("/App_Data/data.xml"));

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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        vidDocument.Load(Server.MapPath("/App_Data/data.xml"));
        XmlNode node = vidDocument.SelectNodes("/store")[0].LastChild;
        XmlNode newnode = node.CloneNode(true);

        newnode.SelectSingleNode("id").InnerText = (int.Parse(newnode.SelectSingleNode("id").InnerText) + 1).ToString();
        newnode.SelectSingleNode("title").InnerText = txtTitle.Text;
        newnode.SelectSingleNode("artist").InnerText = txtArtist.Text;
        newnode.SelectSingleNode("price").InnerText = txtPrice.Text;

        vidDocument.DocumentElement.AppendChild(newnode);

        XmlTextWriter writer = new XmlTextWriter(Server.MapPath("App_Data/data.xml"), null);
        writer.Formatting = Formatting.Indented;
        vidDocument.Save(writer);
        writer.Close();

        Response.Redirect(Request.RawUrl);
    }


}