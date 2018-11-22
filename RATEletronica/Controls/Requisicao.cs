using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles
{
    public class Requisicao
    {
        #region Campos

        public enum TipoFalha { Qualidade, Operacional }
        public enum StatusRequisicao { Aberto, Aguardando_atendimento, Aguardando_peças, Encerrado, Cancelado }
        public int idRequisicao { get; set; }
        public int idTecnico { get; set; }
        public string codigo { get; set; }
        public string serie { get; set; }
        public TipoFalha tipoFalha { get; set; }
        public string descricao { get; set; }
        public string usuario { get; set; }
        public string emailUsuario { get; set; }
        public string foneUsuario { get; set; }
        public DateTime dataAbertura { get; set; }
        public DateTime dataEncerramento { get; set; }
        public StatusRequisicao status { get; set; }


        public Requisicao()
        {

        }

        public Requisicao(int _idRequisicao, int _idTecnico, string _codigo, string _serie, TipoFalha _tipoFalha, string _descricao, string _usuario, string _emailUsuario, string _foneUsuario, DateTime _dataAbertura, StatusRequisicao _status)
        {
            this.idRequisicao = _idRequisicao;
            this.idTecnico = _idTecnico;
            this.codigo = _codigo;
            this.serie = _serie;
            this.tipoFalha = _tipoFalha;
            this.descricao = _descricao;
            this.usuario = _usuario;
            this.emailUsuario = _emailUsuario;
            this.foneUsuario = _foneUsuario;
            this.dataAbertura = _dataAbertura;
            this.status = _status;
        }

        #endregion

        public void Adicionar(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);

            string tsqlInsert = @"insert into Requisicoes (idTecnico, codigo, serie, tipoFalha, descricao, usuario, emailUsuario, foneUsuario, dataAbertura, status)
Values (@idTecnico, @codigo, @serie, @tipoFalha, @descricao, @usuario, @emailUsuario, @foneUsuario, @dataAbertura, @status)";

            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@idTecnico", this.idTecnico });
            parametros.Add(new object[] { "@codigo", this.codigo });
            parametros.Add(new object[] { "@serie", this.serie });
            parametros.Add(new object[] { "@tipoFalha", this.tipoFalha });
            parametros.Add(new object[] { "@descricao", this.descricao });
            parametros.Add(new object[] { "@usuario", this.usuario });
            parametros.Add(new object[] { "@emailUsuario", this.emailUsuario });
            parametros.Add(new object[] { "@foneUsuario", this.foneUsuario });
            parametros.Add(new object[] { "@dataAbertura", DateTime.Now });
            parametros.Add(new object[] { "@status", StatusRequisicao.Aberto });

            try
            {
                db.ExecuteNonQuery(tsqlInsert, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
        public static List<Requisicao> Listar(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);
            List<Requisicao> Lista = new List<Requisicao>();

            string tsqlQuery = "select idRequisicao, idTecnico, codigo, serie, tipoFalha, descricao, usuario, emailUsuario, foneUsuario, dataAbertura, dataEncerramento, status from Requisicoes where status < 3";
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
                foreach (DataRow req in dtRequisicoes.Rows)
                {
                    Requisicao newReq = new Requisicao();
                    newReq.idRequisicao = int.Parse(req["idRequisicao"].ToString());
                    newReq.idTecnico = int.Parse(req["idTecnico"].ToString());
                    newReq.codigo = req["codigo"].ToString();
                    newReq.serie = req["serie"].ToString();
                    newReq.tipoFalha = (TipoFalha)int.Parse(req["tipoFalha"].ToString());
                    newReq.descricao = req["descricao"].ToString();
                    newReq.usuario = req["usuario"].ToString();
                    newReq.emailUsuario = req["emailUsuario"].ToString();
                    newReq.foneUsuario = req["emailUsuario"].ToString();
                    newReq.status = (StatusRequisicao)int.Parse(req["status"].ToString());

                    if (!string.IsNullOrEmpty(req["dataAbertura"].ToString()))
                        newReq.dataAbertura = DateTime.Parse(req["dataAbertura"].ToString());
                    if (!string.IsNullOrEmpty(req["dataEncerramento"].ToString()))
                        newReq.dataEncerramento = DateTime.Parse(req["dataEncerramento"].ToString());
                    Lista.Add(newReq);
                }
            }

            return Lista;
        }

        public static Requisicao ListarPorID(string connString, int idRequisicao)
        {
            DBMSSQL db = new DBMSSQL(connString);
            List<Requisicao> Lista = new List<Requisicao>();

            string tsqlQuery = "select idRequisicao, idTecnico, codigo, serie, tipoFalha, descricao, usuario, emailUsuario, foneUsuario, dataAbertura, dataEncerramento, status from Requisicoes where idRequisicao = @idRequisicao";
            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@idRequisicao", idRequisicao });

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
                foreach (DataRow req in dtRequisicoes.Rows)
                {
                    Lista.Add(new Requisicao(
                        int.Parse(req["idRequisicao"].ToString())
                        , int.Parse(req["idTecnico"].ToString())
                        , req["codigo"].ToString()
                        , req["serie"].ToString()
                        , (TipoFalha)int.Parse(req["tipoFalha"].ToString())
                        , req["descricao"].ToString()
                        , req["usuario"].ToString()
                        , req["emailUsuario"].ToString()
                        , req["foneUsuario"].ToString()
                        , DateTime.Parse(req["dataAbertura"].ToString())
                        , (StatusRequisicao)int.Parse(req["status"].ToString())
                        ));
                }
            }

            return Lista.First();
        }

        public void Salvar(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);

            string tsqlUpdate = @"Update Requisicoes set idTecnico = @idTecnico, tipoFalha = @tipoFalha, descricao = @descricao, usuario = @usuario
, emailUsuario = @emailUsuario, foneUsuario = @foneUsuario, dataEncerramento = @dataEncerramento, status = @status
where idRequisicao = @idRequisicao";

            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@idTecnico", this.idTecnico });
            parametros.Add(new object[] { "@tipoFalha", this.tipoFalha });
            parametros.Add(new object[] { "@descricao", this.descricao });
            parametros.Add(new object[] { "@usuario", this.usuario });
            parametros.Add(new object[] { "@emailUsuario", this.emailUsuario });
            parametros.Add(new object[] { "@foneUsuario", this.foneUsuario });
            if (this.dataEncerramento.ToShortDateString() != "01/01/0001")
            {
                parametros.Add(new object[] { "@dataEncerramento", this.dataEncerramento });
            }
            else
            {
                tsqlUpdate =  tsqlUpdate.Replace("dataEncerramento = @dataEncerramento,", " ");
            }

            parametros.Add(new object[] { "@status", this.status });
            parametros.Add(new object[] { "@idRequisicao", this.idRequisicao });

            try
            {
                db.ExecuteNonQuery(tsqlUpdate, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);

            string tsqlUpdate = "Update Requisicoes set status = @status where idRequisicao = @idrequisicao;";

            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@status", StatusRequisicao.Cancelado });
            parametros.Add(new object[] { "@idRequisicao", this.idRequisicao });

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
