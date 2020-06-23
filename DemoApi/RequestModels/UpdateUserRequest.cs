using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.RequestModels
{
    public class UpdateUserRequest
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int id { get; set; }
    }
}
