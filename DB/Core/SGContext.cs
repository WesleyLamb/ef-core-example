using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using System.IO;
using Microsoft.Extensions.Logging;
using FirebirdSql.Data.Logging;

namespace DB.Core
{
    public enum Driver
    {
        Firebird,
        MySql
    }
    
    public class ConnectionParams
    {
        public string Host { get; set; } = "localhost";
        public string Database { get; set; } = "C:\\SGBR\\Master\\BD\\BASESGMASTER.FDB";
        public int Port { get; set; } = 3050;
        public string Username { get; set; } = "SYSDBA";
        public string Password { get; set; } = "masterkey";
        public Driver Driver { get; set; } = Driver.Firebird;

        public void LoadFromIniFile(string aIniFilePath)
        {
            IniFile iniFile = new IniFile(aIniFilePath);

            this.Driver = iniFile.Read("Busca BD", "Firebird", "1") == "1" ? Driver.Firebird : Driver.MySql;

            if (this.Driver == Driver.Firebird)
            {
                FileInfo bd = new FileInfo(iniFile.Read("Busca BD", "Conexao", "C:\\SGBr\\Master\\BD\\BASESGMASTER.FDB"));

                this.Port = 3050;
                this.Database = bd.FullName;
                this.Username = "SYSDBA";
                this.Password = "masterkey";
            }
            else
            {
                this.Host = iniFile.Read("Busca BD", "Conexao", "localhost");
                this.Port = Int32.TryParse(iniFile.Read("Busca BD", "Porta"), out int j) ? j : 3345;
                this.Database = iniFile.Read("Busca BD", "NomeBD", "basesgmaster");
                this.Username = iniFile.Read("Busca BD", "UsuárioBD", "root");
                this.Password = iniFile.Read("Busca BD", "SenhaBD");
            }
        }
        
        public string ConnectionString
        {
            get
            {
                switch (Driver) {
                    case Driver.MySql: {
                            return $"Server={Host};Database={Database};Port={Port};Uid={Username};Pwd={Password}";
                        }
                    default: {
                            return $"DataSource={Host};Database={Database};Port={Port};User={Username};Password={Password};Charset=ISO8859_1;Dialect=3;Connection lifetime=15;Packet Size=8192;";
                        }
                }
            }
        }
    }
    
    public class SGContext: DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        
        public ConnectionParams ConnectionParams { get; private set; }
        public SGContext(ConnectionParams connectionParams) : base()
        {
            ConnectionParams = connectionParams;
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ClienteEntityTypeConfiguration().Configure(modelBuilder.Entity<Cliente>());
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.EnableSensitiveDataLogging();
            //optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            //optionsBuilder.EnableDetailedErrors();

            switch (ConnectionParams.Driver) {
                case Driver.MySql: {
                        optionsBuilder.UseMySQL(ConnectionParams.ConnectionString);
                        break;
                    }
                default: {
                        optionsBuilder.UseFirebird(ConnectionParams.ConnectionString);
                        break;
                    }
            }
        }
    }
}
