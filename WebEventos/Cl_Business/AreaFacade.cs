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
    public class AreaFacade
    {
        public Resultado Insert(tbArea pArea)
        {
            return new AreaProcess().Insert(pArea);
        }

        public Resultado Update(tbArea pArea)
        {
            return new AreaProcess().Update(pArea);
        }

        public Resultado Delete(tbArea pArea)
        {
            return new AreaProcess().Delete(pArea);
        }

        public tbArea GetId(int pIdData, int pIdAction)
        {
            return new AreaProcess().GetId(pIdData, pIdAction);
        }

        public List<tbArea> GetAll()
        {
            return new AreaProcess().GetAll();
        }
    }
}
