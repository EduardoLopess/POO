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
    public class DepartamenoController : ControllerBase
    {
        private readonly IDepartamentoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartamenoController(IDepartamentoRepository departamentoRepository, IUnitOfWork unitOfWork)
        {
            this._repository = departamentoRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult<Departamento>> getAsync()
        {
            var departamentoList = await _repository.getAsync();
            List<DepartamentoDTO> departamentoDTO = new List<DepartamentoDTO>();

            foreach (Departamento departamento in departamentoList)
            {
                var departamentosDTO = new DepartamentoDTO()
                {
                    Id = departamento.Id,
                    Nome = departamento.Nome,
                    cursos = departamento.cursos,
                    professores = departamento.professores         
                };
                departamentoDTO.Add(departamentosDTO);
            }
            return Ok(new {
                message = "Lista",
                erroCod = 202
            });
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var departamento = await _repository.getByIdAsync(id);

            if(departamento == null)
                return NotFound(new {
                    message = "Departamento Não encontrado",
                    erroCod = 404
                });
            else
            {
                var departamentoDTO = new DepartamentoDTO()
                {
                    Id = departamento.Id,
                    Nome = departamento.Nome,
                    cursos = departamento.cursos
                };

                 return Ok(new {
                    message = "Departamento encontrado",
                    erroCod = 202
                });
            }
        }
        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] DepartamentoViewModel model)
        {
            var departamento = new Departamento
            {
                Nome = model.Nome,
                // cursos = model.cursos,
                // professores = model.professores         
            };

            await _repository.createAsync(departamento);
            await _unitOfWork.CommitAsync();

             return Ok(new {
                message = "Departamento Adcionado",
                erroCod = 202
            }); 
        }
        [HttpPatch("id")]    
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] DepartamentoViewPatch model)
        {
            var departamento = await _repository.getByIdAsync(id);

            if(departamento == null)
                return NotFound(new {
                    message = "Aluno Não encontrado",
                    erroCod = 404
                });
            else
            {
                departamento.Nome = model.Nome;
                // departamento.cursos = model.cursos;
                // departamento.professores = model.professores;

                await _repository.updateAsync(departamento);
                await _unitOfWork.CommitAsync();

                var departamentoDTO = new DepartamentoDTO()
                {
                    Nome = departamento.Nome,
                    cursos = departamento.cursos,
                    professores = departamento.professores
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
            var departamentoDelet = _repository.deleteAsync(id);
            await _unitOfWork.CommitAsync();

             if(departamentoDelet == null)
                return NotFound(new {
                    message = "Departamento Não encontrado",
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