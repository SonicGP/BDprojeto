using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.dominio
{
    public class usuario
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Preencha o nome usuário")]
        public string Nome { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Preencha o Cargo")]
        public string Cargo { get; set; }

        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "Preencha a Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
    }
}
