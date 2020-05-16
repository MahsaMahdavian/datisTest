using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertLinqApplication.Identity
{

        public interface IEntity
        {
        }

        public abstract class BaseEntity<TKey> : IEntity
        {
            public TKey Id { get; set; }
        }

        public abstract class BaseEntity : BaseEntity<int>
        {
        }
    
}
