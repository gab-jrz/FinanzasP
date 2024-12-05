using AutoMapper;
using FinanzasPersonales.DTOs;
using FinanzasPersonales.Entities;
using Microsoft.AspNetCore.Mvc;
using FinanzasPersonales.Repositories;


namespace FinanzasPersonales.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : Controller
    {
        private readonly IGastoRepository _gastoRepository;
        private readonly IMapper _mapper;

        public GastosController(IGastoRepository gastoRepository, IMapper mapper)
            => (_gastoRepository, _mapper) = (gastoRepository, mapper);

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gastos = await _gastoRepository.GetAllAsync() ?? new List<Gasto>();
            var gastosDto = _mapper.Map<IEnumerable<GastoDto>>(gastos);
            return Ok(gastosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var gasto = await _gastoRepository.GetByIdAsync(id);
            if (gasto == null) return NotFound();
            var gastoDto = _mapper.Map<GastoDto>(gasto);
            return Ok(gastoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GastoDto gastoDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var gasto = _mapper.Map<Gasto>(gastoDto);
            await _gastoRepository.AddAsync(gasto);
            return CreatedAtAction(nameof(GetById), new { id = gasto.Id }, gastoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GastoDto gastoDto)
        {
            if (id != gastoDto.Id) return BadRequest("El ID no coincide.");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var gasto = _mapper.Map<Gasto>(gastoDto);
            await _gastoRepository.UpdateAsync(gasto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gasto = await _gastoRepository.GetByIdAsync(id);
            if (gasto == null) return NotFound();

            await _gastoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
