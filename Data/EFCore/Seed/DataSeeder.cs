using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Data.EFCore;

namespace Data.EFCore.Seed
{
    public class DataSeeder
    {
        public async static Task SeedAsync(ApplicationContext context)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            //tests
            var json = File.ReadAllText("../Data/EFCore/Seed/tests.json");
            var tests = JsonSerializer.Deserialize<List<Test>>(json, options);
            if (!context.Tests.Any())
            {
                context.Tests.AddRange(tests);
                await context.SaveChangesAsync();
            }

            //checks
            json = File.ReadAllText("../Data/EFCore/Seed/checks.json");
            var checks = JsonSerializer.Deserialize<List<Check>>(json, options);
            if (!context.Checks.Any())
            {
                context.Checks.AddRange(checks);
                await context.SaveChangesAsync();
            }

            //testchecks
            var rand = new Random((int)DateTime.Now.Ticks);
            if (!context.TestChecks.Any())
            {

                foreach (var test in tests)
                {
                    var totalChecks = rand.Next(1, checks.Count());
                    for (int i = 1; i <= totalChecks; i++)
                    {
                        context.TestChecks.Add(new TestCheck
                        {
                            TestId = test.Id,
                            CheckId = i,
                            DisplayOrder = rand.Next(1, totalChecks)
                        });
                    }
                    await context.SaveChangesAsync();
                }
            }

            //groups
            json = File.ReadAllText("../Data/EFCore/Seed/groups.json");
            var groups = JsonSerializer.Deserialize<List<Group>>(json, options);
            if (!context.Groups.Any())
            {
                context.Groups.AddRange(groups);
                await context.SaveChangesAsync();
            }

            //branches
            json = File.ReadAllText("../Data/EFCore/Seed/branches.json");
            var branches = JsonSerializer.Deserialize<List<Branch>>(json, options);
            if (!context.Branches.Any())
            {
                context.Branches.AddRange(branches);
                await context.SaveChangesAsync();
            }


            //workstations
            json = File.ReadAllText("../Data/EFCore/Seed/workstations.json");
            var workstations = JsonSerializer.Deserialize<List<Workstation>>(json, options);
            if (!context.Workstations.Any())
            {
                context.Workstations.AddRange(workstations);
                await context.SaveChangesAsync();
            }


            //test instances
            if (!context.TestInstances.Any())
            {
                foreach (var test in tests)
                {
                    foreach (var workstation in workstations)
                    {
                        var testInstance = new TestInstance
                        {
                            TestId = test.Id,
                            WorkstationName = workstation.Name,
                            GroupId = rand.Next(1, groups.Count)
                        };

                        var testChecks = context.TestChecks.Where(tc => tc.TestId == test.Id).ToArray();

                        foreach (var testCheck in testChecks)
                        {
                            ResponseValue? value = null;
                            var probability = rand.NextDouble();
                            if (probability <= 0.70)
                                value = ResponseValue.Positive;
                            else if (probability <= 0.75)
                                value = ResponseValue.Negative;
                            else
                                value = null;


                            context.TestCheckResponses.Add(new TestCheckResponse
                            {
                                TestId = test.Id,
                                WorkstationName = workstation.Name,
                                CheckId = testCheck.CheckId,
                                Value = value
                            });
                        }

                        context.Add(testInstance);
                    }
                }
                await context.SaveChangesAsync();
            }

        }
    }
}