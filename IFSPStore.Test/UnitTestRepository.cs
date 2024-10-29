using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestRepository
    {
        public partial class myDbContext : DbContext
        {
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Cidade> Cidades { get; set; }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Grupo> Grupos { get; set; }
            public DbSet<Produto> Produtos { get; set; }
            public DbSet<Venda> Vendas { get; set; }
            public DbSet<VendaItem> VendaItens { get; set; }

            public myDbContext()
            {
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var server = "localhost";
                var port = "3306";
                var database = "IFSPStore";
                var username = "root";
                var password = "admin";
                var strCon = $"Server={server};Port={port};Database={database};" +
                    $"Uid={username};Pwd={password}";
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseMySql(strCon, ServerVersion.AutoDetect(strCon));
                }
            }
        }

        // CIDADE
        [TestMethod]
        public void TestInsertCidade()
        {
            using (var context = new myDbContext()) {


                var cidade = new Cidade
                {
                    Nome = "Birigui",
                    Estado = "SP"
                };
                context.Cidades.Add(cidade);

                cidade = new Cidade
                {
                    Nome = "Araçatuba",
                    Estado = "SP"
                };
                context.Cidades.Add(cidade);

                context.SaveChanges();
            }
        }
        [TestMethod]
        public void TestListCidades()
        {
            using (var context = new myDbContext())
            {
                foreach (var cidade in context.Cidades)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cidade));
                }
            }
        }
        
        // CLIENTES
        [TestMethod]
        public void TestInsertClientes()
        {
            using (var context = new myDbContext())
            {
                var cidade =context.Cidades.FirstOrDefault(c=> c.Id == 1);
                var cliente = new Cliente
                {
                    Nome = "kayky",
                    Endereco = "na frente do SESI",
                    Bairro = "SESI",
                    Documento = "526.112.778-80",
                    Cidade = cidade
                };
                context.Clientes.Add(cliente);

                cidade = context.Cidades.FirstOrDefault(c => c.Id == 2);
                cliente = new Cliente
                {
                    Nome = "Kaue",
                    Endereco = "habiana 1",
                    Bairro = "Aeroporto",
                    Documento = "526.112.778-50",
                    Cidade = cidade
                };
                context.Clientes.Add(cliente);

                context.SaveChanges();
            }
        }
        [TestMethod]
        public void TestListClientes()
        {
            using (var context = new myDbContext())
            {
                foreach (var cliente in context.Clientes)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cliente));
                }
            }
        }

        // USUARIO
        [TestMethod]
        public void TestInsertUsuario()
        {
            using (var context = new myDbContext())
            {
                var usuario = new Usuario
                {
                    Nome = "kayky",
                    Senha = "senha",
                    Login = "kaykyEnzo",
                    Email = "kaykyEnzo@gmail.com",
                    DataCadastro = DateTime.Today,
                    DataLogin = DateTime.Today,
                    Ativo = false
                };
                context.Usuarios.Add(usuario);

                usuario = new Usuario
                {
                    Nome = "kaue",
                    Senha = "12345",
                    Login = "yggdrasil",
                    Email = "kaueleivas@gmail.com",
                    DataCadastro = DateTime.Today,
                    DataLogin = DateTime.Today,
                    Ativo = false
                };
                context.Usuarios.Add(usuario);

                context.SaveChanges();
            }
        }
        [TestMethod]
        public void TestListUsuario()
        {
            using (var context = new myDbContext())
            {
                foreach (var usuario in context.Usuarios)
                {
                    Console.WriteLine(JsonSerializer.Serialize(usuario));
                }
            }
        }
        
        // GRUPO
        [TestMethod]
        public void TestInsertGrupo()
        {
            using (var context = new myDbContext())
            {
                var grupo = new Grupo
                {
                    Nome = "root"
                };
                context.Grupos.Add(grupo);

                grupo = new Grupo
                {
                    Nome = "nao sei"
                };
                context.Grupos.Add(grupo);

                context.SaveChanges();
            }
        }
        [TestMethod]
        public void TestListGrupo()
        {
            using (var context = new myDbContext())
            {
                foreach (var group in context.Grupos)
                {
                    Console.WriteLine(JsonSerializer.Serialize(group));
                }
            }
        }
        
        //PRODUTO
        [TestMethod]
        public void TestInsertProduto()
        {
            using (var context = new myDbContext())
            {
                var grupo = context.Grupos.FirstOrDefault(c => c.Id == 1);
                var produto = new Produto
                {
                    Preco = 20,
                    Quantidade = 10,
                    DataCompra = DateTime.Now,
                    UnidadeVenda = "unidade",
                    Grupo = grupo
                };
                context.Produtos.Add(produto);

                grupo = context.Grupos.FirstOrDefault(c => c.Id == 2);
                produto = new Produto
                {
                    Preco = 10,
                    Quantidade = 500,
                    DataCompra = DateTime.Now,
                    UnidadeVenda = "unidade 2",
                    Grupo = grupo
                };
                context.Produtos.Add(produto);

                context.SaveChanges();
            }
        }
        [TestMethod]
        public void TestListProduto()
        {
            using (var context = new myDbContext())
            {
                foreach (var usuario in context.Usuarios)
                {
                    Console.WriteLine(JsonSerializer.Serialize(usuario));
                }
            }
        }
        
        // VENDA
        [TestMethod]
        public void TestInsertVenda()
        {
            using (var context = new myDbContext())
            {
                var usuario = context.Usuarios.FirstOrDefault(c => c.Id == 1);
                var cliente = context.Clientes.FirstOrDefault(c => c.Id == 1);
                var produto = context.Produtos.FirstOrDefault(c => c.Id == 1);

                var venda = new Venda
                {
                    Data = DateTime.Today,
                    ValorTotal = 50,
                    Usuario = usuario,
                    Cliente = cliente
                    
                };

                venda.Items.Add(
                 new VendaItem
                 {
                     Produto = produto,
                     Quantidade = 1,
                     ValorUnitario = (float)produto.Preco,
                     ValorTotal = 1 * (float)produto.Preco,
                     Venda = venda
                 });
                venda.Items.Add(
                 new VendaItem
                 {
                     Produto = produto,
                     Quantidade = 1,
                     ValorUnitario = (float)produto.Preco,
                     ValorTotal = 1 * (float)produto.Preco,
                     Venda = venda
                 });
                context.Vendas.Add(venda);


                usuario = context.Usuarios.FirstOrDefault(c => c.Id == 1);
                cliente = context.Clientes.FirstOrDefault(c => c.Id == 1);
                produto = context.Produtos.FirstOrDefault(c => c.Id == 1);

                venda = new Venda
                {
                    Data = DateTime.Today,
                    ValorTotal = 50,
                    Usuario = usuario,
                    Cliente = cliente
                };

                venda.Items.Add(
                 new VendaItem
                 {
                     Produto = produto,
                     Quantidade = 1,
                     ValorUnitario = (float)produto.Preco,
                     ValorTotal = 1 * (float)produto.Preco,
                     Venda = venda
                 });
                venda.Items.Add(
                 new VendaItem
                 {
                     Produto = produto,
                     Quantidade = 1,
                     ValorUnitario = (float)produto.Preco,
                     ValorTotal = 1 * (float)produto.Preco,
                     Venda = venda
                 });
                context.Vendas.Add(venda);

                context.SaveChanges();
            }
        }
        [TestMethod]
        public void TestListVenda()
        {
            using (var context = new myDbContext())
            {
                foreach (var venda in context.Vendas)
                {
                    Console.WriteLine(JsonSerializer.Serialize(venda));
                }
            }
        }
        
    }
}
