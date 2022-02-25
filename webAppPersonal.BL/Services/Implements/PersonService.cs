using webAppPersonal.BL.Models;
using webAppPersonal.BL.Repositories;

namespace webAppPersonal.BL.Services.Implements
{
    public class PersonService: GenericService<persona>, IPersonService
    {
        public PersonService(IPersonRepository personRepository): base(personRepository)
        {

            
        }
    }
}
