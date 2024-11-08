using DivisaoDeTimesAPI.Models;
using DivisaoDeTimesAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace DivisaoDeTimesTests
{
    [TestFixture]
    public class SorteadorDeTimesServiceTests
    {
        private SorteadorDeTimesService _service;

        [SetUp]
        public void Setup()
        {
            _service = new SorteadorDeTimesService();
        }

        [Test]
        public void DividirTimes_Com16Jogadores_DeveDistribuirIgualmente()
        {
            var jogadores = CriarListaJogadores(16);
            var (time1, time2) = _service.DividirTimes(jogadores);
            Assert.That(time1.Jogadores.Count, Is.EqualTo(8));
            Assert.That(time2.Jogadores.Count, Is.EqualTo(8));
        }

        [Test]
        public void DividirTimes_ComExcedentePar_DeveDistribuirIgualmente()
        {
            var jogadores = CriarListaJogadores(18);
            var (time1, time2) = _service.DividirTimes(jogadores);
            Assert.That(time1.Jogadores.Count, Is.EqualTo(9));
            Assert.That(time2.Jogadores.Count, Is.EqualTo(9));
        }

        [Test]
        public void DividirTimes_ComExcedenteImpar_DeveDistribuirComUmJogadorAMaisEmUmTime()
        {
            var jogadores = CriarListaJogadores(19);
            var (time1, time2) = _service.DividirTimes(jogadores);
            Assert.That((time1.Jogadores.Count == 10 && time2.Jogadores.Count == 9) || (time1.Jogadores.Count == 9 && time2.Jogadores.Count == 10), Is.True);
        }

        [Test]
        public void DividirTimes_ComMenosDe16Jogadores_DeveLancarExcecao()
        {
            var jogadores = CriarListaJogadores(15);
            Assert.Throws<ArgumentException>(() => _service.DividirTimes(jogadores));
        }

        [Test]
        public void DividirTimes_JogadorSemNome_DeveLancarExcecao()
        {
            var jogadores = CriarListaJogadores(16);
            jogadores[0].Nome = null;
            Assert.Throws<ValidationException>(() => _service.DividirTimes(jogadores));
        }

        [Test]
        public void DividirTimes_JogadorSemPosicao_DeveLancarExcecao()
        {
            var jogadores = CriarListaJogadores(16);
            jogadores[0].Posicao = null;
            Assert.Throws<ValidationException>(() => _service.DividirTimes(jogadores));
        }

        private List<Jogador> CriarListaJogadores(int quantidade)
        {
            var jogadores = new List<Jogador>();
            var posicoes = new[] { Posicao.Goleiro, Posicao.Zagueiro, Posicao.Lateral, Posicao.MeioCampista, Posicao.Atacante };

            for (int i = 0; i < quantidade; i++)
            {
                jogadores.Add(new Jogador($"Jogador {i + 1}", posicoes[i % posicoes.Length]));
            }

            return jogadores;
        }
    }
}
