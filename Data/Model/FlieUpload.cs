using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_4._0.Data.Model
{
    public class FlieUpload
    {
        public string Title { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
