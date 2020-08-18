using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Entit;
using Webshop.DAL.Repositories;

namespace Webshop.BL
{
    public class CourseManager : IManager<Course>
    {
        private CourseRepo repo;

        public CourseManager()
        {
            repo = new CourseRepo();
        }

        public void Add(Course t)
        {
            repo.Create(t);
        }

        public Course FindById(int? id)
        {
            return repo.Read(id);
        }

        public void Modify()
        {
            repo.Update();
        }

        public List<Course> GetAll()
        {
            return repo.ReadAll();
        }

        public void Remove(Course t)
        {
            repo.Delete(t);
        }
    }
}