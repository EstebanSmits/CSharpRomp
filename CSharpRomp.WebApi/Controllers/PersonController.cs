using System.Linq;
using CSharpRomp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;

namespace CSharpRomp.WebApi.Controllers
{
    
    [Produces("application/json")]
    [Route("api/Person")]
    public class PersonController : ODataController
    {
        //public IQueryable<Person>
    }
}