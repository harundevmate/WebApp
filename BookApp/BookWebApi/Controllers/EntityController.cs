using ApiBusiness.Interfaces;
using BookWebApi.Constanta;
using BookWebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BookWebApi.Controllers
{
    [Authorize]
    public abstract class EntityController<TEntity, TRepository> : ControllerBase where TEntity : class, IEntity where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;
        public EntityController(TRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<IEntity>>> GetAllAsync()
        {
            try
            {
                List<TEntity> records = await this._repository.GetAllAsync();
                if (records == null || records.Count == 0)
                {
                    return Ok(new ListResponse<IEntity>()
                    {
                        HttpStatusCode = (int)HttpStatusCode.NotFound,
                        Message = CsMessage.Response.NotFound
                    });
                }
                else
                {
                    return Ok(new ListResponse<IEntity>()
                    {
                        Data = records,
                        HttpStatusCode = (int)HttpStatusCode.OK,
                        Message = CsMessage.Response.NotFound
                    });
                }
            }
            catch (System.Exception e)
            {
                return Ok(new ResponseSingle<IEntity>()
                {
                    HttpStatusCode = (int)HttpStatusCode.InternalServerError,
                    Errors = new[] { e.Message }
                });
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<List<IEntity>>> GetByIdAsync(string id)
        {
            try
            {
                var record = await this._repository.GetByIdAsync(id);
                if (record == null)
                {
                    return Ok(new ResponseSingle<IEntity>()
                    {
                        HttpStatusCode = (int)HttpStatusCode.NotFound,
                        Message = CsMessage.Response.NotFound
                    });
                }
                else
                {
                    return Ok(new ResponseSingle<IEntity>()
                    {
                        HttpStatusCode = (int)HttpStatusCode.OK,
                        Message = CsMessage.Response.Success
                    });
                }
            }
            catch (System.Exception e)
            {
                return Ok(new ResponseSingle<IEntity>()
                {
                    HttpStatusCode = (int)HttpStatusCode.InternalServerError,
                    Errors = new[] { e.Message }
                });
            }
        }


        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<IEntity>> DeleteAsync(string id)
        {
            try
            {
                var record = await this._repository.DeleteAsync(id);
                if (record == null)
                {
                    return Ok(new ResponseSingle<IEntity>()
                    {
                        HttpStatusCode = (int)HttpStatusCode.NotFound,
                        Message = CsMessage.Response.NotFound
                    });
                }
                else
                {
                    return Ok(new ResponseSingle<IEntity>()
                    {
                        HttpStatusCode = (int)HttpStatusCode.OK,
                        Message = CsMessage.Response.Success
                    });
                }
            }
            catch (System.Exception e)
            {
                return Ok(new ResponseSingle<IEntity>()
                {
                    HttpStatusCode = (int)HttpStatusCode.InternalServerError,
                    Errors = new[] { e.Message }
                });
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<IEntity>> UpdateAsync(string id,[FromBody]TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    return Ok(new ResponseSingle<IEntity>()
                    {
                        HttpStatusCode = (int)HttpStatusCode.NotFound,
                        Message = CsMessage.Response.NotFound
                    });
                }

                //Check available data
                var record = await this._repository.GetByIdAsNoTrackingAsync(id);
                if (record == null)
                {
                    return Ok(new ResponseSingle<IEntity>()
                    {
                        HttpStatusCode = (int)HttpStatusCode.NotFound,
                        Message = CsMessage.Response.NotFound
                    });
                }
                else
                {
                    //do update
                    return Ok(new ResponseSingle<IEntity>()
                    {
                        HttpStatusCode = (int)HttpStatusCode.OK,
                        Message = CsMessage.Response.Success
                    });
                }
            }
            catch (System.Exception e)
            {
                return Ok(new ResponseSingle<IEntity>()
                {
                    HttpStatusCode = (int)HttpStatusCode.InternalServerError,
                    Errors = new[] { e.Message }
                });
            }
        }
    }
}
