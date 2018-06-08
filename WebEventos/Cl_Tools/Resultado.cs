using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl_Tools
{
    public class Resultado
    {
        public string PageName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string ExceptionMsg { get; set; }
        public bool ResultAction { get; set; }
        public DateTime DateAction { get; set; }
        public int IdUserAction { get; set; }
    }
}
