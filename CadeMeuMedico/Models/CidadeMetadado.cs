using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
	[MetadataType(typeof(CidadeMetadado))]
	public partial class Cidade
	{

	}
	public class CidadeMetadado
	{
		[Required(ErrorMessage = "Obrigatório informar nome da cidade")]
		[StringLength(80,ErrorMessage = "Nome da cidade deve possuir no máximo 80 caracteres")]
		public string Nome { get; set; }
	}
}