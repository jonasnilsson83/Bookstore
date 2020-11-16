using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreData
{
    public class SqlParamValues
    {
        public ParameterDirection Direction { get; set; }
        public DbType Type { get; set; }
        public string Name { get; set; }
        public Object Value { get; set; }
    }
}
