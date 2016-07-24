using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CadeMeuMedico.Controllers
{
    public class CidadesController : BaseController
    {
		private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();
        // GET: Cidades
        public ActionResult Index()
        {
			var cidade = db.Cidade.ToList();
            return View(cidade);
        }

		public ActionResult Adicionar()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Adicionar(Cidade cidade)
		{
			if (ModelState.IsValid)
			{
				db.Cidade.Add(cidade);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(cidade);
		}

		public ActionResult Editar(long id)
		{
			Cidade cidade = db.Cidade.Find(id);
			return View(cidade);
		}

		[HttpPost]
		public ActionResult Editar(Cidade cidade)
		{
			if (ModelState.IsValid)
			{
				db.Entry(cidade).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(cidade);
		}

		public ActionResult Deletar(long id)
		{
			Cidade cidade = db.Cidade.Find(id);
			return View(cidade);
		}

		[HttpPost]
		public string Deletar(Cidade cidade)
		{
			try
			{
				db.Cidade.Remove(cidade);
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