using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athos.Web.Models.Comunication
{
    public class CustomResponse
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public object Data { get; set; }

    }
}
