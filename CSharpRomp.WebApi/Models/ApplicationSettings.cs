using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpRomp.WebApi.Models
{
    public class ApplicationSettings
    {
  
            public string ApplicationName { get; set; }
            public string Version { get; set; }
        

    }
    public class TokenSettings
    {
        public int  TokenExpiration { get; set; }
        public String issuer { get; set; }
        public String audience{ get; set; }
        public String secretKey { get; set; }

    }
    public class ClaimSettings
    {
        public int ClaimExpiration { get; set; }
        

    }
    

}
