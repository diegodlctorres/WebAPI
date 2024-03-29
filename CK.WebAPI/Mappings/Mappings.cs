﻿using CK.DataAccess.Models;
using CK.DataTransferObject;
using System.Collections.Generic;

namespace CK.WebAPI.Mappings
{

    //DTO EFIC_050
    public static partial class Mapper
    {
        //Métodos de extensión
        public static Efic050DTO ToDataTransferObject(this Efic050 model)  // Convierte de ModelContext a DTO
        {
            return new Efic050DTO()
            {

                CodEmpresa=model.CodEmpresa,
                CodFuncionario=model.CodFuncionario,
                Nome=model.Nome,
                Turno=model.Turno,
                LancaParada=model.LancaParada,
                LancaRejeicao=model.LancaRejeicao,
                CodigoCargo=model.CodigoCargo,
                CentroCusto=model.CentroCusto,
                DataNascimento=model.DataAdmissao,
                DataAdmissao=model.DataAdmissao,
                Sexo=model.Sexo,
                EstadoCivil=model.EstadoCivil,
                GrauInstrucao=model.GrauInstrucao,
                PlanoSaude=model.PlanoSaude,
                CpfFunc=model.CpfFunc,
                CustoHora=model.CustoHora,
                ResponsavelDados=model.ResponsavelDados,
                EMail=model.EMail,
                Ramal=model.Ramal,
                Observacao= model.Observacao,
                CrachaFuncionario=model.CrachaFuncionario,
                SetorResponsavel=model.SetorResponsavel,
                SitFuncionario=model.SitFuncionario,
                LancaHrsManu=model.LancaHrsManu,
                FlgDestajo=model.FlgDestajo
            };
        }
    }

    public static partial class Mapper
    {
        public static Efic050 ToModel(this Efic050DTO dto)  // Convierte de DTO a ModelContext
        {
            return new Efic050()
            {
                CodEmpresa = dto.CodEmpresa,
                CodFuncionario = dto.CodFuncionario,
                Nome = dto.Nome,
                Turno = dto.Turno,
                LancaParada = dto.LancaParada,
                LancaRejeicao = dto.LancaRejeicao,
                CodigoCargo = dto.CodigoCargo,
                CentroCusto = dto.CentroCusto,
                DataNascimento = dto.DataAdmissao,
                DataAdmissao = dto.DataAdmissao,
                Sexo = dto.Sexo,
                EstadoCivil = dto.EstadoCivil,
                GrauInstrucao = dto.GrauInstrucao,
                PlanoSaude = dto.PlanoSaude,
                CpfFunc = dto.CpfFunc,
                CustoHora = dto.CustoHora,
                ResponsavelDados = dto.ResponsavelDados,
                EMail = dto.EMail,
                Ramal = dto.Ramal,
                Observacao = dto.Observacao,
                CrachaFuncionario = dto.CrachaFuncionario,
                SetorResponsavel = dto.SetorResponsavel,
                SitFuncionario = dto.SitFuncionario,
                LancaHrsManu = dto.LancaHrsManu,
                FlgDestajo = dto.FlgDestajo
            };
        }
    }


    public static partial class Mapper
    {
        //Métodos de extensión
        public static UsuarioDTO ToDataTransferObject(this Usuario model)  // Convierte de ModelContext a DTO
        {
            return new UsuarioDTO()
            {
                CodFuncionario = model.CodFuncionario,
                Contrasena=model.Contrasena ,
                Nome = model.Nome,
                Mensaje = model.Mensaje
             };
        }
    }

    public static partial class Mapper
    {
        public static Usuario ToModel(this UsuarioDTO dto)  // Convierte de DTO a ModelContext
        {
            return new Usuario()
            {
                CodFuncionario = dto.CodFuncionario,
                Contrasena = dto.Contrasena,
                Nome = dto.Nome,
                Mensaje = dto.Mensaje
            };
        }
    }
    public static partial class Mapper
    {
        //Métodos de extensión
        public static MoverCajaDTO ToDataTransferObject(this MoverCaja model)  // Convierte de ModelContext a DTO
        {
            return new MoverCajaDTO()
            {
                p_cb_prenda=model.p_cb_prenda,
                p_num_caja= model.p_num_caja,
                p_tipo = model.p_tipo,
                p_deposito = model.p_deposito,
                p_new_caja=model.p_new_caja

            };
        }
    }

    public static partial class Mapper
    {
        public static MoverCaja ToModel(this MoverCajaDTO dto)  // Convierte de DTO a ModelContext
        {
            return new MoverCaja()
            {
                p_cb_prenda = dto.p_cb_prenda,
                p_num_caja = dto.p_num_caja,
                p_tipo = dto.p_tipo,
                p_deposito = dto.p_deposito,
                p_new_caja = dto.p_new_caja
            };
        }
    }

    public static partial class Mapper
    {
        public static List<CajaDTO> ToDataTransferObject(this List<Caja> model)  // Convierte de DTO a ModelContext
        {
            List<CajaDTO> cajaDtos = new List<CajaDTO>();
            foreach(var mdl in model)
            {
                CajaDTO aux = new CajaDTO();
                aux.DEPOSITO_ENTRADA = mdl.DEPOSITO_ENTRADA;
                aux.DESCRIPCION = mdl.DESCRIPCION;
                aux.DESCRIPCION_DEPOSITO = mdl.DESCRIPCION_DEPOSITO;
                aux.PEDIDO_VENDA = mdl.PEDIDO_VENDA;
                aux.QTDE_PECAS_REAL = mdl.QTDE_PECAS_REAL;
                aux.GRUPO = mdl.GRUPO;
                aux.SUB = mdl.SUB;
                aux.ITEM = mdl.ITEM;
                aux.NIVEL = mdl.NIVEL;
                aux.COLOR = mdl.COLOR;
                aux.CLIENTE = mdl.CLIENTE;
                cajaDtos.Add(aux);
            }
            return cajaDtos;
            //return new CajaDTO()
            //{
            //    DEPOSITO_ENTRADA = model.DEPOSITO_ENTRADA,
            //    DESCRIPCION = model.DESCRIPCION,
            //    DESCRIPCION_DEPOSITO = model.DESCRIPCION_DEPOSITO,
            //    PEDIDO_VENDA = model.PEDIDO_VENDA,
            //    QTDE_PECAS_REAL = model.QTDE_PECAS_REAL,
            //    GRUPO = model.GRUPO,
            //    SUB = model.SUB,
            //    ITEM = model.ITEM,
            //    NIVEL = model.NIVEL
            //};
        }
    }



}
