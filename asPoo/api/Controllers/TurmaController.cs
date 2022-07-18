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
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TurmaController(ITurmaRepository turmaRepository, IUnitOfWork unitOfWork)
        {
            this._repository = turmaRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult<Turma>> getAsync()
        {
            var turmaList = await _repository.getAsync();
            List<TurmaDTO> turmaDTOs = new List<TurmaDTO>();

            foreach (Turma turma in turmaList)
            {
               var turmaDTO = new TurmaDTO()
               {
                Id = turma.Id,
                Sala = turma.Sala,
                alunos = turma.Alunos,
                numeroTurma = turma.numeroTurma,
                Professor = turma.Professor,
                CursoID = turma.CursoID,
               }; 
               
               turmaDTOs.Add(turmaDTO);
            }
             return Ok(new {
                message = "Lista",
                erroCod = 202
            });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var turma = await _repository.getByIdAsync(id);

            if(turma == null)
                return NotFound(new {
                    message = "Turma Não encontrada",
                    erroCod = 404
                });
            else
            {
                var turmaDTO = new TurmaDTO()
                {
                    Id = turma.Id,
                    Sala = turma.Sala,
                    numeroTurma = turma.numeroTurma,
                    alunos = turma.Alunos,
                    Professor = turma.Professor,
                    CursoID = turma.CursoID,
                };

                  return Ok(new {
                    message = "Turma encontrada",
                    erroCod = 202
                });
            }    
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] TurmaViewModel model)
        {
            var turma = new Turma
            {
                Sala = model.Sala,
                numeroTurma = model.numeroTurma
                
            };

            await _repository.createAsync(turma);
            await _unitOfWork.CommitAsync();

            return Ok(new {
                message = "Turma adcionada",
                erroCod = 202
            }); 

        }

        [HttpPatch("id")]    
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] TurmaViewPatch model)
        {
            var turma = await _repository.getByIdAsync(id);

            if(turma == null)
                return NotFound(new {
                    message = "Turma Não encontrada",
                    erroCod = 404
                });
            else
            {
                turma.Sala = model.Sala;
                turma.numeroTurma = model.numeroTurma;

                await _repository.updateAsync(turma);
                await _unitOfWork.CommitAsync();

                var TurmaDTO = new TurmaDTO()
                {
                    Sala = turma.Sala,
                    numeroTurma = turma.numeroTurma
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
            var turmaDelet = _repository.deleteAsync(id);
            await _unitOfWork.CommitAsync();
            
            if(turmaDelet == null)
                return NotFound(new {
                    message = "Turma Não encontrada",
                    erroCod = 404
                });
            else
                return Ok(new {
                    message = "Deletada",
                    erroCod = 202
                });        
        }
    }
}

 