<p align="center">

  <h2 align="center">API para gerenciamento de consumo energético ⚡</h2>
</p>

## ❓ Por quê?
Este projeto foi criado para aperfeiçoar meus conhecimentos em .Net e arquitetura Rest API, sendo assim, eu realmente aprecio qualquer feedback que você possa me dar sobre o projeto, o código, a arquitetura, o padrão de design ou qualquer outro ponto que queira reportar — isso me ajuda a me tornar um desenvolvedor melhor.  
Para contribuir com isso, você pode me enviar um e-mail: [dellano.liagi2004@gmail.com](mailto:dellano.liagi2004@gmail.com), se conectar comigo no [LinkedIn](https://www.linkedin.com/in/maurizio-dellano/) ou abrir uma issue aqui [issue](https://github.com/Dellano23/EnergyApi/issues/new).


## ⚖ REST
O objetivo de aplicar REST aqui é basicamente melhorar alguns detalhes no serviço web. REST oferece diversos benefícios, como desempenho e confiabilidade.  
Desempenho é um dos fatores que motivam o uso de um aplicativo — quanto maior a velocidade, melhor. Já a confiabilidade é essencial para o serviço, pois outras aplicações irão consumir esta API, e uma comunicação clara entre elas precisa acontecer.

Sobre esta API: ela é separada do cliente e é *stateless* (sem estado). Isso significa que cada requisição é independente. Por exemplo, a rota `api/equipamento` requer um *bearer token* para autenticação. Sendo assim, se um usuário fizer duas requisições para essa rota, ambas devem conter o token.

Tenho certeza de que ainda há detalhes do REST que esta API não segue, ou até mesmo regras que estão sendo quebradas. Ainda estou em processo de aprendizado, que é constante e portanto não me permite corrigir tudo ainda, mas meu foco é total no aprendizado e melhorar cada vez mais meus conhecimentos, para desenvolvimento de soluções cada vez mais completas.  
 — então, se você identificar algo, me avise (você pode abrir uma issue [aqui](https://github.com/Dellano23/EnergyApi/issues/new)) 😉.


 ## 🔨 Arquiterura

Neste projeto, utilizei a arquitetura MVVM (Model - View - ViewModel) para organizar melhor as responsabilidades e facilitar a manutenção. Os Models representam a estrutura dos dados, os Services concentram as regras de negócio, o Repository é utilizado para acesso direto ao banco, pois neste projeto utilizei Entity Framework Core para utilizar objetos C# e transformá-los em entidades relacionais salva em um Banco de Dados Oracle. Também temos as ViewModels, que servem para transportar os dados entre a API e o restante da aplicação.

Além disso, utilizei o padrão de injeção de dependência nativo do ASP.NET Core para registrar nossos serviços e repositórios. Dessa forma, conseguimos aplicar o princípio de inversão de dependência, desacoplando os componentes e facilitando a troca ou evolução de suas implementações no futuro. Por exemplo:

```ts
builder.Services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
builder.Services.AddScoped<IEquipamentoService, EquipamentoService>();
```

Isso significa que, sempre que algum componente precisar de um IEquipamentoRepository por exemplo, o .NET irá injetar uma instância da classe EquipamentoRepository, sem que seja necessário criá-la manualmente. Isso torna a aplicação mais testável, pois podemos facilmente substituir implementações reais por mocks em cenários de teste.

Por fim, utilizei o AutoMapper para automatizar o mapeamento entre as ViewModels e os Models. Isso elimina a necessidade de conversões manuais e reduz a chance de erros de mapeamento, além de manter o código mais limpo.

## Funcionamento 
Tendo uma média do valor do kwh, que pode ser obtido dividindo o valor total da conta de luz pelo consumo total de kwh nela, o usuário, estando devidamente logado no sistema que gera um Bearer token e permite acesso a 3 roles, pode inserir o custo do kwh e o id do equipamento que deseja realizar o cálculo.

Com base no tempo de uso (minutos) registrado na model do equipamento e sua potência em Watts, temos o retorno na API do custo diário e mensal do equipamento. 

<p align="center">
  <img src="EnergyApi.gif" alt="Prévia do projeto" width="600" />
</p>

Caso a visualização não esteja boa, pode ser acessado o link do vídeo diretamente no YouTube:

https://youtu.be/Ercn9bGk328

## 🔷 Diagrama do banco de dados

