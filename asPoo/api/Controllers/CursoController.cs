using api.DTOs;
using api.ViewModels;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CursoController(ICursoRepository cursoRepository, IUnitOfWork unitOfWork)
        {
            this._repository = cursoRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult<Curso>> getAsync()
        {
            var cursoList = await _repository.getAsync();
            List<CursoDTO> cursoDTO = new List<CursoDTO>();

            foreach (Curso curso in cursoList)
            {
                var cursosDTO = new CursoDTO()
                {
                    Id = curso.Id,
                    Nome = curso.Nome,
                    Duracao = curso.Duracao,
                    Departamento = curso .Departamento
                };
                cursoDTO.Add(cursosDTO);
            }
            return Ok(new {
                message = "Lista",
                erroCod = 202
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var curso = await _repository.getByIdAsync(id);

            if(curso == null)
                return NotFound(new {
                    message = "Curso Não encontrado",
                    erroCod = 404
                });
            else
            {
                var cursoDTO = new CursoDTO()
                {
                    Id = curso.Id,
                    Nome = curso.Nome,
                    Duracao = curso.Duracao,
                    // Departamento = curso.Departamento
                };

                return Ok(new {
                    message = "Curso encontrado",
                    erroCod = 202
                });
            }    
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] CursoViewModel model)
        {
            var curso = new Curso
            {
                Nome = model.Nome,
                Duracao = model.Duracao,
                // Departamento = model.Departamento
            };

            await _repository.createAsync(curso);
            await _unitOfWork.CommitAsync();

              return Ok(new {
                message = "Curso Adcionado",
                erroCod = 202
            });
        }

        [HttpPatch("id")]    
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] CursoViewPatch model)
        {
            var curso = await _repository.getByIdAsync(id);

            if(curso == null)
                return NotFound(new {
                    message = "Curso Não encontrado",
                    erroCod = 404
                });
            else
            {
                curso.Nome = model.Nome;
                curso.Duracao = model.Duracao;
                // curso.Departamento = model.Departamento;

                await _repository.updateAsync(curso);
                await _unitOfWork.CommitAsync();
                
                var cursoDTO = new CursoDTO()
                {
                    Nome = curso.Nome,
                    Duracao = curso.Duracao,
                    // Departamento = curso.Departamento
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
            var cursoDelet = _repository.deleteAsync(id);
            await _unitOfWork.CommitAsync();

            if(cursoDelet == null)
                return NotFound(new {
                    message = "Curso Não encontrado",
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
