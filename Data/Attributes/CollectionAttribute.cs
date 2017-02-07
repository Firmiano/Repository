using System;

namespace Data.Attributes
{
    public class CollectionAttribute : Attribute
    {
        public string Collection { get; set; }

        public CollectionAttribute(string collection)
        {
            this.Collection = collection;
        }
    }
}
