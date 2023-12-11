using AspNetCoreWebApi6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Menu_ItemsController : ControllerBase
    {
        private readonly MenuItemContext _dbContext;

        public Menu_ItemsController(MenuItemContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Menu_Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenu_Items()
        {
            if (_dbContext.Menu_Items == null)
            {
                return NotFound();
            }
            return await _dbContext.Menu_Items.ToListAsync();
        }

        // GET: api/Menu_Items/3
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenu(int id)
        {
            if (_dbContext.Menu_Items == null)
            {
                return NotFound();
            }
            var menu = await _dbContext.Menu_Items.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

        // POST: api/Menu_Items
        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenu(MenuItem menu)
        {
            _dbContext.Menu_Items.Add(menu);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMenu), new { id = menu.Id }, menu);
        }

        // PUT: api/Menu_Items/3
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(int id, MenuItem menu)
        {
            if (id != menu.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(menu).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!menuExists(id))
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

        // DELETE: api/Menu_Items/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            if (_dbContext.Menu_Items == null)
            {
                return NotFound();
            }

            var menu = await _dbContext.Menu_Items.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _dbContext.Menu_Items.Remove(menu);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool menuExists(long id)
        {
            return (_dbContext.Menu_Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
