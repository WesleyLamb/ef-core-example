using FirebirdSql.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Core
{
    public enum TipoCliente
    {
        PessoaFisica,
        PessoaJuridica
    }
    public enum EstadoCivil
    {
        Solteiro,
        Casado,
        Viuvo,
        Divorciado,
        Outro
    }
    
    public enum Sexo
    {
        Masculino,
        Feminino
    }
    
    public enum TributacaoCliente
    {
        Normal,
        Substituto,
        NaoContribuinte
    }

    public class DataTypes
    {

        public static string TipoClienteToString(TipoCliente aTipoCliente)
        {
            return aTipoCliente == TipoCliente.PessoaFisica ? "FÍSICA" : "JURÍDICA";
        }

        public static TipoCliente StringToTipoCliente(string aString)
        {
            return aString == "FÍSICA" ? TipoCliente.PessoaFisica : TipoCliente.PessoaJuridica;
        }

        public static string EstadoCivilToString(EstadoCivil aEstadoCivil)
        {
            switch (aEstadoCivil)
            {
                case EstadoCivil.Solteiro:
                    return "SOLTEIRO";
                case EstadoCivil.Casado:
                    return "CASADO";
                case EstadoCivil.Viuvo:
                    return "VIÚVO";
                case EstadoCivil.Divorciado:
                    return "DIVORCIADO";
                default:
                    return "OUTRO";
            }
        }

        public static EstadoCivil StringToEstadoCivil(string aString)
        {
            switch (aString)
            {
                case "SOLTEIRO":
                    return EstadoCivil.Solteiro;
                case "CASADO":
                    return EstadoCivil.Casado;
                case "VIÚVO":
                    return EstadoCivil.Viuvo;
                case "DIVORCIADO":
                    return EstadoCivil.Divorciado;
                default:
                    return EstadoCivil.Outro;
            }
        }

        public static string SexoToString(Sexo aSexo)
        {
            return aSexo == Sexo.Masculino ? "F" : "F";
        }

        public static Sexo StringToSexo(string aString)
        {
            return aString == "M" ? Sexo.Masculino : Sexo.Feminino;
        }

        public static string TributacaoClienteToString(TributacaoCliente aTributacaoCliente)
        {
            switch (aTributacaoCliente)
            {
                case TributacaoCliente.Normal:
                    return "NORMAL";
                case TributacaoCliente.Substituto:
                    return "SUBSTITUTO";
                default:
                    return "NÃO CONTRIBUINTE";
            }
        }

        public static TributacaoCliente StringToTributacaoCliente(string aString)
        {
            switch (aString)
            {
                case "NORMAL":
                    return TributacaoCliente.Normal;
                case "SUBSTITUTO":
                    return TributacaoCliente.Substituto;
                default:
                    return TributacaoCliente.NaoContribuinte;
            }
        }

        public static bool SimNaoToBool(string aString)
        {
            return aString == "SIM";
        }

        public static string BoolToSimNao(bool aBool)
        {
            return aBool ? "SIM" : "NÃO";
        }
    }
}
