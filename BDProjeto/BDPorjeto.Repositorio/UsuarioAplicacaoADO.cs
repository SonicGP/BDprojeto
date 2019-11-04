using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDProjeto.Repositorio;
using BDProjeto.dominio;
using BDProjeto.dominio.contrato;

namespace BDProjeto.RepositorioADO
{
    public class UsuarioAplicacaoADO:IRepositorio<usuario>
    {
        private bd bd;

        private void Inserir(usuario usuario)
        {
            var strQuery = "";
            strQuery += "INSERT INTO usuario(nome, cargo, date)";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}')",usuario.Nome, usuario.Cargo, usuario.Data);

            using(bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        private void Alterar(usuario usuario)
        {
            var strQuery = "";
            strQuery += "UPDATE usuario SET ";
            strQuery += string.Format("nome = '{0}',", usuario.Nome);
            strQuery += string.Format("cargo = '{0}',", usuario.Cargo);            
            strQuery += string.Format("date = '{0}'", usuario.Data);
            strQuery += string.Format("WHERE usuarioId = {0} ", usuario.Id);

            using(bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        public void Salvar(usuario usuario)
        {
            if(usuario.Id > 0)
            {
                Alterar(usuario);
            }
            else
            {
                Inserir(usuario);
            }
        }

        public void Excluir(usuario usuario)
        {
            using (bd = new bd())
            {
                var strQuery = string.Format(" DELETE FROM usuario WHERE usuarioId = {0}", usuario.Id);
                bd.ExecutaComando(strQuery);
            }
        }

        /*public SqlDataReader ListarTodos()
        {
            var bd = new bd();
            
            var strQuery = "SELECT * FROM usuario";
            return bd.ExecutaComandoComRetorno(strQuery);
                //return bd.ExecutaComandoComRetorno(strQuery);
           
        }*/

        public IEnumerable<usuario> ListarTodos()
        {
            using (bd = new bd())
            {
                var strQuery = "SELECT * FROM usuario";
                var retorno = bd.ExecutaComandoComRetorno(strQuery);
                return ReaderEmLista(retorno);
            }                
        }

        public usuario UsuarioPorId(string id)
        {
            using (bd = new bd())
            {
                var strQuery = string.Format("SELECT * FROM usuario WHERE usuarioId = {0}", id);
                var retorno = bd.ExecutaComandoComRetorno(strQuery);
                return ReaderEmLista(retorno).FirstOrDefault();
            }
        }

        private List<usuario>ReaderEmLista(SqlDataReader reader)
        {
            var usuarios = new List<usuario>();
            while (reader.Read())
            {
                var tempoObjeto = new usuario()
                {
                    Id = int.Parse(reader["usuarioId"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Cargo = reader["cargo"].ToString(),
                    Data = DateTime.Parse(reader["date"].ToString())
                };
                usuarios.Add(tempoObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}
