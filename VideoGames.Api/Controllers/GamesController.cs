using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGames.Api.Models.Models;
using VideoGames.BLL.Abstract;
using VideoGames.BLL.Domain.DTO;

namespace VideoGames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : BaseController<GameModel, IGameService, GameDTO>
    {
        public GamesController(IGameService service, IMapper mapper) : base(service, mapper) { }

        [HttpGet("[action]/{id}")]
        public  async Task<IActionResult> GetByGenreAsync(int id)
        {
            try
            {
                IEnumerable<GameDTO> dto = await _service.GetByGenreAsync(id);
                IEnumerable<GameModel> model = _mapper.Map<IEnumerable<GameModel>>(dto);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
