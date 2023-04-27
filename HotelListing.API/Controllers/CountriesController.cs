using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Query;
using HotelListing.Application.Interface;
using HotelListing.Application.Dto.Country;
using HotelListing.Application.Dto;
using HotelListing.Application.Exception;
using HotelListing.Domain.Model;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countriesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CountriesController> _logger;

        public CountriesController(ICountryRepository countryRepository, IMapper mapper, ILogger<CountriesController> logger)
        {
            _countriesRepository = countryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Countries
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(records);
        }


        // GET: api/Countries
        [HttpGet]
        [Route("GetPagedCountries")]
        public async Task<ActionResult<PagedResult<GetCountryDto>>> GetPagedCountries([FromQuery] QueryParams queryParams)
        {
            var pagedCountriesResult = await _countriesRepository.GetAlllAsync<GetCountryDto>(queryParams);
            return Ok(pagedCountriesResult);
        }




        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);
           
            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountry), id);
            }
            var record = _mapper.Map<CountryDto>(country); 
            return Ok(record);
        }



        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            //_context.Entry(country).State = EntityState.Modified;

            var country = await _countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountryDto, country);

            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }




        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
        {
            var country = _mapper.Map<Country>(createCountry);
            await _countriesRepository.AddAsync(country); 
            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }




        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(DeleteCountry), id);
            }
            await _countriesRepository.DeleteAsync(id);
            return NoContent();
        }



        private async Task<bool> CountryExists(int id)
        {
            return ( await _countriesRepository.Exists(id));
        }
    }
}
