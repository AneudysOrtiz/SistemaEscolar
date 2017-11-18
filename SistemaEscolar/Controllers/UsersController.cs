using Microsoft.AspNet.Identity;
using SistemaEscolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SistemaEscolar.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using(var db=new GeneralContext())
            {
                var users = db.Users.ToList();

                    return users;
            }
        }

        // GET: api/Users/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            
            using (var db = new GeneralContext())
            {
                var user = db.Users.Where(x=>x.UserId==id).FirstOrDefault();

                
                return Ok(user);
            }
        }

        [HttpGet, Route("getUsersQuantity")]
        public IHttpActionResult getUsersQuantity()
        {
            using(var db =new GeneralContext())
            {
                var quantity = db.Users.Count();

                return Ok(quantity);
            }
        }

        // POST: api/Users
        [HttpPost]
        public IHttpActionResult Post([FromBody]User entity)
        {
            if (entity == null)
                return BadRequest();

            
            using (var db = new GeneralContext())
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return Ok();
            }


           

        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }

    
}
