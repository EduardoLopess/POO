using apinet06.Models.Domains;
using apinet06.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private IClientRepository repository;

        public ClientController(IClientRepository repository)
        {
            this.repository = repository;
        }

  

        [HttpGet()]
        public IEnumerable<Client>Get()
        {
            return repository.GetAll();
        }
    

        [HttpGet("{id}")]
        public Client GetClient(int id)
        {
            return repository.GetById(id);
        }
    
        
        [HttpPost()]
        public IActionResult Post([FromBody]Client client)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(client);
            repository.Create(client);
            return Ok(new {
                message = "Cliente Salvo",
                erroCode = 202,
                objCreated = client
            });
        }
     

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return Ok(new {
                message = " Deletado com sucesso.",
                erroCod = 202
            });
        }
       
     
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Client client)
        {
            repository.Update(client);
            return Ok(new {
                message = "Client Update.",
                erroCod = 202
            });
        }
       
        
    }
}