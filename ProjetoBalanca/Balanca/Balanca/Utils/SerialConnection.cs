using Balanca.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Xml.Linq;

namespace Balanca.Utils
{
    public class SerialConnection
    {
        #region Attributes

        private static readonly string _fileName = "ConfiguracoesPorta.xml";
        private static readonly string _filePath = ConfigurationManager.AppSettings["FileDirectoryPath"];
        private static readonly string _fullPath = $"{_filePath}\\{_fileName}";

        #endregion

        #region Methods

        /// <summary>
        /// Método abre a conexão com o serial para emular a balança
        /// </summary>
        /// <returns>Retorno dos dados do serial</returns>
        public static SerialPort InicializarConexao(SerialPort serialPort, out bool developerOptions, out string msgErroConexao)
        {
            developerOptions = false;
            msgErroConexao = string.Empty;

            try
            {
                if (PossuiConfiguracoesPorta())
                {
                    var configXML = XDocument.Load(_fullPath);
                    var nodeValues = from u in configXML.Descendants("PortConfig")
                                     select new
                                     {
                                         PortName = (string)u.Element("PortName"),
                                         BaudRate = (int)u.Element("BaudRate"),
                                         DataBits = (int)u.Element("DataBits"),
                                         ReadTimeout = (int)u.Element("ReadTimeout"),
                                         WriteTimeout = (int)u.Element("WriteTimeout"),
                                         NewLine = (string)u.Element("NewLine"),
                                         Parity = (string)u.Element("Parity"),
                                         StopBits = (string)u.Element("StopBits"),
                                         Handshake = (string)u.Element("Handshake"),
                                         DtrEnable = (bool)u.Element("DtrEnable"),
                                         DeveloperOptions = (bool)u.Element("DeveloperOptions")
                                     };

                    if (nodeValues != null)
                    {
                        foreach (var node in nodeValues)
                        {
                            developerOptions = node.DeveloperOptions;

                            serialPort.PortName = node.PortName;
                            serialPort.BaudRate = node.BaudRate;
                            serialPort.ReadTimeout = node.ReadTimeout;
                            serialPort.WriteTimeout = node.WriteTimeout;
                            serialPort.NewLine = node.NewLine;
                            serialPort.DtrEnable = node.DtrEnable;

                            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), node.Parity);
                            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), node.StopBits);
                            serialPort.Handshake = (Handshake)Enum.Parse(typeof(Parity), node.Handshake);
                        }
                    }

                    serialPort.Open();
                }           
            }
            catch (IOException)
            {
                msgErroConexao = $"Não foi possível estabelacer conexão com a porta '{serialPort.PortName}'";
            }
            catch (UnauthorizedAccessException)
            {
                msgErroConexao += $"Acesso não autorizado para a porta '{serialPort.PortName}'";
            }
            catch (InvalidOperationException)
            {
                msgErroConexao += $"Instância da porta '{serialPort.PortName}' já foi inicializada";
            }
            catch (Exception)
            {
                InicializarConexaoDefault(serialPort);
                msgErroConexao = $"Ocorreu um erro ao configurar as informações de conexão da porta '{serialPort.PortName}'";
            }

            return serialPort;
        }

        /// <summary>
        /// Método usado para iniciar a conexão da porta com valores default
        /// </summary>
        /// <returns>Retorno dos dados do serial</returns>
        private static void InicializarConexaoDefault(SerialPort serialPort)
        {
            try
            {
                serialPort.PortName = ConfigurationManager.AppSettings["PortName"];
                serialPort.BaudRate = int.Parse(ConfigurationManager.AppSettings["BaudRate"]);
                serialPort.DataBits = int.Parse(ConfigurationManager.AppSettings["DataBits"]);
                serialPort.ReadTimeout = int.Parse(ConfigurationManager.AppSettings["ReadTimeout"]);
                serialPort.WriteTimeout = int.Parse(ConfigurationManager.AppSettings["WriteTimeout"]);
                serialPort.NewLine = ConfigurationManager.AppSettings["NewLine"];

                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.Handshake = Handshake.None;
                serialPort.DtrEnable = true;

                serialPort.Open();
            }
            catch (IOException)
            {
                throw new IOException();
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Método encerra a conexão com o serial
        /// </summary>
        /// <returns>Retorno dos dados do serial</returns>
        public static SerialPort EncerrarConexao(SerialPort serialPort, out string msgErroConexao)
        {
            msgErroConexao = string.Empty;

            try
            {
                if (serialPort != null)
                    serialPort.Close();
            }
            catch (IOException)
            {
                msgErroConexao = $"Ocorreu um erro ao tentar encerrar a conexão com a porta '{serialPort.PortName}'";
            }
            catch (UnauthorizedAccessException)
            {
                msgErroConexao += $"Acesso não autorizado para a porta '{serialPort.PortName}'";
            }
            catch (InvalidOperationException)
            {
                msgErroConexao += $"Instância da porta '{serialPort.PortName}' já foi encerrada";
            }
            catch (Exception ex)
            {
                msgErroConexao = ex.InnerException.Message;
            }

            return serialPort;
        }

        /// <summary>
        /// Método usado para carregar as portas disponíveis para conexão
        /// </summary>
        /// <returns>Retorna todas as portas disponíveis para uso</returns>
        public static List<string> ListarPortasDisponiveis()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
                return portnames.ToList();
            }
        }

        /// <summary>
        /// Método utilizado para salvar as configurações de porta do usuário
        /// </summary>
        public static void SalvarConfiguracoesPorta(ConfiguracaoSerial configuracoes, out string msgErro)
        {
            try
            {
                msgErro = string.Empty;

                if (configuracoes != null)
                {
                    XDocument xmlSourceTree = new XDocument(
                        new XComment("Configurações do usuário - Conexão de porta"),
                        new XElement("PortConfig",
                            new XElement("PortName", configuracoes.PortName),
                            new XElement("DtrEnable", configuracoes.DtrEnable),
                            new XElement("BaudRate", configuracoes.BaudRate),
                            new XElement("DataBits", configuracoes.DataBits),
                            new XElement("ReadTimeout", configuracoes.ReadTimeout),
                            new XElement("WriteTimeout", configuracoes.WriteTimeout),
                            new XElement("NewLine", configuracoes.NewLine),
                            new XElement("Parity", configuracoes.Parity.ToString()),
                            new XElement("StopBits", configuracoes.StopBits.ToString()),
                            new XElement("Handshake", configuracoes.Handshake.ToString()),
                            new XElement("DeveloperOptions", false)
                        ));

                    if (!Directory.Exists(_filePath))
                        Directory.CreateDirectory(_filePath);

                    xmlSourceTree.Save(_fullPath);
                }
            }
            catch (Exception ex)
            {
                msgErro = ex.InnerException.Message;
                return;
            }
        }

        /// <summary>
        /// Método usado validar se o usuário possui o arquivo de configuração
        /// </summary>
        /// <returns>Retorno dos dados do serial</returns>
        public static bool PossuiConfiguracoesPorta()
        {
            if (File.Exists(_fullPath))
                return true;

            return false;
        }

        #endregion
    }
}