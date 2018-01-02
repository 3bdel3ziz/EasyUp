using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyUp.Core
{
    public class ContentField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Length { get; set; }
        public string ValidationExpression { get; set; }
        public int ContentTypeId { get; set; }
        public int DataTypeId { get; set; }
    }
}
