using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Exceptions
{
    public class Exceptions
    {
        public class NotFoundException : Exception
        {
            public NotFoundException() : base("") { }

            public NotFoundException(string message) : base(message) { }
        }
        public static NotFoundException NotFound<TEntity>(object id)
        {
            return new NotFoundException($"Record not found - {typeof(TEntity).Name} - Id: {id}");
        }
    }
}
