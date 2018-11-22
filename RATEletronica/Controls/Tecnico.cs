using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Controles
{
    public class Tecnico 
    {
        #region Campos

        public enum tipoTecnico { Tecnico, Empresa}

        public int IdTecnico { get; set; }
        public tipoTecnico Tipo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Contato { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaModificacao { get; set; }
        public string ModificadoPor { get; set; }

        #endregion

        public Tecnico()
        {

        }

        public Tecnico(int idTecnico, string nome, string email, string telefone, string endereco, int numero, string bairro, string cidade, string uf, string contato)
        {
            this.IdTecnico = idTecnico;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = uf;
            this.Contato = contato;
        }

        public void Adicionar(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);

            string tsqlInsert = @"insert into Tecnicos(nome, email, telefone, endereco, numero, bairro, cidade, uf, contato, status) 
values(@nome, @email, @telefone, @endereco, @numero, @bairro, @cidade, @uf, @contato, @status);";

            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@nome", this.Nome });
            parametros.Add(new object[] { "@email", this.Email });
            parametros.Add(new object[] { "@telefone", this.Telefone });
            parametros.Add(new object[] { "@endereco", this.Endereco });
            parametros.Add(new object[] { "@numero", this.Numero });
            parametros.Add(new object[] { "@bairro", this.Bairro });
            parametros.Add(new object[] { "@cidade", this.Cidade });
            parametros.Add(new object[] { "@uf", this.Estado });
            parametros.Add(new object[] { "@contato", this.Contato });
            parametros.Add(new object[] { "@status", true });

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

            string tsqlUpdate = "update Tecnicos set status = 0  where idTecnico = @idTecnico;";

            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@idTecnico", this.IdTecnico });

            try
            {
                db.ExecuteNonQuery(tsqlUpdate, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<Tecnico> Listar(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);
            List<Tecnico> Lista = new List<Tecnico>();

            string tsqlQuery = "Select idTecnico, nome, email, telefone, endereco, numero, bairro, cidade, uf, contato FROM Tecnicos where status = 1;";
            DataTable dtTecnicos = new DataTable();

            try
            {
                dtTecnicos = db.ReturnDT(tsqlQuery, null);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            if (dtTecnicos.Rows.Count > 0)
            {
                foreach (DataRow tec in dtTecnicos.Rows)
                {
                    Lista.Add(new Tecnico(
                        int.Parse(tec["idTecnico"].ToString())
                        , tec["nome"].ToString()
                        , tec["email"].ToString()
                        , tec["telefone"].ToString()
                        , tec["endereco"].ToString()
                        , int.Parse(tec["numero"].ToString())
                        , tec["bairro"].ToString()
                        , tec["cidade"].ToString()
                        , tec["uf"].ToString()
                        , tec["contato"].ToString()));
                }
            }

            return Lista;
        }

        public static Tecnico ListarPorID(string connString, int idTecnico)
        {
            DBMSSQL db = new DBMSSQL(connString);
            List<Tecnico> Lista = new List<Tecnico>();

            string tsqlQuery = "Select idTecnico, nome, email, telefone, endereco, numero, bairro, cidade, uf, contato FROM Tecnicos where idTecnico = @idTecnico;";
            DataTable dtTecnicos = new DataTable();

            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@idTecnico", idTecnico });

            try
            {
                dtTecnicos = db.ReturnDT(tsqlQuery, parametros);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            if (dtTecnicos.Rows.Count > 0)
            {
                foreach (DataRow tec in dtTecnicos.Rows)
                {
                    Lista.Add(new Tecnico(
                        int.Parse(tec["idTecnico"].ToString())
                        , tec["nome"].ToString()
                        , tec["email"].ToString()
                        , tec["telefone"].ToString()
                        , tec["endereco"].ToString()
                        , int.Parse(tec["numero"].ToString())
                        , tec["bairro"].ToString()
                        , tec["cidade"].ToString()
                        , tec["uf"].ToString()
                        , tec["contato"].ToString()));
                }
            }

            return Lista.First();
        }

        public void Salvar(string connString)
        {
            DBMSSQL db = new DBMSSQL(connString);

            string tsqlUpdate = @"update Tecnicos set  nome = @nome, email = @email, telefone = @telefone, endereco = @endereco, numero = @numero
, bairro = @bairro, cidade = @cidade, uf = @uf, contato = @contato, ultimaModificacao = @ultimaModificacao, modificadoPor = @modificadoPor where idTecnico = @idTecnico;";

            List<object[]> parametros = new List<object[]>();
            parametros.Add(new object[] { "@idTecnico", this.IdTecnico });
            parametros.Add(new object[] { "@nome", this.Nome });
            parametros.Add(new object[] { "@email", this.Email });
            parametros.Add(new object[] { "@telefone", this.Telefone });
            parametros.Add(new object[] { "@endereco", this.Endereco });
            parametros.Add(new object[] { "@numero", this.Numero });
            parametros.Add(new object[] { "@bairro", this.Bairro });
            parametros.Add(new object[] { "@cidade", this.Cidade });
            parametros.Add(new object[] { "@uf", this.Estado });
            parametros.Add(new object[] { "@contato", this.Contato });
            parametros.Add(new object[] { "@ultimaModificacao", this.UltimaModificacao });
            parametros.Add(new object[] { "@modificadoPor", this.ModificadoPor });

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
