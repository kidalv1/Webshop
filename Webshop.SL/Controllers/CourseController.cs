using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webshop.BL;
using Webshop.Domain;

namespace Webshop.SL.Controllers
{
    public class CourseController : ApiController
    {
        private ILogic<CourseDTO> _courseLogic;

        public CourseController(CourseLogic logic)
        {
          _courseLogic = logic;
        }

        public IHttpActionResult GetCourses()
        {

          return Ok(_courseLogic.GetAll().AsEnumerable());
        }

        public IHttpActionResult GetCourse(int id)
        {
            var course = _courseLogic.FindByID(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public IHttpActionResult CreateCourse(CourseDTO courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _courseLogic.Create(courseDto);
            return Created(new Uri(Request.RequestUri + "/" + courseDto.Id), courseDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCourse(CourseDTO courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var courseInDb = _courseLogic.FindByID(courseDto.Id);

            if (courseInDb == null)
            {
                return NotFound();
            }

            return Ok(_courseLogic.Update(courseDto));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var courseInDb = _courseLogic.FindByID(id);

            if (courseInDb == null)
            {
                return NotFound();
            }

            _courseLogic.Delete(courseInDb);

            return Ok();
        }
    }
}
