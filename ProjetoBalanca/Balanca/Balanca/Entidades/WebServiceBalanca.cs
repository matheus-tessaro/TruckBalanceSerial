using Balanca.servicoBalanca;
using System.ServiceModel;

namespace Balanca.Entidades
{
    public class WebServiceBalanca
    {
        #region Attributes

        public wsBalancaSoapClient Servicos { get; }

        #endregion

        #region Constructor

        public WebServiceBalanca()
        {
            Servicos = new wsBalancaSoapClient();

            if (!string.IsNullOrEmpty(Parametros.urlServico))
                Servicos = new wsBalancaSoapClient(new BasicHttpBinding(), new EndpointAddress(Parametros.urlServico));
        }

        #endregion
    }
}