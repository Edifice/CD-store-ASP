using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    XmlDocument vidDocument = new XmlDocument();
    const string fileName = "|DataDirectory|/data.xml";
    protected void Page_Load(object sender, EventArgs e)
    {
        vidDocument.Load(Server.MapPath("App_Data/data.xml"));

        // this is how you get all the video nodes, perhaps to bind them or iterate over them
        XmlNodeList videos = vidDocument.SelectNodes("/store/album");

        // this would select all title elements
        XmlNodeList titles = vidDocument.GetElementsByTagName("title");

        // this binds the gridview to the title text to display
        GridView1.DataSource = titles;
        GridView1.DataBind();
        
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