using Layer.Architecture.Application.Models;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Layer.Architecture.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeEntityController : ControllerBase
    {
        private IBaseService<SomeEntity> _baseSomeEntityService;

        public SomeEntityController(IBaseService<SomeEntity> baseSomeEntityService)
        {
            _baseSomeEntityService = baseSomeEntityService;
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSomeEntityModel someEntity)
        {
            if (someEntity == null)
                return NotFound();

            return Execute(() => _baseSomeEntityService.Add<CreateSomeEntityModel, SomeEntityModel, SomeEntityValidator>(someEntity));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateSomeEntityModel someEntity)
        {
            if (someEntity == null)
                return NotFound();

            return Execute(() => _baseSomeEntityService.Update<UpdateSomeEntityModel, SomeEntityModel, SomeEntityValidator>(someEntity));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseSomeEntityService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseSomeEntityService.Get<SomeEntityModel>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(()=> _baseSomeEntityService.GetById<SomeEntityModel>(id));
        }
    }
}
