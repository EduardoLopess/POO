using api.DTOs;
using api.ViewModels;
using api.ViewModels.Patchs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotasController : ControllerBase
    {
       private readonly INotaRepository _repository;
       private readonly IUnitOfWork _unitOfWork;

       public NotasController(INotaRepository notaRepository, IUnitOfWork unitOfWork)
       {
        this._repository = notaRepository;
        this._unitOfWork = unitOfWork;
       }

       
        [HttpGet()]
        public async Task<ActionResult<Notas>> getAsync()
        {
            var notasList = await _repository.getAsync();
            List<NotasDTO> notasDTOs = new List<NotasDTO>();

            foreach (Notas notas in notasList)
            {
                var notasDTO = new NotasDTO()
                {
                    Id = notas.Id,
                    Nota = notas.Nota,
                    MateriaID = notas.MateriaID,
                    AlunoID = notas.AlunoID,
                    HistoricoID = notas.HistoricoID
                };

                notasDTOs.Add(notasDTO);
            }
              return Ok(new {
                message = "Lista",
                erroCod = 202
            });
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var notas = await _repository.getByIdAsync(id);
            
            if(notas == null)
                return NotFound(new {
                    message = "Notas Não encontrada",
                    erroCod = 404
                });
            else
            {
                var notasDTO = new NotasDTO()
                {
                    Id = notas.Id,
                    Nota = notas.Nota,
                    MateriaID = notas.MateriaID,
                    AlunoID = notas.AlunoID,
                    HistoricoID = notas.HistoricoID
                };

                return Ok(new {
                    message = "Nota encontrado",
                    erroCod = 202
                });
            }    
        }
        [HttpPost()]
         public async Task<IActionResult> PostAsync([FromBody] NotasViewModel model)
        {
            var notas = new Notas
            {
                Nota = model.Nota,
                MateriaID = model.MateriaID,
                AlunoID = model.AlunoID,
                HistoricoID = model.HistoricoID
            };

            await _repository.createAsync(notas);
            await _unitOfWork.CommitAsync();

            return Ok(new {
                message = "Nota adcionada",
                erroCod = 202
            }); 
        }

        [HttpPatch("id")]    
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] NotasViewPatch model)
        {
            var notas = await _repository.getByIdAsync(id);

            if(notas == null)
                return NotFound(new {
                    message = "Nota Não encontrada",
                    erroCod = 404
                });
            else
            {
                notas.Nota = model.Nota;

                await _repository.updateAsync(notas);
                await _unitOfWork.CommitAsync();

                var NotasDTO = new NotasDTO()
                {
                    Nota = notas.Nota
                };

                return Ok(new {
                    message = "Atualizado",
                    erroCod = 202
                });
            }    
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var notasDelet = _repository.deleteAsync(id);
            await _unitOfWork.CommitAsync();

            if(notasDelet == null)
                return NotFound(new {
                    message = "Nota Não encontrada",
                    erroCod = 404
                });
            else
                return Ok(new {
                    message = "Deletado",
                    erroCod = 202
                });     
        }
    }
}