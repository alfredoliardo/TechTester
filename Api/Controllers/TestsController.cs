using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Core.Entities;
using Data.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public TestsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<Test>>> GetTests()
        {
            return await _context.Tests.ToListAsync();
        }

        [HttpGet("grouped/{id}")]
        public async Task<ActionResult<Object>> GetGroupedTests(Guid id)
        {
            return await _context.TestInstances
            .Include(i => i.Test)
            .Where( i => i.TestId == id)
            .GroupBy(g => new {g.GroupId, g.Workstation.Bank, g.Workstation.OU})
            .Select(s => new {
                Group = s.Key.GroupId,
                Bank = s.Key.Bank,
                OU = s.Key.OU,
                LastUpdateTime = s.Max(w => w.LastUpdateTime),
                Workstations = s.Count(),
                NotStarted = s.Count(w => w.LastUpdateTime == null),
                Running = s.Count(w => w.LastUpdateTime != null && w.Completed == null),
                Completed = s.Count(w => w.Completed != null),
                Damaged = s.Count(w => w.Damaged)
            })
            .ToListAsync();
        }

        [HttpGet("{id}/branch")]
        public async Task<ActionResult<Object>> GetBranchTests(Guid id, string bank, string ou)
        {
            var tests = await _context.TestInstances
            .Where(i => i.TestId == id &&
            (string.IsNullOrEmpty(bank) || i.Workstation.Bank == bank ) &&
            (string.IsNullOrEmpty(ou) || i.Workstation.OU == ou))
            .ToListAsync();

            return Ok(tests);
        }
    }
}