# BibliotecaMongoDb

Tecnologias usadas: MongoDB para banco de dados. C# Api BackEnd e Typescrypt angular para o Front End
Versão do node v14.15.0
Angular CLI: 13.2.6

Pacotes do nuget que devem ser verificados:
MongoDb.Driver versão 2.15.0
MongoDb.Entities versão 20.25.3

Antes de rodar o angular deve ser rodado o comando 'npm i' para baixar os pacotes necessários

Mongo Db Compass usado link string de conexão na solução da BibliotecaDLL arquivo Connection.cs


Após rodar o front e backend na pagina localhost:4200 vai entrar na home ao clicar na NavBar na opção de Livros carrega os livros já cadastrados,
são carregados na ordem de qual possui mais empréstimos.
Para adicionar um novo livro, basta preencher o campo de título e autor e clicar no botão salvar,
para editar um livro selecionar o "lápis" na tabela que ira carregar as informações atuais e salvar o livro.
Caso queira excluir um livro basta clicar na opção do "menos" em vermelho que aparecerá uma caixa de confirmação.

Para fazer um empréstimo basta clicar no botao de marcação de livro que ira pedir para informar o nome do usuário.
Para realizar a devolução do livro basta clicar agora no botão de vinculação que ira realizar a devolução.

É possível filtrar os campos id, autor e titulo no campo acima da tabela para facilitar a busca.
