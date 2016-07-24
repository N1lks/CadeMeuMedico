﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
	[MetadataType(typeof(EspecialidadeMetadado))]

	public partial class Especialidade
	{

	}
	public class EspecialidadeMetadado
	{
		[Required (ErrorMessage = "Obrigatório informar nome para especialidade")]
		[StringLength(80,ErrorMessage = "O nome deve possuir no máximo 80 caracteres")]
		public string Nome { get; set; }
	}
}