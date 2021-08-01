using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;

namespace Data.EFCore.Seed.Baudelaire
{
    public class BaudelaireSeeder
    {
        public async static Task SeedAsync(ApplicationContext context)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            //test
            var json = File.ReadAllText("../Data/EFCore/Seed/Baudelaire/tests.json");
            var test = JsonSerializer.Deserialize<Test>(json, options);
            if (context.Tests.Find(test.Id) == null)
            {
                context.Tests.Add(test);
                await context.SaveChangesAsync();
            }

            //test checks
            json = File.ReadAllText("../Data/EFCore/Seed/Baudelaire/test_checks.json");
            var testChecks = JsonSerializer.Deserialize<List<TestCheck>>(json, options);
            if (!context.TestChecks.Any(t => t.TestId == test.Id))
            {
                context.TestChecks.AddRange(testChecks);
                await context.SaveChangesAsync();
            }

            //test instances
            json = File.ReadAllText("../Data/EFCore/Seed/Baudelaire/test_instances.json");
            var testInstances = JsonSerializer.Deserialize<List<TestInstance>>(json, options);
            if (!context.TestInstances.Any(t => t.TestId == test.Id))
            {
                foreach (var item in testInstances)
                {
                    item.StartTime = item.LastUpdateTime;
                    context.Add(item);
                }
                context.TestInstances.AddRange(testInstances);
                await context.SaveChangesAsync();
            }


            //responses
            json = File.ReadAllText("../Data/EFCore/Seed/Baudelaire/responses.json");
            var responses = JsonSerializer.Deserialize<List<TestCheckResponse>>(json, options);
            if (!context.TestCheckResponses.Any(t => t.TestId == test.Id))
            {
                foreach (var r in responses)
                {
                    if(r.Value.HasValue && r.Value.Value == ResponseValue.Negative){
                        var instance = context.TestInstances.Find(r.TestId, r.WorkstationName);
                        if(instance != null){
                            instance.NegativeResponses++;
                        }
                    }
                    context.TestCheckResponses.Add(r);
                }
                await context.SaveChangesAsync();
            }

        }
    }
}