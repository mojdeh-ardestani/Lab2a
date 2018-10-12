using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1A.Data;
using Lab1A.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1A.Controllers
{
    [Produces("application/json")]
    [Route("api/Dealership")]

    public class DealershipApiController : Controller
    {

        private DealershipMgr dealershipMgr = new DealershipMgr();


        // GET: api/DealershipApi
        [HttpGet]
        public IEnumerable<Dealership> GetDealership()
        {
            return dealershipMgr.Get();
            // return _context.Dealership;
        }

        // GET: api/DealershipApi/5
        [HttpGet("{id}")]
        public Dealership GetDealership([FromRoute] int id)
        {


            return dealershipMgr.GetOneDealer(id);


        }

        // PUT: api/DealershipApi/5
        [HttpPut("{id}")]
        public String PutDealership([FromRoute] int id, [FromBody] Dealership dealership)
        {

            // dealershipMgr.Put(dealership,id);
            //_context.Entry(dealership).State = EntityState.Modified;


            dealershipMgr.Put(dealership, id);

            return ("Dealership has been updated");
        }

        // POST: api/DealershipApi
        [HttpPost]
        public String PostDealership([FromBody] Dealership dealership)
        {


            dealershipMgr.Post(dealership);


            return ("Dealership has been added");
        }

        // DELETE: api/DealershipApi/5
        [HttpDelete("{id}")]
        public String DeleteDealership([FromRoute] int id)
        {


            dealershipMgr.DeleteOneDealer(id);

            return ("Dealership has been deleted");

        }
        private bool DealershipExists(int id)
        {
            return dealershipMgr.DealershipExists(id);
        }
    }
}
