using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Controles
{
    public class Atendimento
    {
        #region Campos

        public enum TipoAtendimentos { MC, MP, Recolha_suprimento, Instalação, Desinstalação, Canibalização }
        public enum Itinerarios { BC, CC, CB }
        public enum Condicaofinal { Operacional, Precário, Parado }
        public enum CondicaoMaterial { Não_necessário, Necessita_peças, Necessita_suprimentos, Necessita_peças_e_suprimentos }

        public int IdAtendimento { get; set; }
        public int IdTecnico { get; set; }
        public int IdRequisicao { get; set; }
        public string Serie { get; set; }
        public TipoAtendimentos TipoAtendimento { get; set; }
        public DateTime? DataPrevista { get; set; }
        public DateTime? DataAtendimento { get; set; }
        public TimeSpan? TempoViagem { get; set; }
        public int Contador { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFim { get; set; }
        public Itinerarios ITI1 { get; set; }
        public int KM1 { get; set; }
        public Itinerarios ITI2 { get; set; }
        public int KM2 { get; set; }
        public Condicaofinal CFM { get; set; }
        public CondicaoMaterial CSI { get; set; }
        public string Observacoes { get; set; }
        public bool Status { get; set; }

        public Atendimento()
        {

        }

        public Atendimento(int idAtendimento, int idTecnico, int idRequisicao, string serie, TipoAtendimentos tipoAtendimento, DateTime dataPrevista, DateTime dataAtendimento, int contador, TimeSpan tempoViagem, TimeSpan horaInicio, TimeSpan horaFim,
            Itinerarios iti1, int km1, Itinerarios iti2, int km2, Condicaofinal cfm, CondicaoMaterial csi, string observacoes)
        {
            this.IdAtendimento = idAtendimento;
            this.IdTecnico = idTecnico;
            this.IdRequisicao = idRequisicao;
            this.Serie = serie;
            this.TipoAtendimento = tipoAtendimento;
            this.DataPrevista = dataPrevista;
            this.DataAtendimento = dataAtendimento;
            this.Contador = contador;
            this.TempoViagem = tempoViagem;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
            this.ITI1 = iti1;
            this.KM1 = km1;
            this.ITI2 = iti2;
            this.KM2 = km2;
            this.CFM = cfm;
            this.CSI = csi;
            this.Observacoes = observacoes;

        }

        public Atendimento(int _idAtendimento, int _idTecnico, int _idRequisicao, string _serie, TipoAtendimentos tipoAtendimentos, string _dataPrevista
            , string _dataAtendimento, string _contador, string _tempoViagem, string _horaInicio, string _horaFim
            , string _iti1, string _km1, string _iti2, string _km2, string _cfm, string _csi, string _observacoes)
        {
            this.IdAtendimento = _idAtendimento;
            this.IdTecnico = _idTecnico;
            this.IdRequisicao = _idRequisicao;
            this.Serie = _serie;
            this.TipoAtendimento = tipoAtendimentos;

            if (!string.IsNullOrEmpty(_dataPrevista))
                this.DataPrevista = DateTime.Parse(_dataPrevista);
            if (!string.IsNullOrEmpty(_dataAtendimento))
                this.DataAtendimento = DateTime.Parse(_dataAtendimento);
            if (!string.IsNullOrEmpty(_contador))
                this.Contador = int.Parse(_contador);
            if (!string.IsNullOrEmpty(_tempoViagem))
                this.TempoViagem = TimeSpan.Parse(_tempoViagem);
            if (!string.IsNullOrEmpty(_horaInicio))
                this.HoraInicio = TimeSpan.Parse(_horaInicio);
            if (!string.IsNullOrEmpty(_horaFim))
                this.HoraFim = TimeSpan.Parse(_horaFim);
            if (!string.IsNullOrEmpty(_iti1))
                this.ITI1 = (Itinerarios)int.Parse(_iti1);
            if (!string.IsNullOrEmpty(_iti2))
                this.ITI2 = (Itinerarios)int.Parse(_iti2);
            if (!string.IsNullOrEmpty(_km1))
                this.KM1 = int.Parse(_km1);
            if (!string.IsNullOrEmpty(_km2))
                this.KM2 = int.Parse(_km2);
            if (!string.IsNullOrEmpty(_cfm))
                this.CFM = (Condicaofinal)int.Parse(_cfm);
            if (!string.IsNullOrEmpty(_csi))
                this.CSI = (CondicaoMaterial)int.Parse(_csi);
            this.Observacoes = _observacoes;


        }

    }
}
        #endregion

        