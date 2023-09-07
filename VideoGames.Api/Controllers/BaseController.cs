using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGames.Api.Models.Abstract;
using VideoGames.BLL.Abstract;
using VideoGames.BLL.Entities.Abstract;

namespace VideoGames.Api.Controllers
{
    public abstract class BaseController<TModel, TService, TDTO> : ControllerBase where TModel : BaseModel where TService : IService<TDTO> where TDTO: BaseDTO
    {
        protected readonly TService _service;
        protected readonly IMapper _mapper;

        public BaseController(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add(TModel model)
        {
            try
            {
                TDTO dto = _mapper.Map<TDTO>(model);
                await _service.AddAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(TModel model)
        {
            try
            {
                TDTO dto = _mapper.Map<TDTO>(model);
                await _service.UpdateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            try
            {
                TDTO? dto = await _service.GetAsync(id);

                if (dto == null)
                    return NotFound();

                TModel model = _mapper.Map<TModel>(dto);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<TDTO> dto = await _service.GetAllAsync();

                if (dto == null || dto.Count() == 0)
                    return NotFound();

                IEnumerable<TModel> model = _mapper.Map<IEnumerable<TModel>>(dto);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
