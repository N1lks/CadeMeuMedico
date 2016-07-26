using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Controllers
{
    public class HomeController : BaseController
    {
		private	CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();
		// GET: Home
		public ActionResult Index()
		{
			ViewBag.Especialidades = new SelectList(db.Especialidade, "IDEspecialidade", "Nome");
			ViewBag.Cidades = new SelectList(db.Cidade, "IDCidade", "Nome");

			return View();
		}


		public ActionResult Login()
		{
			ViewBag.Title = "Seja Bem Vindo(a)";
			return View();	
		}

		public ActionResult Pesquisar(Pesquisa pesquisa)
		{
			var medicos = from m in db.Medico
						  where m.IDCidade == pesquisa.IDCidade && m.IDEspecialidade == pesquisa.IDEspecialidade
						  select new ResultadoPesquisa { Nome = m.Nome, Crm = m.CRM };

			return Json(medicos, JsonRequestBehavior.AllowGet);
		}
	}
}