using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl_Tools
{
    public class Mensagem
    {
        #region Atributos
        private string m_campo;
        private List<string> m_descricoes;
        #endregion

        #region Propriedades
        /// <summary>
        /// Nome do campo a ser validado
        /// </summary>
        public string Campo
        {
            get { return m_campo; }
            set { m_campo = value; }
        }

        /// <summary>
        /// Lista de menssagens de validação
        /// </summary>
        public List<string> Descricoes
        {
            get { return m_descricoes; }
            set { m_descricoes = value; }
        }

        public string Metodo { get; set; }

        public string Pagina { get; set; }

        #endregion

        #region Construtores
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public Mensagem()
        {
            this.m_descricoes = new List<string>();
            this.m_campo = string.Empty;
        }
        #endregion

        #region Métodos Estáticos
        public static Mensagem Cria(string campo, string descricao)
        {
            Mensagem m = new Mensagem();
            m.Campo = campo;
            m.Descricoes.Add(descricao);

            return m;
        }
        #endregion
    }
}