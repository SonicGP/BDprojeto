using System.Collections.Generic;
using BDProjeto.dominio;
using BDProjeto.dominio.contrato;
using BDProjeto.RepositorioADO;

namespace BDProjeto.Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly IRepositorio<usuario> repositorio;

        public UsuarioAplicacao(IRepositorio<usuario> Repositorio)
        {
            repositorio = Repositorio;
        }          

        public void Salvar(usuario usuario)
        {
            repositorio.Salvar(usuario);
        }

        public void Excluir(usuario usuario)
        {
            repositorio.Excluir(usuario);
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
            return repositorio.ListarTodos();              
        }

        public usuario UsuarioPorId(string id)
        {
            return repositorio.UsuarioPorId(id);
        }
    }
}
