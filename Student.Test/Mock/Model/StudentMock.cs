using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Test.Mock.Model
{
    public class StudentMock
    {
        public async Task <List<Domain.Entities.Students>> GetAll()
        {
            return  new List<Domain.Entities.Students>()
            {
                new Domain.Entities.Students
                {
                    Id = 1,
                    Name = "Name 1",
                    Gender ="M",
                    //Addresse ="Adress 1",
                    ContactNo ="08888888",
                    Faculty ="Science"
                },
                 new Domain.Entities.Students
                {
                    Id = 2,
                     Name = "Name 2",
                    Gender ="F",
                    //Addresse ="Adress 2",
                    ContactNo ="09999999",
                    Faculty ="Arts"
                },
                  new Domain.Entities.Students
                {
                    Id = 3,
                    Name = "Name 3",
                    Gender ="F",
                    //Addresse ="Adress 3",
                    ContactNo ="07777777",
                    Faculty ="Pedagogie"
                }
            };
        }

        public async Task<Domain.Entities.Students> Get()
        {
            return new Domain.Entities.Students
            {
                Id = 3,
                Name = "Name 3",
                Gender = "F",
                //Addresse = "Adress 3",
                ContactNo = "07777777",
                Faculty = "Pedagogie"
            };
        }
        public Domain.Entities.Students? GetNotFound()
        {
            return default;
        }   
    }
}
