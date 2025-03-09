using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RpgApi.Models;
using RpgApi.Models.Enuns;
namespace RpgApi.Controllers{
    [ApiController]
    [Route("[Controller]")]

    public class PersonagensExemploController: ControllerBase{

        private static List<Personagem> personagens = new List<Personagem>(){
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago },
        };

        [HttpGet("Getfirst")]
        public IActionResult GetFirst(){
            Personagem p = personagens[0];
            return Ok(p);
        }

        [HttpGet("GetAll")]
        public IActionResult Get(){
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id){
            return Ok(personagens.FirstOrDefault(pe => pe.Id == id));
        }
  
        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdem(){
            List<Personagem> listaFinal = personagens.OrderBy(p => p.Forca).ToList();
            return Ok(listaFinal);
        }

        [HttpGet("GetContagem")]
        public IActionResult GetQuantidade(){
            return Ok("a quantidade de personagens é: " + personagens.Count());
        }

        [HttpGet("GetSomaForca")]
        public IActionResult GetSomaForca(){
            return Ok("A soma das forcas de todos os personagens é: " + personagens.Sum(p => p.Forca));
        }

        [HttpGet("GetSemCavaleiro")]
        public IActionResult GetSemCavaleiro(){
            List<Personagem> ListaSemCavaleiros = personagens.FindAll(pe => pe.Classe != ClasseEnum.Cavaleiro);
            return Ok(ListaSemCavaleiros);
        }

        [HttpGet("GetByNomeAproximado/{nome}")]
        public IActionResult GetByNomeAproximado(string nome){
            List<Personagem> ListaBusca = personagens.FindAll(p => p.Nome.Contains(nome));
            return Ok(ListaBusca);
        }

        [HttpGet("GetRemovendoMago")]
        public IActionResult GetRemovendoMagos(){
            Personagem pRemove = personagens.Find(pe => pe.Classe == ClasseEnum.Mago);
            personagens.Remove(pRemove);
            return Ok("O personagem removido foi: " + pRemove.Nome);
        }

    	[HttpGet("GetByForca/{Forca}")]
        public IActionResult Get(int Forca){
            List<Personagem> personagensPorForca = personagens.FindAll(pe => pe.Forca == Forca);
            return Ok(personagensPorForca);
        }

        [HttpPut]
        public IActionResult UpdatePersonagem(Personagem p){
            Personagem PersonagemAlterado = personagens.Find(pers => pers.Id == p.Id);
            PersonagemAlterado.Nome = p.Nome;
            PersonagemAlterado.PontosVida = p.PontosVida;
            PersonagemAlterado.Forca = p.Forca;
            PersonagemAlterado.Defesa = p.Defesa;
            PersonagemAlterado.Inteligencia = p.Inteligencia;
            PersonagemAlterado.Classe = p.Classe;

            return Ok(personagens);

        }

        [HttpGet("GetByEnum/{enumId}")]
        public IActionResult GetByEnum(int enumId){
            ClasseEnum enumDigitado = (ClasseEnum)enumId;

            List<Personagem> p = personagens.FindAll(pe => pe.Classe == enumDigitado);
            return Ok(p);
        }

        /*Atividade*/

        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome){
            Personagem PersonagemNome = personagens.Find(pe => pe.Nome == nome);
            if(PersonagemNome == null)
                return NotFound("Personagem não encontrado.");
            return Ok(PersonagemNome); 
        }

        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago(){
            List<Personagem> ListaClerigoMago = personagens.FindAll(pe => pe.Classe == ClasseEnum.Mago || pe.Classe == ClasseEnum.Clerigo);
            ListaClerigoMago = ListaClerigoMago.OrderByDescending(pe => pe.PontosVida).ToList();
            return Ok(ListaClerigoMago);
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas(){
            int quantidadeDePersonagens = personagens.Count();
            int somaDaInteIigencia = personagens.Sum(pe => pe.Inteligencia);

            string quantidadeDePersonagensString = quantidadeDePersonagens.ToString();
            string somaDaInteIigenciaString = somaDaInteIigencia.ToString();
            return Ok("A quantidade de personagens presentes na lista é: " + quantidadeDePersonagensString + "\n a soma das inteligencias é: " + somaDaInteIigenciaString  );
        }

        [HttpPost("PostValidacao")]
        public IActionResult addPersonagem(Personagem novoPersonagem){
            if(novoPersonagem.Defesa < 30){
                return BadRequest("A defesa do personagem nao pode ser menor que a 30.");
            }
            else if(novoPersonagem.Inteligencia < 10){
                return BadRequest("A Inteligencia do personagem nao pode ser menor que 10.");
            }
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem novPersonagem){
            if(novPersonagem.Classe == ClasseEnum.Mago && novPersonagem.Inteligencia < 35){
                return BadRequest("Um personagem da classe mago nao pode ser adicionado com uma inteligencia menor que 35.");
            }
            personagens.Add(novPersonagem);
            return Ok(personagens);
        }

        [HttpGet("GetByClasse/{classe}")]
        public IActionResult GetByclasse(ClasseEnum classe){
            List<Personagem> listasFiltrada = personagens.FindAll(pe => pe.Classe == classe).ToList();
            return Ok(listasFiltrada);
        }
    
    }
}
