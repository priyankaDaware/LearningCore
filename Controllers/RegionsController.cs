using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NZWalks.API.Models.Domain;
using NZWalksAPI.Data;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NzwalkDbContext dbContext;

        public RegionsController(NzwalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetRegions()
        {
            // implementation
            var regions = dbContext.Regions.ToList();
            return Ok(regions);
        }

        [HttpPost]
        public IActionResult PostRegions()
        {
            var region = dbContext.Regions.FirstOrDefault();
            
            List<Region> re = new List<Region>();
           
            if (region == null)
            {
                re.Add(
                new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "AKL",
                    Name = "Auckland Region"
                });
                re.Add(new Region
                {
                    Id = Guid.NewGuid(),
                    Code = "MSL",
                    Name = "Saint claire Region"
                });

                dbContext.Regions.AddRange(re);
                dbContext.SaveChanges();
            }
            return Ok(region);
        }

        [HttpDelete]
        public IActionResult DeleteRegion()
        {
            var region = dbContext.Regions.Where(x=>x.Code == "AKL").FirstOrDefault();
            if(region != null)
            {
                dbContext.Regions.Remove(region);
            }
            /////dbContext.Regions.Add(region);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRegion()
        {
            var region = dbContext.Regions.Where(x => x.Code == "MSL").FirstOrDefault();
            if (region != null)
            {
                region.Name = "Saint claire Region Center";
                region.Area = 100.2;
            }
            /////dbContext.Regions.Add(region);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}

