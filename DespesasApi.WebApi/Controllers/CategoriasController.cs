using DespesasApi.Application.Interfaces;
using DespesasApi.Domain.Entities;
using DespesasApi.UnitOfWork;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DespesasApi.WebApi.Controllers
{
    [Route("v1/api/[controller]/[action]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        //Injeção Categoria service
        private readonly ICategoriaService _categoriasService;

        //Injeção Validator
        private readonly IValidator<Categoria> _validator;

        //Injeção UnitOfWork
        private readonly IUoW _uow;

        public CategoriasController(IUoW uow, ICategoriaService categoriasService, IValidator<Categoria> validator)
        {
            _categoriasService = categoriasService;
            _uow = uow;
            _validator = validator;
        }

        //GetAll api/categorias/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _categoriasService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //GetById
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _categoriasService.GetById(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //Post api/categorias
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _categoriasService.Create(categoria);

                if (result != null)
                {
                    ValidationResult validacao = await _validator.ValidateAsync(categoria);

                    if (validacao.IsValid)
                    {
                        await _uow.Commit();
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(validacao.Errors);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var categOld = await _categoriasService.GetById(id);

                ValidationResult validacao = await _validator.ValidateAsync(categoria);

                if (categOld != null)
                {
                    categOld.Nome = categoria.Nome;

                    var result = _categoriasService.Update(categOld);

                    if (result != null && validacao.IsValid)
                    {
                        await _uow.Commit();
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(validacao.Errors);
                    }
                }

                return BadRequest();

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var categOld = await _categoriasService.GetById(id);

                if (categOld != null)
                    _categoriasService.Delete(categOld);

                await _uow.Commit();

                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}
