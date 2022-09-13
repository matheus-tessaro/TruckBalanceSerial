using Balanca.Controller;
using Balanca.Entidades;
using Balanca.servicoBalanca;
using Balanca.Utils;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Balanca
{
    public partial class Terminal : Form
    {
        #region Attributes

        /// <summary>
        /// Atributo que define se a placa informada se repete na lista
        /// </summary>
        private bool _developerOptions = false;

        /// <summary>
        /// Atributo que armazena o valor do tipo de operação
        /// </summary>
        private string _tipoOperacaoPesagem = "Entrada";

        /// <summary>
        /// Atributo que armazena o valor formatado informado pelo emulador da balança
        /// </summary>
        private string _rxString = "N/A";

        /// <summary>
        /// Atributo que armazena a placa do veículo
        /// </summary>
        private string _placaVeiculo = string.Empty;

        /// <summary>
        /// Atributo que armazena o valor do peso informado pela balança
        /// </summary>
        private decimal? _pesoBalanca = null;

        /// <summary>
        /// Atributo que define o objeto selecionado na grid
        /// </summary>
        private CadBalancaDTOBalanca _objetoSelecionadoGrid;

        /// <summary>
        /// Atributo que armazena a lista com as informações da balança/janela
        /// </summary>
        private List<CadBalancaDTOBalanca> _listaCadBalancaDTO;

        /// <summary>
        /// Atributo que define o controlador da balança
        /// </summary>
        private readonly ControllerBalanca _controllerBalanca;

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion

        #region Constructor

        public Terminal()
        {
            _controllerBalanca = new ControllerBalanca();
            _objetoSelecionadoGrid = new CadBalancaDTOBalanca();
            _listaCadBalancaDTO = new List<CadBalancaDTOBalanca>();

            InitializeComponent();

            if (!SerialConnection.PossuiConfiguracoesPorta())
                ConectorPortaToolStripMenuItem_Click(null, null);

            ListarJanelas(null, null);
            BtnConectarSerial_Click(null, null);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Método que recebe os dados vindos do emulador de balança
        /// </summary>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _rxString = serialPort.ReadExisting();
            _rxString = _rxString.Replace("\u00020", string.Empty);
            _rxString = _rxString.Replace("\u0003", string.Empty);
            _rxString = _rxString.Replace(".", ",");

            Invoke(new EventHandler(DisplayText));
        }

        /// <summary>
        /// Método que controla o evento do botão para efetuar a conexão com o SerialPort
        /// </summary>
        private void BtnConectarSerial_Click(object sender, EventArgs e)
        {
            var msgErroConexao = string.Empty;

            if (!serialPort.IsOpen)
                serialPort = SerialConnection.InicializarConexao(serialPort, out _developerOptions, out msgErroConexao);

            if (serialPort.IsOpen && string.IsNullOrEmpty(msgErroConexao))
            {
                btnConectarSerial.Enabled = false;
                btnEncerrarConexao.Enabled = true;
                btnEnviarDados.Enabled = true;
            }
            else
            {
                if (SerialConnection.PossuiConfiguracoesPorta())
                {
                    btnConectarSerial.Enabled = true;
                    btnEncerrarConexao.Enabled = false;

                    MessageBox.Show(msgErroConexao, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }         
        }

        /// <summary>
        /// Método que controla o evento do botão para encerrar a conexão com o SerialPort
        /// </summary>
        private void BtnEncerrarConexao_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                var msgErroConexao = string.Empty;
                serialPort = SerialConnection.EncerrarConexao(serialPort, out msgErroConexao);

                if (!serialPort.IsOpen && string.IsNullOrEmpty(msgErroConexao))
                {
                    btnConectarSerial.Enabled = true;
                    btnEncerrarConexao.Enabled = false;
                }
                else
                    MessageBox.Show(msgErroConexao, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Método que controla o evento do botão para enviar os dados da balança para o GTK
        /// </summary>
        private void btnEnviarDados_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var msgErro = string.Empty;

                if (_objetoSelecionadoGrid != null)
                    _controllerBalanca.SalvarPesoEntrada(_objetoSelecionadoGrid, (decimal)_pesoBalanca, _tipoOperacaoPesagem, out msgErro);
                else
                {
                    CadBalancaDTOBalanca dadosBalanca = _listaCadBalancaDTO.Where(x => x.PlacaVeiculo == _placaVeiculo).FirstOrDefault();

                    if (dadosBalanca != null)
                        _controllerBalanca.SalvarPesoEntrada(dadosBalanca, (decimal)_pesoBalanca, _tipoOperacaoPesagem, out msgErro);
                }

                if (!string.IsNullOrEmpty(msgErro))
                    MessageBox.Show(msgErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                else
                {
                    MessageBox.Show($"Peso de {_tipoOperacaoPesagem} foi registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    BtnLimparCampos_Click(null, null);
                }
            }
        }

        /// <summary>
        /// Método que controla o evento do botão para atualizar a grid de janelas
        /// </summary>
        private void BtnAtualizarListaJanelas_Click(object sender, EventArgs e)
        {
            DateTime? entradaPrevista = null;

            if (dtpDataEntradaPrevista.Enabled)
                entradaPrevista = dtpDataEntradaPrevista.Value.Date;

            ListarJanelas(entradaPrevista, txtFiltroPlaca.Text);
        }

        /// <summary>
        /// Método que seta os valores do formulário para o seu estado inicial
        /// </summary>
        private void BtnLimparCampos_Click(object sender, EventArgs e)
        {
            txtPlaca.Text = string.Empty;
            lblPesoEntrada.Text = "N/A";

            dtpDataEntradaPrevista.Value = DateTime.Now.Date;
            chkDesativarData.Checked = false;

            rbtEntrada.Checked = true;
            rbtSaida.Checked = false;

            _tipoOperacaoPesagem = "Entrada";
            _listaCadBalancaDTO = new List<CadBalancaDTOBalanca>();

            ListarJanelas(null, null);
        }

        /// <summary>
        /// Método que controla o evento do stripmenu
        /// </summary>
        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                string msgErroConexao;
                serialPort = SerialConnection.EncerrarConexao(serialPort, out msgErroConexao);

                if (!string.IsNullOrEmpty(msgErroConexao))
                    MessageBox.Show(msgErroConexao, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            Application.Exit();
        }

        /// <summary>
        /// Método que controla o evento de perda de foco no campo placa
        /// </summary>
        private void TxtFiltroPlaca_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFiltroPlaca.Text))
            {
                string formatada;
                bool? validacao = ValidacoesVeiculo.ValidarPlaca(txtFiltroPlaca.Text, out formatada);

                if (validacao != null)
                {
                    if ((bool)validacao && !string.IsNullOrEmpty(formatada))
                    {
                        _placaVeiculo = formatada;
                        txtFiltroPlaca.Text = formatada;
                        btnLimparCampos.Enabled = true;
                    }
                    else
                    {
                        txtFiltroPlaca.Text = string.Empty;
                        txtFiltroPlaca.Focus();

                        MessageBox.Show("A placa informada é inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        /// <summary>
        /// Método que controla se o sistema efetuará a pesquisa de janelas se baseando na data de entrada prevista
        /// </summary>
        private void ChkDesativarData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDesativarData.CheckState == CheckState.Checked)
                dtpDataEntradaPrevista.Enabled = false;
            else
                dtpDataEntradaPrevista.Enabled = true;
        }

        /// <summary>
        /// Método que controla o valor do radiobutton de entrada
        /// </summary>
        private void RbtEntrada_Click(object sender, EventArgs e)
        {
            _tipoOperacaoPesagem = "Entrada";

            if (rbtSaida.Checked)
                rbtSaida.Checked = false;
        }

        /// <summary>
        /// Método que controla o valor do radiobutton de saída
        /// </summary>
        private void RbtSaida_Click(object sender, EventArgs e)
        {
            _tipoOperacaoPesagem = "Saída";

            if (rbtEntrada.Checked)
                rbtEntrada.Checked = false;
        }

        /// <summary>
        /// Método que controla a linha selecionada na grid de janelas
        /// </summary>
        private void GrdJanelasDisponiveis_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridView dataGridViewObject = (DataGridView)sender;

                if (dataGridViewObject.SelectedCells.Count > 0)
                {
                    #region Dados da janela

                    int? idJanela = null;
                    int? idUnidOper = null;

                    string placa = string.Empty;
                    string motorista = string.Empty;

                    if (dataGridViewObject.SelectedCells[0].Value != null)
                        idJanela = int.Parse(dataGridViewObject.SelectedCells[0].Value.ToString());

                    if (dataGridViewObject.SelectedCells[1].Value != null)
                        idUnidOper = int.Parse(dataGridViewObject.SelectedCells[1].Value.ToString());

                    if (dataGridViewObject.SelectedCells[2].Value != null)
                        placa = dataGridViewObject.SelectedCells[2].Value.ToString();

                    if (dataGridViewObject.SelectedCells[3].Value != null)
                        motorista = dataGridViewObject.SelectedCells[3].Value.ToString();

                    #endregion

                    #region Data pesagem

                    DateTime? entradaPrevista = null;
                    DateTime? entradaReal = null;

                    if (dataGridViewObject.SelectedCells[4].Value != null)
                        entradaPrevista = DateTime.Parse(dataGridViewObject.SelectedCells[4].Value.ToString());

                    if (dataGridViewObject.SelectedCells[5].Value != null)
                        entradaReal = DateTime.Parse(dataGridViewObject.SelectedCells[5].Value.ToString());

                    #endregion

                    #region Dados pesagem balança

                    decimal? pesoEntrada = null;
                    decimal? pesoSaida = null;

                    decimal? pesoAcondicionado = null;
                    decimal? pesoLiquido = null;

                    if (!string.IsNullOrEmpty(dataGridViewObject.SelectedCells[6].Value.ToString()))
                        pesoEntrada = decimal.Parse(dataGridViewObject.SelectedCells[6].Value.ToString().Replace(" Kg", ""));

                    if (!string.IsNullOrEmpty(dataGridViewObject.SelectedCells[7].Value.ToString()))
                        pesoSaida = decimal.Parse(dataGridViewObject.SelectedCells[7].Value.ToString().Replace(" Kg", ""));

                    if (!string.IsNullOrEmpty(dataGridViewObject.SelectedCells[8].Value.ToString()))
                        pesoAcondicionado = decimal.Parse(dataGridViewObject.SelectedCells[8].Value.ToString().Replace(" Kg", ""));

                    if (!string.IsNullOrEmpty(dataGridViewObject.SelectedCells[9].Value.ToString()))
                        pesoLiquido = decimal.Parse(dataGridViewObject.SelectedCells[9].Value.ToString().Replace(" Kg", ""));

                    #endregion

                    _objetoSelecionadoGrid = new CadBalancaDTOBalanca()
                    {
                        IdPorJanela = idJanela ?? 0,
                        IdUnidadeOperacional = idUnidOper ?? 0,
                        PlacaVeiculo = placa,
                        Motorista = motorista,
                        DataEntradaPrevista = entradaPrevista,
                        DataEntradaReal = entradaReal,
                        PesoEntrada = pesoEntrada,
                        PesoSaida = pesoSaida,
                        PesoAcondicionado = pesoAcondicionado,
                        PesoLiquido = pesoLiquido
                    };

                    if (_objetoSelecionadoGrid != null)
                    {
                        _placaVeiculo = _objetoSelecionadoGrid.PlacaVeiculo;
                        txtPlaca.Text = _placaVeiculo;

                        btnEnviarDados.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Método que controla a exibição do painél de configurações
        /// </summary>
        private void ConectorPortaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarCombos();

            pnlConfiguracoesPorta.Visible = true;
            pnlConfiguracoesPorta.Enabled = true;

            if (!_developerOptions)
            {
                if (SerialConnection.PossuiConfiguracoesPorta())
                {
                    cboPort.Enabled = false;
                    cboBaudRate.Enabled = false;
                    cboParity.Enabled = false;
                    cboStopBits.Enabled = false;
                    cboHandshake.Enabled = false;
                    txtDataBits.Enabled = false;
                    txtDataBits.ReadOnly = true;
                    chkDTREnabled.Enabled = false;
                    chkDTRDisabled.Enabled = false;
                    btnSalvarConfiguracoes.Enabled = false;
                }
            }

            cboPort.Focus();
            pnlConfiguracoesPorta.BringToFront();
        }

        /// <summary>
        /// Método que chama o método para salvar as configurações de porta
        /// </summary>
        private void BtnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            try
            {
                var configuracoes = new ConfiguracaoSerial()
                {
                    PortName = cboPort.SelectedItem.ToString(),
                    BaudRate = int.Parse(cboBaudRate.SelectedItem.ToString()),
                    DataBits = int.Parse(txtDataBits.Text),
                    ReadTimeout = int.Parse(txtReadTimeout.Text),
                    WriteTimeout = int.Parse(txtWriteTimeout.Text),
                    NewLine = txtNewLine.Text,
                    DtrEnable = chkDTREnabled.Checked ? true : false,
                    Parity = cboParity.SelectedItem.ToString(),
                    StopBits = cboStopBits.SelectedItem.ToString(),
                    Handshake = cboHandshake.SelectedItem.ToString()
                };

                if (configuracoes != null)
                {
                    string msgErro;
                    SerialConnection.SalvarConfiguracoesPorta(configuracoes, out msgErro);

                    if (!string.IsNullOrEmpty(msgErro))
                    {
                        MessageBox.Show(msgErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        BtnCancelar_Click(null, null);
                        MessageBox.Show("Configurações salvas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Método que cancela o registro das configurações de porta
        /// </summary>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            pnlPesagem.Visible = true;
            pnlPesagem.Enabled = true;
            pnlPesagem.BringToFront();
        }

        /// <summary>
        /// Método que controla se o DRT é ativo
        /// </summary>
        private void CbxDTREnabled_Click(object sender, EventArgs e)
        {
            if (chkDTRDisabled.Checked)
                chkDTRDisabled.Checked = false;

            chkDTREnabled.Checked = true;
        }

        /// <summary>
        /// Método que controla se o DRT é inativo
        /// </summary>
        private void CbxDTRDisabled_Click(object sender, EventArgs e)
        {
            if (chkDTREnabled.Checked)
                chkDTREnabled.Checked = false;

            chkDTRDisabled.Checked = true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Método que executa a chamada para o GTK com a finalidade de listar as janelas em aberto
        /// </summary>
        private void ListarJanelas(DateTime? dataEntradaPrevista, string placaVeiculo)
        {
            string msgErro = string.Empty;
            _listaCadBalancaDTO = _controllerBalanca.BuscarJanelasAbertas(dataEntradaPrevista, placaVeiculo, out msgErro);

            if (!string.IsNullOrEmpty(msgErro))
                MessageBox.Show(msgErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            MontarGrid();
        }

        /// <summary>
        /// Método que seta o valor do formatado do serial na tela
        /// </summary>
        private void DisplayText(object sender, EventArgs e)
        {
            decimal valor;

            if (decimal.TryParse(_rxString, out valor))
            {
                valor = Convert.ToDecimal(_rxString);
                var resultado = (valor / 1000);

                _pesoBalanca = resultado;
                lblPesoEntrada.Text = $"{resultado.ToString("0.000")} Kg";
            }
            else
            {
                lblPesoEntrada.Text = "N/A";
            }
        }

        /// <summary>
        /// Método que monta a grid com as janelas em aberto
        /// </summary>
        private void MontarGrid()
        {
            if (_listaCadBalancaDTO != null && _listaCadBalancaDTO.Any())
            {
                List<object> listaCadBalanca = (from lista in _listaCadBalancaDTO
                                       select new
                                       {
                                           lista.IdPorJanela,
                                           lista.IdUnidadeOperacional,
                                           Placa = lista.PlacaVeiculo,
                                           lista.Motorista,
                                           EntradaPrevista = lista.DataEntradaPrevista,
                                           EntradaReal = lista.DataEntradaReal,
                                           PesoEntrada = lista.PesoEntrada != null ? $"{lista.PesoEntrada} Kg" : lista.PesoEntrada.ToString(),
                                           PesoSaida = lista.PesoSaida != null ? $"{lista.PesoSaida} Kg" : lista.PesoSaida.ToString(),
                                           Acondicionado = lista.PesoAcondicionado != null ? $"{lista.PesoAcondicionado} Kg" : lista.PesoAcondicionado.ToString(),
                                           PesoLiquido = lista.PesoLiquido != null ? $"{lista.PesoLiquido} Kg" : lista.PesoLiquido.ToString()
                                       }).Distinct().Cast<object>().ToList();

                grdJanelasDisponiveis.DataSource = listaCadBalanca;

                grdJanelasDisponiveis.Columns[0].Visible = false;
                grdJanelasDisponiveis.Columns[1].Visible = false;
            }
            else
            {
                grdJanelasDisponiveis.DataSource = null;
                MessageBox.Show("Nenhum resultado encontrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Método que valida o formulário
        /// </summary>
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(_placaVeiculo) && _objetoSelecionadoGrid == null)
            {
                MessageBox.Show("Obrigatório informar a placa do veículo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }

            if (_objetoSelecionadoGrid == null)
            {
                MessageBox.Show("Obrigatório selecionar um item na lista!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }

            if (_pesoBalanca == null)
            {
                MessageBox.Show("Obrigatório informar o peso da balança!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método que monta todos os combobox da tela de configuração
        /// </summary>
        private void InicializarCombos()
        {
            List<string> portasDisponiveis = SerialConnection.ListarPortasDisponiveis();

            if (!string.IsNullOrEmpty(serialPort.PortName) && !portasDisponiveis.Contains(serialPort.PortName))
                portasDisponiveis.Add(serialPort.PortName);

            cboPort.DataSource = portasDisponiveis;
            cboBaudRate.DataSource = new List<string>() { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            cboParity.DataSource = Enum.GetValues(typeof(Parity));
            cboStopBits.DataSource = Enum.GetValues(typeof(StopBits));
            cboHandshake.DataSource = Enum.GetValues(typeof(Handshake));

            if (SerialConnection.PossuiConfiguracoesPorta())
            {
                cboPort.SelectedItem = serialPort.PortName;
                cboBaudRate.SelectedIndex = cboBaudRate.FindStringExact(serialPort.BaudRate.ToString());
                cboParity.SelectedItem = serialPort.Parity;
                cboStopBits.SelectedItem = serialPort.StopBits;
                cboHandshake.SelectedItem = serialPort.Handshake;

                txtDataBits.Text = serialPort.DataBits.ToString();
                txtNewLine.Text = serialPort.NewLine;
                txtReadTimeout.Text = serialPort.ReadTimeout.ToString();
                txtWriteTimeout.Text = serialPort.WriteTimeout.ToString();

                if (serialPort.DtrEnable)
                {
                    chkDTREnabled.Checked = true;
                    chkDTRDisabled.Checked = false;
                }
                else
                {
                    chkDTREnabled.Checked = false;
                    chkDTRDisabled.Checked = true;
                }        
            }
        }

        #endregion
    }
}