//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using AGENDAR.Data;
//using AGENDAR.Models;

//namespace AGENDAR.Controllers
//{
//    public class DisponibilidadHorariasController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public DisponibilidadHorariasController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: DisponibilidadHorarias
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.DisponibilidadHoraria.ToListAsync());
//        }
//        // Funcion para CompletarTablasProvincias 
//        public JsonResult BuscarDisponibilidadHoraria()
//        {
//            var disponibilidadHoraria = _context.DisponibilidadHoraria.ToList();

//            return Json(disponibilidadHoraria);
//        }



//        private bool DisponibilidadHorariaExists(int id)
//        {
//            return _context.DisponibilidadHoraria.Any(e => e.DisponibilidadHorariaID == id);
//        }
//    }
//}
