namespace Balanca.Entidades
{
    public class Parametros
    {
        /// <summary>
        /// Propriedade que define se o sistema utiliza serviço do windows para impressão
        /// </summary>
        public static bool utilizaServicoWindows { get; set; }

        /// <summary>
        /// Propriedade que define a url do serviço
        /// </summary>
        public static string urlServico { get; set; }

        /// <summary>
        /// Propriedade que define o usuário do serviço
        /// </summary>
        public static string usuarioServico { get; set; }

        /// <summary>
        /// Propriedade que define a senha do serviço
        /// </summary>
        public static string senhaServico { get; set; }
    }
}