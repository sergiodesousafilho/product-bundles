# product-bundles

Este projeto tem por objetivo realizar uma demonstração de como criar uma estrutura recursiva que descreve peças necessárias para montagem de produtos.


### Como executar o projeto localmente

- Configurar uma connection string com credenciais válidas para uma base SQL Server local no arquivo appsettings.Development.json que está na raíz do projeto.
- Caso não tenha o cli do ef core instalado na máquina, navegar pelo terminar para a pasta do projeto e executar o comando abaixo.
    > `dotnet tool install --global dotnet-ef`
- Para criar a base de dados ou atualizar, executar o comando abaixo.
    > `dotnet ef database update`


### Dados de exemplo

- Não criei tela de cadastro de produtos ainda. Então, para alimentar o projeto com produtos, deve-se cadastrar manualmente os produtos no banco de dados.
  Também estou incluindo um script para inserir dados de exemplo, caso prefira. O arquivo insert-sample-data.sql está na pasta scripts na raíz do repositório.
- A lógica utilizada na tela de cadastro de novos bundles foi permitir somente criar bundles contendo bundles filhos que já estejam cadastrados na base.
  Então, para o exemplo da bicicleta, seria necessário cadastrar primeiro o bundle da roda da bicicleta para depois sim poder criar o bundle da bicicleta utilizando o bundle da roda.


### Solução do problema

- A solução para quantos bundles seria possível construir com os produtos cadastrados na base, está na parte de baixo da tela Home, sob o título "Information". 
  Esta área exibe uma tabela com a quantidade máxima de bundles de cada tipo que seria possível construir com os produtos atualmente no estoque.
- Esta resposta não inclui lógica para construir bundles raíz (P0) diferentes ao mesmo tempo. 
  Então, caso existam bundles que utilizam os mesmos produtos de outros bundles, deve-se atentar que este resultado está exibindo o total possível de bundles a 
  serem construídos caso todos os produtos do estoque fossem utilizados para aquele bundle raíz específico.
- O diagrama solicitado está na pasta diagrams na raíz do repositório.
- A coluna Amount da tabela Product, informa quantos itens de um produto existem no estoque.
- A coluna Amount da tabela BundleProduct, informa quantos itens de um produto são necessários para a construção de um bundle.
- A coluna Amount da tabela BundleRelation, informa quantos bundles filhos são necessários para a criação de um bundle pai.

### Considerações

Existem muito pontos de melhoria possíveis neste projeto, por exemplo:

- Utilizei lazy loading para acelerar o desenvolvimento mas não é uma boa prática para um projeto de produção.
- Utilizei uma versão muito simplificada de DDD para organizar o projeto. Poderia incluir mais camadas, inversão de dependência com interfaces, etc.
- As consultas em loop seriam certamente um problema em projetos reais e poderiam ser evitadas de várias formas diferentes. Por exemplo:
  - Carregando todos os objetos para a memória primeiro com uma consulta de tudo ou com eager loading, caso a base seja pequena.
  - Fazer consultas recursivas em SQL, também somente caso a quantidade de dados não seja tão grande.
  - Incluir uma base noSql com dados pré-alimentados contendo toda a hierarquia dos bundles. Isso exigiria um projeto ETL para alimentar periodicamente a base noSql.
  - Entre outras opções. Tudo isso dependeria de detalhes específicos de um projeto real.

### Troubleshooting

- Caso o google chrome bloqueie o acesso do navegador ao sistema devido ao certificado SSL, pode-se digitar no teclado "thisisunsafe" estando com o navegador em primeiro plano, para desligar este bloqueio de certificado.