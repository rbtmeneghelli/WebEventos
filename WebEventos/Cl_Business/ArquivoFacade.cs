using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cl_Entities;
using Cl_Tools;
using Cl_Business.Process;

namespace Cl_Business
{
    public class ArquivoFacade
    {
        public Resultado Backup(tbBackup pBackup)
        {
            return new ArquivoProcess().Backup(pBackup);
        }

        public List<tbArquivo> GetAll()
        {
            return new ArquivoProcess().GetAll();
        }
    }
}
