using Microsoft.Extensions.DependencyInjection;
using IFSPStore.Repository.Context;
using IFSPStore.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Service.Services;
using IFSPStore.Service.Validators;
using AutoMapper;
using System.Data;
using System.Text.Json;
using IFSPStore.Repository.Mapping;

namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestService
    {
        private ServiceCollection? services;
        public ServiceProvider ConfigureServices()
        {
            services = new ServiceCollection();
            services.AddDbContext<MySqlContext>(options =>
                {
                    var server = "localhost";
                    var port = "3306";
                    var database = "IFSPStoreService";
                    var username = "root";
                    var password = "admin";
                    var strCon = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password}";
                    options.UseMySql(strCon, ServerVersion.AutoDetect(strCon), opt =>
                    {
                        opt.CommandTimeout(180);
                        opt.EnableRetryOnFailure(5);
                    });
                });
            services.AddScoped<IBaseRepository<Cidade>, BaseRepository<Cidade>>();
            services.AddScoped<IBaseService<Cidade>, BaseService<Cidade>>();

            services.AddScoped<IBaseRepository<Cliente>, BaseRepository<Cliente>>();
            services.AddScoped<IBaseService<Cliente>, BaseService<Cliente>>();

            services.AddScoped<IBaseRepository<Grupo>, BaseRepository<Grupo>>();
            services.AddScoped<IBaseService<Grupo>, BaseService<Grupo>>();

            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();
            services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();

            services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
            services.AddScoped<IBaseService<Usuario>, BaseService<Usuario>>();

            services.AddScoped<IBaseRepository<Venda>, BaseRepository<Venda>>();
            services.AddScoped<IBaseService<Venda>, BaseService<Venda>>();

            services.AddSingleton(new MapperConfiguration(config =>
                {
                    config.CreateMap<Cidade, Cidade>();
                }).CreateMapper());

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Cliente, Cliente>();
            }).CreateMapper());

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Grupo, Grupo>();
            }).CreateMapper());

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Produto, Produto>();
            }).CreateMapper());

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Usuario, Usuario>();
            }).CreateMapper());

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Venda, Venda>();
            }).CreateMapper());

            return services.BuildServiceProvider();
        }

        //      CIDADE
        [TestMethod]
        public void TestInsertCidade()
        {
            var sp = ConfigureServices();
            var cidadeService = sp.GetService<IBaseService<Cidade>>();

            var cidade = new Cidade
            {
                Nome = "Araçatuba",
                Estado = "SP"
            };

            var result = cidadeService.Add<Cidade, Cidade, CidadeValidator>(cidade);
            Console.Write(JsonSerializer.Serialize(result));
        }
        [TestMethod]
        public void TestSelectCidade()
        {
            var sp = ConfigureServices();
            var cidadeService = sp.GetService<IBaseService<Cidade>>();

            var result = cidadeService.get<Cidade>();
            Console.WriteLine(JsonSerializer.Serialize(result));

        }

        //      CLIENTE
        [TestMethod]
        public void TestInsertCliente()
        {
            var sp = ConfigureServices();
            var clienteService = sp.GetService<IBaseService<Cliente>>();
            var cidade = sp.GetService<IBaseService<Cidade>>().get<Cidade>().FirstOrDefault(c => c.Id == 1);
            var cliente = new Cliente
            {
                Nome = "Kaue",
                Endereco = "Rua Mario Geraldi",
                Documento = "526.112.778-50",
                Bairro = "Aeroporto",
                Cidade = cidade
            };

            var result = clienteService.Add<Cliente, Cliente, ClienteValidator>(cliente);
            Console.Write(JsonSerializer.Serialize(result));
        }
        [TestMethod]
        public void TestSelectCliente()
        {
            var sp = ConfigureServices();
            var usuarioService = sp.GetService<IBaseService<Usuario>>();

            var result = usuarioService.get<Usuario>();
            Console.WriteLine(JsonSerializer.Serialize(result));

        }

        //      GRUPO
        [TestMethod]
        public void TestInsertGrupo()
        {
            var sp = ConfigureServices();
            var grupoService = sp.GetService<IBaseService<Grupo>>();
            var grupo = new Grupo
            {
                Nome = "Alimento"
            };

            var result = grupoService.Add<Grupo, Grupo, GrupoValidator>(grupo);
            Console.Write(JsonSerializer.Serialize(result));
        }
        [TestMethod]
        public void TestSelectGrupo()
        {
            var sp = ConfigureServices();
            var grupoService = sp.GetService<IBaseService<Grupo>>();

            var result = grupoService.get<Grupo>();
            Console.WriteLine(JsonSerializer.Serialize(result));

        }

        //      PRODUTO
        [TestMethod]
        public void TestInsertProduto()
        {
            var sp = ConfigureServices();
            var produtoService = sp.GetService<IBaseService<Produto>>();
            var grupoService = sp.GetService<IBaseService<Grupo>>();

            var grupo = grupoService.get<Grupo>().FirstOrDefault(g => g.Id == 1);

            var produto = new Produto
            {
                Nome = "Laranja",
                Preco = 10,
                Quantidade = 100,
                DataCompra = DateTime.Now,
                UnidadeVenda = "10",
                Grupo = grupo
            };

            var result = produtoService.Add<Produto, Produto, ProdutoValidator>(produto);
            Console.Write(JsonSerializer.Serialize(result));
        }
        [TestMethod]
        public void TestSelectProduto()
        {
            var sp = ConfigureServices();
            var produtoService = sp.GetService<IBaseService<Produto>>();

            var result = produtoService.get<Produto>();
            Console.WriteLine(JsonSerializer.Serialize(result));

        }

        //      USUARIO
        [TestMethod]
        public void TestInsertUsuario()
        {
            var sp = ConfigureServices();
            var usuarioService = sp.GetService<IBaseService<Usuario>>();
            var usuario = new Usuario
            {
                Nome = "Kaue",
                Login = "yyggrasil",
                Email = "extremodemolidor@gmail.com",
                Senha = "ASFD123sadfsf@#!",
                DataCadastro = DateTime.Now,
                DataLogin = DateTime.Now,
                Ativo = true
            };

            var result = usuarioService.Add<Usuario, Usuario, UsuarioValidator>(usuario);
            Console.Write(JsonSerializer.Serialize(result));
        }
        [TestMethod]
        public void TestSelectUsuario()
        {
            var sp = ConfigureServices();
            var usuarioService = sp.GetService<IBaseService<Usuario>>();

            var result = usuarioService.get<Usuario>();
            Console.WriteLine(JsonSerializer.Serialize(result));

        }

        //      VENDA
        [TestMethod]
        public void TestInsertVenda()
        {
            var sp = ConfigureServices();
            var vendaService = sp.GetService<IBaseService<Venda>>();
            var produtoService = sp.GetService<IBaseService<Produto>>();
            var clienteService = sp.GetService<IBaseService<Cliente>>();

            var produto = produtoService.get<Produto>().FirstOrDefault(g => g.Id == 1);
            var cliente = clienteService.get<Cliente>().FirstOrDefault(c => c.Id == 1);
            

            
            var venda = new Venda
            {
                Data = DateTime.Now,
                ValorTotal = 100,
                Cliente = cliente
            };

            venda.Items.Add(new VendaItem {
                Produto = produto,
                Quantidade = 1,
                ValorUnitario = (float)produto.Preco,
                ValorTotal = 1 * (float)produto.Preco,
                Venda = venda
            });

            var result = vendaService.Add<Venda, Venda, VendaValidator>(venda);
            Console.Write(JsonSerializer.Serialize(result));
        }
        [TestMethod]
        public void TestSelectVenda()
        {
            var sp = ConfigureServices();
            var vendaService = sp.GetService<IBaseService<Venda>>();

            var result = vendaService.get<Venda>();
            Console.WriteLine(JsonSerializer.Serialize(result));

        }
    }
}
