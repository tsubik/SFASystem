using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using SFASystem.Services;
using SFASystem.Domain;
using SFASystem.DataAccess.SqlServerNH;



public partial class Install_Rozne_PanstwaMiasta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void uploadPanstwa_Click(object sender, EventArgs e)
    {
        if (filePanstwa.HasFile)
        {
            MemoryStream stream = new MemoryStream(fileMiasta.FileBytes);
            XmlReaderSettings settings = new XmlReaderSettings();

            using (XmlReader r = XmlReader.Create(stream, settings))
            {
                while (r.Read())
                {

                }
            }
        }
    }
    protected void uploadMiasta_Click(object sender, EventArgs e)
    {
        if(fileMiasta.HasFile)
        {
            MemoryStream stream = new MemoryStream(fileMiasta.FileBytes);
            XmlReaderSettings settings = new XmlReaderSettings();

            int i = 0;
            Repository<City, Guid> cityrep = new Repository<City, Guid>();
            using (XmlReader r = XmlReader.Create(stream, settings))
            {
                XPathDocument xpathDoc = new XPathDocument(r);
                XPathNavigator xpathNav = xpathDoc.CreateNavigator();

                string xpathQuery = "/teryt/catalog/row/col[attribute::name='NAZWA']";

                XPathExpression xpathExpr = xpathNav.Compile(xpathQuery);

                XPathNodeIterator xpathIter = xpathNav.Select(xpathExpr);

                while (xpathIter.MoveNext())
                {
                    City city = new City();
                    city.Name = xpathIter.Current.Value;
                   
                    cityrep.SaveOrUpdate(city);
                    if (i % 500 == 0)
                        HBManager.Instance.GetSession().Flush();
                    i++;
                    //AddressManager.InsertCity(new City { Name = xpathIter.Current.Value });
                }
            }
            HBManager.Instance.GetSession().Flush();
        }

        
    }
    protected void btnUsunMiasta_Click(object sender, EventArgs e)
    {
        IList<City> cities = BasicService<City, Guid>.GetAll();

        var groupByName = cities.GroupBy(c => c.Name);

        foreach (IGrouping<string, City> group in groupByName)
        {
            if (group.Count() > 1)
            {
                bool skip = true;
                foreach (City city in group)
                {
                    if (skip)
                    {
                        skip = false;
                    }
                    else
                    {
                        BasicService<City, Guid>.Delete(city);
                    }
                }
            }
            
        }
        BasicService<City, Guid>.Evict();
    }
}
