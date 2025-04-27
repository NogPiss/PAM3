using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagensController(DataContext context){
            _context = context;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id){
            try{
                Personagem p = await _context.TB_PERSONAGEM
                .Include(ar => ar.Arma)
                .Include(u => u.Usuario)
                .Include(ph => ph.PersonagemHabilidades)
                .ThenInclude(h => h.Habilidade)
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                // .Include(ph => ph.PersonagemHabilidades)
                // .ThenInclude(h => h.Habilidade)
                // .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                return Ok(p);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){
            try{
                List<Personagem> p = await _context.TB_PERSONAGEM.ToListAsync();
                return Ok(p);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetNome/{nome}")]
        public async Task<IActionResult> GetByClass(string nome){
            try{
                Personagem Lp = await _context.TB_PERSONAGEM.FirstOrDefaultAsync(p => p.Nome == nome);
                return Ok(Lp);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Personagem novoPersonagem){
            try{
                if (novoPersonagem.PontosVida > 100){
                    throw new Exception("Os pontos de vida nao podem ser maior que 100");
                }
                await _context.TB_PERSONAGEM.AddAsync(novoPersonagem);
                await _context.SaveChangesAsync();

                return Ok(novoPersonagem.Id);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update(Personagem novoPersonagem){
            try{
                if(novoPersonagem.PontosVida > 100){
                    throw new Exception("Pontos de vida nao pode ser maior que 100");
                }
                _context.TB_PERSONAGEM.Update(novoPersonagem);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

                
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            try{
                Personagem pRemover = await _context.TB_PERSONAGEM.FirstOrDefaultAsync(p => p.Id == id);
                _context.TB_PERSONAGEM.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                
                List<Personagem> listap = await _context.TB_PERSONAGEM.ToListAsync();
                return Ok(listap);

            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }
}