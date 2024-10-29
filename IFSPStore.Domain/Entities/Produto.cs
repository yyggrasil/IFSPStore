using IFSPStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{
    public class Produto : BaseEntity<int>
    {
        public Produto()
        {

        }

        public Produto(int id, string nome, float preco, int quantidade, DateTime datacompra, string unidadevenda, Grupo grupo) : base(id)
        {
            Preco = preco;
            Quantidade = quantidade;
            DataCompra = datacompra;
            UnidadeVenda = unidadevenda;
            Grupo = grupo;
        }

        public string? Nome { get; set; }
        public float? Preco { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataCompra {  get; set; }
        public string? UnidadeVenda { get; set; }
        public virtual Grupo? Grupo { get; set; }
    }
}
