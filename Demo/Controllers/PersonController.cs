using Demo.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        [HttpGet("/get-all")]
        public List<PersonDto> GetList()
        {
            List<PersonDto> list = new List<PersonDto>();

            list.Add(new PersonDto { Id = 1, Name = "John Doe", Phone = "123-456-7890", Email = "john@example.com", Address = "123 Main St" });
            list.Add(new PersonDto { Id = 2, Name = "Jane Smith", Phone = "987-654-3210", Email = "jane@example.com", Address = "456 Elm St" });
            list.Add(new PersonDto { Id = 3, Name = "Alice Johnson", Phone = "555-555-5555", Email = "alice@example.com", Address = "789 Oak St" });

            return list;
        }

        [HttpGet("/get-by-id/{id}")]
        public  IEnumerable<PersonDto> GetById(int id)
        {
            List<PersonDto> list = new List<PersonDto>();

            list.Add(new PersonDto { Id = 1, Name = "John Doe", Phone = "123-456-7890", Email = "john@example.com", Address = "123 Main St" });
            list.Add(new PersonDto { Id = 2, Name = "Jane Smith", Phone = "987-654-3210", Email = "jane@example.com", Address = "456 Elm St" });
            list.Add(new PersonDto { Id = 3, Name = "Alice Johnson", Phone = "555-555-5555", Email = "alice@example.com", Address = "789 Oak St" });

            PersonDto? response =list.Where(x => x.Id == id).FirstOrDefault();

            if(response == null)
            {
                return new List<PersonDto> { };
            }
            return new List<PersonDto> { response };
        }
    }
}
