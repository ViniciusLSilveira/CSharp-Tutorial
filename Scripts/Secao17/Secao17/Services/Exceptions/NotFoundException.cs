using System;

namespace Secao17.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {

        public NotFoundException(string message) : base (message)
        {
        }

    }
}
