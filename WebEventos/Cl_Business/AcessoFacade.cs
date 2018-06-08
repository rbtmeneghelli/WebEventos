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
    public class AcessoFacade
    {
        public Resultado Insert(tbAcesso pAcesso)
        {
            return new AcessoProcess().Insert(pAcesso);
        }

        public Resultado Update(tbAcesso pAcesso)
        {
            return new AcessoProcess().Update(pAcesso);
        }

        public Resultado Delete(tbAcesso pAcesso)
        {
            return new AcessoProcess().Delete(pAcesso);
        }

        public tbAcesso GetId(int pIdData, int pIdAction)
        {
            return new AcessoProcess().GetId(pIdData, pIdAction);
        }

        public List<tbAcesso> GetAll()
        {
            return new AcessoProcess().GetAll();
        }
    }
}
