using EzPay.ServiceProvider.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceProvider.Infrastructure;

namespace ServiceProvider.Api.Controllers
{
    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class ServiceProvidersController : ControllerBase
    {
        private readonly EzJobContext _dbContext;

        public ServiceProvidersController(EzJobContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]     
        public async Task<IActionResult> Get(int id)
        {
            var serviceProvider = await _dbContext.ServiceProviders
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();


            if(serviceProvider is null)
            {
                return NotFound();
            }

            return Ok(serviceProvider);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceProviderProfile serviceProvider)
        {
            await _dbContext.ServiceProviders.AddAsync(serviceProvider);
            await _dbContext.SaveChangesAsync();

            return Ok(serviceProvider);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ServiceProviderProfile serviceProvider)
        {
            var oldServiceProvider = await _dbContext.ServiceProviders
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();

            if (oldServiceProvider is null)
            {
                return NotFound();
            }

            oldServiceProvider.Street = serviceProvider.Street;
            oldServiceProvider.City = serviceProvider.City;
            oldServiceProvider.BRN = serviceProvider.BRN;
            oldServiceProvider.Province = serviceProvider.Province;
            await _dbContext.SaveChangesAsync();

            return Ok(serviceProvider);
        }  
    }
}
