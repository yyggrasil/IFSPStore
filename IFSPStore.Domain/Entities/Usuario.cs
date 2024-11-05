using IFSPStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{
    public class Usuario : BaseEntity<int>
    {
        public Usuario()
        {

        }

        public Usuario(int id, string nome, string senha, string login, string email, DateTime datacadastro, DateTime datalogin, bool ativo)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            Login = login;
            Email = email;
            DataCadastro = datacadastro;
            DataLogin = datalogin;
            Ativo = ativo;
        }

        public string? Nome {  get; set; }
        public string? Senha { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataLogin { get; set; }
        public bool Ativo { get; set; }
    }
}
