# Classes do C#

Vou anotar aqui as classes que usei no projeto, a fim de saber por que a usei.

## ServiceProvider

- Injeção de dependência (DI) = precisa de classe instanciada no construtor;
  - Exemplo: 
  ```
  private ClasseServico _classeServico;
  
  public ClasseExemplo(ClasseServico classeServico){
        _classeServico = classeServico;
   }

- É DI? Use ServiceProvider
  - Por quê?:
    - Ele *proverá* a instância necessária
  
### .AddDbContext
- Adicionar contexto de banco de dados no serviço

### .AddScoped<>
- Quer compartilhar instância em mesmo escopo? Adicione ao escopo;
- Escopo = Contexto onde instâncias se compartilham
- Escopo diferente = instâncias diferentes
- *Scoped*:
  - Forçar com que instâncias funcionem no mesmo escopo;
- Quando usar isso?
  - Quero que mesmo contexto no DB sejam compartilhados entre serviços;

### .AddTransient<>
- Terminou um serviço? Criar nova instância 

### .BuildServiceProvider
- Já incluiu tudo o que precisava no provedor de serviço? -> Construa-o!

### .CreateScope
- Criar os escopos depois de definidos

### .GetRequiredService
- Obter serviço do tipo especificado

## DataBaseFacade
- Uma fachada para intergir com banco de dados
- Quer interagir com banco? Use `DataBaseFacade`

### .Migrate
- Migrar as migrations especificadas do contexto


## ServiceCollection
- Irmão de `ServiceProvider`;
- `ServiceProvider` vê sua "coleção" de serviços e determina qual "encaixa" na classe que quer usar DI;
- Exemplo:
  - ``BookService`` precisa de ``BookRepo`` para funcionar;
  - `ServiceProvider` vê se tem ``BookRepo`` na sua ``ServiceCollection``;
  - Se tem, encaixa.

## Path

- O que é?:
  - Strings para caminhos no sistema de arquivos
- É caminho de diretório? -> use `Path`

### .Combine
- Que combinar strings para caminho? -> .Combine!

## Environment
- Environment = Ambiente
- Ambiente = Onde está o software;
- Quer info sobre ambiente? -> User `Environment`

### .GetFolderPath
- Pegar caminho especificado

### .SpecialFolder
- Quer uma pasta específica? É uma `SpecialFolder`
- Você especifica um `Enum` que identifica o tipo de pasta
- Exemplo:
  - Enum = 0 -> Pasta `Desktop`
  - Enum = 5 -> Pasta `MyDocuments`

### .LocalApplicationData
- É um `Enum`
- Ele é = 28
- Enum 28 = LocalApplicationData = Dados atuais da aplicação; Onde está meu aplicativo

## Directory
- Mexer com diretórios do sistema
- Quer:
  - Manipular;
  - Criar;
  - Mover;
  - Enumerar
- Use `Directory`

### .CreateDirectory
- Nome já diz: "Criar diretório novo"
- Especifique o caminho para esse diretório ao usar esse método;

## DbContextOptionsBuilder
- Construir facilmente contextos para Db;
- É uma API para construir Contexto;

### .UseSqlite
- Configurar contexto para banco SQLite;
- Informe o caminho para o banco
- Como sei qual é o banco?
  - Temina em `.db`
