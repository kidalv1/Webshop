using System;
using System.Collections.Generic;
using AutoMapper;
using Webshop.DAL;
using Webshop.DAL.Entit;
using Webshop.DAL.Repositories;
using Webshop.DAL.UnitOfWork;
using Webshop.Domain;

namespace Webshop.BL
{
    public class CourseLogic : ILogic<CourseDTO>
    {
        private UnitOfWork _uow;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CourseLogic(UnitOfWork uow)
        {
            _uow = uow;
        }

        public CourseDTO Create(CourseDTO c)
        {
            try
            {
                var course = MapDTO.Map<Course, CourseDTO>(c);
                _uow.CourseRepo.Add(course);
                _uow.Save();

                c.Id = course.Id;

                return c;
            }
            catch (Exception e)
            {
                log.Error("Kon geen cursus aanmaken", e);
                throw new Exception(e.Message);
            }
        }

        public CourseDTO FindByID(int? id)
        {
            try
            {
                var c = _uow.CourseRepo.FindById(id);

                return c == null ? null : MapDTO.Map<CourseDTO, Course>(c);
            }
            catch (Exception e)
            {
                log.Error("Kon id niet vinden", e);
                throw new Exception(e.Message);
            }
        }

        public void Delete(CourseDTO c)
        {
            try
            {
                _uow.CourseRepo.Remove(MapDTO.Map<Course, CourseDTO>(c));
                _uow.Save();
            }
            catch (Exception e)
            {
                log.Error("kon geen cursus verwijderren", e);
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            var c = FindByID(id);
            try
            {
                _uow.CourseRepo.Remove(MapDTO.Map<Course, CourseDTO>(c));
                _uow.Save();
            }
            catch (Exception e)
            {
                log.Error("kon geen cursus verwijderren", e);
                throw new Exception(e.Message);
            }
        }

        public List<CourseDTO> GetAll()
        {
            try
            {
                return MapDTO.MapList<CourseDTO, Course>(_uow.CourseRepo.GetAll());
            }
            catch (Exception e)
            {
                log.Error("kon niet ophalen", e);
                throw new Exception(e.Message);
            }
        }

        public CourseDTO Update(CourseDTO c)
        {
            try
            {
                _uow.CourseRepo.Modify(MapDTO.Map<Course, CourseDTO>(c));
                _uow.Save();
                return c;
            }
            catch (Exception e)
            {
                log.Error("kon niet updaten");
                throw new Exception(e.Message);
            }
        }
    }
}