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
    public class AvaliacaoFacade
    {
        public Resultado Insert(tbAvaliacao pAval)
        {
            return new AvaliacaoProcess().Insert(pAval);
        }

        public Resultado Update(tbAvaliacao pAval)
        {
            return new AvaliacaoProcess().Update(pAval);
        }

        public Resultado Delete(tbAvaliacao pAval)
        {
            return new AvaliacaoProcess().Delete(pAval);
        }

        public tbAvaliacao GetId(int pIdData, int pIdAction)
        {
            return new AvaliacaoProcess().GetId(pIdData, pIdAction);
        }

        public List<tbAvaliacao> GetAll()
        {
            return new AvaliacaoProcess().GetAll();
        }
    }
}
