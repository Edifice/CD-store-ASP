using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Web;

public class Album
{
    public int ID { get; private set; }
    public string Artist { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }

    public Album(){}

    public Album(int _ID, string _Artist, string _Title, decimal _Price)
    {
        this.ID = _ID;
        this.Artist = _Artist;
        this.Title = _Title;
        this.Price = _Price;
    }

    public Album findById(int id, HttpServerUtility Server){
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("App_Data/data.xml"));

        XmlNodeList nodeList = doc.GetElementsByTagName("album");
        foreach (XmlNode node in nodeList)
        {
            if (node["id"].InnerText == id.ToString())
            {
                return new Album(
                    id,
                    node["artist"].InnerText,
                    node["title"].InnerText,
                    decimal.Parse(node["price"].InnerText)
                    );
            }
        }
        return null;
    }
}