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
    public class PalestraFacade
    {
        public Resultado Insert(tbPalestra pPalestra)
        {
            return new PalestraProcess().Insert(pPalestra);
        }

        public Resultado Update(tbPalestra pPalestra)
        {
            return new PalestraProcess().Update(pPalestra);
        }

        public Resultado Delete(tbPalestra pPalestra)
        {
            return new PalestraProcess().Delete(pPalestra);
        }

        public tbPalestra GetId(int pIdData, int pIdAction)
        {
            return new PalestraProcess().GetId(pIdData, pIdAction);
        }

        public List<tbPalestra> GetAll()
        {
            return new PalestraProcess().GetAll();
        }
    }
}
