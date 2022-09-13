using Balanca.Entidades;
using Balanca.servicoBalanca;
using Balanca.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanca.Controller
{
    public class ControllerBalanca
    {
        #region Attributes

        public Conexao _conexao { get; set; }
        private readonly WebServiceBalanca _wsBalanca;

        #endregion

        #region Constructor

        public ControllerBalanca()
        {
            _wsBalanca = new WebServiceBalanca();
            _conexao = new Conexao();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que retorna a lista de tipos de etiqueta
        /// </summary>
        /// <param name="idBalanca">Código da balança</param>
        /// <param name="identificacaoBalanca">Identificação da balança</param>
        /// <param name="placa">Placa do véiculo</param>
        /// <param name="peso">Peso balança</param>
        /// <param name="erro">Retorno de erro</param>
        /// <returns>Retorno de usuários cadastrados</returns>
        public void SalvarPesoEntrada(CadBalancaDTOBalanca dadosBalanca, decimal peso, string tipoOperacao, out string msgErro)
        {
            try
            {
                var balanca = new CadBalancaRegistraPesoDTOBalanca()
                {
                    IdPorJanela = dadosBalanca.IdPorJanela,
                    IdUnidadeOperacional = dadosBalanca.IdUnidadeOperacional,
                    PlacaVeiculo = dadosBalanca.PlacaVeiculo,
                    PesoBalancaEntrada = tipoOperacao.Equals("Entrada") ? peso : decimal.Zero,
                    PesoBalancaSaida = tipoOperacao.Equals("Saida") ? peso : decimal.Zero
                };

                msgErro = string.Empty;
                _wsBalanca.Servicos.SalvarPesoBalancaJanela(balanca);

                if (!string.IsNullOrEmpty(balanca.Erro))
                    msgErro = balanca.Erro;
            }
            catch (Exception ex)
            {
                msgErro = ex.InnerException.Message;
                return;
            }
        }

        /// <summary>
        /// Método que retorna a lista de janelas
        /// </summary>
        /// <returns>Retorno de usuários cadastrados</returns>
        public List<CadBalancaDTOBalanca> BuscarJanelasAbertas(DateTime? dataEntradaPrevista, string placaVeiculo, out string msgErro)
        {
            msgErro = string.Empty;

            try
            {
                CadBalancaDTOBalanca[] arrCadBalanca = _wsBalanca.Servicos.ListaBalancasCadastradas(dataEntradaPrevista, placaVeiculo);
                return arrCadBalanca.Cast<CadBalancaDTOBalanca>().ToList();
            }
            catch (Exception ex)
            {
                msgErro = ex.InnerException.Message;
                return null;
            }            
        }

        #endregion
    }
}