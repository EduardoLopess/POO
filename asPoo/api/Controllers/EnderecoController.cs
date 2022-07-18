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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EnderecoController(IEnderecoRepository enderecoRepository, IUnitOfWork unitOfWork)
        {
            this._repository = enderecoRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<ActionResult<Endereco>> getAsync()
        {
            var enderecoList = await _repository.getAsync();
            List<EnderecoDTO> enderecoDTOs = new List<EnderecoDTO>();

            foreach (Endereco endereco in enderecoList)
            {
                var enderecoDTO = new EnderecoDTO()
                {
                    Id = endereco.Id,
                    CEP = endereco.CEP,
                    Rua = endereco.Rua,
                    Cidade = endereco.Cidade,
                    numCasa = endereco.numCasa,
                    AlunoID = endereco.AlunoID,
                    ProfessorID = endereco.ProfesssorID
                };
                enderecoDTOs.Add(enderecoDTO);
            }
             return Ok(new {
                message = "Lista",
                erroCod = 202
            });
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var endereco = await _repository.getByIdAsync(id);

            if(endereco == null)
                return NotFound(new {
                    message = "Endereço Não encontrado",
                    erroCod = 404
                });
            else
            {
                var EnderecoDTO = new EnderecoDTO()
                {
                    Id = endereco.Id,
                    CEP = endereco.CEP,
                    Rua = endereco.Rua,
                    Cidade = endereco.Cidade,
                    numCasa = endereco.numCasa,
                    AlunoID = endereco.AlunoID,
                    ProfessorID = endereco.ProfesssorID
                };
                return Ok(new {
                    message = "Endereço encontrado",
                    erroCod = 202
                });
            }    
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody] EnderecoViewModel model)
        {
            var endereco = new Endereco
            {
                CEP = model.CEP,
                Rua = model.Rua,
                Cidade = model.Cidade,
                numCasa = model.numCasa,
                Complemento = model.Complemento,
                ProfesssorID = model.ProfessorID,
                AlunoID = model.AlunoID
            };

            await _repository.createAsync(endereco);
            await _unitOfWork.CommitAsync();

            return Ok(new {
                message = "Endereço Adcionado",
                erroCod = 202
            }); 
        }

        [HttpPatch("id")]    
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EnderecoViewPatch model)
        {
            var endereco = await _repository.getByIdAsync(id);

            if(endereco == null)
                return NotFound(new {
                    message = "Endereço Não encontrado",
                    erroCod = 404
                });
            else
            {
                endereco.CEP = model.CEP;
                endereco.Rua = model.Rua;
                endereco.Cidade = model.Cidade;
                endereco.numCasa = model.numCasa;
                endereco.Complemento = model.Complemento;
                endereco.AlunoID = model.AlunoID;
                endereco.ProfesssorID = model.ProfessorID;

                await _repository.updateAsync(endereco);
                await _unitOfWork.CommitAsync();

                var enderecoDTO = new EnderecoDTO()
                {
                    CEP = model.CEP,
                    Rua = model.Rua,
                    Cidade = model.Cidade,
                    numCasa = model.numCasa,
                    Complemento = model.Complemento,
                    ProfessorID = model.ProfessorID,
                    AlunoID = model.AlunoID
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
            var enderecoDelet = _repository.deleteAsync(id);
            await _unitOfWork.CommitAsync();

            if(enderecoDelet == null)
                return NotFound(new {
                    message = "Endereço não encontrado",
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
