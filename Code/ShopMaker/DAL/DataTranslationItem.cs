using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaker.DAL
{
    public class DataTranslationItem
    {
        public object[] ResultSet { get; set; }
        public string[] DataTypeNames { get; set; }
        public Type[] Types { get; set; }
        public string[] ColumnNames { get; set; }
        private int _size;
        public int Size
        {
            get
            {
                return _size;
            }
        }

        public DataTranslationItem(int size)
        {
            ResultSet = new object[size];
            DataTypeNames = new string[size];
            Types = new Type[size];
            ColumnNames = new string[size];
            _size = size;
        }
    }
}
