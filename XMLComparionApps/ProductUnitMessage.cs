using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLComparionApps
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.volvo.com/vtc/vpps/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("ProductUnit", Namespace = "http://www.volvo.com/vtc/vpps/1_0", IsNullable = false)]
    public partial class ProductUnitType
    {

        private ProductUnitDataSourceType productUnitDataSourceField;

        private ProductUnitIdentifyerType ProductUnitIdentifyerField;

        private ProductUnitPrintItemType[] productUnitPrintItemField;

        private ProductUnitTermType[] productUnitTermField;

        private ProductUnitPositionType productUnitPositionField;

        /// <remarks/>
        public ProductUnitDataSourceType ProductUnitDataSource
        {
            get
            {
                return this.productUnitDataSourceField;
            }
            set
            {
                this.productUnitDataSourceField = value;
            }
        }

        /// <remarks/>
        public ProductUnitIdentifyerType ProductUnitIdentifyer
        {
            get
            {
                return this.ProductUnitIdentifyerField;
            }
            set
            {
                this.ProductUnitIdentifyerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProductUnitPrintItem")]
        public ProductUnitPrintItemType[] ProductUnitPrintItem
        {
            get
            {
                return this.productUnitPrintItemField;
            }
            set
            {
                this.productUnitPrintItemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProductUnitTerm")]
        public ProductUnitTermType[] ProductUnitTerm
        {
            get
            {
                return this.productUnitTermField;
            }
            set
            {
                this.productUnitTermField = value;
            }
        }

        /// <remarks/>
        public ProductUnitPositionType ProductUnitPosition
        {
            get
            {
                return this.productUnitPositionField;
            }
            set
            {
                this.productUnitPositionField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.volvo.com/vtc/vpps/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("ProductUnitDataSource", Namespace = "http://www.volvo.com/vtc/vpps/1_0", IsNullable = false)]
    public partial class ProductUnitDataSourceType
    {

        private string sourceSystemField;

        private string composingDateTimeField;

        /// <remarks/>
        public string SourceSystem
        {
            get
            {
                return this.sourceSystemField;
            }
            set
            {
                this.sourceSystemField = value;
            }
        }

        /// <remarks/>
        public string ComposingDateTime
        {
            get
            {
                return this.composingDateTimeField;
            }
            set
            {
                this.composingDateTimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.volvo.com/vtc/vpps/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("ProductUnitIdentifyer", Namespace = "http://www.volvo.com/vtc/vpps/1_0", IsNullable = false)]
    public partial class ProductUnitIdentifyerType
    {

        private string key1Field;

        private string key2Field;

        private string key3Field;

        private string productUnitTypeField;

        /// <remarks/>
        public string Key1
        {
            get
            {
                return this.key1Field;
            }
            set
            {
                this.key1Field = value;
            }
        }

        /// <remarks/>
        public string Key2
        {
            get
            {
                if (string.IsNullOrEmpty(this.key2Field))
                    return string.Empty;
                return this.key2Field;
            }
            set
            {
                this.key2Field = value;
            }
        }

        /// <remarks/>
        public string Key3
        {
            get
            {
                if (string.IsNullOrEmpty(this.key2Field))
                    return string.Empty;
                return this.key3Field;
            }
            set
            {
                this.key3Field = value;
            }
        }

        /// <remarks/>
        public string ProductUnitType
        {
            get
            {
                return this.productUnitTypeField;
            }
            set
            {
                this.productUnitTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.volvo.com/vtc/vpps/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("ProductUnitPrintItem", Namespace = "http://www.volvo.com/vtc/vpps/1_0", IsNullable = false)]
    public partial class ProductUnitPrintItemType
    {

        private string printItemNameField;

        /// <remarks/>
        public string PrintItemName
        {
            get
            {
                return this.printItemNameField;
            }
            set
            {
                this.printItemNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.volvo.com/vtc/vpps/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("ProductUnitTerm", Namespace = "http://www.volvo.com/vtc/vpps/1_0", IsNullable = false)]
    public partial class ProductUnitTermType
    {

        private string termNameField;

        private string itemCountField;

        private ProductUnitTermItemType[] productUnitTermItemField;

        /// <remarks/>
        public string TermName
        {
            get
            {
                return this.termNameField;
            }
            set
            {
                this.termNameField = value;
            }
        }

        /// <remarks/>
        public string ItemCount
        {
            get
            {
                return this.itemCountField;
            }
            set
            {
                this.itemCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ProductUnitTermItem")]
        public ProductUnitTermItemType[] ProductUnitTermItem
        {
            get
            {
                return this.productUnitTermItemField;
            }
            set
            {
                this.productUnitTermItemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.volvo.com/vtc/vpps/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("ProductUnitTermItem", Namespace = "http://www.volvo.com/vtc/vpps/1_0", IsNullable = false)]
    public partial class ProductUnitTermItemType
    {

        private string termItemNameField;

        private string itemSequenceField;

        private string dataField;

        /// <remarks/>
        public string TermItemName
        {
            get
            {
                return this.termItemNameField;
            }
            set
            {
                this.termItemNameField = value;
            }
        }

        /// <remarks/>
        public string ItemSequence
        {
            get
            {
                return this.itemSequenceField;
            }
            set
            {
                this.itemSequenceField = value;
            }
        }

        /// <remarks/>
        public string Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.volvo.com/vtc/vpps/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("ProductUnitPosition", Namespace = "http://www.volvo.com/vtc/vpps/1_0", IsNullable = false)]
    public partial class ProductUnitPositionType
    {

        private string positionField;

        private string siteField;

        /// <remarks/>
        public string Position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }

        /// <remarks/>
        public string Site
        {
            get
            {
                return this.siteField;
            }
            set
            {
                this.siteField = value;
            }
        }
    }
}
