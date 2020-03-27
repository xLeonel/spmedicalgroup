using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace spmedgroup.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "É necessário informar a data da consulta")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm:ss}")]
        public DateTime DataConsulta { get; set; }

        [DataType(DataType.Text)]
        public string DescricaoPaciente { get; set; }

        [Required(ErrorMessage = "É necessário informar o medico")]
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "É necessário informar o paciente")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "É necessário informar a situaçao da consulta")]
        public int IdSituacaoConsulta { get; set; }

        public Medico IdMedicoNavigation { get; set; }
        public SituacaoConsulta IdSituacaoConsultaNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}
