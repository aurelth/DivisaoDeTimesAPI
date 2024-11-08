namespace DivisaoDeTimesAPI.Models
{
    public class Time
    {
        public List<Jogador> Jogadores { get; set; }

        public Time(List<Jogador> jogadores)
        {
            Jogadores = jogadores;
        }
    }
}
