using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Webshop.DAL.Entit;

namespace Webshop.DAL.Repositories
{
    public class CourseRepo : IRepository<Course>
    {
        private WebshopContext _webshopContext;
        public CourseRepo(WebshopContext context)
        {
            _webshopContext = context;  
        }

        public Course Add(Course course)
        {
            try
            {
                _webshopContext._Courses.Add(course);
                return course;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
           
          
        }

        public Course FindById(int? id)
        {
            try
            {
                return _webshopContext._Courses.Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public Course Modify(Course course)
        {
            try
            {
                _webshopContext._Courses.AddOrUpdate(course);
                return course;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
            
        }

        public List<Course> GetAll()
        {
            try
            {
                return _webshopContext._Courses.ToList();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
            
        }

        public void Remove(Course t)
        {
            try
            {
              var course = FindById(t.Id);
              _webshopContext._Courses.Remove(course);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

       
    }
}
