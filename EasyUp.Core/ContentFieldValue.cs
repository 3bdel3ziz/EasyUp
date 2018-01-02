using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyUp.Core
{
    public class ContentFieldValue
    {
        public int Id { get; set; }
        public int ContentFieldId { get; set; }
        public int NumericValue { get; set; }
        public string SingleLineValue { get; set; }
        public string MultiLineValue { get; set; }
        public Boolean BooleanValue { get; set; }

    }
}
