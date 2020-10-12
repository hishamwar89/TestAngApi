using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ValueController:ControllerBase
    {
        private readonly DataContext _context;
        public ValueController(DataContext context)//Debancy injection
        {
            _context=context;
        }
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetAll()
        {
            var _values =await _context.Values.ToListAsync();
            return Ok(_values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var _values = await _context.Values.FirstOrDefaultAsync(x => x.id == id);
            return Ok(_values);
        }
    }
}