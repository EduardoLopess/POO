using apinet06.Models.Domains;
using apinet06.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apinet06.Controllers
{  
    [ApiController]
    [Route("[controller]")]
    public class CobrancaController : ControllerBase
    {
        private ICobrancaRepository repository;
        public CobrancaController(ICobrancaRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public async Task<IEnumerable<Cobranca>> Listar()
        {
            return await repository.get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cobranca>> ListarID(int id)
        {
            return await repository.Get(id);
        }
        
        [HttpPost()]
        public async Task<ActionResult<Cobranca>> AddClient([FromBody] Cobranca cobranca)
        {
            var addCobranca = await repository.Create(cobranca);
            return cobranca;
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
        public async Task<ActionResult> UpCobranca(int id,[FromBody] Cobranca cobranca)
        {
            if(id == cobranca.Id)
                await repository.Update(cobranca);
            return NoContent();    
        }
    }
}