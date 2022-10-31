using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.Repositories.Abstract;
using IleriRepository.Repositories.Concretes;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Completion;

namespace IleriRepository.Controllers
{
    public class CityController : Controller
    {
        public IUnit _uow;
        CityModel _model;
     
      
        public CityController(IUnit uow,CityModel model)
        {
            _uow=uow;
            _model=model;

          
        }
        public IActionResult List()
        {
           var clist= _uow._cityRep.List();
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
            _model.City = new City();
            return View("Crud", _model);
           

        }
        [HttpPost]
        public IActionResult Create(CityModel  model)
        {
             _uow._cityRep.Add(model.City);
            //herşey uow de olcak
            //add
            //update
            //Delete
             _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
        public IActionResult Update(int Id)
        {
            _model.Head = "güncelle" +
                "";
            _model.Text = "güncelle";
            _model.Cls = "btn btn-success";
           _model.City= _uow._cityRep.Find(Id);
            return View("Crud",_model);
                
        }
        [HttpPost]
        public IActionResult Update(CityModel model)
        {
            _uow._cityRep.Update(model.City);
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
        public IActionResult Delete(int Id)
        {

            _model.Head = "silme";
            _model.Text = "sil";
            _model.Cls = "btn btn-danger";
            _model.City = _uow._cityRep.Find(Id);
            return View("Crud", _model);

        }
        [HttpPost]
        public IActionResult Delete(City city)
        {
            _uow._cityRep.Delete(city);
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }

    }
}
