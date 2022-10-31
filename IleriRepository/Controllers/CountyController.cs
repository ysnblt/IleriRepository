using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace IleriRepository.Controllers
{
    public class CountyController : Controller
    {
        public IUnit _uow;
        CountyModel _model;


        public CountyController(IUnit uow, CountyModel model)
        {
            _uow = uow;
            _model = model;


        }
        public IActionResult List()
        {
            var clist = _uow._countyRep.List();
            return View(clist);
        }
        //cretae önce program.cs newledikl
        //builder.Services.AddScoped<CityModel>();
        public IActionResult Create()
        {
            _model.Head = "Yeni giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            //yeni bir nesne oluşturduk
            _model.County = new County();
            _model.City = _uow._cityRep.List();
            return View("Crud", _model);


        }
        [HttpPost]
        public IActionResult Create(CountyModel model)
        {
            _uow._countyRep.Add(model.County);
            //herşey uow de olcak
            //add
            //update
            //Delete
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
        public IActionResult Edit(int Id)
        {
            _model.Head = "güncelle" +
                "";
            _model.Text = "güncelle";
            _model.Cls = "btn btn-success";
            _model.County = _uow._countyRep.Find(Id);
            _model.City = _uow._cityRep.List();
            return View("Crud", _model);

        }
        [HttpPost]
        public IActionResult Edit(CountyModel model)
        {
            _uow._countyRep.Update(model.County);
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
        public IActionResult Delete(int Id)
        {

            _model.Head = "silme";
            _model.Text = "sil";
            _model.Cls = "btn btn-danger";
            _model.County = _uow._countyRep.Find(Id);
            _model.City = _uow._cityRep.List();
            return View("Crud", _model);

        }
        [HttpPost]
        public IActionResult Delete(CountyModel city)
        {
            _uow._countyRep.Delete(city.County);
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
    }
}
