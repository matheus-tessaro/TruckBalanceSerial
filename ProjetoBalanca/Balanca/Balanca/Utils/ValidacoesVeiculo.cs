using System.Text.RegularExpressions;

namespace Balanca.Utils
{
    public class ValidacoesVeiculo
    {
        #region Attributes

        private static readonly Regex regex = new Regex(@"^[a-zA-Z]{3}-\d{4}$");
        private static readonly Regex regexMercosul = new Regex(@"[a-zA-Z]{3}-[0-9]{1}[a-zA-Z0-9]{1}[0-9]{2}$");
        private static readonly Regex regexSemHifen = new Regex(@"^[a-zA-Z]{3}\d{4}$");
        private static readonly Regex regexSemHifenMercosul = new Regex(@"[a-zA-Z]{3}[0-9]{1}[a-zA-Z0-9]{1}[0-9]{2}$");

        #endregion

        #region Methods

        public static bool? ValidarPlaca(string placa, out string formatada)
        {
            formatada = string.Empty;

            if (!string.IsNullOrEmpty(placa))
            {
                if (placa.Length == 7 && !placa.Contains("-"))
                {
                    if (regexSemHifen.IsMatch(placa) || regexSemHifenMercosul.IsMatch(placa))
                    {
                        formatada = AjustarTextoPlaca(placa, false);
                        return true;
                    }
                    else
                        return false;
                }
                else if (placa.Length > 7 && !placa.Contains("-"))
                    return false;

                if (placa.Length == 8 && placa.Contains("-"))
                {
                    if (regex.IsMatch(placa) || regexMercosul.IsMatch(placa))
                    {
                        formatada = AjustarTextoPlaca(placa, true);
                        return true;
                    }
                    else
                        return false;
                }
                else if (placa.Length > 8 && placa.Contains("-"))
                    return false;
            }

            return null;
        }

        private static string AjustarTextoPlaca(string placa, bool possuiHifen)
        {
            if (!possuiHifen && (regexSemHifen.IsMatch(placa) || regexSemHifenMercosul.IsMatch(placa)))
            {
                return placa.ToUpper().Insert(3, "-");
            }

            return placa.ToUpper();
        }

        #endregion
    }
}