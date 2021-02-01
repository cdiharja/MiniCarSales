using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarSales.Model
{
    [AttributeUsage(AttributeTargets.All)]
    public class ElementTypeAttribute : Attribute
    {
        // Private fields.
        private string validationName;
        private string format;
        private string element;
        private int sortOrder;


        public ElementTypeAttribute(string validationName, string format,string element,int sortOrder=100)
        {
            this.validationName = validationName;
            this.format = format;
            this.element = element;
            this.sortOrder = sortOrder;
        }

        // Define Name property.
        // This is a read-only attribute.

        public virtual string ValidationName
        {
            get { return validationName; }
        }
        public virtual string Format
        {
            get { return format; }
        }
        public virtual string Element
        {
            get { return element; }
        }
        public virtual int SortOrder
        {
            get { return sortOrder; }
        }
    }
}
