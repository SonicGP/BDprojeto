using BDProjeto.dominio;
using BDProjeto.dominio.contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.RepositorioEF
{
    public class UsuarioRepositorioEF : IRepositorio<usuario>
    {
        private readonly BD bd;

        public UsuarioRepositorioEF()
        {
            bd = new BD();
        }

        public void Excluir(usuario entidade)
        {
            var usuarioExcluir = bd.usuarios.First(x => x.Id == entidade.Id);
            bd.Set<usuario>().Remove(usuarioExcluir);
            bd.SaveChanges();
        }

        public IEnumerable<usuario> ListarTodos()
        {
            return bd.usuarios;
        }

        public void Salvar(usuario entidade)
        {
            if(entidade.Id > 0)
            {
                var usuarioAlterar = bd.usuarios.First(x=>x.Id == entidade.Id);
                usuarioAlterar.Nome = entidade.Nome;
                usuarioAlterar.Cargo = entidade.Cargo;
                usuarioAlterar.Data = entidade.Data;
            }
            else
            {
                bd.usuarios.Add(entidade);
            }
            bd.SaveChanges();
        }

        public usuario UsuarioPorId(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return bd.usuarios.First(x => x.Id == idInt);
        }
    }
}
