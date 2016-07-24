using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data.Entity;

namespace CadeMeuMedico.Controllers
{
    public class EspecialidadesController : BaseController
    {
		private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();
        // GET: Especialidades
        public ActionResult Index()
        {
			var especialidades = db.Especialidade.ToList();
            return View(especialidades);
        }

		public ActionResult Adicionar()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Adicionar(Especialidade especialidade)
		{
			if (ModelState.IsValid)
			{
				//Especialidade especialidade = db.Especialidade.Find(id);
				db.Especialidade.Add(especialidade);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(especialidade);
		}

		public ActionResult Editar(long id)
		{
			Especialidade especialidade = db.Especialidade.Find(id);
			return View(especialidade);
		}

		[HttpPost]
		public ActionResult Editar(Especialidade especialidade)
		{
			if (ModelState.IsValid)
			{
				db.Entry(especialidade).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(especialidade);
		}

		public ActionResult Deletar(long id)
		{
			Especialidade especialidade = db.Especialidade.Find(id);
			return View(especialidade);
		}

		[HttpPost]
		public string Deletar(Especialidade especialidade)
		{
			try
			{
				db.Especialidade.Remove(especialidade);
				return Boolean.TrueString;
			}
			catch
			{
				return Boolean.FalseString;
			}

		}
    }
}