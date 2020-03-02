using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLComparionApps
{
    public class ResultDto
    {
        public Guid Id { get; set; }
        public string XPath { get; set; }
        public string Description { get; set; }
        public string DiffType { get; set; }
        public string DiffId { get; set; }
        public string NodeType { get; set; }
        public string ResultantOutput { get; set; }
        public string FromValue { get; set; }
        public string ToValue { get; set; }
        public ResultDto Parent { get; set; }
        public bool IsRootInsert { get; set; }
    }
}
