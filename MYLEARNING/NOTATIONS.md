# Notações do C#
Vou registrar aqui minhas observações sobre as notações que observei no C#

## `null!`

- Valor é `null`? Pode dar erro;
- Coloque `!` ao final de `null` e você promete para o compilador que o **valor não vai ser nulo para sempre!**

## `override`
- Override = sobrescrever;
- Para que serve?:
  - Sobrescrever método da classe pai
- Exemplo:
 Classe pai tem método:
 ```
    public void Imprimir(){
        Console.WriteLine("Imprimindo");

    }
  ```

Filho vai usar método do pai:
```
    public override void Imprimir(){
        Console.WriteLine("Imprimindo");
        Console.WriteLine("Tem coisa nova aqui!");

    }
```

Coloquei algo novo no método do pai

---