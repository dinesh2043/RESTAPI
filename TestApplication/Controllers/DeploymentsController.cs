using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Model;
using Newtonsoft.Json;

namespace TestApplication.Controllers
{
    // A controller is used to define and group a set of actions.
    // Controllers logically group similar actions together. 
    // This aggregation of actions allows common sets of rules, such as routing, caching, and 
    // authorization, to be applied collectively. 
    // Requests are mapped to actions through routing.

    [Route("/api/deployments")]
    public class DeploymentsController : Controller
    {
        private readonly DeploymentsContext _context;
        private List<String> catlist = new List<string> { "full" };
        
        public DeploymentsController(DeploymentsContext context)
        {
            _context = context;

            if (_context.DeploymentItems.Count() == 0)
            {
                _context.DeploymentItems.Add(new Deployment {
                    Name = "ta104400ww_dev",
                    Description = "ND1 TA-1044_00WW (dev-keys)",
                    Categories = JsonConvert.SerializeObject(catlist)
                });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Deployment> GetAll()
        {
            return _context.DeploymentItems.ToList();
        }

        /**
        [HttpGet("{id}", Name = "GetDeployments")]
        public IActionResult GetById(Guid id)
        {
            var item = _context.DeploymentItems
                .FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    **/
    }
    
}
