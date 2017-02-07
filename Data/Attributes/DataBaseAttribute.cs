using System;

namespace Data.Attributes
{
    public class DataBaseAttribute : Attribute
    {
        public readonly string DataBase;

        public DataBaseAttribute(string dataBase)
        {
            this.DataBase = dataBase;
        }
    }
}
