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
        public IEnumerable<Cobranca>Get()
        {
            return repository.GetAll();
        }
    

        [HttpGet("{id}")]
        public Cobranca GetClient(int id)
        {
            return repository.GetById(id);
        }
    
        
        [HttpPost()]
        public IActionResult Post([FromBody]Cobranca cobranca)
        {
            repository.Create(cobranca);
            return Ok(new {
                message = "Cliente Salvo",
                erroCode = 202,
                objCreated = cobranca
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
        public ActionResult Put([FromBody] Cobranca cobranca)
        {
            repository.Update(cobranca);
            return Ok(new {
                message = "Client Update.",
                erroCod = 202
            });
        }
    
    }
}