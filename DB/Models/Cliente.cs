using DB.Core;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DB.Models
{    
    public class Cliente
    {
        [System.ComponentModel.DisplayName("Código")]
        public int Controle { get; private set; }

        [System.ComponentModel.DisplayName("Cliente")]
        public string RazaoSocial { get; set; }

        [System.ComponentModel.DisplayName("Endereço")]
        public string Endereco { get; set; }
        
        [System.ComponentModel.DisplayName("Complemento")]
        public string Complemento { get; set; }

        [System.ComponentModel.DisplayName("Bairro")]
        public string Bairro { get; set; }
        
        [System.ComponentModel.DisplayName("Cidade")]
        public string Cidade { get; set; }

        [System.ComponentModel.DisplayName("UF")]
        public string UF { get; set; }

        [System.ComponentModel.DisplayName("País")]
        public string Pais { get; set; }
        
        [System.ComponentModel.DisplayName("CEP")]
        public string CEP { get; set; }

        [System.ComponentModel.DisplayName("Tipo de cliente")]
        public string GridTipoCliente
        {
            get
            {
                return DataTypes.TipoClienteToString(TipoCliente);
            }
        }

        [Display(AutoGenerateField = false)]
        public TipoCliente TipoCliente { get; set; }
        
        [System.ComponentModel.DisplayName("RG")]
        public string GridRG
        {
            get
            {
                return Helper.ColocaMascaraRG(RG);
            }
        }

        [Display(AutoGenerateField = false)]
        public string RG { get; set; }
       
        [System.ComponentModel.DisplayName("CPF")]
        public string GridCPF
        {
            get
            {
                return Helper.ColocaMascaraCPF(CPF);
            }
            
        }

        [Display(AutoGenerateField = false)]
        public string CPF { get; set; }

        [System.ComponentModel.DisplayName("CNPJ")]
        public string GridCNPJ
        {
            get
            {
                return Helper.ColocaMascaraCNPJ(CNPJ);
            }
        }

        [Display(AutoGenerateField = false)]
        public string CNPJ { get; set; }

        [System.ComponentModel.DisplayName("Inscrição estadual")]
        public string GridInscricaoEstadual
        { 
            get
            {
                return Helper.ColocaMascaraIE(InscricaoEstadual);
            }
        }

        [Display(AutoGenerateField = false)]
        public string InscricaoEstadual { get; set; }

        [System.ComponentModel.DisplayName("Inscrição municipal")]
        public string GridInscricaoMunicipal
        {
            get
            {
                return Helper.ColocaMascaraIM(InscricaoMunicipal);
            }
        }

        [Display(AutoGenerateField = false)]
        public string InscricaoMunicipal { get; set; }

        [System.ComponentModel.DisplayName("Data nascimento")]
        public DateTime? DataNascimento { get; set; }

        [System.ComponentModel.DisplayName("Data e hora cadastro")]        
        public DateTime DataHoraCadastro { get; set; }

        [System.ComponentModel.DisplayName("Estado civil")]
        public string GridEstadoCivil 
        {
            get
            {
                return DataTypes.EstadoCivilToString(EstadoCivil);
            }
        }

        [Display(AutoGenerateField = false)]
        public EstadoCivil EstadoCivil { get; set; }

        [System.ComponentModel.DisplayName("Ativo")]
        public string GridAtivo
        {
            get
            {
                return DataTypes.BoolToSimNao(Ativo);
            }
        }

        [Display(AutoGenerateField = false)]
        public bool Ativo { get; set; }

        [System.ComponentModel.DisplayName("Fantasia")]
        public string Fantasia { get; set; }

        [System.ComponentModel.DisplayName("Nacionalidade")]
        public string Nacionalidade { get; set; }
        
        [System.ComponentModel.DisplayName("Número")]
        public string Numero { get; set; }

        [System.ComponentModel.DisplayName("Sexo")]
        public string GridSexo
        {
            get
            {
                return DataTypes.SexoToString(Sexo);
            }
        }

        [Display(AutoGenerateField = false)]
        public Sexo Sexo { get; set; }

        [System.ComponentModel.DisplayName("Código cidade IBGE")]
        public string CodigoCidadeIBGE { get; set; }

        [System.ComponentModel.DisplayName("Tributação")]
        public string GridTributacao
        {
            get
            {
                return DataTypes.TributacaoClienteToString(Tributacao);
            }
        }

        [Display(AutoGenerateField = false)]
        public TributacaoCliente Tributacao { get; set; }
        
        [System.ComponentModel.DisplayName("Código país")]
        public string CodigoPais { get; set; } = "1058";
    }

    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TCLIENTE");

            builder.HasKey(c => c.Controle);
            builder.Property(c => c.Controle).HasColumnName("CONTROLE");

            builder.Property(c => c.RazaoSocial).HasColumnName("CLIENTE").IsRequired();

            builder.Property(c => c.Endereco).HasColumnName("ENDERECO");

            builder.Property(c => c.Complemento).HasColumnName("COMPLEMENTO");

            builder.Property(c => c.Bairro).HasColumnName("BAIRRO");

            builder.Property(c => c.Cidade).HasColumnName("CIDADE");

            builder.Property(c => c.UF).HasColumnName("UF");

            builder.Property(c => c.Pais).HasColumnName("PAIS");

            builder.Property(c => c.CEP).HasColumnName("CEP").HasConversion(
                v => Helper.ColocaMascaraCEP(v),
                v => Helper.SoNumeros(v)
            );

            builder.Property(c => c.TipoCliente).HasColumnName("TIPOCLIENTE").HasConversion<string>(
                v => DataTypes.TipoClienteToString(v),
                v => DataTypes.StringToTipoCliente(v)
            );

            builder.Property(c => c.RG).HasColumnName("RG").HasConversion<string>(
                v => Helper.ColocaMascaraRG(v),
                v => Helper.SoNumeros(v)
            );

            builder.Property(c => c.CPF).HasColumnName("CPF").HasConversion<string>(
                v => Helper.ColocaMascaraCPF(v),
                v => Helper.SoNumeros(v)
            );

            builder.Property(c => c.CNPJ).HasColumnName("CNPJ").HasConversion<string>(
                v => Helper.ColocaMascaraCNPJ(v),
                v => Helper.SoNumeros(v)
            );

            builder.Property(c => c.InscricaoEstadual).HasColumnName("IE").HasConversion<string>(
                v => Helper.SoNumeros(v),
                v => v
            );

            builder.Property(c => c.InscricaoMunicipal).HasColumnName("IM").HasConversion<string>(
                v => Helper.SoNumeros(v),
                v => v
            );

            builder.Property(c => c.DataNascimento).HasColumnName("DATANASCIMENTO");

            builder.Property(c => c.DataHoraCadastro).HasColumnName("DATAHORACADASTRO");

            builder.Property(c => c.EstadoCivil).HasColumnName("ESTADOCIVIL").HasConversion<string>(
                v => DataTypes.EstadoCivilToString(v),
                v => DataTypes.StringToEstadoCivil(v)
            );

            builder.Property(c => c.Ativo).HasColumnName("ATIVO").HasConversion<string>(
                v => DataTypes.BoolToSimNao(v),
                v => DataTypes.SimNaoToBool(v)
            );

            builder.Property(c => c.Fantasia).HasColumnName("FANTASIA");

            builder.Property(c => c.Nacionalidade).HasColumnName("NACIONALIDADE");

            builder.Property(c => c.Numero).HasColumnName("NUMERO");

            builder.Property(c => c.Sexo).HasColumnName("SEXO").HasConversion<string>(
                v => DataTypes.SexoToString(v),
                v => DataTypes.StringToSexo(v)
            );

            builder.Property(c => c.CodigoCidadeIBGE).HasColumnName("CODIGOCIDADEIBGE");

            builder.Property(c => c.Tributacao).HasColumnName("TRIBUTACAO").HasConversion<string>(
                v => DataTypes.TributacaoClienteToString(v),
                v => DataTypes.StringToTributacaoCliente(v)
            );

            builder.Property(c => c.CodigoPais).HasColumnName("CODIGOPAIS");
        }
    }
}
