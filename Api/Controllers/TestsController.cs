using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using Data.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<TestsController> _logger;
        private readonly IDatabase _db;
        public TestsController(ApplicationContext context, ILogger<TestsController> logger, IDatabase db)
        {
            _db = db;
            _logger = logger;
            _context = context;
        }

        [HttpGet()]
        public ActionResult<IReadOnlyList<Dtos.Test>> GetTests()
        {
            var spec = new TestsWithChecksAndInstances();
            var tests = _db.Repository<Core.Entities.Test>().Find(spec); 
            return Ok(tests.Select(test => new Dtos.Test
            {
                Id = test.Id,
                Name = test.Name,
                Description = test.Description,
                StartDate = test.StartDate,
                ExpirationDate = test.ExpirationDate,
                Checks = test.TestChecks.Select(check => new Dtos.Check
                {
                    Id = check.Check.Id,
                    Name = check.Check.Name,
                    Help = check.Check.Help,
                    HasNeutralOption = check.Check.HasNotRelevantOption,
                    DisplayOrder = check.DisplayOrder
                }),
                Instances = test.Instances.Select(instance => new Dtos.TestInstance
                {
                    WorkstationName = instance.WorkstationName,
                    StartTime = instance.StartTime,
                    LastUpdateTime = instance.LastUpdateTime,
                    Completed = instance.Completed,
                    Damaged = instance.Damaged
                })
            }));

        }

        [HttpGet("for/{workstationName}")]
        public async Task<ActionResult<IReadOnlyList<Api.Dtos.TestInstance>>> GetWorkstationTests(string workstationName)
        {
            return await _context.TestInstances
            .Where(i => i.WorkstationName == workstationName)
            .Select(i => new Dtos.TestInstance
            {
                TestId = i.TestId,
                TestName = i.Test.Name,
                Name = i.WorkstationName,
                TestStartDate = i.Test.StartDate,
                TestExpirationDate = i.Test.ExpirationDate,
                StartTime = i.StartTime,
                LastUpdateTime = i.LastUpdateTime,
                Completed = i.Completed,
                Damaged = i.Damaged
            })
            .ToListAsync();
        }

        [HttpGet("{testId}/of/{workstationName}")]
        public async Task<ActionResult<Dtos.TestInstance>> GetWorkstationTest(Guid testId, string workstationName)
        {
            return await _context.TestInstances
            .Where(i => i.TestId == testId && i.WorkstationName == workstationName)
            .Select(i => new Dtos.TestInstance
            {
                TestName = i.Test.Name,
                Name = i.WorkstationName,
                TestStartDate = i.Test.StartDate,
                TestExpirationDate = i.Test.ExpirationDate,
                StartTime = i.StartTime,
                LastUpdateTime = i.LastUpdateTime,
                Completed = i.Completed,
                Damaged = i.Damaged,
                TestId = i.TestId,
                Checks = i.Responses.Select(r => new
                {
                    CheckId = r.TestCheck.CheckId,
                    CheckName = r.TestCheck.Check.Name,
                    CheckHelp = r.TestCheck.Check.Help,
                    Value = r.Value,
                    HasNeutralOption = r.TestCheck.Check.HasNotRelevantOption
                }).ToList()
            })
            .FirstOrDefaultAsync();
        }

        [HttpGet("grouped/{id}")]
        public async Task<ActionResult<IEnumerable<BranchTestStats>>> GetGroupedTests(Guid id)
        {   
            var query = _context.TestInstances
            .AsNoTracking()
            .Include(i => i.Responses)
            .Where(i => i.TestId == id)
            .GroupBy(g => new { g.Group.Name, g.Workstation.Bank, g.Workstation.OU, g.Workstation.Branch.Info });

            var grouped = query.Select(s => new BranchTestStats
            {
                GroupName = s.Key.Name,
                Bank = s.Key.Bank,
                OU = s.Key.OU,
                Info = s.Key.Info,
                Status = (s.Max(w => w.LastUpdateTime != null)
                ? BranchTestStatsStatus.Running
                : s.Count() == (s.Count(w => w.Completed.HasValue) - s.Count(w => w.Damaged))
                ? BranchTestStatsStatus.Completed
                : BranchTestStatsStatus.NotStarted),
                LastUpdateTime = s.Max(w => w.LastUpdateTime),
                Workstations = s.Count(),
                NotStarted = s.Count(w => w.LastUpdateTime == null),
                Running = s.Count(w => w.LastUpdateTime != null && w.Completed == null),
                Completed = s.Count(w => w.Completed != null),
                Damaged = s.Count(w => w.Damaged),
                WithNegativeResponses = s.Count(w => w.NegativeResponses > 0)
            });

            

            return Ok(await grouped.ToListAsync());
        }

        [HttpGet("{id}/branch")]
        public async Task<ActionResult<Object>> GetBranchTests(Guid id, string bank, string ou)
        {
            var tests = await _context.TestInstances
            .Where(i => i.TestId == id &&
            (string.IsNullOrEmpty(bank) || i.Workstation.Bank == bank) &&
            (string.IsNullOrEmpty(ou) || i.Workstation.OU == ou))
            .ToListAsync();

            return Ok(tests);
        }
    }
}