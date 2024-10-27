using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public string ResourceNotFound { get; }
        public ResourceNotFoundException()
        {

        }

        public ResourceNotFoundException(string message) : base(message)
        {
            ResourceNotFound = message;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, ResourceNotFound:{ResourceNotFound}";
        }
    }
}
