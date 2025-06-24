<p align="center">

  <h2 align="center">API para gerenciamento de consumo energético ⚡</h2>
</p>

## ❓ Por quê?
Este projeto foi criado durante as aulas de .NET oferecidas durante curso de ADS na FIAP, sendo assim, eu realmente aprecio qualquer feedback que você possa me dar sobre o projeto, o código, a arquitetura, o padrão de design ou qualquer outro ponto que queira reportar — isso me ajuda a me tornar um desenvolvedor melhor.  
Para contribuir com isso, você pode me enviar um e-mail: [dellano.liagi2004@gmail.com](mailto:dellano.liagi2004@gmail.com), se conectar comigo no [LinkedIn](https://www.linkedin.com/in/maurizio-dellano/) ou abrir uma issue aqui [issue](https://github.com/Dellano23/EnergyApi/issues/new).

## 🔧 Requisitos
Os requisitos funcionais e não funcionais estão neste 

## ⚖ REST
O objetivo de aplicar REST aqui é basicamente melhorar alguns detalhes no serviço web. REST oferece diversos benefícios, como desempenho e confiabilidade.  
Desempenho é um dos fatores que motivam o uso de um aplicativo — quanto maior a velocidade, melhor. Já a confiabilidade é essencial para o serviço, pois outras aplicações irão consumir esta API, e uma comunicação clara entre elas precisa acontecer.

Sobre esta API: ela é separada do cliente e é *stateless* (sem estado). Isso significa que cada requisição é independente. Por exemplo, a rota `api/equipamento` requer um *bearer token* para autenticação. Sendo assim, se um usuário fizer duas requisições para essa rota, ambas devem conter o token.

Tenho certeza de que ainda há detalhes do REST que esta API não segue, ou até mesmo regras que estão sendo quebradas. Ainda estou em processo de aprendizado, que é constante e portanto não me permite corrigir tudo ainda, mas meu foco é total no aprendizado e melhorar cada vez mais meus conhecimentos, para desenvolvimento de soluções cada vez mais completas.  
 — então, se você identificar algo, me avise (você pode abrir uma issue [aqui](https://github.com/Dellano23/EnergyApi/issues/new)) 😉.
