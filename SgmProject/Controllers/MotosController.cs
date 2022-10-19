using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SgmProject.Data;
using SgmProject.Models;

namespace SgmProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : Controller
    {
        private readonly Context _context;

        public MotosController(Context contexto)
        {
            this._context = contexto;
        }

        [HttpGet] //notacion 
        public async Task<IActionResult> GetAll()
        {
            var motos = await _context.Motos.ToListAsync();
            return Ok(motos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var motos = await _context.Motos.FirstOrDefaultAsync(x => x.Id == id);
            if (motos != null)
            {
                return Ok(motos);
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> AddMotos([FromBody] Moto moto)
        {
            moto.Id = Guid.NewGuid();
            await _context.Motos.AddAsync(moto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(AddMotos), moto.Id, moto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateMotos([FromRoute] Guid id, [FromBody] Moto moto)
        {
           var motoExistente = await _context.Motos.FirstOrDefaultAsync(x => x.Id == id);
            if (motoExistente != null)
            {
                motoExistente.Modelo = moto.Modelo;
                motoExistente.Cilindrada = moto.Cilindrada;
                motoExistente.Categoria = moto.Categoria;
                motoExistente.Marca = moto.Marca;
                motoExistente.Preco = moto.Preco;
                motoExistente.Ano = moto.Ano;
                await _context.SaveChangesAsync();
                return Ok(motoExistente);
            }
            return NotFound("Moto não encontrada");
           
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteMotos([FromRoute] Guid id)
        {
            var motoExistente = await _context.Motos.FirstOrDefaultAsync(x => x.Id == id);
            if (motoExistente != null)
            {
                _context.Remove(motoExistente);
                await _context.SaveChangesAsync();
                return Ok(motoExistente);
            }
            return NotFound("Moto não encontrada para exclusão");

        }

    }
}
