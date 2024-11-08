
A lógica de distribuição dos jogadores na API é projetada para garantir que os times sejam formados de maneira justa e equilibrada. 
Abaixo estão as regras detalhadas de como os jogadores são distribuídos:

* Número Mínimo de Jogadores: A lista de jogadores fornecida deve conter no mínimo 16 jogadores. Se a lista tiver menos de 16 jogadores, a API lançará uma exceção.

* Divisão Equilibrada com 16 Jogadores:

* Se forem fornecidos exatamente 16 jogadores, a API dividirá igualmente os jogadores entre os dois times, resultando em 8 jogadores para cada time.
  Distribuição com Jogadores Excedentes:

* Caso a lista contenha mais de 16 jogadores, esses jogadores adicionais são considerados excedentes e seguem uma regra específica para distribuição:

	1- Número Par de Excedentes:

		Se o número de jogadores excedentes (jogadores além dos 16 iniciais) for par, os excedentes serão divididos igualmente entre os dois times. Por exemplo, com 18 jogadores (16 + 2 excedentes), 
		cada time receberá 9 jogadores no total.

	2- Número Ímpar de Excedentes:

		Se o número de jogadores excedentes for ímpar, um dos times receberá aleatoriamente um jogador a mais do que o outro. Por exemplo, com 19 jogadores (16 + 3 excedentes), um time terá 10 jogadores 
		e o outro terá 9. A escolha de qual time terá o jogador extra é feita de forma aleatória para garantir imparcialidade.

* Validação dos Campos Obrigatórios:

* Cada jogador deve ter um nome e uma posição válida. A posição deve ser uma das seguintes:
	Goleiro
	Zagueiro
	Lateral
	MeioCampista
	Atacante
	
* Se qualquer jogador não tiver nome ou posição, a API lançará uma exceção de validação.