using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Logging;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    public class PatchInfoData
    {
        #region Members
        XmlNode PatchNode = null;
        CatDatExtractor cde = null;
        #endregion

        #region Constructors
        public PatchInfoData(XmlNode patchNode, CatDatExtractor cde)
        {
            PatchNode = patchNode;
            this.cde = cde;
        }
        #endregion

        #region Functions
        public void Remove()
        {
            PatchNode.ParentNode.RemoveChild(PatchNode);
        }
        #endregion

        #region Property
        public string Extension
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(PatchNode, "extension");
            }
            set
            {
                XMLFunctions.SetSafeAttribute(PatchNode, "extension", value);
            }
        }

        public string Version
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(PatchNode, "version");
            }
            set
            {
                XMLFunctions.SetSafeAttribute(PatchNode, "version", value);
            }
        }

        public string Name
        {
            get
            {
                return XMLFunctions.GetSafeAttribute(PatchNode, "name");
            }
            set
            {
                XMLFunctions.SetSafeAttribute(PatchNode, "name", value);
            }
        }
        #endregion

    }
}
