using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ArmasController : ControllerBase
    {
        private readonly DataContext _context;

        public ArmasController(DataContext context){
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){
            try{
                List<Arma> a = await _context.TB_ARMAS.ToListAsync();
                return Ok(a);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> PostArma(Arma arma){
            try{
                await _context.TB_ARMAS.AddAsync(arma);
                await _context.SaveChangesAsync();
                return Ok(GetAll());
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> atualizaArma(Arma novaArma){
            try{
                _context.TB_ARMAS.Update(novaArma);
                await _context.SaveChangesAsync();
                return Ok(await GetAll());
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            try{
                Arma arma = await _context.TB_ARMAS.FirstOrDefaultAsync(arma => arma.Id == id);
                return Ok(arma);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            try{
                Arma arma = await _context.TB_ARMAS.FirstOrDefaultAsync(a => a.Id == id);
                _context.TB_ARMAS.Remove(arma);
                await _context.SaveChangesAsync();
                List<Arma> LArma = await _context.TB_ARMAS.ToListAsync();
                return Ok(LArma);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }


        }
    }
}