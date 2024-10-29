using IFSPStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{
    public class Grupo : BaseEntity<int>
    {
        public Grupo()
        {
        
        }

        public Grupo(int id, string nome) : base(id)
        {
            Nome = nome;
        }

        public string? Nome { get; set; }
    }
}
