using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGames.Api.Models.Models;
using VideoGames.BLL.Abstract;
using VideoGames.BLL.Domain;
using VideoGames.BLL.Domain.DTO;

namespace VideoGames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;
        private readonly IMapper _mapper;

        public GamesController(IGameService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(GameRequest model)
        {
            try
            {
                GameRequestDTO dto = _mapper.Map<GameRequestDTO>(model);
                OperationResult result = await _service.AddAsync(dto);
                if (result.Status == OperationResult.OperationStatus.Success)
                    return Ok(result);
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(GameUpdateRequest model)
        {
            try
            {
                GameRequestDTO dto = _mapper.Map<GameRequestDTO>(model);
                OperationResult result = await _service.UpdateAsync(dto);
                if (result.Status == OperationResult.OperationStatus.Success)
                    return Ok(result);
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                OperationResult result = await _service.DeleteAsync(id);
                if (result.Status == OperationResult.OperationStatus.Success)
                    return Ok(result);
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            try
            {
                GameResponseDTO? dto = await _service.GetAsync(id);

                if (dto == null)
                    return NotFound();
                GameResponse model = _mapper.Map<GameResponse>(dto);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<GameResponseDTO> dto = await _service.GetAllAsync();

                if (dto == null || dto.Count() == 0)
                    return NotFound();
                IEnumerable<GameResponse> model = _mapper.Map<IEnumerable<GameResponse>>(dto);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByGenreAsync(int id)
        {
            try
            {
                IEnumerable<GameResponseDTO> dto = await _service.GetByGenreAsync(id);
                IEnumerable<GameResponse> model = _mapper.Map<IEnumerable<GameResponse>>(dto);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
