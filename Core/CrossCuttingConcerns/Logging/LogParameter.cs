using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogParameter
    {
        public string Name { get; set; } // örneğin product nesnemiz var, instanceye product dedik name budur
        public object Value { get; set; } // value, product nesnesi.. elma gibi..
        public string Type { get; set; } // product
    }
}
