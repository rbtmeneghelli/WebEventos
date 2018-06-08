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
    public class InstituicaoFacade
    {
        public Resultado Insert(tbInstituicao pInst)
        {
            return new InstituicaoProcess().Insert(pInst);
        }

        public Resultado Update(tbInstituicao pInst)
        {
            return new InstituicaoProcess().Update(pInst);
        }

        public Resultado Delete(tbInstituicao pInst)
        {
            return new InstituicaoProcess().Delete(pInst);
        }

        public tbInstituicao GetId(int pIdData, int pIdAction)
        {
            return new InstituicaoProcess().GetId(pIdData, pIdAction);
        }

        public List<tbInstituicao> GetAll()
        {
            return new InstituicaoProcess().GetAll();
        }
    }
}
