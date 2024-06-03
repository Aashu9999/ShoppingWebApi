 using Microsoft.AspNetCore.Mvc;
using ShoppingWebApi.EfCore;
using ShoppingWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingApiController : ControllerBase
    { 
        private readonly DbHelper _db;
        public ShoppingApiController(EF_Data_Context eF_Data_Context)
        {
            _db = new DbHelper(eF_Data_Context);
        }
        // GET: api/<ShoppingApiController>
        [HttpGet]

        //[Route("api/[controller]/GetProducts")]

        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<ProductModel> data = _db.GetProducts();
                
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(data);
            }
            catch(Exception)
            {
                type = ResponseType.Failure;
                return BadRequest();
            }


        }

        // GET api/<ShoppingApiController>/5
       /* [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<ShoppingApiController>
        [HttpPost]

       // [Route("api/[controller]/SaveOrder")]
        public IActionResult Post([FromBody] OrderModel model)
        {
            try 
            { 
                _db.SaveOrder(model);
                return Ok("Great");    
            } 
            
            catch (Exception e)
            { 
                return BadRequest();
            }
        }

        // PUT api/<ShoppingApiController>/5
        [HttpPut("{id}")]

       // [Route("api/[controller]/UpdateOrder")]
        public IActionResult Put(int id, [FromBody] OrderModel model)
        {
            try 
            {
                _db.SaveOrder(model);
                return Ok("Done");
            } 
            
            catch (Exception ex) 
            {
                return BadRequest("Error");
            }
        }

        // DELETE api/<ShoppingApiController>/5
        [HttpDelete("{id}")]

       // [Route("api/[controller]/DeleteOrder/{id}")]
        public IActionResult Delete(int id)
        {
            try 
            { 
                _db.DeleteOrder(id);
                return Ok("Done");
            } 
            catch (Exception ex) 
            { 
                return BadRequest($"Could not delete {id}");
            }
        }
    }
}
