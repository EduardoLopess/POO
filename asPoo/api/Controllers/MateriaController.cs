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
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MateriaController(IMateriaRepository materiaRepository, IUnitOfWork unitOfWork)
        {
            this._repository = materiaRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult<Materia>> getAsync()
        {
           var materiaList = await _repository.getAsync();
           List<MateriaDTO> materiaDTOs = new List<MateriaDTO>();

           foreach (Materia materia in materiaList)
           {
                var materiaDTO = new MateriaDTO()
                {
                    Id = materia.Id,
                    Nome = materia.Nome,
                    notas = materia.notas,
                    Duracao = materia.Duracao,
                    Professor = materia.professor,
                    Curso = materia.curso
                    
                };
                materiaDTOs.Add(materiaDTO);
           }
           return Ok(new {
                message = "Lista",
                erroCod = 202
            }); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var materia = await _repository.getByIdAsync(id);

            if(materia == null)
                return NotFound(new {
                    message = "Matéria Não encontrada",
                    erroCod = 404
                });
            else
            {
                var MateriaDTO = new MateriaDTO()
                {
                    Id = materia.Id,
                    Nome = materia.Nome,
                    notas = materia.notas,
                    Duracao = materia.Duracao,
                    Professor = materia.professor,
                    Curso = materia.curso
                };
                return Ok(new {
                    message = "Matéria encontrado",
                    erroCod = 202
                });
            }    
        }
         [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] MateriaViewModel model)
        {
            var materia = new Materia
            {
                Nome = model.Nome,
                Duracao = model.Duracao,
                // professor = model.Professor,
                // curso = model.Curso,
                // notas = model.notas
            };

            await _repository.createAsync(materia);
            await _unitOfWork.CommitAsync();

            return Ok(new {
                message = "Matéria Adcionado",
                erroCod = 202
            }); 
        }
        [HttpPatch("id")]    
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] MateriaViewPatch model)
        {
            var materia = await _repository.getByIdAsync(id);

            if(materia == null)
                return NotFound(new {
                    message = "Matéria Não encontrado",
                    erroCod = 404
                });
            else
            {
                materia.Nome = model.Nome;
                materia.professor = model.Professor;
                materia.Duracao = model.Duracao;
                // materia.notas = model.notas;
                // materia.curso = model.Curso;

                await _repository.updateAsync(materia);
                await _unitOfWork.CommitAsync();

                var MateriaDTO = new MateriaDTO()
                {
                    Nome = materia.Nome,
                    Curso = materia.curso,
                    Professor = materia.professor,
                    Duracao = materia.Duracao,
                    notas = materia.notas
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
            var materiaDelet = _repository.deleteAsync(id);
            await _unitOfWork.CommitAsync();

             if(materiaDelet == null)
                return NotFound(new {
                    message = "Matéria Não encontrada",
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

   