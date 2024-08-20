﻿using Microsoft.EntityFrameworkCore;
using SquadSecurity.Backend.Data;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.Responses;

namespace SquadSecurity.Backend.Repositories.Implementations
{
    public partial class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entity;
        public GenericRepository(DataContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSucceess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionAxtionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }

        }

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    WasSucceess = false,
                    Message = "Registro no encontrado."
                };
            }

            try
            {
                _entity.Remove(row);
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSucceess = true,
                };
            }
            catch
            {
                return new ActionResponse<T>
                {
                    WasSucceess = false,
                    Message = "No se pudo borrar, porque tiene registros relacionados."
                };
            }
        }

        public virtual async Task<ActionResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    WasSucceess = false,
                    Message = "Registro no encontrado."
                };
            }

            return new ActionResponse<T>
            {
                WasSucceess = true,
                Result = row
            };
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
        {
            return new ActionResponse<IEnumerable<T>>
            {
                WasSucceess = true,
                Result = await _entity.ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            _context.Update(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSucceess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionAxtionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }
        }

        private ActionResponse<T> DbUpdateExceptionAxtionResponse()
        {
            return new ActionResponse<T>
            {
                WasSucceess = false,
                Message = "Ya existe el registro que estas intentando crear."
            };
        }
   
        private ActionResponse<T> ExceptionActionResponse(Exception exception)
        {
            return new ActionResponse<T>
            {
                WasSucceess = false,
                Message = exception.Message
            };
        }

 
    }
}
