using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

namespace SFASystem.Pocket.Utils
{
    public static class ConfigurationHelper
    {
        //private static StringBuilder m_ConfigPropertyName;
        private static string m_ConfigPropertyName;
        private static string m_ConfigOrderStepName;

        #region Funkcje uzywane w kontrolce edycji dostaw
        public static void InsertEmptyNodeByXpath(string aXmlUri, string xpath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(aXmlUri);
            XmlNode nodex = xmlDoc.SelectSingleNode(xpath);
            nodex.ParentNode.AppendChild(nodex.Clone());
            foreach (XmlAttribute atr in nodex.Attributes)
            {
                atr.Value = "0";
            }
            xmlDoc.Save(aXmlUri);
        }

        public static void SaveUserConfigurationByXpath(string aXmlUri, string xpath, IDictionary<string, string> atributes)// string aControlProperty, string value)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(aXmlUri);
                XmlNode node = xmlDoc.SelectSingleNode(xpath);

                foreach (string key in atributes.Keys)
                {
                    node.Attributes[key].Value = atributes[key];
                }

                xmlDoc.Save(aXmlUri);
            }
            catch (NullReferenceException) { }
        }

        public static void DeleteByXpath(string aXmlUri, string xpath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(aXmlUri);
                XmlNode node = xmlDoc.SelectSingleNode(xpath);
                node.ParentNode.RemoveChild(node);
                xmlDoc.Save(aXmlUri);
            }
            catch (NullReferenceException) { }
        }
        #endregion

        // nie wiem po co to bylo ?? 
        // nie lepiej value dac stringa a nie pozniej zamieniac boola na stringa
        public static void SaveUserConfiguration(string aXmlUri, string aControlProperty, bool value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(aXmlUri);

            foreach (XmlNode node in xmlDoc.SelectNodes("controls"))
            {
                if (node.Name == "property" && node.Attributes["name"].Value == aControlProperty)
                {
                    node.Attributes["value"].Value = value.ToString();
                    xmlDoc.Save(aXmlUri);
                    return;
                }
            }
        }

        public static ArrayList GetConfigPropertyNames(string aXmlUri)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(aXmlUri);

            ArrayList lista_nazw = new ArrayList();
            //.SelectNodes("controls/property")
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                if (node.Name == "property")
                {
                    lista_nazw.Add(node.Attributes["name"].Value);
                }
            }

            return lista_nazw;
        }




        public static int GetConfigurationIntValue(string aXmlUri, string aControlProperty)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(aXmlUri);
            //xmlDoc.SelectNodes("controls/property")
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                if (node.Name == "property" && node.Attributes["name"].Value == aControlProperty)
                {
                    return int.Parse(node.Attributes["value"].Value);
                }
            }

            return 0;
        }

        public static string GetConfigurationStringValue(string aXmlUri, string aControlProperty)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(aXmlUri);
            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                if (node.Name == "property" && node.Attributes["name"].Value == aControlProperty)
                {
                    return node.Attributes["value"].Value;
                }
            }

            return string.Empty;
        }

        public static void SetConfigurationStringValue(string aXmlUri, string aControlProperty, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(aXmlUri);

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                if (node.Name == "property" && node.Attributes["name"].Value == aControlProperty)
                {
                    node.Attributes["value"].Value = value;
                    xmlDoc.Save(aXmlUri);
                    return;
                }
            }
        }

        public static string GetConfigurationStringValueByXPath(string aXmlUri, string aControlProperty)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(aXmlUri);
            String xpath = "//property[@name='" + aControlProperty + "']";
            XmlNode node = xmlDoc.SelectSingleNode(xpath);

            if (node != null)
            {
                return node.Attributes["value"].Value;
            }

            return String.Empty;
        }


    }
}
