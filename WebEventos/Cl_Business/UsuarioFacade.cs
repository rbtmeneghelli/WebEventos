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
    public class UsuarioFacade
    {
        public Resultado Insert(tbUsuario pUsuario)
        {
            return new UsuarioProcess().Insert(pUsuario);
        }

        public Resultado Update(tbUsuario pUsuario)
        {
            return new UsuarioProcess().Update(pUsuario);
        }

        public Resultado Delete(tbUsuario pUsuario)
        {
            return new UsuarioProcess().Delete(pUsuario);
        }

        public tbUsuario GetId(int pIdData, int pIdAction)
        {
            return new UsuarioProcess().GetId(pIdData, pIdAction);
        }

        public List<tbUsuario> GetAll()
        {
            return new UsuarioProcess().GetAll();
        }

        public Resultado EsqueciSenha(tbUsuario user)
        {
            return new UsuarioProcess().EsqueciSenha(user);
        }

    }
}
