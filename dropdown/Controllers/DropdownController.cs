using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace dropdown.Controllers
{
      [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DropdownController : ApiController
    {
        private praveenbhattEntities1 db = new praveenbhattEntities1();

        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetState")]

        [Route("api/Dropdown/GetState")]
        public IHttpActionResult GetState()
        {
            List<State> allState = new List<State>();
            allState = db.States.OrderBy(a => a.StateId).ToList();
            return Ok(allState);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("api/Dropdown/GetCities/{id:int}")]
        public IHttpActionResult GetCities(int id)
        {
            var q = db.Cities.Where(c => c.StateId == id);

            return Ok(q);
        }

    }
}
