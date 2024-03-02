using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortener.Dados.CustomExceptions
{
    public class InvalidUrlException : Exception
    {
        public int StatusCode { get; }
        public InvalidUrlException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
