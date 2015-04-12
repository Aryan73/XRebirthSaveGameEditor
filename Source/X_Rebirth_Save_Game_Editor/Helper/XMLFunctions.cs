using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Logging;

namespace X_Rebirth_Save_Game_Editor.Helper
{
    class XMLFunctions
    {
        #region Members
        private static int LastId = 0;
        #endregion

        #region Standard XML Functions
        public static XmlNode FindChild(XmlNode nodeToSearchIn, string childName)
        {
            XmlNode returnNode = null;
            try
            {
                returnNode = nodeToSearchIn.FirstChild;
                while (returnNode != null
                        && returnNode.Name != childName
                      )
                {
                    returnNode = returnNode.NextSibling;
                }
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(childName)) childName = "";
                string node = "null";
                if (nodeToSearchIn != null) node = nodeToSearchIn.Name;
#if (DEBUG)
                if (nodeToSearchIn != null) node += ", XML(" + nodeToSearchIn.OuterXml + ")";
#endif
                throw new Exception("Unable to retrieve child " + childName + " from node " + node, ex);
            }

            return returnNode;
        }

        public static string DetermineNewId(XmlDocument doc)
        {
            if (LastId <= 0)
            {
                XmlNodeList nodes = doc.SelectNodes("//@id");
                foreach (XmlNode node in nodes)
                {
                    if (!string.IsNullOrEmpty(node.Value)
                        && node.Value.StartsWith("[0x")
                        )
                    {
                        int id = Int32.Parse(node.Value.Substring(3, node.Value.Length - 4), System.Globalization.NumberStyles.HexNumber);
                        //Convert.ToInt32(node.Value.Substring(1, node.Value.Length -2));
                        if (LastId < id)
                        {
                            LastId = id;
                        }
                    }
                }
            }
            LastId++;

            return "[0x" + LastId.ToString("X") + "]";
        }

        public static string GetSafeAttribute(XmlNode node, string attName)
        {
            if (node == null)
            {
                return "No element? When retrieving " + attName;
            }
            XmlAttribute att = node.Attributes[attName];

            if (att == null)
            {
                return "No attribute: " + attName;
            }

            return att.Value;
        }

        public static void SetSafeAttribute(XmlNode node, string attName, string value)
        {
            if (node == null)
            {
                Logger.Warning("Unable to set atribute " + attName + " with value " + value + " since it does not exist.");
                return;
            }

            XmlAttribute att = node.Attributes[attName];

            if (att == null)
            {
                att = node.OwnerDocument.CreateAttribute(attName);
                node.Attributes.Append(att);
            }

            att.Value = value;
        }
        #endregion

        #region Some other XR specific functions
        public static DateTime ConvertEpochToDateTime(string epoch)
        {
            long res;
            DateTime ret = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            if (Int64.TryParse(epoch, out res))
            {
                ret = ret.AddSeconds(res);
            }

            return ret;
        }
        #endregion
    }
}
