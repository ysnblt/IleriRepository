using IleriRepository.Data;

namespace IleriRepository.Models
{
    public class PersonelModel
    {
        public Personel ?Personel { get; set; }
        public List<County> ?County { get; set; }
        public List<Grade> ?Grade { get; set; }
        public List<Department> ?Department { get; set; }
        public string? Head { get; set; }
        public string? Text { get; set; }
        public string? Cls { get; set; }
    }
}
