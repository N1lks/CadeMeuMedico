using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using CadeMeuMedico.Models;
using System.Data.Entity;
using CadeMeuMedico.Repositorios;

namespace CadeMeuMedico.Repositorios
{
	public class RepositorioUsuarios
	{
		public static bool AutenticarUsuario(string Login, string Senha)
		{
			var senhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
			using (CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities())
			{
				var QueryAutenticaUsuario = db.Usuario.Where(x => x.Login == Login && x.Senha == Senha).SingleOrDefault();
				if(QueryAutenticaUsuario == null)
				{
					return false;
				}
				else
				{
					RepositorioCookies.RegistraCookieAutenticacao(QueryAutenticaUsuario.IDUsuario);
					return true;
				}
			}
		}
	}
}