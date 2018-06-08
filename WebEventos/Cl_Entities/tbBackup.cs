using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl_Entities
{
    public class tbBackup
    {
        public int tbBackup_Id { get; set; }
        public string tbBackup_Servidor { get; set; }
        public string tbBackup_Database { get; set; }
        public string tbBackup_Diretorio { get; set; }
        public DateTime tbBackup_Data { get; set; }
        public int tbBackup_IdUser { get; set; }
    }
}
