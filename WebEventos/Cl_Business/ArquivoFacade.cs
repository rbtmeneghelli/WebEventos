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

        public Resultado UploadArquivo(tbArquivo pArquivo, string pPath)
        {
            return new ArquivoProcess().UploadArquivo(pArquivo, pPath);
        }

        public tbArquivo GetId(int pIdData, int pIdAction)
        {
            return new ArquivoProcess().GetId(pIdData, pIdAction);
        }

    }
}
