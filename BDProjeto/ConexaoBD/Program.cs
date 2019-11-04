using System;
using System.Data.SqlClient;
using BDProjeto.dominio;
using BDProjeto.Aplicacao;

namespace DOS
{
    class Program
    {
        static void Main(string[] args)
        {            
            var usarioAplicacao = UsuarioAplicacaoConstrutor.UsuarioApADO();
            usuario usuario;

            SqlConnection conexao = new SqlConnection(@"data source=DESKTOP-L3M9FG8\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=ExemploBD");
            conexao.Open();
            
            Console.Write("Digite o nome do usuário: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o cargo do usuário: ");
            string cargo = Console.ReadLine();

            Console.Write("Digite a data do usuário: ");
            string data = Console.ReadLine();

            usuario = new usuario
            {
                Nome = nome,
                Cargo = cargo,
                Data = DateTime.Parse(data)
            };

            //usuario.Id = 3;

            //usarioAplicacao.Insert(usuario);
            usarioAplicacao.Salvar(usuario);
            //string strQueryInsert = string.Format("INSERT INTO usuario(nome, cargo, date) VALUES ('{0}','{1}','{2}')", nome, cargo, data);
            //bd.ExecutaComando(strQueryInsert);
            
            //string strQuerySelect = "SELECT * FROM usuario";
            var dados = usarioAplicacao.ListarTodos();

            foreach(var usuarios in dados)
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}", usuarios.Id, usuarios.Nome, usuarios.Cargo, usuarios.Data);
            }
        }
    }
}
