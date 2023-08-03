# Aplicação Fluxo Caixa

Aplicação responsavel por creditar e debitar valores e mostrar o saldo consolidado diario

É composta por 3 endpoints:

	Creditar, onde é passado o valor do credito
	Debitar, onde é passado o valor do debito
	Mostrar o saldo consolidado diario

Existem mais 2 endpoints de infraestrutura da aplicação:

	HealthCheck: faz validações se a aplicação esta funcionando corretamente. É usada por exemplo para o kubernetes verificar se a aplicação esta com problemas, nesse caso ele pode reinicia-la. Em uma aplicação real, podem ser adicionadas mais verificações nesse endpoint
	Home: um endpoint basico que responde no endereço base (/). Serve para testar a aplicação e retorna informações uteis sobre ela

Para que a aplicação funcione, algumas variaveis de ambiente devem ser informadas:

- SERVICE_NAME: Nome da aplicação. Util em ambiente de microsserviços
- SERVICE_VERSION: Numero da versão da aplicação
- ASPNETCORE_ENVIRONMENT: Ambiente onde esta a aplicação (desenvolvimento, homologação, produção)
- MAX_MEMORY: Quantidade maxima de memoria que a aplicação deve usar. Caso passe disso, o endpoint healhcheck retornará erro (400). Com isso a aplicação poderá ser reiniciada ou outra ação pode ser tomada

## Para executar via docker:

- docker build -t fluxocaixa:1 .
- docker run -p 5000:80 --name fluxocaixa fluxocaixa:1

Acesse: http://localhost:5000/swagger

Fiz um desenho de arquitetura considerando um monolito (ja que a aplicaçao é muito simples) com um frontend SPA com angular por exemplo e backend em dot net hospedado na azure usando AKS (kubernetes)

O desenho esta disponivel aqui:

https://github.com/AndreRoque/Carrefour/blob/main/docs/Arquitetura%20macro%20-%20Carrefour.pptx
