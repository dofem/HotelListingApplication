﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListing.Application.DataAccess.Data;
using HotelListing.Application.Dto;
using HotelListing.Application.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Application.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<PagedResult<TResult>> GetAlllAsync<TResult>(QueryParams queryParameters)
        {
            
            {
                var totalSize = await _context.Set<T>().CountAsync();
                var items = await _context.Set<T>()
                    .Skip(queryParameters.StartIndex)
                    .Take(queryParameters.PageSize)
                    .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return new PagedResult<TResult>
                {
                    Items = items,
                    PageNumber = queryParameters.PageNumber,
                    RecordNumber = queryParameters.PageSize,
                    TotalCount = totalSize
                };
            }
        }


        public async Task<T> GetAsync(int? id)
        {
            if(id == null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();  
        }
    }
}
