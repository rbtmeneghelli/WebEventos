using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Runtime.Serialization.Json;
using Cl_Tools;

namespace Cl_Tools
{
    public class Util
    {
        //Expressão regular retirada de https://msdn.microsoft.com/pt-br/library/01escwtf(v=vs.110).aspx
        public static bool validarEmail(string email)
        {
            bool emailValido = false;

            string emailRegex = string.Format("{0}{1}",
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            try
            {
                emailValido = Regex.IsMatch(email, emailRegex);
            }
            catch (RegexMatchTimeoutException)
            {
                emailValido = false;
            }

            return emailValido;
        }

        //Expressão regular para verificar CPF\CNPJ valido https://social.msdn.microsoft.com/Forums/pt-BR/15115947-b137-4533-92ef-856102787d4a/customvalidator-pra-validar-cpf-e-cnpj-com-javascript?forum=aspnetpt

        public static bool ValidarCPF(string vrCPF)
        {
            bool igual = true;
            string valor = vrCPF.Replace(".", "").Replace("-", "");

            if (valor.Length != 11)
                return false;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];



            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }

            else
                if (numeros[10] != 11 - resultado)
                    return false;

            return true;

        }

        public static bool ValidarCNPJ(string vrCNPJ)
        {

            string CNPJ = vrCNPJ.Replace(".", "").Replace("/", "").Replace("-", "");

            int[] digitos, soma, resultado;

            int nrDig;

            string ftmt;

            bool[] CNPJOk;

            ftmt = "6543298765432";

            digitos = new int[14];

            soma = new int[2];

            soma[0] = 0;

            soma[1] = 0;

            resultado = new int[2];

            resultado[0] = 0;

            resultado[1] = 0;

            CNPJOk = new bool[2];

            CNPJOk[0] = false;

            CNPJOk[1] = false;

            try
            {

                for (nrDig = 0; nrDig < 14; nrDig++)
                {

                    digitos[nrDig] = int.Parse(

                        CNPJ.Substring(nrDig, 1));

                    if (nrDig <= 11)

                        soma[0] += (digitos[nrDig] *

                          int.Parse(ftmt.Substring(

                          nrDig + 1, 1)));

                    if (nrDig <= 12)

                        soma[1] += (digitos[nrDig] *

                          int.Parse(ftmt.Substring(

                          nrDig, 1)));

                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {

                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (

                         resultado[nrDig] == 1))

                        CNPJOk[nrDig] = (

                        digitos[12 + nrDig] == 0);

                    else

                        CNPJOk[nrDig] = (

                        digitos[12 + nrDig] == (

                        11 - resultado[nrDig]));

                }

                return (CNPJOk[0] && CNPJOk[1]);

            }

            catch
            {
                return false;
            }

        }

        public static string BuildPassword()
        {
            Random numero = new Random();
            string letras = "ABCDEFGHIJKLMNOPQRSTUVYWXZ";
            string password = string.Empty;

            password = string.Format("{0}{1}{2}{3}{4}", letras.Substring(numero.Next(0, 25), 1), numero.Next(0, 9), letras.Substring(numero.Next(0, 25), 1), numero.Next(0, 9), letras.Substring(numero.Next(0, 25), 1));

            return password;
        }

        public static void GravaLog(Resultado resultado)
        {
            string diretorio = ConfigurationManager.AppSettings["LogPath"];
            string arqLog = string.Format("{0}{1}{2}{3}{4}", diretorio, "\\", "Proenergy_", DateTime.Now.ToString("ddMMyyyy"), ".txt");

            try
            {
                if (!Directory.Exists(diretorio))
                    Directory.CreateDirectory(diretorio);

                if (File.Exists(arqLog))
                {
                    using (StreamWriter sw = File.AppendText(arqLog))
                    {
                        var texto = string.Format("Page:{0:d} Class:{1} Method:{2} Error:{3} Date:{4} Result:{5} IdUser:{6}", resultado.PageName, resultado.ClassName, resultado.MethodName, resultado.ExceptionMsg, resultado.DateAction, resultado.ResultAction, resultado.IdUserAction);
                        sw.WriteLine(texto);
                    }
                }

                else
                {
                    using (StreamWriter sw = File.AppendText(arqLog))
                    {
                        var texto = string.Format("Page:{0:d} Class:{1} Method:{2} Error:{3} Date:{4} Result:{5} IdUser:{6}", resultado.PageName, resultado.ClassName, resultado.MethodName, resultado.ExceptionMsg, resultado.DateAction, resultado.ResultAction, resultado.IdUserAction);
                        sw.WriteLine(texto);
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static Cep LocalizarCEP(string pCep)
        {
            Cep DadosCep = new Cep();

            //try
            //{
            //    if (!string.IsNullOrWhiteSpace(pCep))
            //    {
            //        var ws = new WsCorreios.AtendeClienteClient();
            //        var endereco = ws.consultaCEP(pCep);

            //        if (endereco != null)
            //        {
            //            DadosCep.Endereco = endereco.end;
            //            DadosCep.Cidade = endereco.cidade;
            //            DadosCep.Bairro = endereco.bairro;
            //            DadosCep.Estado = endereco.uf;
            //        }
            //    }
            //}

            //catch (Exception ex)
            //{
            //    return null;
            //}

            return DadosCep;
        }

        public static void EnviarEmail(string pFrom, string pTo, string pSubject, string pText, Array pAnex = null)
        {
            //
            string MailHost = ConfigurationManager.AppSettings["MailHost"].ToString();
            int MailPort = int.Parse(ConfigurationManager.AppSettings["MailPort"].ToString());
            string MailUser = ConfigurationManager.AppSettings["MailUser"].ToString(); //.Replace("@", "=");
            string MailPassword = ConfigurationManager.AppSettings["MailPassword"].ToString().Replace("_", "&");

            string sBody = string.Empty;
            //
            pFrom = string.IsNullOrEmpty(pFrom) ? MailUser : pFrom;

            //var text = HttpUtility.HtmlEncode(pText);

            MailMessage mm = new MailMessage { From = new MailAddress(pFrom, "Energia - Administrador") };

            mm.To.Add(new MailAddress(pTo));
            mm.Subject = pSubject;
            //mm.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(pText, null, MediaTypeNames.Text.Plain));
            //mm.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(pText, null, MediaTypeNames.Text.Html));

            //System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(pFrom, pTo);
            //
            mm.Priority = MailPriority.High;
            mm.IsBodyHtml = true;

            //codificação do assunto e corpo do email para que os caracteres acentuados serem reconhecidos.
            mm.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            mm.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            foreach (char l in pText)
            {
                if (char.GetUnicodeCategory(l) == System.Globalization.UnicodeCategory.Control |
                    char.GetUnicodeCategory(l) == System.Globalization.UnicodeCategory.ParagraphSeparator |
                    char.GetUnicodeCategory(l) == System.Globalization.UnicodeCategory.LineSeparator)
                {
                    sBody += "<br>";
                }
                else
                {
                    sBody += l;
                }
            }

            //
            mm.Body = sBody;
            //

            if ((pAnex != null) && pAnex.Length > 0)
            {
                foreach (string anx in pAnex)
                {
                    Attachment attached = new Attachment(anx, MediaTypeNames.Application.Octet);
                    mm.Attachments.Add(attached);
                }
                //
            }

            //
            SmtpClient clientMail = new SmtpClient(MailHost, MailPort);

            //clientMail = New Net.Mail.SmtpClient(pSrvSMTP)
            //
            //clientMail.UseDefaultCredentials = false;
            //clientMail.UseDefaultCredentials = True;
            clientMail.EnableSsl = true;
            //
            if (MailUser.Contains("@habiltecnologia"))
                MailUser = MailUser.Replace("@", "=");

            clientMail.Credentials = new NetworkCredential(MailUser, MailPassword);
            //
            clientMail.Send(mm);
            //'
        }

        // C# - Testando cada elemento em um Array ou List<T> com TrueForAll (http://www.macoratti.net/17/01/c_tstlist1.htm)
        public static void ValidaItensLista()
        {
            // Cria uma lista de strings
            List<string> nomes = new List<string>() { "Macoratti", "Visual C#", null, ".NET", "2017" };
            // Determina se existe um valor null na lista
            string str = nomes.TrueForAll(delegate(string val)
            {
                if (val == null)
                    return false;
                else
                    return true;
            }).ToString();
            // exibe o resultado
            Console.WriteLine("Todos os valores da lista são diferentes de null ? Resposta = {0}", str);
        }

        public static void ValidaItensArray()
        {
            //cria uma lista de numeros inteiros
            var numeros = new List<int>() { 4, 6, 7, 8, 34, 33, 11 };
            //verifica se existe um valor menor ou igual a zero
            var isTrue = numeros.TrueForAll(n => n > 0);
            Console.WriteLine("Todos os valores da lista são diferentes de zero ? Resposta = {0}", isTrue);
        }

        public static bool ValidaTelefoneCelular(string pStNumeros)
        {
            string[] stDigitoMovel = new string[] { "6", "7", "8", "9" };
            string[] stDigitosFixo = new string[] { "1", "2", "3", "4", "5" };

            if (!string.IsNullOrWhiteSpace(pStNumeros) && pStNumeros.Length > 5)
            {
                if (pStNumeros.Length < 13 && stDigitoMovel.Contains(pStNumeros.Substring(5, 1)))
                    return true;

                else if (pStNumeros.Length < 14 && stDigitosFixo.Contains(pStNumeros.Substring(5, 1)))
                    return true;
            }

            return false;
        }

        //C# - Converter de JSON para Object e vice-versa (http://www.macoratti.net/16/07/c_jsonob1.htm)
        public string ConverteObjectParaJSon<T>(T obj)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream();
                ser.WriteObject(ms, obj);
                string jsonString = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return jsonString;
            }
            catch
            {
                throw;
            }
        }

        public T ConverteJSonParaObject<T>(string jsonString)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
                T obj = (T)serializer.ReadObject(ms);
                return obj;
            }
            catch
            {
                throw;
            }
        }

        //Gerador de arquivo Zip(http://www.macoratti.net/15/05/c_zip1.htm)
        //Biblioteca DotNetZip or SharpZipLib.
    }
}
