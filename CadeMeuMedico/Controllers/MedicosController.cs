using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data.Entity;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : BaseController
    {
		private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();
        // GET: Medicos
        public ActionResult Index()
        {
			var medicos = db.Medico.Include(m => m.Cidade)
				.Include(m => m.Especialidade).ToList();
            return View(medicos);
        }

		public ActionResult Adicionar()
		{
			ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome");
			ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome");
			return View();
		}

		[HttpPost]
		public ActionResult Adicionar(Medico medico)
		{
			if (ModelState.IsValid)
			{
				db.Medico.Add(medico);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome");
			ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome");
			return View(medico);
		}

		public ActionResult Editar(long id)
		{
			Medico medico = db.Medico.Find(id);
			ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome");
			ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome");
			return View(medico);
		}

		[HttpPost]
		public ActionResult Editar(Medico medico)
		{
			if (ModelState.IsValid)
			{
				db.Entry(medico).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome");
			ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome");
			return View(medico);
		}

		public ActionResult Deletar(long id)
		{
			Medico medico = db.Medico.Find(id);
			ViewBag.IDCidade = new SelectList(db.Cidade, "Cidade", "Nome");
			ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "Especialide", "Nome");
			return View(medico);
		}

		[HttpPost]
		public string Deletar(Medico medico)
		{
			try
			{
				//Medico medico = db.Medico.Find(id);
				db.Medico.Remove(medico);
				db.SaveChanges();
				return Boolean.TrueString;

			}
			catch
			{
				return Boolean.FalseString;
			}
		}
	}
}