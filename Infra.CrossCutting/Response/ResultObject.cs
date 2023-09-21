using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Infra.CrossCutting.Response
{
    public class ResultObject : ObjectResult
    {
        public ResultObject(HttpStatusCode statusCode, object value) : base(value)
        {
            StatusCode = (int)statusCode;
        }
    }
}