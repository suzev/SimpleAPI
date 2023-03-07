using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Data;
using SimpleAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private ApplicationDbContext _context;

        public MembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET : api/MemberInfoes
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> MemberInfo()
        {
            if (_context.Members == null)
            {
                return NotFound();
            }

            var results = await _context.Members.Include(x=>x.Hobbies).ToListAsync();
            return results;
        }

        //GET : api/MemberInfoes/2
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> Get(int id)
        {
            var memberInfo= await _context.Members.FindAsync(id);

            if(memberInfo == null)
            {
                return NotFound();
            }

            return memberInfo;
        }

        [HttpPost]
        public async Task<ActionResult<Member>> PostMember([FromBody]Member member)
        {
            if (await _context.Members.AnyAsync(u => u.Email == member.Email))
            {
                ModelState.AddModelError(nameof(member.Email), "Email already exists");
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            var members = await _context.Members.FindAsync(id);
            if(members == null)
            {
                return NotFound();
            }

            _context.Members.Remove(members);
            await _context.SaveChangesAsync();

            return Ok($"Data user {id} berhasil dihapus");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Member>> UpdateMember(int id, [FromBody] Member member)
        {
            var members = await _context.Members.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }
            members.Name = member.Name;
            members.Email = member.Email;
            members.Phone = member.Phone;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
