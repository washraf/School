using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils.Exceptions
{
    public class EntityNotValidException:Exception
    {
        public string EntityName { get; private set; }

        public EntityNotValidException(string entityName, string message)
            :base(message)
        {
            EntityName = entityName;
        }
    }
}
