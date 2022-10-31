using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace IleriRepository.Controllers
{
    public class PersonelController : Controller
    {
        public IUnit _uow;
        PersonelModel _model;


        public PersonelController(IUnit uow, PersonelModel model)
        {
            _uow = uow;
            _model = model;


        }
        public IActionResult ListGrade()
        {
            var clist = _uow._personelRep.ListbyGrade();
            return View(clist);
        }
        public IActionResult Details(int Id)
        {
            Personel p = _uow._personelRep.FindDetail(Id); 
            return View(p);
        }
        public IActionResult ListDep()
        {
            var clist = _uow._personelRep.ListbyDepatment();
            return View(clist);
        }
        public IActionResult List()
        {
            var clist = _uow._personelRep.List();
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
            _model.Personel = new Personel ();
            return View("Crud", _model);


        }
        [HttpPost]
        public IActionResult Create(PersonelModel model)
        {
            _uow._personelRep.Add(model.Personel);
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
            _model.Personel = _uow._personelRep.Find(Id);
            return View("Crud", _model);

        }
        [HttpPost]
        public IActionResult Edit(PersonelModel model)
        {
            _uow._personelRep.Update(model.Personel);
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
        public IActionResult Delete(int Id)
        {

            _model.Head = "silme";
            _model.Text = "sil";
            _model.Cls = "btn btn-danger";
            _model.Personel = _uow._personelRep.Find(Id);
            return View("Crud", _model);

        }
        [HttpPost]
        public IActionResult Delete(PersonelModel d)
        {
            _uow._personelRep.Delete(d.Personel);
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.


        }
    }
}
