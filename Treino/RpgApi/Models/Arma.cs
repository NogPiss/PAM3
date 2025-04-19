namespace RpgApi.Models
{
    public class Arma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Dano { get; set; }
        public Personagem? Personagem { get; set; } = null!; //null! => Ignora os warnings 
        public int? PersonagemId { get; set; }
    }
}