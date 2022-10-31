using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace IleriRepository.Controllers
{
    public class DepartmentController : Controller
    {
        public IUnit _uow;
        DepartmentModel _model;


        public DepartmentController(IUnit uow, DepartmentModel model)
        {
            _uow = uow;
            _model = model;


        }
        public IActionResult List()
        {
            var clist = _uow._departmanRep.List();
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
            _model.Department = new Department();
            return View("Crud", _model);


        }
        [HttpPost]
        public IActionResult Create(DepartmentModel model)
        {
            _uow._departmanRep.Add(model.Department);
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
            _model.Department = _uow._departmanRep.Find(Id);
            return View("Crud", _model);

        }
        [HttpPost]
        public IActionResult Edit(DepartmentModel model)
        {
            _uow._departmanRep.Update(model.Department);
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
        public IActionResult Delete(int Id)
        {

            _model.Head = "silme";
            _model.Text = "sil";
            _model.Cls = "btn btn-danger";
            _model.Department = _uow._departmanRep.Find(Id);
            return View("Crud", _model);

        }
        [HttpPost]
        public IActionResult Delete(DepartmentModel d)
        {
            _uow._departmanRep.Delete(d.Department);
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
    }
}
