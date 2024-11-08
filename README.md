
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


* TECNOLOGIAS UTILIZADAS:

	.NET 7 - Framework principal da aplicação.
	ASP.NET Core Web API - Para construção dos endpoints REST.
	Swagger - Para documentação e teste direto na interface da API.
	System.Text.Json - Para serialização/deserialização de objetos JSON.
	Injeção de Dependência - Para organização dos serviços de divisão de times.

*ESTRUTURA DO PROJETO:
	Controllers: Contém o controlador DivisaoDeTimesController, que expõe o endpoint de divisão de times.
	Services: Contém o serviço SorteadorDeTimesService, que realiza a lógica de sorteio e distribuição dos jogadores.
	Models: Contém as classes Jogador, Time e Posicao para estruturar os dados da API.
	
*PARA BAIXAR E TESTAR:
	1- Clone o projeto (git clone https://github.com/aurelth/DivisaoDeTimesAPI)
	2- Entre na pasta do projeto (cd seu-repositorio)
	3- Restaure as dependências e execute a aplicação: dotnet restore e dotnet run
	4- Entre no Swagger e teste: http://localhost:5028/swagger/index.html
	5- Use esse JSon como exemplo para testar:
	[
	{ "nome": "Jogador 1", "posicao": "Goleiro" },
	{ "nome": "Jogador 2", "posicao": "Goleiro" },
	{ "nome": "Jogador 3", "posicao": "Zagueiro" },
	{ "nome": "Jogador 4", "posicao": "Zagueiro" },
	{ "nome": "Jogador 5", "posicao": "Lateral" },
	{ "nome": "Jogador 6", "posicao": "Lateral" },
	{ "nome": "Jogador 7", "posicao": "MeioCampista" },
	{ "nome": "Jogador 8", "posicao": "MeioCampista" },
	{ "nome": "Jogador 9", "posicao": "Atacante" },
	{ "nome": "Jogador 10", "posicao": "Atacante" },
	{ "nome": "Jogador 11", "posicao": "Zagueiro" },
	{ "nome": "Jogador 12", "posicao": "Zagueiro" },
	{ "nome": "Jogador 13", "posicao": "Lateral" },
	{ "nome": "Jogador 14", "posicao": "Lateral" },
	{ "nome": "Jogador 15", "posicao": "MeioCampista" },
	{ "nome": "Jogador 16", "posicao": "Atacante" }
	]