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

        [HttpPost]
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
    }
}