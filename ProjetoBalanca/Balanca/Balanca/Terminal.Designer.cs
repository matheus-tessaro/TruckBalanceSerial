using System.Collections.Generic;

namespace Balanca
{
    partial class Terminal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.applicationMenu = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectorPortaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPesagem = new System.Windows.Forms.Panel();
            this.gbxVeiculoBalanca = new System.Windows.Forms.GroupBox();
            this.rbtSaida = new System.Windows.Forms.RadioButton();
            this.rbtEntrada = new System.Windows.Forms.RadioButton();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblPesoEntrada = new System.Windows.Forms.Label();
            this.gbxFiltrosPesquisa = new System.Windows.Forms.GroupBox();
            this.txtFiltroPlaca = new System.Windows.Forms.TextBox();
            this.lblFiltroPlaca = new System.Windows.Forms.Label();
            this.chkDesativarData = new System.Windows.Forms.CheckBox();
            this.dtpDataEntradaPrevista = new System.Windows.Forms.DateTimePicker();
            this.lblEntradaPrevista = new System.Windows.Forms.Label();
            this.btnAtualizarListaJanelas = new System.Windows.Forms.Button();
            this.btnEncerrarConexao = new System.Windows.Forms.Button();
            this.btnConectarSerial = new System.Windows.Forms.Button();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.lblJanelasDisponiveis = new System.Windows.Forms.Label();
            this.grdJanelasDisponiveis = new System.Windows.Forms.DataGridView();
            this.btnEnviarDados = new System.Windows.Forms.Button();
            this.pnlConfiguracoesPorta = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvarConfiguracoes = new System.Windows.Forms.Button();
            this.cbxConfig2 = new System.Windows.Forms.GroupBox();
            this.chkDTRDisabled = new System.Windows.Forms.CheckBox();
            this.chkDTREnabled = new System.Windows.Forms.CheckBox();
            this.cboHandshake = new System.Windows.Forms.ComboBox();
            this.lblDTR = new System.Windows.Forms.Label();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.lblParity = new System.Windows.Forms.Label();
            this.lblHandshake = new System.Windows.Forms.Label();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.gbxConfig = new System.Windows.Forms.GroupBox();
            this.txtNewLine = new System.Windows.Forms.TextBox();
            this.lblNewLine = new System.Windows.Forms.Label();
            this.txtDataBits = new System.Windows.Forms.TextBox();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cboConfgTimeout = new System.Windows.Forms.GroupBox();
            this.txtWriteTimeout = new System.Windows.Forms.TextBox();
            this.lblWriteTimeout = new System.Windows.Forms.Label();
            this.txtReadTimeout = new System.Windows.Forms.TextBox();
            this.lblReadTimeout = new System.Windows.Forms.Label();
            this.lblConfiguracoesConexao = new System.Windows.Forms.Label();
            this.applicationMenu.SuspendLayout();
            this.pnlPesagem.SuspendLayout();
            this.gbxVeiculoBalanca.SuspendLayout();
            this.gbxFiltrosPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJanelasDisponiveis)).BeginInit();
            this.pnlConfiguracoesPorta.SuspendLayout();
            this.cbxConfig2.SuspendLayout();
            this.gbxConfig.SuspendLayout();
            this.cboConfgTimeout.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 4800;
            this.serialPort.PortName = "COM3";
            this.serialPort.RtsEnable = true;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // applicationMenu
            // 
            this.applicationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.configuraçõesToolStripMenuItem});
            resources.ApplyResources(this.applicationMenu, "applicationMenu");
            this.applicationMenu.Name = "applicationMenu";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            resources.ApplyResources(this.sistemaToolStripMenuItem, "sistemaToolStripMenuItem");
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            resources.ApplyResources(this.sairToolStripMenuItem, "sairToolStripMenuItem");
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.SairToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectorPortaToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            resources.ApplyResources(this.configuraçõesToolStripMenuItem, "configuraçõesToolStripMenuItem");
            // 
            // conectorPortaToolStripMenuItem
            // 
            this.conectorPortaToolStripMenuItem.Name = "conectorPortaToolStripMenuItem";
            resources.ApplyResources(this.conectorPortaToolStripMenuItem, "conectorPortaToolStripMenuItem");
            this.conectorPortaToolStripMenuItem.Click += new System.EventHandler(this.ConectorPortaToolStripMenuItem_Click);
            // 
            // pnlPesagem
            // 
            this.pnlPesagem.Controls.Add(this.gbxVeiculoBalanca);
            this.pnlPesagem.Controls.Add(this.gbxFiltrosPesquisa);
            this.pnlPesagem.Controls.Add(this.btnEncerrarConexao);
            this.pnlPesagem.Controls.Add(this.btnConectarSerial);
            this.pnlPesagem.Controls.Add(this.btnLimparCampos);
            this.pnlPesagem.Controls.Add(this.lblJanelasDisponiveis);
            this.pnlPesagem.Controls.Add(this.grdJanelasDisponiveis);
            this.pnlPesagem.Controls.Add(this.btnEnviarDados);
            resources.ApplyResources(this.pnlPesagem, "pnlPesagem");
            this.pnlPesagem.Name = "pnlPesagem";
            // 
            // gbxVeiculoBalanca
            // 
            this.gbxVeiculoBalanca.Controls.Add(this.rbtSaida);
            this.gbxVeiculoBalanca.Controls.Add(this.rbtEntrada);
            this.gbxVeiculoBalanca.Controls.Add(this.lblPlaca);
            this.gbxVeiculoBalanca.Controls.Add(this.txtPlaca);
            this.gbxVeiculoBalanca.Controls.Add(this.lblPeso);
            this.gbxVeiculoBalanca.Controls.Add(this.lblPesoEntrada);
            resources.ApplyResources(this.gbxVeiculoBalanca, "gbxVeiculoBalanca");
            this.gbxVeiculoBalanca.Name = "gbxVeiculoBalanca";
            this.gbxVeiculoBalanca.TabStop = false;
            // 
            // rbtSaida
            // 
            resources.ApplyResources(this.rbtSaida, "rbtSaida");
            this.rbtSaida.Name = "rbtSaida";
            this.rbtSaida.TabStop = true;
            this.rbtSaida.UseVisualStyleBackColor = true;
            this.rbtSaida.Click += new System.EventHandler(this.RbtSaida_Click);
            // 
            // rbtEntrada
            // 
            resources.ApplyResources(this.rbtEntrada, "rbtEntrada");
            this.rbtEntrada.BackColor = System.Drawing.SystemColors.Control;
            this.rbtEntrada.Checked = true;
            this.rbtEntrada.Name = "rbtEntrada";
            this.rbtEntrada.TabStop = true;
            this.rbtEntrada.UseVisualStyleBackColor = false;
            this.rbtEntrada.Click += new System.EventHandler(this.RbtEntrada_Click);
            // 
            // lblPlaca
            // 
            resources.ApplyResources(this.lblPlaca, "lblPlaca");
            this.lblPlaca.Name = "lblPlaca";
            // 
            // txtPlaca
            // 
            resources.ApplyResources(this.txtPlaca, "txtPlaca");
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.ReadOnly = true;
            // 
            // lblPeso
            // 
            resources.ApplyResources(this.lblPeso, "lblPeso");
            this.lblPeso.Name = "lblPeso";
            // 
            // lblPesoEntrada
            // 
            resources.ApplyResources(this.lblPesoEntrada, "lblPesoEntrada");
            this.lblPesoEntrada.Name = "lblPesoEntrada";
            // 
            // gbxFiltrosPesquisa
            // 
            this.gbxFiltrosPesquisa.Controls.Add(this.txtFiltroPlaca);
            this.gbxFiltrosPesquisa.Controls.Add(this.lblFiltroPlaca);
            this.gbxFiltrosPesquisa.Controls.Add(this.chkDesativarData);
            this.gbxFiltrosPesquisa.Controls.Add(this.dtpDataEntradaPrevista);
            this.gbxFiltrosPesquisa.Controls.Add(this.lblEntradaPrevista);
            this.gbxFiltrosPesquisa.Controls.Add(this.btnAtualizarListaJanelas);
            resources.ApplyResources(this.gbxFiltrosPesquisa, "gbxFiltrosPesquisa");
            this.gbxFiltrosPesquisa.Name = "gbxFiltrosPesquisa";
            this.gbxFiltrosPesquisa.TabStop = false;
            // 
            // txtFiltroPlaca
            // 
            resources.ApplyResources(this.txtFiltroPlaca, "txtFiltroPlaca");
            this.txtFiltroPlaca.Name = "txtFiltroPlaca";
            this.txtFiltroPlaca.Leave += new System.EventHandler(this.TxtFiltroPlaca_Leave);
            // 
            // lblFiltroPlaca
            // 
            resources.ApplyResources(this.lblFiltroPlaca, "lblFiltroPlaca");
            this.lblFiltroPlaca.Name = "lblFiltroPlaca";
            // 
            // chkDesativarData
            // 
            resources.ApplyResources(this.chkDesativarData, "chkDesativarData");
            this.chkDesativarData.Name = "chkDesativarData";
            this.chkDesativarData.UseVisualStyleBackColor = true;
            this.chkDesativarData.CheckedChanged += new System.EventHandler(this.ChkDesativarData_CheckedChanged);
            // 
            // dtpDataEntradaPrevista
            // 
            resources.ApplyResources(this.dtpDataEntradaPrevista, "dtpDataEntradaPrevista");
            this.dtpDataEntradaPrevista.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataEntradaPrevista.Name = "dtpDataEntradaPrevista";
            // 
            // lblEntradaPrevista
            // 
            resources.ApplyResources(this.lblEntradaPrevista, "lblEntradaPrevista");
            this.lblEntradaPrevista.Name = "lblEntradaPrevista";
            // 
            // btnAtualizarListaJanelas
            // 
            resources.ApplyResources(this.btnAtualizarListaJanelas, "btnAtualizarListaJanelas");
            this.btnAtualizarListaJanelas.Image = global::Balanca.Properties.Resources.ico_refresh;
            this.btnAtualizarListaJanelas.Name = "btnAtualizarListaJanelas";
            this.btnAtualizarListaJanelas.UseVisualStyleBackColor = true;
            this.btnAtualizarListaJanelas.Click += new System.EventHandler(this.BtnAtualizarListaJanelas_Click);
            // 
            // btnEncerrarConexao
            // 
            this.btnEncerrarConexao.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnEncerrarConexao, "btnEncerrarConexao");
            this.btnEncerrarConexao.ForeColor = System.Drawing.Color.Red;
            this.btnEncerrarConexao.Name = "btnEncerrarConexao";
            this.btnEncerrarConexao.UseVisualStyleBackColor = true;
            this.btnEncerrarConexao.Click += new System.EventHandler(this.BtnEncerrarConexao_Click);
            // 
            // btnConectarSerial
            // 
            resources.ApplyResources(this.btnConectarSerial, "btnConectarSerial");
            this.btnConectarSerial.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnConectarSerial.ForeColor = System.Drawing.Color.Green;
            this.btnConectarSerial.Name = "btnConectarSerial";
            this.btnConectarSerial.UseVisualStyleBackColor = true;
            this.btnConectarSerial.Click += new System.EventHandler(this.BtnConectarSerial_Click);
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnLimparCampos, "btnLimparCampos");
            this.btnLimparCampos.ForeColor = System.Drawing.Color.Red;
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.BtnLimparCampos_Click);
            // 
            // lblJanelasDisponiveis
            // 
            resources.ApplyResources(this.lblJanelasDisponiveis, "lblJanelasDisponiveis");
            this.lblJanelasDisponiveis.Name = "lblJanelasDisponiveis";
            // 
            // grdJanelasDisponiveis
            // 
            this.grdJanelasDisponiveis.AllowUserToAddRows = false;
            this.grdJanelasDisponiveis.AllowUserToDeleteRows = false;
            this.grdJanelasDisponiveis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdJanelasDisponiveis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.grdJanelasDisponiveis, "grdJanelasDisponiveis");
            this.grdJanelasDisponiveis.MultiSelect = false;
            this.grdJanelasDisponiveis.Name = "grdJanelasDisponiveis";
            this.grdJanelasDisponiveis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdJanelasDisponiveis.SelectionChanged += new System.EventHandler(this.GrdJanelasDisponiveis_SelectionChanged);
            // 
            // btnEnviarDados
            // 
            this.btnEnviarDados.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.btnEnviarDados, "btnEnviarDados");
            this.btnEnviarDados.ForeColor = System.Drawing.Color.Green;
            this.btnEnviarDados.Name = "btnEnviarDados";
            this.btnEnviarDados.UseVisualStyleBackColor = true;
            this.btnEnviarDados.Click += new System.EventHandler(this.btnEnviarDados_Click);
            // 
            // pnlConfiguracoesPorta
            // 
            this.pnlConfiguracoesPorta.Controls.Add(this.btnCancelar);
            this.pnlConfiguracoesPorta.Controls.Add(this.btnSalvarConfiguracoes);
            this.pnlConfiguracoesPorta.Controls.Add(this.cbxConfig2);
            this.pnlConfiguracoesPorta.Controls.Add(this.gbxConfig);
            this.pnlConfiguracoesPorta.Controls.Add(this.cboConfgTimeout);
            this.pnlConfiguracoesPorta.Controls.Add(this.lblConfiguracoesConexao);
            resources.ApplyResources(this.pnlConfiguracoesPorta, "pnlConfiguracoesPorta");
            this.pnlConfiguracoesPorta.Name = "pnlConfiguracoesPorta";
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnSalvarConfiguracoes
            // 
            this.btnSalvarConfiguracoes.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.btnSalvarConfiguracoes, "btnSalvarConfiguracoes");
            this.btnSalvarConfiguracoes.ForeColor = System.Drawing.Color.Green;
            this.btnSalvarConfiguracoes.Name = "btnSalvarConfiguracoes";
            this.btnSalvarConfiguracoes.UseVisualStyleBackColor = true;
            this.btnSalvarConfiguracoes.Click += new System.EventHandler(this.BtnSalvarConfiguracoes_Click);
            // 
            // cbxConfig2
            // 
            this.cbxConfig2.Controls.Add(this.chkDTRDisabled);
            this.cbxConfig2.Controls.Add(this.chkDTREnabled);
            this.cbxConfig2.Controls.Add(this.cboHandshake);
            this.cbxConfig2.Controls.Add(this.lblDTR);
            this.cbxConfig2.Controls.Add(this.cboParity);
            this.cbxConfig2.Controls.Add(this.lblParity);
            this.cbxConfig2.Controls.Add(this.lblHandshake);
            this.cbxConfig2.Controls.Add(this.cboStopBits);
            this.cbxConfig2.Controls.Add(this.lblStopBits);
            resources.ApplyResources(this.cbxConfig2, "cbxConfig2");
            this.cbxConfig2.Name = "cbxConfig2";
            this.cbxConfig2.TabStop = false;
            // 
            // chkDTRDisabled
            // 
            resources.ApplyResources(this.chkDTRDisabled, "chkDTRDisabled");
            this.chkDTRDisabled.Name = "chkDTRDisabled";
            this.chkDTRDisabled.UseVisualStyleBackColor = true;
            this.chkDTRDisabled.Click += new System.EventHandler(this.CbxDTRDisabled_Click);
            // 
            // chkDTREnabled
            // 
            resources.ApplyResources(this.chkDTREnabled, "chkDTREnabled");
            this.chkDTREnabled.Checked = true;
            this.chkDTREnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDTREnabled.Name = "chkDTREnabled";
            this.chkDTREnabled.UseVisualStyleBackColor = true;
            this.chkDTREnabled.Click += new System.EventHandler(this.CbxDTREnabled_Click);
            // 
            // cboHandshake
            // 
            this.cboHandshake.FormattingEnabled = true;
            resources.ApplyResources(this.cboHandshake, "cboHandshake");
            this.cboHandshake.Name = "cboHandshake";
            // 
            // lblDTR
            // 
            resources.ApplyResources(this.lblDTR, "lblDTR");
            this.lblDTR.Name = "lblDTR";
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            resources.ApplyResources(this.cboParity, "cboParity");
            this.cboParity.Name = "cboParity";
            // 
            // lblParity
            // 
            resources.ApplyResources(this.lblParity, "lblParity");
            this.lblParity.Name = "lblParity";
            // 
            // lblHandshake
            // 
            resources.ApplyResources(this.lblHandshake, "lblHandshake");
            this.lblHandshake.Name = "lblHandshake";
            // 
            // cboStopBits
            // 
            this.cboStopBits.FormattingEnabled = true;
            resources.ApplyResources(this.cboStopBits, "cboStopBits");
            this.cboStopBits.Name = "cboStopBits";
            // 
            // lblStopBits
            // 
            resources.ApplyResources(this.lblStopBits, "lblStopBits");
            this.lblStopBits.Name = "lblStopBits";
            // 
            // gbxConfig
            // 
            this.gbxConfig.Controls.Add(this.txtNewLine);
            this.gbxConfig.Controls.Add(this.lblNewLine);
            this.gbxConfig.Controls.Add(this.txtDataBits);
            this.gbxConfig.Controls.Add(this.cboPort);
            this.gbxConfig.Controls.Add(this.lblPort);
            this.gbxConfig.Controls.Add(this.lblDataBits);
            this.gbxConfig.Controls.Add(this.cboBaudRate);
            this.gbxConfig.Controls.Add(this.lblBaudRate);
            resources.ApplyResources(this.gbxConfig, "gbxConfig");
            this.gbxConfig.Name = "gbxConfig";
            this.gbxConfig.TabStop = false;
            // 
            // txtNewLine
            // 
            resources.ApplyResources(this.txtNewLine, "txtNewLine");
            this.txtNewLine.Name = "txtNewLine";
            this.txtNewLine.ReadOnly = true;
            // 
            // lblNewLine
            // 
            resources.ApplyResources(this.lblNewLine, "lblNewLine");
            this.lblNewLine.Name = "lblNewLine";
            // 
            // txtDataBits
            // 
            resources.ApplyResources(this.txtDataBits, "txtDataBits");
            this.txtDataBits.Name = "txtDataBits";
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            resources.ApplyResources(this.cboPort, "cboPort");
            this.cboPort.Name = "cboPort";
            // 
            // lblPort
            // 
            resources.ApplyResources(this.lblPort, "lblPort");
            this.lblPort.Name = "lblPort";
            // 
            // lblDataBits
            // 
            resources.ApplyResources(this.lblDataBits, "lblDataBits");
            this.lblDataBits.Name = "lblDataBits";
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.DataSource = ((object)(resources.GetObject("cboBaudRate.DataSource")));
            this.cboBaudRate.FormattingEnabled = true;
            resources.ApplyResources(this.cboBaudRate, "cboBaudRate");
            this.cboBaudRate.Name = "cboBaudRate";
            // 
            // lblBaudRate
            // 
            resources.ApplyResources(this.lblBaudRate, "lblBaudRate");
            this.lblBaudRate.Name = "lblBaudRate";
            // 
            // cboConfgTimeout
            // 
            this.cboConfgTimeout.Controls.Add(this.txtWriteTimeout);
            this.cboConfgTimeout.Controls.Add(this.lblWriteTimeout);
            this.cboConfgTimeout.Controls.Add(this.txtReadTimeout);
            this.cboConfgTimeout.Controls.Add(this.lblReadTimeout);
            resources.ApplyResources(this.cboConfgTimeout, "cboConfgTimeout");
            this.cboConfgTimeout.Name = "cboConfgTimeout";
            this.cboConfgTimeout.TabStop = false;
            // 
            // txtWriteTimeout
            // 
            resources.ApplyResources(this.txtWriteTimeout, "txtWriteTimeout");
            this.txtWriteTimeout.Name = "txtWriteTimeout";
            this.txtWriteTimeout.ReadOnly = true;
            // 
            // lblWriteTimeout
            // 
            resources.ApplyResources(this.lblWriteTimeout, "lblWriteTimeout");
            this.lblWriteTimeout.Name = "lblWriteTimeout";
            // 
            // txtReadTimeout
            // 
            resources.ApplyResources(this.txtReadTimeout, "txtReadTimeout");
            this.txtReadTimeout.Name = "txtReadTimeout";
            this.txtReadTimeout.ReadOnly = true;
            // 
            // lblReadTimeout
            // 
            resources.ApplyResources(this.lblReadTimeout, "lblReadTimeout");
            this.lblReadTimeout.Name = "lblReadTimeout";
            // 
            // lblConfiguracoesConexao
            // 
            resources.ApplyResources(this.lblConfiguracoesConexao, "lblConfiguracoesConexao");
            this.lblConfiguracoesConexao.Name = "lblConfiguracoesConexao";
            // 
            // Terminal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.applicationMenu);
            this.Controls.Add(this.pnlPesagem);
            this.Controls.Add(this.pnlConfiguracoesPorta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.applicationMenu;
            this.MaximizeBox = false;
            this.Name = "Terminal";
            this.applicationMenu.ResumeLayout(false);
            this.applicationMenu.PerformLayout();
            this.pnlPesagem.ResumeLayout(false);
            this.pnlPesagem.PerformLayout();
            this.gbxVeiculoBalanca.ResumeLayout(false);
            this.gbxVeiculoBalanca.PerformLayout();
            this.gbxFiltrosPesquisa.ResumeLayout(false);
            this.gbxFiltrosPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJanelasDisponiveis)).EndInit();
            this.pnlConfiguracoesPorta.ResumeLayout(false);
            this.pnlConfiguracoesPorta.PerformLayout();
            this.cbxConfig2.ResumeLayout(false);
            this.cbxConfig2.PerformLayout();
            this.gbxConfig.ResumeLayout(false);
            this.gbxConfig.PerformLayout();
            this.cboConfgTimeout.ResumeLayout(false);
            this.cboConfgTimeout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.MenuStrip applicationMenu;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectorPortaToolStripMenuItem;
        private System.Windows.Forms.Panel pnlPesagem;
        private System.Windows.Forms.GroupBox gbxVeiculoBalanca;
        private System.Windows.Forms.RadioButton rbtSaida;
        private System.Windows.Forms.RadioButton rbtEntrada;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblPesoEntrada;
        private System.Windows.Forms.GroupBox gbxFiltrosPesquisa;
        private System.Windows.Forms.CheckBox chkDesativarData;
        private System.Windows.Forms.DateTimePicker dtpDataEntradaPrevista;
        private System.Windows.Forms.Label lblEntradaPrevista;
        private System.Windows.Forms.Button btnAtualizarListaJanelas;
        private System.Windows.Forms.Button btnEncerrarConexao;
        private System.Windows.Forms.Button btnConectarSerial;
        private System.Windows.Forms.Button btnLimparCampos;
        private System.Windows.Forms.Label lblJanelasDisponiveis;
        private System.Windows.Forms.DataGridView grdJanelasDisponiveis;
        private System.Windows.Forms.Button btnEnviarDados;
        private System.Windows.Forms.Panel pnlConfiguracoesPorta;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Label lblConfiguracoesConexao;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.TextBox txtDataBits;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.GroupBox cboConfgTimeout;
        private System.Windows.Forms.TextBox txtWriteTimeout;
        private System.Windows.Forms.Label lblWriteTimeout;
        private System.Windows.Forms.TextBox txtReadTimeout;
        private System.Windows.Forms.Label lblReadTimeout;
        private System.Windows.Forms.GroupBox gbxConfig;
        private System.Windows.Forms.GroupBox cbxConfig2;
        private System.Windows.Forms.Label lblDTR;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.Label lblHandshake;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.TextBox txtNewLine;
        private System.Windows.Forms.Label lblNewLine;
        private System.Windows.Forms.ComboBox cboHandshake;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvarConfiguracoes;
        private System.Windows.Forms.CheckBox chkDTRDisabled;
        private System.Windows.Forms.CheckBox chkDTREnabled;
        private System.Windows.Forms.TextBox txtFiltroPlaca;
        private System.Windows.Forms.Label lblFiltroPlaca;
    }
}