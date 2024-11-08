using System.ComponentModel.DataAnnotations;

namespace DivisaoDeTimesAPI.Models
{
    public class Jogador
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'Posicao' é obrigatório.")]
        public Posicao? Posicao { get; set; }

        public Jogador(string nome, Posicao? posicao)
        {
            Nome = nome;
            Posicao = posicao;
        }
    }
}
