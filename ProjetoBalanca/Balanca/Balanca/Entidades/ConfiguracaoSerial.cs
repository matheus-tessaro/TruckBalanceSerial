namespace Balanca.Entidades
{
    public class ConfiguracaoSerial
    {
        /// <summary>
        /// Atributo que armazena o nome da porta
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// Atributo que o valor do DTR
        /// </summary>
        public bool DtrEnable { get; set; }

        /// <summary>
        /// Atributo que armazena o valor da taxa de transmissão de dados
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// Atributo que armazena o valor dos databits
        /// </summary>
        public int DataBits { get; set; }

        /// <summary>
        /// Atributo que define o tempo para timeout
        /// </summary>
        public int ReadTimeout { get; set; }

        /// <summary>
        /// Atributo que define o tempo para timeout
        /// </summary>
        public int WriteTimeout { get; set; }

        /// <summary>
        /// Atributo que armazena o valor newline
        /// </summary>
        public string NewLine { get; set; }

        /// <summary>
        /// Atributo que define o valor da paridade de dados
        /// </summary>
        public string Parity { get; set; }

        /// <summary>
        /// Atributo que define os bits de parada
        /// </summary>
        public string StopBits { get; set; }

        /// <summary>
        /// Atributo que define o tipo de protocolo
        /// </summary>
        public string Handshake { get; set; }
    }
}