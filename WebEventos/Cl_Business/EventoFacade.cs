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
    public class EventoFacade
    {
        public Resultado Insert(tbEvento pEvento)
        {
            return new EventoProcess().Insert(pEvento);
        }

        public Resultado Update(tbEvento pEvento)
        {
            return new EventoProcess().Update(pEvento);
        }

        public Resultado Delete(tbEvento pEvento)
        {
            return new EventoProcess().Delete(pEvento);
        }

        public tbEvento GetId(int pIdData, int pIdAction)
        {
            return new EventoProcess().GetId(pIdData, pIdAction);
        }

        public List<tbEvento> GetAll()
        {
            return new EventoProcess().GetAll();
        }
    }
}
