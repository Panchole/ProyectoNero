using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoNero.Client.Models;

namespace ProyectoNero.Client.Controllers;

public class HomeController : Controller
{

    private readonly IUnitOfWork _unitOfWork;

    public HomeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var CarruselIndexImagen = await _unitOfWork.CarruselIndex.GetAll();
        return View(CarruselIndexImagen);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<JsonResult> GetCarruselIndex()
    {
        var CarruselIndexImagen = await _unitOfWork.CarruselIndex.GetAll();
        return Json(CarruselIndexImagen);
    }

    public async Task<JsonResult> GetCarruselIndexByID(int id)
    {
        var CarruselIndexImagen = await _unitOfWork.CarruselIndex.GetById(id);
        return Json(CarruselIndexImagen);
    }
}
