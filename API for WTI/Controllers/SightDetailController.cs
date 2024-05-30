using API_for_WTI.Data;
using API_for_WTI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_for_WTI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightDetailController : ControllerBase
    {
        private readonly SightingDetailContext _dbContext;

        public SightDetailController(SightingDetailContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SightingDetail>>> GetSightDetails()
        {
            if (_dbContext.SightingDetails == null)
            {
                return NotFound();
            }
             var sightdetails = await _dbContext.SightingDetails.ToListAsync();
             return Ok(sightdetails);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<SightingDetail>> GetSightDetail(int id)
        {
            if (_dbContext.SightingDetails == null)
            {
                return NotFound();
            }
            var sightdetail = await _dbContext.SightingDetails.FindAsync(id);

            if (sightdetail == null)
            {
                return NotFound("Sight Detail not found");
            }
            return sightdetail;
        }



        [HttpPost]
        public async Task<ActionResult<List<SightingDetail>>> AddSightingDetail(SightingDetail sightdetail)
        {
            _dbContext.SightingDetails.Add(sightdetail);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.SightingDetails.ToListAsync());
         
        }

        [HttpPut]
        public async Task<ActionResult<List<SightingDetail>>> UpdateSightingDetail(SightingDetail updatedSightDetail)
        {
            var dbsighdetail = await _dbContext.SightingDetails.FindAsync(updatedSightDetail.Id);

            if (dbsighdetail is null)
                return NotFound("Sight details not found.");

            dbsighdetail.Name = updatedSightDetail.Name;
            dbsighdetail.ShortName = updatedSightDetail.ShortName;
            dbsighdetail.AirlineCode = updatedSightDetail.AirlineCode;
            dbsighdetail.Location = updatedSightDetail.Location;


            dbsighdetail.CreatedDate = updatedSightDetail.CreatedDate;
            dbsighdetail.Active = updatedSightDetail.Active;
            dbsighdetail.Delete = updatedSightDetail.Delete;
            dbsighdetail.CreatedUserId = updatedSightDetail.CreatedUserId;
            dbsighdetail.ModifiedUserId = updatedSightDetail.ModifiedUserId;
            dbsighdetail.PhotoPath = updatedSightDetail.PhotoPath;

             
             await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.SightingDetails.ToListAsync());
        }



        [HttpDelete]
        public async Task<ActionResult<List<SightingDetail>>> DeleteSightingDetail(int  id)
        {
            var dbsighdetail = await _dbContext.SightingDetails.FindAsync(id);

            if (dbsighdetail is null)
                return NotFound("Sight details not found.");

            _dbContext.SightingDetails.Remove(dbsighdetail);

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.SightingDetails.ToListAsync());
        }



    }
}
