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
    public class LancamentosController : Controller
    {
        //Injeção Lancamento service
        private readonly ILancamentoService _lancamentoService;

        //Injeção Validator
        private readonly IValidator<Lancamento> _validator;

        //Injeção UnitOfWork
        private readonly IUoW _uow;

        public LancamentosController(ILancamentoService lancamentoService, IValidator<Lancamento> validator, IUoW uow)
        {
            _lancamentoService = lancamentoService;
            _validator = validator;
            _uow = uow;
        }


        //GetAll:  v1/api/lancamentos/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                return Ok(await _lancamentoService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //GetById: v1/api/lancamentos/{id}
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                return Ok(await _lancamentoService.GetById(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //Post: v1/api/lancamentos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Lancamento lancamento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _lancamentoService.Create(lancamento);

                if (result != null)
                {
                    ValidationResult validacao = await _validator.ValidateAsync(lancamento);

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


        //Put: v1/api/lancamentos/{id} 
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Lancamento lancamento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var lancamentoOld = await _lancamentoService.GetById(id);

                ValidationResult validacao = await _validator.ValidateAsync(lancamento);

                if (lancamentoOld != null)
                {
                    lancamentoOld.Local = lancamento.Local;
                    lancamentoOld.Data = lancamento.Data;
                    lancamentoOld.Descricao = lancamento.Descricao;
                    lancamentoOld.Valor = lancamento.Valor;

                    var result = _lancamentoService.Update(lancamentoOld);

                    if (result != null)
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

        //HttpDelete: v1/api/lancamentos/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var lancamentoOld = await _lancamentoService.GetById(id);
                if (lancamentoOld != null)
                    _lancamentoService.Delete(lancamentoOld);

                await _uow.Commit();

                return Ok();

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message); ;
            }
        }
    }
}
