using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEP3_Tier1.Data;
using SEP3_Tier1.Models;

namespace Tier2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyController : ControllerBase
    {
        private ISaleService _service;
        public DummyController(ISaleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<string>>> GetSaleAsync([FromQuery] string title)
        {
            try
            {
                IList<string> bookSales = await _service.GetSaleAsync();
                return Ok(bookSales);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
    }
}