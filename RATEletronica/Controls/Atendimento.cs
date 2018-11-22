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
        public DateTime DataPrevista { get; set; }
        public DateTime DataAtendimento { get; set; }
        public TimeSpan TempoViagem { get; set; }
        public int Contador { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
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


        #endregion

        public void Adicionar(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);

                string tsqlInsert = @"insert into Atendimentos(idTecnico, idRequisicao, serie, tipoAtendimento, dataPrevista, dataAtendimento, contador, tempoViagem
, horaInicio, horaFim, iti1, km1, iti2, km2, cfm, csi, observacoes)
Values(@idTecnico, @idRequisicao, @serie, @tipoAtendimento, @dataPrevista, @dataAtendimento, @contador, @tempoViagem, @horaInicio
, @horaFim, @iti1, @km1, @iti2, @km2, @cfm, @csi, @observacoes)";

                List<object[]> parametros = new List<object[]>();
                #region Parâmetros
                parametros.Add(new object[] { "@idTecnico", this.IdTecnico });
                parametros.Add(new object[] { "@idRequisicao", this.IdRequisicao });
                parametros.Add(new object[] { "@serie", this.Serie });
                parametros.Add(new object[] { "@tipoAtendimento", this.TipoAtendimento });
                parametros.Add(new object[] { "@dataPrevista", this.DataPrevista });

                if (this.DataAtendimento.ToShortDateString() != "01/01/0001")
                {
                    parametros.Add(new object[] { "@dataAtendimento", this.DataAtendimento });
                }
                else
                {
                    tsqlInsert = tsqlInsert.Replace(", @dataAtendimento", "").Replace(", dataAtendimento", "");
                }

                parametros.Add(new object[] { "@contador", this.Contador });
                parametros.Add(new object[] { "@tempoViagem", this.TempoViagem });
                parametros.Add(new object[] { "@horaInicio", this.HoraInicio });
                parametros.Add(new object[] { "@horaFim", this.HoraFim });
                parametros.Add(new object[] { "@iti1", this.ITI1 });
                parametros.Add(new object[] { "@km1", this.KM1 });
                parametros.Add(new object[] { "@iti2", this.ITI2 });
                parametros.Add(new object[] { "@km2", this.KM2 });
                parametros.Add(new object[] { "@cfm", this.CFM });
                parametros.Add(new object[] { "@csi", this.CSI });
                if (!string.IsNullOrEmpty(this.Observacoes))
                    parametros.Add(new object[] { "@observacoes", this.Observacoes });
                else
                    tsqlInsert = tsqlInsert.Replace(", @observacoes", "").Replace(", observacoes", "");
                #endregion
                try
                {
                    db.ExecuteNonQuery(tsqlInsert, parametros);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
        }

        public void Excluir(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);

            string tsqlUpdate = "Update Atendimentos set status = @status where idAtendimento = @idAtendimento;";

            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@status", false });
            parametros.Add(new object[] { "@idAtendimento", this.IdAtendimento });

            try
            {
                db.ExecuteNonQuery(tsqlUpdate, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Atendimento> Listar(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);
            List<Atendimento> Lista = new List<Atendimento>();

            string tsqlQuery = @"SELECT idAtendimento, idTecnico, idRequisicao, serie, tipoAtendimento, dataPrevista, dataAtendimento, contador
, tempoViagem, horaInicio, horaFim, iti1, km1, iti2, km2, cfm, csi, observacoes
FROM Atendimentos WHERE  status = 1";

            DataTable dtRequisicoes = new DataTable();

            try
            {
                dtRequisicoes = db.ReturnDT(tsqlQuery, null);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            if (dtRequisicoes.Rows.Count > 0)
            {
                foreach (DataRow atend in dtRequisicoes.Rows)
                {
                    Lista.Add(new Atendimento(int.Parse(atend["idAtendimento"].ToString())
                        , int.Parse(atend["idTecnico"].ToString())
                        , int.Parse(atend["idRequisicao"].ToString())
                        , atend["serie"].ToString()
                        , (TipoAtendimentos)int.Parse(atend["tipoAtendimento"].ToString())
                        , atend["dataPrevista"].ToString()
                        , atend["dataAtendimento"].ToString()
                        , atend["contador"].ToString()
                        , atend["tempoViagem"].ToString()
                        , atend["horaInicio"].ToString()
                        , atend["horaFim"].ToString()
                        , atend["iti1"].ToString()
                        , atend["km1"].ToString()
                        , atend["iti2"].ToString()
                        , atend["km2"].ToString()
                        , atend["cfm"].ToString()
                        , atend["csi"].ToString()
                        , atend["observacoes"].ToString()
                        ));
                }
            }

            return Lista;
        }

        public Atendimento ListarPorID(string connString, int idAtendimento)
        {
            DBMSSQL db = new DBMSSQL(connString);
            List<Atendimento> Lista = new List<Atendimento>();

            string tsqlQuery = @"SELECT idAtendimento, idTecnico, idRequisicao, serie, tipoAtendimento, dataPrevista, dataAtendimento, contador
, tempoViagem, horaInicio, horaFim, iti1, km1, iti2, km2, cfm, csi, observacoes
FROM Atendimentos WHERE  idAtendimento = @idAtendimento";

            DataTable dtRequisicoes = new DataTable();

            try
            {
                dtRequisicoes = db.ReturnDT(tsqlQuery, null);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            if (dtRequisicoes.Rows.Count > 0)
            {
                foreach (DataRow atend in dtRequisicoes.Rows)
                {
                    Lista.Add(new Atendimento(int.Parse(atend["idAtendimento"].ToString())
                        , int.Parse(atend["idTecnico"].ToString())
                        , int.Parse(atend["idRequisicao"].ToString())
                        , atend["serie"].ToString()
                        , (TipoAtendimentos)int.Parse(atend["tipoAtendimento"].ToString())
                        , DateTime.Parse(atend["dataPrevista"].ToString())
                        , DateTime.Parse(atend["dataAtendimento"].ToString())
                        , int.Parse(atend["contador"].ToString())
                        , TimeSpan.Parse(atend["tempoViagem"].ToString())
                        , TimeSpan.Parse(atend["horaInicio"].ToString())
                        , TimeSpan.Parse(atend["horaFim"].ToString())
                        , (Itinerarios)int.Parse(atend["iti1"].ToString())
                        , int.Parse(atend["km1"].ToString())
                        , (Itinerarios)int.Parse(atend["iti2"].ToString())
                        , int.Parse(atend["km2"].ToString())
                        , (Condicaofinal)int.Parse(atend["cfm"].ToString())
                        , (CondicaoMaterial)int.Parse(atend["csi"].ToString())
                        , atend["observacoes"].ToString()
                        ));
                }
            }

            return Lista.First();
        }

        public static Atendimento ListarPorIDReq(string connString, int idRequisicao)
        {
            DBMSSQL db = new DBMSSQL(connString);
            List<Atendimento> Lista = new List<Atendimento>();

            string tsqlQuery = @"SELECT idAtendimento, idTecnico, idRequisicao, serie, tipoAtendimento, dataPrevista, dataAtendimento, contador
, tempoViagem, horaInicio, horaFim, iti1, km1, iti2, km2, cfm, csi, observacoes
FROM Atendimentos WHERE  idRequisicao = @idRequisicao";

            List<object[]> parametros = new List<object[]>();
            #region Parâmetros
            parametros.Add(new object[] { "@idRequisicao", idRequisicao });
            #endregion

            DataTable dtRequisicoes = new DataTable();

            try
            {
                dtRequisicoes = db.ReturnDT(tsqlQuery, parametros);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            if (dtRequisicoes.Rows.Count > 0)
            {
                foreach (DataRow atend in dtRequisicoes.Rows)
                {
                    Atendimento newAtend = new Atendimento();
                    newAtend.IdAtendimento = int.Parse(atend["idAtendimento"].ToString());
                    newAtend.IdTecnico = int.Parse(atend["idTecnico"].ToString());
                    newAtend.IdRequisicao = int.Parse(atend["idRequisicao"].ToString());
                    newAtend.Serie = atend["serie"].ToString();
                    newAtend.TipoAtendimento = (TipoAtendimentos)int.Parse(atend["tipoAtendimento"].ToString());

                    if (!string.IsNullOrEmpty(atend["dataPrevista"].ToString()))
                        newAtend.DataPrevista = DateTime.Parse(atend["dataPrevista"].ToString());

                    if (!string.IsNullOrEmpty(atend["dataAtendimento"].ToString()))
                        newAtend.DataAtendimento = DateTime.Parse(atend["dataAtendimento"].ToString());


                    Lista.Add(newAtend);
                }
                return Lista.First();
            }
            else
            {
                return new Atendimento();
            }

        }

        public void Salvar(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);

            string tsqlUpdate = @"UPDATE Atendimentos 
SET dataPrevista = @dataPrevista, dataAtendimento = @dataAtendimento, contador = @contador, tempoViagem = @tempoViagem, horaInicio = @horaInicio
, horaFim = @horaFim, iti1 = @iti1, km1 = @km1, iti2 = @iti2, km2 = @km2, cfm = @cfm, csi = @csi, observacoes = @observacoes, status = @status
WHERE idAtendimento = @idAtendimento";

            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@dataPrevista", this.DataPrevista });
            if (this.DataAtendimento.ToShortDateString() != "01/01/0001")
            {
                parametros.Add(new object[] { "@dataAtendimento", this.DataAtendimento });
            }
            else
            {
                tsqlUpdate = tsqlUpdate.Replace("dataAtendimento = @dataAtendimento,", "");
            }
            parametros.Add(new object[] { "@contador", this.Contador });
            parametros.Add(new object[] { "@tempoViagem", this.TempoViagem });
            parametros.Add(new object[] { "@horaInicio", this.HoraInicio });
            parametros.Add(new object[] { "@horaFim", this.HoraFim });
            parametros.Add(new object[] { "@iti1", this.ITI1 });
            parametros.Add(new object[] { "@km1", this.KM1 });
            parametros.Add(new object[] { "@iti2", this.ITI2 });
            parametros.Add(new object[] { "@km2", this.KM2 });
            parametros.Add(new object[] { "@cfm", this.CFM });
            parametros.Add(new object[] { "@csi", this.CSI });
            if (!string.IsNullOrEmpty(this.Observacoes))
                parametros.Add(new object[] { "@observacoes", this.Observacoes });
            else
                tsqlUpdate = tsqlUpdate.Replace(", observacoes = @observacoes", "");

            parametros.Add(new object[] { "@status", this.Status });
            parametros.Add(new object[] { "@idAtendimento", this.IdAtendimento });

            try
            {
                db.ExecuteNonQuery(tsqlUpdate, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
