using IFSPStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{
    public class Cliente : BaseEntity<int>
    {
        public Cliente()
        {

        }

        public Cliente(int id, string nome, string endereco, string bairro, string documento, Cidade cidade)
        {
            Id = id;
            this.Nome = nome;
            this.Endereco = endereco;
            this.Bairro = bairro;
            this.Documento = documento;
            this.Cidade = cidade;
        }

        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Bairro { get; set; }
        public string? Documento { get; set; }
        public Cidade? Cidade { get; set; }

    }
}
