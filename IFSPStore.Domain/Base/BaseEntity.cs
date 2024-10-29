using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Base
{
    // Abstract Class: Classe não instanciável (Modelo/Herança para outras classes)
    // Class: Modelo de Objeto
    // <TID>: Tipo de Dado do ID
    public abstract class BaseEntity<TID>
    {
        protected BaseEntity()
        {

        }

        protected BaseEntity(TID id)
        {
            Id = id;
        }

        public TID? Id { get; set; }
    }
}
