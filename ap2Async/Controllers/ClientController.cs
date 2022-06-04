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
        public async Task<IEnumerable<Client>> Listar()
        {
            return await repository.get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> ListarID(int id)
        {
            return await repository.Get(id);
        }
    
        [HttpPost()]
        public async Task<ActionResult<Client>> AddClient([FromBody] Client client)
        {
            var addClient = await repository.Create(client);
            return client;
        }

        [HttpDelete("{id}")]
        public async Task<AcceptedResult> Deletar(int id)
        {
            var deletar = await repository.Get(id);
            if(repository != null)
                await repository.Delete(deletar.Id);
                return null;
        }

     
        [HttpPut("{id}")]
        public async Task<ActionResult> AttClient(int id,[FromBody] Client client)
        {
            if(id ==client.Id)
                await repository.Update(client);
            return NoContent();    
        }
       
        
    }
}