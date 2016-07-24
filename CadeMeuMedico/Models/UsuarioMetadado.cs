using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
	[MetadataType(typeof(UsuarioMetadado))]

	public partial class Usuario
	{

	}

	public class UsuarioMetadado
	{
		[Required(ErrorMessage = "Obrigatório informar Nome")]
		[StringLength(100,ErrorMessage = "Nome deve possuir no máximo 100 caracteres")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Obrigatório informar Login")]
		[StringLength(30,ErrorMessage = "Login deve possuir no máximo 30 caracteres")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Obrigatório informar a Senha")]
		[StringLength(30,MinimumLength = 6, ErrorMessage = "Senha deve possuir entre 6 e 30 caracteres")]
		public string Senha { get; set; }

		[Required(ErrorMessage = "Obrigatório informar o Email")]
		[StringLength(60,ErrorMessage = "Email deve possuir no máximo 60 caracteres")]
		public string Email { get; set; }
	}
}