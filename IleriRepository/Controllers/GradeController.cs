using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace IleriRepository.Controllers
{
    public class GradeController : Controller
    {
        public IUnit _uow;
        GradeModel _model;


        public GradeController(IUnit uow, GradeModel model)
        {
            _uow = uow;
            _model = model;


        }
        public IActionResult List()
        {
            var clist = _uow._gradeRep.List();
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
            _model.Grade = new Grade();
            return View("Crud", _model);


        }
        [HttpPost]
        public IActionResult Create(GradeModel model)
        {
            _uow._gradeRep.Add(model.Grade);
            //herşey uow de olcak
            //add
            //update
            //Delete
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
        public IActionResult Edit(string Id)
        {
            _model.Head = "güncelle";
            _model.Text = "güncelle";
            _model.Cls = "btn btn-success";
            _model.Grade = _uow._gradeRep.Find(Id);
            return View("Crud", _model);

        }
        [HttpPost]
        public IActionResult Edit(GradeModel model)
        {
            _uow._gradeRep.Update(model.Grade);
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
        public IActionResult Delete(string Id)
        {

            _model.Head = "silme";
            _model.Text = "sil";
            _model.Cls = "btn btn-danger";
            _model.Grade = _uow._gradeRep.Find(Id);
            return View("Crud", _model);

        }
        [HttpPost]
        public IActionResult Delete(GradeModel model)
        {

            _uow._gradeRep.Delete(model.Grade);
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.

        }
    }
}
