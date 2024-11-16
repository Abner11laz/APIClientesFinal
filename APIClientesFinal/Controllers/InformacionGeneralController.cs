using APIClientesFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIClientesFinal.Controllers
{
    public class InformacionGeneralController : Controller
    {
        private readonly Umgdesaweb24Context _context;
        // GET: InformacionGeneralController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet("ListadoGeneral")]
        public async Task<ActionResult<IEnumerable<Informaciongeneral>>> ListadoGeneral()
        {
            var lista = await _context.Informaciongenerals
                .OrderBy(info => info.Fechacreacion)
                .ThenBy(info => info.Tipoinformacion)
                .ToListAsync();
            return Ok(lista);
        }
        // GET: InformacionGeneralController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InformacionGeneralController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformacionGeneralController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InformacionGeneralController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InformacionGeneralController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InformacionGeneralController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InformacionGeneralController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
