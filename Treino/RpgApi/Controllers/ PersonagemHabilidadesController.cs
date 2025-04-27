using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class  PersonagemHabilidadesController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonagemHabilidadesController(DataContext context){
            _context = context;
        }

        [HttpPost("addPersonagemHabilidade")]
        public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade){
            try{
                Personagem personagem = await _context.TB_PERSONAGEM.Include(p => p.Arma).Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);
                if(personagem == null){
                    throw new Exception("Personagem não encontrado para o Id informado");
                }

                Habilidade habilidade = await _context.TB_HABILIDADES.FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

                if(habilidade == null){
                    throw new Exception("Habilidade não encontrada para o Id informado");
                }

                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.TB_PERSONAGESN_HABILIDADES.AddAsync(ph);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> pega(int id){
            try{
                List<PersonagemHabilidade> Li = await _context.TB_PERSONAGESN_HABILIDADES.Where(ph => ph.PersonagemId == id).ToListAsync();
                return Ok(Li);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetHabilidades")]
        public async Task<IActionResult> GetHabilidades(){
            try{
                List<Habilidade> lh = await _context.TB_HABILIDADES.ToListAsync();
                return Ok(lh);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("deletePersonagemHabilidade")]
        public async Task<IActionResult> DeletePersonagemHabilidade(PersonagemHabilidade personagemHabilidade ){
            try{
                PersonagemHabilidade? ph = await _context.TB_PERSONAGESN_HABILIDADES.FirstOrDefaultAsync(phb => phb.HabilidadeId == personagemHabilidade.HabilidadeId && phb.PersonagemId == personagemHabilidade.PersonagemId);
                if (ph == null){
                    throw new Exception("nao encontrado");
                }
                else{
                    _context.TB_PERSONAGESN_HABILIDADES.Remove(ph);
                    await _context.SaveChangesAsync();

                     List<PersonagemHabilidade> lph =  await _context.TB_PERSONAGESN_HABILIDADES.ToListAsync(); 
                     return Ok(lph);

                }
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){
            try{
                List<PersonagemHabilidade> lph = await _context.TB_PERSONAGESN_HABILIDADES.ToListAsync();
                return Ok(lph);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }
}