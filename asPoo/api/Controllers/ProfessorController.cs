using api.DTOs;
using api.ViewModels;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfessorController(IProfessorRepository professorRepository, IUnitOfWork unitOfWork)
        {
            this._repository = professorRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult<Professor>> getAsync()
        {
            var professorList = await _repository.getAsync();
            List<ProfessorDTO> professorDTO = new List<ProfessorDTO>();

            foreach (Professor professor in professorList)
            {
                var  professoresDTO = new ProfessorDTO()
                {
                    Id = professor.Id,
                    nome = professor.nome,
                    sobreNome = professor.sobreNome,
                    cdgIndentificacao = professor.cdgIndentificacao,
                    fone = professor.fone,
                    // Turma = professor.Turmas,
                    // Curso = professor.Curso,
                    Endereco = professor.Endereco,
                    // Departamento = professor.departamento
                };

                professorDTO.Add(professoresDTO);
            }
            return Ok(new {
                message = "Lista",
                erroCod = 202
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var professor = await _repository.getByIdAsync(id);

             if(professor == null)
                return NotFound(new {
                    message = "Professor Não encontrado",
                    erroCod = 404
                });
            else
            {
                var  professoresDTO = new ProfessorDTO()
                {
                    Id = professor.Id,
                    nome = professor.nome,
                    sobreNome = professor.sobreNome,
                    cdgIndentificacao = professor.cdgIndentificacao,
                    fone = professor.fone,
                    // Turma = professor.Turmas,
                    // Curso = professor.Curso,
                    Endereco = professor.Endereco,
                    // Departamento = professor.departamento
                   
                };

                return Ok(new {
                    message = "Professor encontrado",
                    erroCod = 202
                });
            }
        }
        
        [HttpPost()]
         public async Task<IActionResult> PostAsync([FromBody] ProfessorViewModel model)
         {
            var professor = new Professor
            {
                nome = model.nome,
                fone = model.fone,
                sobreNome = model.sobreNome,
                cdgIndentificacao = model.cdgIndentificacao,
                // departamento = model.departamento,
                // Turmas = model.Turma,
                 Endereco = model.Endereco
                // Curso = model.Curso   
            };

            await _repository.createAsync(professor);
            await _unitOfWork.CommitAsync();

            return Ok(new {
                message = "Professor adcionado",
                erroCod = 202
            }); 
        }

        [HttpPatch("id")]    
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] ProfessorViewPatch model)
        {
            var professor = await _repository.getByIdAsync(id);

            if(professor == null)
                return NotFound(new {
                    message = "Professor Não encontrado",
                    erroCod = 404
                });
            else
            {
                professor.nome = model.nome;
                professor.fone = model.fone;
                professor.sobreNome = model.sobreNome;
                professor.cdgIndentificacao = model.cdgIndentificacao;
                professor.Endereco = model.Endereco;
                // professor.Curso = model.Curso;
                // professor.Turmas = model.Turma;

                await _repository.updateAsync(professor);
                await _unitOfWork.CommitAsync();

                var ProfessorDTO = new ProfessorDTO()
                {
                    nome = professor.nome,
                    sobreNome = professor.sobreNome,
                    cdgIndentificacao = professor.cdgIndentificacao,
                    fone = professor.fone,
                    // Turma = professor.Turmas,
                    // Curso = professor.Curso,
                    Endereco = professor.Endereco,
                    // Departamento = professor.departamento
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
            var professorDelet = _repository.deleteAsync(id);
            await _unitOfWork.CommitAsync();
            
            if(professorDelet == null)
                return NotFound(new {
                    message = "Professor Não encontrado",
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

       