using System.Runtime.InteropServices.JavaScript;
using CrimeRadius.Model;
using CrimeRadius.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrimesByRadius.Controllers;

public class CrimesByRadiusController(ICrimeService crimeService) : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> GetCrimeData(double latitude, double longitude, DateOnly date)
    {
        var crimeData = await crimeService.GetCrimeDataAsync(latitude, longitude, date);

        if (crimeData != null)
        {
            return View(crimeData);
        }

        return View(new List<CrimeData>());
    }
}