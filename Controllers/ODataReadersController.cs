using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using ODataCore3.API.Contracts;

namespace ODataCore3.API.Controllers
{
    public class ODataReadersController : ODataController
    {
        private IReadersRepo repo;

        public ODataReadersController(IReadersRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("AllReaders()")]
        public IActionResult Get()
        {
            return Ok(this.repo.GetReaders());
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("ReadersById(id={id})")]
        public IActionResult Get(int id)
        {
            return Ok(this.repo.GetReaders(id));
        }
    }
}