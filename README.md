# Como usar o projeto

## Visual Studio

- Faça o git clone do projeto no Visual Studio;

- Alterne de branch "*master*" para "*GeladeiraAPI*"

- Certifique-se de ter instalado no seu ambiente os pacotes necessários:
  
  ![image](https://github.com/user-attachments/assets/dc2008e7-e4ae-48c1-85d6-25b157dbfca0)

- Coloque o projeto "*GeladeiraAPI*" como projeto inicializador:

  ![image](https://github.com/user-attachments/assets/b8237306-bd3f-4990-a82f-df4f7439972d)

- Dentro de "*GeladeiraAPI*" > Entre no arquivo "*appsettings.json*":

 ![image](https://github.com/user-attachments/assets/4a215094-2c60-4133-977f-f22ebeb84a25)

- Em "*DefaultConnection*", altere a connection string para conexão com o seus dados de acesso ao SQLServer:

  ![image](https://github.com/user-attachments/assets/f09c538a-a0cc-4ea8-9426-37f0d83a1629)

```bash
"Server=localhost;Database=GeladeiraDB;Uid=**seu_user_id**;Pwd=**sua_senha**;TrustServerCertificate=True;"
```

## SQLServer
- Crie um banco de dados com nome "GeladeiraDB" no seu banco de dados;

- Execute os scripts de criação, inserção de dados e consulta;

[Script de Criação de Tabelas](SQLScripts/criando_tabelas.sql)
- [Script de Inserção de Dados](SQLScripts/inserindo_dados_propriedade.sql)
- [Script de Atualização de Dados](SQLScripts/consultando_tabelas.sql)


  
