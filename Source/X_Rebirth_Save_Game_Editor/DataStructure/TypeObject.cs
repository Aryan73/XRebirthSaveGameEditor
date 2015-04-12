using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using X_Rebirth_Save_Game_Editor.Helper;

namespace X_Rebirth_Save_Game_Editor.DataStructure
{
    class TypeObject
    { 
        #region Members
        XmlNode TypeNode = null;
        XmlNode ShipNode = null;
        XmlNode ShipGroupNode = null;
        CatDatExtractor cde = null;
        TypeCategoryEnum? _category = null;
        string _transportType = null;
        string _id = null;
        string _macro = null;
        string _name = null;
        string _componentRef = null;
        string _size = null;
        string _translatedName
        bool? _isShip = null;
        KeyValuePair<string, string>? _dropDownValues = null;
        #endregion

        #region Constructors
        private TypeObject()
        {
        }

        public TypeObject(XmlNode node, CatDatExtractor cde)
        {
            TypeNode = node;
            _isShip = false;
            this.cde = cde;
        }

        public TypeObject(XmlNode shipNode, XmlNode shipGroupNode, CatDatExtractor cde)
        {
            ShipNode = shipNode;
            ShipGroupNode = shipGroupNode;
            _isShip = true;
            this.cde = cde;
        }
        #endregion

        #region Functions
        
        #endregion

        #region Properties
        public string TransportType
        {
            get
            {
                if (_transportType == null)
                {
                    if (IsShip)
                    {
                        // TODO: Determine the transport type of the ship. For now it's ""
                        _transportType = "";
                    }
                    else
                    {
                        _transportType = XMLFunctions.GetSafeAttribute(TypeNode, "transport");
                    }
                }

                return _transportType;
            }
        }

        public string Id
        {
            get
            {
                if (_id == null)
                {
                    if (IsShip)
                    {
                        // If ship retrieve macro and id at the same time
                        string t = Macro;
                    }
                    else
                    {
                        _id = XMLFunctions.GetSafeAttribute(TypeNode, "id");
                    }
                }

                return _id;
            }
        }

        public string Name
        {
            get
            {
                if (_name == null)
                {
                    if (IsShip)
                    {
                        _name = "";
                    }
                    else
                    {
                        _name = XMLFunctions.GetSafeAttribute(TypeNode, "name");
                    }
                }

                return _name;
            }
        }

        public string TranslatedName
        {
            get
            {
                return _translatedName;
            }
            set
            {
                _translatedName = value;
            }
        }

        public string Macro
        {
            get
            {
                if (_macro == null)
                {
                    if (IsShip)
                    { // If ship retrieve macro and id at the same time
                        XmlAttribute att1 = ShipNode.ParentNode.Attributes["macro"];
                        if (att1 != null)
                        {
                            _macro = ShipNode.ParentNode.Attributes["macro"].Value;
                        }

                        if (!string.IsNullOrEmpty(_macro))
                        {
                            _id = XMLFunctions.GetSafeAttribute(ShipNode, "id");
                        }

                        if (_macro == null)
                        {
                            att1 = null;

                            att1 = ShipNode.ParentNode.Attributes["group"];
                            XmlNode groupChildNode = ShipGroupNode.SelectSingleNode("//group[@name='" + att1.Value + "']").FirstChild;

                            if (groupChildNode != null)
                            {
                                _macro = XMLFunctions.GetSafeAttribute(groupChildNode, "macro");

                                while (groupChildNode != null)
                                {
                                    if (_id == null)
                                    {
                                        _id = groupChildNode.ParentNode.Attributes["id"].Value;
                                    }
                                    else
                                    {
                                        _id += " & " + groupChildNode.ParentNode.Attributes["id"].Value;
                                    }

                                    groupChildNode = groupChildNode.NextSibling;
                                }
                            }
                        }

                        if (_macro == null)
                        {
                            _macro = "MacroNotFound!";
                        }
                    }
                    else
                    {
                        _macro = "";
                    }
                }

                return _macro;
            }
        }

        public string ComponentRef
        {
            get
            {
                if (_componentRef == null)
                {
                    if  (  Category == TypeCategoryEnum.Inventory_Weapon_Secondary
                        || Category == TypeCategoryEnum.Inventory_Marines
                        || Category == TypeCategoryEnum.Inventory_Drone
                        || Category == TypeCategoryEnum.Equipment_Engine
                        || Category == TypeCategoryEnum.Equipment_Scanner
                        || Category == TypeCategoryEnum.Equipment_Shield
                        || Category == TypeCategoryEnum.Equipment_Weapon_Primary
                        || Category == TypeCategoryEnum.Equipment_Unknown
                        )
                    {
                        _componentRef = XMLFunctions.GetSafeAttribute(XMLFunctions.FindChild(TypeNode, "component"), "ref");
                    }
                    else
                    {
                        _componentRef = "";
                    }
                }

                return _componentRef;
            }
        }    

        public KeyValuePair<string, string> DropDownValues
        {
            get
            {
                if (_dropDownValues == null)
                {
                    if (IsShip)
                    {
                        _dropDownValues = new KeyValuePair<string, string>(Macro, Id);
                    }
                    else if (   Category == TypeCategoryEnum.Inventory_Wares
                            ||  Category == TypeCategoryEnum.Wares_Container
                            ||  Category == TypeCategoryEnum.Wares_Bulk
                            ||  Category == TypeCategoryEnum.Wares_Liquid
                            ||  Category == TypeCategoryEnum.Wares_Energy
                            )
                    {
                        _dropDownValues = new KeyValuePair<string, string>(Id, Name);
                    }
                    else if (   Category == TypeCategoryEnum.Inventory_Weapon_Secondary
                            ||  Category == TypeCategoryEnum.Inventory_Marines
                            ||  Category == TypeCategoryEnum.Inventory_Drone
                            ||  Category == TypeCategoryEnum.Equipment_Engine
                            ||  Category == TypeCategoryEnum.Equipment_Scanner
                            ||  Category == TypeCategoryEnum.Equipment_Shield
                            ||  Category == TypeCategoryEnum.Equipment_Weapon_Primary
                            ||  Category == TypeCategoryEnum.Equipment_Unknown
                            )
                    {
                        _dropDownValues = new KeyValuePair<string, string>(ComponentRef, Name);
                    }
                }

                return _dropDownValues.Value;
            }
        }

        public string Size
        {
            get
            {
                if (_size == null)
                {
                    if (IsShip)
                    {
                        _size = XMLFunctions.GetSafeAttribute(XMLFunctions.FindChild(ShipNode, "category"), "size");
                    }
                    else
                    {
                        _size = "";
                    }
                }

                return _size;
            }
        }
        
        public bool IsShip
        {
            get
            {
                return _isShip.Value;
            }
        }

        public TypeCategoryEnum Category
        {
            get
            {
                if (_category == null)
                {
                    if (IsShip)
                    {
                        if (Size == "ship_xs")
                        {
                            _category = TypeCategoryEnum.shiptypes_xs;
                        }
                        else if (Size == "ship_s")
                        {
                            _category = TypeCategoryEnum.shiptypes_s;
                        }
                        else if (Size == "ship_m")
                        {
                            _category = TypeCategoryEnum.shiptypes_m;
                        }
                        else if (Size == "ship_l")
                        {
                            _category = TypeCategoryEnum.shiptypes_l;
                        }
                        else if (Size == "ship_xl")
                        {
                            _category = TypeCategoryEnum.shiptypes_xl;
                        }
                        else
                        {
                            _category = TypeCategoryEnum.shiptypes_Unknown;
                        }
                    }
                    else
                    {
                        if (TransportType == "inventory")
                        {
                            if (Id.StartsWith("spe_ammo_"))
                            {
                                _category = TypeCategoryEnum.Inventory_Weapon_Secondary;
                            }
                            else if (Id.StartsWith("spe_unit_marine_"))
                            {
                                _category = TypeCategoryEnum.Inventory_Marines;
                            }
                            else if (Id.StartsWith("spe_drone_"))
                            {
                                _category = TypeCategoryEnum.Inventory_Drone;
                            }
                            else
                            {
                                _category = TypeCategoryEnum.Inventory_Wares;
                            }
                        }
                        else if (TransportType == "container")
                        {
                            _category = TypeCategoryEnum.Wares_Container;
                        }
                        else if (TransportType == "bulk")
                        {
                            _category = TypeCategoryEnum.Wares_Bulk;
                        }
                        else if (TransportType == "liquid")
                        {
                            _category = TypeCategoryEnum.Wares_Liquid;
                        }
                        else if (TransportType == "energy")
                        {
                            _category = TypeCategoryEnum.Wares_Energy;
                        }
                        else if (TransportType == "equipment")
                        {
                            if (Id.StartsWith("upg_pla_engine_"))
                            {
                                _category = TypeCategoryEnum.Equipment_Engine;
                            }
                            else if (Id.StartsWith("upg_pla_scanner_")
                                    || Id.StartsWith("upg_pla_software_")
                                    )
                            {
                                _category = TypeCategoryEnum.Equipment_Engine;
                            }
                            else if (Id.StartsWith("upg_pla_shield_"))
                            {
                                _category = TypeCategoryEnum.Equipment_Shield;
                            }
                            else if (Id.StartsWith("upg_pla_weapon_"))
                            {
                                _category = TypeCategoryEnum.Equipment_Weapon_Primary;
                            }
                            else
                            {
                                _category = TypeCategoryEnum.Equipment_Unknown;
                            }
                        }
                    }

                    if (_category == null)
                    {
                        _category = TypeCategoryEnum.Unknown;
                    }
                }

                return _category.Value;
            }
        }
        #endregion
    }

    enum TypeCategoryEnum
    {   Inventory_Wares = 1
    ,   Inventory_Weapon_Secondary = 2
    ,   Inventory_Marines = 3
    ,   Inventory_Drone = 4
    ,   Wares_Container = 11
    ,   Wares_Bulk = 12
    ,   Wares_Liquid = 13
    ,   Wares_Energy = 14
    ,   Equipment_Engine = 21
    ,   Equipment_Scanner = 22
    ,   Equipment_Shield = 23
    ,   Equipment_Weapon_Primary = 24
    ,   Equipment_Unknown = 29
    ,   shiptypes_xs = 31
    ,   shiptypes_s = 32
    ,   shiptypes_m = 33
    ,   shiptypes_l = 34
    ,   shiptypes_xl = 35
    ,   shiptypes_Unknown = 39
    ,   Unknown = 100
    }
}
