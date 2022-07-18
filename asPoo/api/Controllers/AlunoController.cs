using api.DTOs;
using api.ViewModels;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoController(IAlunoRepository alunoRepository, IUnitOfWork unitOfWork)
        {
            this._repository = alunoRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult<Aluno>> getAsync()
        {
            var alunoList = await _repository.getAsync();
            List<AlunoDTO> alunoDTO = new List<AlunoDTO>();

            foreach (Aluno aluno in alunoList)
            {
                var alunosDTO = new AlunoDTO()
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    phone = aluno.phone,
                    NumeroMatricula = aluno.NumeroMatricula,
                    DtNascimento = aluno.DtNascimento,
                    // Curso = aluno.Curso,
                    Endereco = aluno.Endereco,
                    // Turma = aluno.Turma
                    
                };
                
                alunoDTO.Add(alunosDTO);
            }
            return Ok(new {
                message = "Lista",
                erroCod = 202
            });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var aluno = await _repository.getByIdAsync(id);

            if(aluno == null)
                return NotFound(new {
                    message = "Aluno Não encontrado",
                    erroCod = 404
                });
            else
            {
                var AlunoDTO = new AlunoDTO()
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    phone = aluno.phone,
                    NumeroMatricula = aluno.NumeroMatricula,
                    DtNascimento = aluno.DtNascimento,
                    // Curso = aluno.Curso,
                    // Turma = aluno.Turma,
                    Endereco = aluno.Endereco
                };

                return Ok(new {
                    message = "ALuno encontrado",
                    erroCod = 202
                });
            }    
        }
           
        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] AlunoViewModel model)
        {
            var Aluno = new Aluno
                {
                    Nome = model.Nome,
                    phone = model.phone,
                    NumeroMatricula = model.NumeroMatricula,
                    DtNascimento = model.DtNascimento,
                    Endereco = model.Endereco,
                        
                };

            await _repository.createAsync(Aluno);
            await _unitOfWork.CommitAsync();

            return Ok(new {
                message = "Aluno " + Aluno.Nome + "Adcionado",
                erroCod = 202
            }); 
        }

        [HttpPatch("id")]    
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] AlunoViewPatch model)
        {
            var aluno = await _repository.getByIdAsync(id);

            if(aluno == null)
                return NotFound(new {
                    message = "Aluno Não encontrado",
                    erroCod = 404
                });

            else
            {
                aluno.Nome = model.Nome;
                aluno.sobreNome = model.sobreNome;
                aluno.phone = model.phone;
                aluno.Endereco = model.Endereco;

                await _repository.updateAsync(aluno);
                await _unitOfWork.CommitAsync();

                var AlunoDTO = new AlunoDTO()
                {
                    Nome = aluno.Nome,
                    phone = aluno.phone,
                    Endereco = aluno.Endereco
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
            var alunoDelet = _repository.deleteAsync(id);
            await _unitOfWork.CommitAsync();

             if(alunoDelet == null)
                return NotFound(new {
                    message = "Aluno Não encontrado",
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