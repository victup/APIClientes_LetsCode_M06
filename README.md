# API Clientes

![image](https://user-images.githubusercontent.com/38474570/188256028-3f07a372-9951-4529-853e-40df946a10f5.png)

Esta API efetua um CRUD de clientes.

## Replicando no ambiente

Para executar, além de clonar este repositório, é necessário substituir alguns valores no arquivo com nome <b> appsettings.json </b> dentro de APIClientes, que contém o seguinte conteúdo. 

> { <br>
  "ConnectionStrings": { <br>
    "DefaultConnection": "Server= enderecoDaBasedeDados.com.br; Database=BaseExemplo; User Id=NomeUsuario; Password=SenhaUsuario; Encrypt=False" <br>
  }, <br>
  "Logging": { <br>
    "LogLevel": { <br>
      "Default": "Information", <br>
      "Microsoft.AspNetCore": "Warning" <br>
    } <br>
  }, <br>
  "AllowedHosts": "*" <br>
}

É necessário substituir os valores na linha do DefaultConnection para efetuar uma conexão. Por segurança, não foram colocados dados reais de uma base de dados.
* enderecoDaBasedeDados.com.br é o endereço do banco de dados; 
* BaseExemplo é o nome da base de dados;
* NomeUsuario é o nome do usuário com permissão de acesso na base de dados;
* SenhaUsuario é a senha do usuário que possui acesso à base de dados;
* Encrypt pode ser mantido como false.

## Geração de Token
Por padrão, essa API está gerando Tokens válidos para a EventAPI (https://github.com/victup/EventAPI_LetsCode_M06). <br>
Para gerar para a APIProdutos (https://github.com/victup/APIProdutos_LetsCode_M06) que também recebe esse Token modifique no arquivo o bloco a seguir: <br>
 <b> Arquivo: APIClientes.Core/Services/TokenService.cs</b> <br>
>  var tokenDescriptor = new SecurityTokenDescriptor <br>
            { <br>
                Issuer = "APIClientes.com", <br>
                Audience = "APIEvents.com", <br>
                Expires = DateTime.UtcNow.AddHours(2), <br>
                Subject = new ClaimsIdentity(new Claim[]  <br>
                { <br>
Modifique o valor entre aspas de <b>Audience</b>, irá ficar assim <br>
<b>Audience: "APIProdutos.com"</b> 
