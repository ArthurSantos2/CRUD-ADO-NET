﻿using System.Data;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=DESKTOP-7V86B4M;Database=MeuFeudo;Integrated Security=True;TrustServerCertificate=True";

//acessando os dados. Ainda fazer o CRUD
//cadastrar áreas(deve existir familias e poder de familia e feudo cadastrados -> 
//se fosse com view poderia redirecionar para criá-las)/familias/feudos/arrecadacoes(deve ter estação,areas e produto cadastrado) /
//produtos/membros da familia (deve ter familia cadastrada)
//alterar dados de areas (deve listar as opcoes de Poder da familia na area e familias e feudos)/
//alterar arrecadacoes(deve listar produtos, estações e areas)
//estações não se alteram. alterar membros/produtos/feudos
//os métodos de exlusão só podem ser feito em: membros 

//falta fazer de arrecadação, area e poder da familia

//maneira de fazer diferente para criar com ADO.NET
// using (var conexaoBD = new SqlConnection(connectionString))
// {
//     conexaoBD.Open();
//     using(var comando = new SqlCommand())
//     {
//         comando.Connection = conexaoBD;
//         comando.CommandType = System.Data.CommandType.Text;
//         comando.CommandText = "Select [ID], [NomeDaArea] FROM [Areas]";

//         var reader = comando.ExecuteReader();
//         while (reader.Read())
//         {
//             Console.WriteLine($"{reader.GetInt32(0)} - {reader.GetString(1)}");
//         }
//     }
// }





Menu();

static void Menu()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar ou modificar um produto, digite: PRODUTO");
    Console.WriteLine("Para cadastrar ou modificar um feudo, digite: FEUDO");
    Console.WriteLine("Se você quer extinguir uma família por inteiro, digite: BANIR");
    Console.WriteLine("Para cadastrar ou modificar uma família, digite: FAMILIA");
    Console.WriteLine("Para cadastrar, deletar ou modificar um membro, digite: MEMBRO");
    Console.WriteLine("Para cadastrar ou modificar um nível de poder de família, digite: PODER");
    

    Console.WriteLine("Se você está não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        Menu();
    }
    
    option = option.ToUpper();

    switch (option)
    {
        case "PRODUTO":
        Console.Clear();
        MenuProduto();
        break;
        case "FEUDO":
        Console.Clear();
        MenuFeudo();
        break;
        case "BANIR":
        Console.Clear();
        MenuExtinguir();
        break;
        case "FAMILIA":
        Console.Clear();
        MenuFamilia();
        break;
        case "MEMBRO":
        Console.Clear();
        MenuMembro();
        break;
        case "PODER":
        Console.Clear();
        MenuPoderFamilia();
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        Console.Clear();
        Menu();
        break;
        
    }
}

static void MenuFeudo()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com as informações dos seus feudos?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar um novo feudo, digite: CADASTRAR");
    Console.WriteLine("Para alterar um feudo, digite: MODIFICAR");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        Console.Clear();
        CriarFeudo(); 
        break;
        case "MODIFICAR":
        Console.Clear();
        Console.WriteLine("Escolha o feudo e digite o ID que identifica ele");
        RetornarFeudos();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var feudoModificado = ModificarFeudoModelo();
        ModificarFeudo(id,feudoModificado);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
        break;
        
    }
}

static void MenuProduto()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com os produtos?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar, digite: CADASTRAR");
    Console.WriteLine("Para alterar um produto, digite: Modificar");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuProduto();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        CriarProduto();
        break;
        case "MODIFICAR":
        Console.WriteLine("Escolha o produto e digite o ID que identifica ele");
        RetornarProdutos();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var produtoModificado = ModificarProdutoModelo();
        ModificarProduto(id,produtoModificado);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        MenuProduto();
        break;
        
    }
}

static void MenuMembro()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com os membros?");
    Console.WriteLine("Espero que tenha aprendido com os monges a ler, veja as opções abaixo:");
    Console.WriteLine("Para cadastrar, digite: CADASTRAR");
    Console.WriteLine("Para alterar um membro, digite: Modificar");
    Console.WriteLine("Para excluir um, digite: EXCLUIR");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuProduto();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        CriarMembro();
        break;
        case "MODIFICAR":
        Console.WriteLine("Escolha o membro e digite o ID que identifica ele");
        RetornarMembros();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var membroModificado = ModificarMembroModelo();
        ModificarMembro(id,membroModificado);
        break;
        case "EXCLUIR":
        Console.WriteLine("Escolha o membro a ser deletado e digite o ID que identifica ele");
        RetornarMembros();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        DeletarMembro(id);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões...");
        Thread.Sleep(3000);
        MenuProduto();
        break;
        
    }
}

static void MenuExtinguir()
{
    Console.WriteLine("Bom dia, Senhor Feudal. Você estar aqui significa que algo muito grave irá ocorrer");
    Console.WriteLine("Em todo caso, espero que tenha misericórdia");
    Console.WriteLine("Para Extinguir uma família e tudo relacionado a ela, digite: BANIR");
    
    Console.WriteLine("Se você teve misericórdia e não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "BANIR":
        Console.Clear();
        Console.WriteLine("Escolha a família e digite o ID que identifica ela");
        RetornarFamilias();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        ExtinguirFamilia(id);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
        break;
        
    }
}

static void MenuFamilia()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com as informações das famílias?");
    Console.WriteLine("Para cadastrar uma nova familia, digite: CADASTRAR");
    Console.WriteLine("Para alterar o nome de uma família, digite: MODIFICAR");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        Console.Clear();
        CriarFamilia(); 
        break;
        case "MODIFICAR":
        Console.Clear();
        Console.WriteLine("Escolha a família e digite o ID que identifica ela");
        RetornarFamilias();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var familiaModificada = ModificarFamiliaModelo();
        ModificarFamilia(id,familiaModificada);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFamilia();
        break;
        
    }
}

static void MenuPoderFamilia()
{
    Console.WriteLine("Bom dia, Senhor Feudal. O que gostaria de fazer com as informações dos níveis de poder das famílias?");
    Console.WriteLine("Para cadastrar um novo nível, digite: CADASTRAR");
    Console.WriteLine("Para alterar a nomenclatura de um nível, digite: MODIFICAR");
    
    Console.WriteLine("Se você não quer continuar aqui, digite: SAIR");
    var option = Console.ReadLine();

    if(option == null)
    {
        Console.WriteLine("Por gentileza, não envie a resposta vazia");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFeudo();
    }
    
    option = option.ToUpper();
    int id;
    switch (option)
    {
        case "CADASTRAR":
        Console.Clear();
        CriarPoderFamiliar(); 
        break;
        case "MODIFICAR":
        Console.Clear();
        Console.WriteLine("Escolha o nível a ser alterado e digite o ID que identifica ela");
        RetornarPoderFamilia();
        Console.WriteLine("Pode digitar:");
        id = int.Parse(Console.ReadLine());
        var poderModificado = ModificarPoderFamiliaModelo();
        ModificarPoderFamilia(id,poderModificado);
        break;
        case "SAIR":
        Console.WriteLine("Saindo...");
        Thread.Sleep(3000);
        Console.Clear();
        Environment.Exit(0);
        break;
        default: 
        Console.WriteLine("Por gentileza, inserir uma opção válida");
        Console.WriteLine("Redirecionando para o menu de opcões atual...");
        Thread.Sleep(3000);
        Console.Clear();
        MenuFamilia();
        break;
        
    }
}



static void CriarProduto()
{
    var produto = new Produto();

    Console.WriteLine("Área de criação de produtos");
    Console.WriteLine("Digite o nome do produto abaixo:");
    produto.NomeDoProduto = Console.ReadLine();

    SalvarProduto(produto);
  
}

static void CriarPoderFamiliar()
{
    var poder = new PoderDaFamilia();

    Console.WriteLine("Área de criação de nível de poder");
    Console.WriteLine("Digite a nomenclatura do novo nível");
    poder.NivelDePoder = Console.ReadLine();

    SalvarPoder(poder);
  
}

static void CriarFeudo()
{
    var feudo = new MeuFeudo();

    Console.WriteLine("Área de criação de produtos");
    Console.WriteLine("Digite o nome do produto abaixo:");
    feudo.Nome = Console.ReadLine();

    SalvarFeudo(feudo);
    
}

static void CriarMembro()
{
    var membro = new Membro();

    Console.WriteLine("Área de inserção de Membros");
    Console.WriteLine("Digite o nome do membro abaixo:");
    membro.Nome = Console.ReadLine();
    Console.WriteLine("Escolha a família abaixo e digite seu ID:");
    RetornarFamilias();
    membro.Familia = int.Parse(Console.ReadLine());

    SalvarMembro(membro);
    
}

static void CriarFamilia()
{
    var familia = new Familia();

    Console.WriteLine("Área de inserção de Famílias");
    Console.WriteLine("Digite o nome da família abaixo:");
    familia.NomeDaFamilia = Console.ReadLine();

    SalvarFamilia(familia);
    
}


static void ModificarProduto(int id, Produto produto)
{

    // if (produto == null)
    // {
    //     throw new ApplicationException
    // }

    using (var conexaoBD = new SqlConnection(connectionString))
    {
    conexaoBD.Open();

    string pesquisar = @"SELECT * FROM Produtos";
    SqlCommand comandando = new SqlCommand(pesquisar, conexaoBD);
        
    DataSet dataSet = new DataSet();
    //puxa o conjunto de dados do banco de dados para um DataSet. O método .Fill preenche o dataset com os dados retornado pelo comando sql
    SqlDataAdapter adapter = new SqlDataAdapter(comandando);
    
    adapter.Fill(dataSet, "Produtos");

    // Verificar se um dado específico existe na tabela
    DataTable dataTable = dataSet.Tables["Produtos"];
    bool exists = dataTable.AsEnumerable().Any(row => row.Field<int>("Id") == id);
    if (exists)
    {
        string modificar = @$"UPDATE Produtos SET Produto = @produto WHERE ID = {id}";
        SqlCommand comando = new SqlCommand(modificar, conexaoBD);
        comando.Parameters.AddWithValue("@Produto", produto.NomeDoProduto);
        comando.Parameters.AddWithValue("@ID", id);

        int linhasModificadas = comando.ExecuteNonQuery();

        Retorno(linhasModificadas, " Modificado");
    }
    else
    {
    Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
    Console.WriteLine("Redirecionando para o menu atual...");
    Thread.Sleep(3000);
    Console.Clear();
    MenuProduto();
    }

    }
}
//método com padrão diferente do de produto, melhorado.
static void ModificarFeudo(int id, MeuFeudo nome)
{
    //codigo refatorado com a exclusão do uso do DataSet, simplificação na consulta da existência de um dado.
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @$"SELECT COUNT(*) FROM MeusFeudos WHERE ID = {id}";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@ID", id);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
        
        string modificar = @$"UPDATE MeusFeudos SET Nome = {nome} WHERE ID = {id}";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@Nome", nome.Nome);
        comandoModificar.Parameters.AddWithValue("@ID", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
}

static void ModificarFamilia(int id, Familia nomeFamilia)
{
    //codigo refatorado com a exclusão do uso do DataSet, simplificação na consulta da existência de um dado.
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @$"SELECT COUNT(*) FROM Familias WHERE ID = @id";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@id", id);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
        
        string modificar = @"UPDATE Familias SET NomeDaFamilia = @nomeFamilia WHERE ID = @id";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@nomeFamilia", nomeFamilia.NomeDaFamilia);
        comandoModificar.Parameters.AddWithValue("@id", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
}

static void ModificarMembro(int id, Membro membro)
{
    //codigo refatorado com a exclusão do uso do DataSet, simplificação na consulta da existência de um dado.
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @$"SELECT COUNT(*) FROM Membros WHERE ID = @id";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@id", id);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuMembro();
        }

        string pesquisa = @$"SELECT COUNT(*) FROM Familias WHERE ID = @identificador";
        SqlCommand comandoPesquisar = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@identificador", membro.Familia);
        
        int qtdRegistro = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuMembro();
        }

        
        string modificar = @"UPDATE Membros SET Nome = @nome, Familia = @familia WHERE ID = @identificado";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@nome", membro.Nome);
        comandoModificar.Parameters.AddWithValue("@familia", membro.Familia);
        comandoModificar.Parameters.AddWithValue("@identificado", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
}

static void ModificarPoderFamilia(int id, PoderDaFamilia nivel)
{
    //codigo refatorado com a exclusão do uso do DataSet, simplificação na consulta da existência de um dado.
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        
        string pesquisar = @$"SELECT COUNT(*) FROM PoderDaFamilia WHERE ID = @id";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@id", id);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
        
        string modificar = @"UPDATE PoderDaFamilia SET NivelDePoder = @nivel WHERE ID = @id";
        SqlCommand comandoModificar = new SqlCommand(modificar, conexaoBD);
        comandoModificar.Parameters.AddWithValue("@nivel", nivel.NivelDePoder);
        comandoModificar.Parameters.AddWithValue("@id", id);

        int linhasModificadas = comandoModificar.ExecuteNonQuery();

        Retorno(linhasModificadas, "Modificadas");
    }
}

static Familia ModificarFamiliaModelo()
{
    var familia = new Familia();
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar uma família agora");
    Console.WriteLine("Por gentileza, escreva novo nome");
    familia.NomeDaFamilia = Console.ReadLine();
    return familia;
}

static Membro ModificarMembroModelo()
{
    var membro = new Membro();
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar um membro agora");
    Console.WriteLine("Por gentileza, escreva novo nome");
    membro.Nome = Console.ReadLine();
    Console.WriteLine("Escolha a família abaixo para mudar e digite seu ID:");
    RetornarFamilias();
    membro.Familia = int.Parse(Console.ReadLine());

    return membro;
}

static PoderDaFamilia ModificarPoderFamiliaModelo()
{
    var poder = new PoderDaFamilia();
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar um dos níveis de poder");
    Console.WriteLine("Por gentileza, escreva o novo nome");
    poder.NivelDePoder = Console.ReadLine();
    return poder;
}

static Produto ModificarProdutoModelo()
{
    var produto = new Produto();
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar o produto agora");
    Console.WriteLine("Por gentileza, escreva novo nome para o produto");
    produto.NomeDoProduto = Console.ReadLine();
    return produto;
}

static MeuFeudo ModificarFeudoModelo()
{
    var feudo = new MeuFeudo();
    Console.WriteLine("Olá, Senhor Feudal. Iremos modificar o feudo agora");
    Console.WriteLine("Por gentileza, escreva novo nome para o feudo");
    feudo.Nome = Console.ReadLine();
    return feudo;
}


//código pensando no ínicio
// static void Deletar(int id)
// {
//     //codigo exemplo, produto nao poder ser excluido por ter relações
//     using (var conexaoBD = new SqlConnection(connectionString))
//     {
//     conexaoBD.Open();
//     string excluir = @"DELETE FROM Produtos WHERE ID = @id";
//     SqlCommand comando = new SqlCommand(excluir, conexaoBD);

//     int linhaExcluida = comando.ExecuteNonQuery();
//     }
// }

static void DeletarMembro(int id)
{
    
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    conexaoBD.Open();
    string excluir = @$"DELETE FROM Membros WHERE ID = {id}";
    SqlCommand comando = new SqlCommand(excluir, conexaoBD);

    int linhaExcluida = comando.ExecuteNonQuery();
    }
}

//erro resolvido com interpolação
static void ExtinguirFamilia(int id)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
    conexaoBD.Open();

        string excluir = @$"DELETE Areas
                            FROM Areas
                            JOIN Familias ON Areas.FamiliaDaArea = Familias.ID 
                            JOIN Membros ON Familias.ID = Membros.Familia 
                            WHERE Areas.FamiliaDaArea = {id};

                            DELETE Membros
                            FROM Membros
                            JOIN Familias ON Familias.ID = Membros.Familia 
                            WHERE Membros.Familia = {id};

                            DELETE Familias
                            FROM Familias
                            WHERE Familias.ID = {id};
                            ";
        SqlCommand comando = new SqlCommand(excluir, conexaoBD);
        

        int linhaExcluida = comando.ExecuteNonQuery();

        Retorno(linhaExcluida, "Modificadas");
        
        
    }
}


static void SalvarProduto(Produto produto)
{

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string insercao = @"INSERT INTO Produtos(Produto) VALUES(@Produto)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@Produto", produto.NomeDoProduto));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criado");
    }
}

static void SalvarPoder(PoderDaFamilia poder)
{

    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        //sempre que não interpola $ quebra ?????????
        string insercao = @$"INSERT INTO PoderDaFamilia(NivelDePoder) VALUES(@poder)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@poder", poder.NivelDePoder));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criado");
    }
}

static void SalvarFeudo(MeuFeudo nome)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string insercao = @"INSERT INTO MeusFeudos(Nome) VALUES(@Nome)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@Nome", nome.Nome));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criado");
    }
}

static void SalvarFamilia(Familia nome)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        string insercao = @$"INSERT INTO Familias(NomeDaFamilia) VALUES(@nome)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@nome", nome.NomeDaFamilia));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criada");
    }
}

static void SalvarMembro(Membro membro)
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        conexaoBD.Open();
        
        string pesquisar = @"SELECT COUNT(*) FROM Familias WHERE ID = @familia";
        SqlCommand comandoPesquisa = new SqlCommand(pesquisar, conexaoBD);
        comandoPesquisa.Parameters.AddWithValue("@familia", membro.Familia);
        
        int qtdRegistros = (int)comandoPesquisa.ExecuteScalar();
        if (qtdRegistros == 0)
        {
            Console.WriteLine("O ID passado não existe na tabela. Você faltou as aulas com os monges");
            Console.WriteLine("Redirecionando para o menu atual...");
            Thread.Sleep(3000);
            Console.Clear();
            MenuFeudo();
        }
    
        string insercao = @$"INSERT INTO Membros(Nome,Familia) VALUES(@nome,@familia)";
        SqlCommand comando = new SqlCommand(insercao, conexaoBD);
        comando.Parameters.Add(new SqlParameter("@nome", membro.Nome));
        comando.Parameters.Add(new SqlParameter("@familia", membro.Familia));

        var linhasSalvas = comando.ExecuteNonQuery();

        Retorno(linhasSalvas, "criada");
    }
}


static void RetornarFeudos()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        //cria-se o comando sql
        string pesquisar = @"SELECT * FROM MeusFeudos";
        SqlCommand comando = new SqlCommand(pesquisar, conexaoBD);
        
        //puxa o conjunto de dados do banco de dados para um DataSet. O método .Fill preenche o dataset com os dados retornado pelo comando sql
        SqlDataAdapter adapter = new SqlDataAdapter(comando);
        DataSet dataSet = new DataSet();
        adapter.Fill(dataSet);
        
        
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
        Console.WriteLine($"Feudo: {row["Nome"]} //// Identificador (ID): {row ["ID"]}");
        
        }

    
    }
}

static void RetornarProdutos()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        //cria-se o comando sql
        string pesquisar = @"SELECT * FROM Produtos";
        SqlCommand comando = new SqlCommand(pesquisar, conexaoBD);
        
        //puxa o conjunto de dados do banco de dados para um DataSet. O método .Fill preenche o dataset com os dados retornado pelo comando sql
        SqlDataAdapter adapter = new SqlDataAdapter(comando);
        DataSet dataSet = new DataSet();
        adapter.Fill(dataSet);
        
        
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
        Console.WriteLine($"Produto: {row["Produto"]} //// Identificador (ID): {row ["ID"]}");
        
        }

    
    }
}

//forma refatorada do dataset para o datatable 
static void RetornarFamilias()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        //cria-se o comando sql
        string consulta = @"SELECT NomeDaFamilia, ID FROM Familias";
        SqlCommand comando = new SqlCommand(consulta, conexaoBD);

        //puxa o conjunto de dados do banco de dados para um DataTable. O método .Fill preenche o datatable com os dados retornado pelo comando sql, o que torna mais eficiente por se tratar apenas de uma tabela
        SqlDataAdapter adapter = new SqlDataAdapter(comando);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);

        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine($"Nome da Família: {row["NomeDaFamilia"]} //// Identificador (ID): {row ["ID"]}");
        }


    
    }
}

static void RetornarPoderFamilia()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        conexaoBD.Open();
        //cria-se o comando sql
        string consulta = @"SELECT NivelDePoder,ID FROM PoderDaFamilia";
        SqlCommand comando = new SqlCommand(consulta, conexaoBD);

        SqlDataAdapter adapter = new SqlDataAdapter(comando);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);

        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine($"Nivel da Família: {row["NivelDePoder"]} //// Identificador (ID): {row ["ID"]}");
        }
    }
}

static void RetornarMembros()
{
    using (var conexaoBD = new SqlConnection(connectionString))
    {
        
        //cria-se o comando sql
        string pesquisar = @"SELECT * FROM Membros";
        SqlCommand comando = new SqlCommand(pesquisar, conexaoBD);
        
        //puxa o conjunto de dados do banco de dados para um DataSet. O método .Fill preenche o dataset com os dados retornado pelo comando sql
        SqlDataAdapter adapter = new SqlDataAdapter(comando);
        DataSet dataSet = new DataSet();
        adapter.Fill(dataSet);
        
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
        Console.WriteLine($"Nome do membro: {row["Nome"]} //// Identificador (ID): {row ["ID"]}");
        
        }

    
    }
}

static void Retorno(int linhasAfetadas, string foiFeitoOque)
{
            
    Console.WriteLine($"{linhasAfetadas} linha(s) {foiFeitoOque}(s)");

}
