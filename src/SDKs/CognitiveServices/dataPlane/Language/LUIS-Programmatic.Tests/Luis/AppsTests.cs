﻿namespace LUIS.Programmatic.Tests.Luis
{
    using System;
    using System.Globalization;
    using System.IO;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using Xunit;

    public class AppsTests : BaseTest
    {
        [Fact]
        public void GetApplicationsList()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetApplicationsListAsync();

                Assert.Equal(12, result.Count);
                foreach (var app in result)
                {
                    Assert.True(Guid.TryParse(app.Id, out Guid id));
                }
            });
        }

        [Fact]
        public void AddApplication()
        {
            UseClientFor(async client =>
            {
                var appId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject
                {
                    Name = "New LUIS App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                Assert.True(Guid.TryParse(appId, out Guid appGuid));
                Assert.Equal(new Guid("9e6703ec-56fe-48ce-8a72-10d592f6056d"), appGuid);
            });
        }

        [Fact]
        public void GetApplicationInfo()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetApplicationInfoAsync(appId);
                Assert.Equal(appId, result.Id);
            });
        }

        [Fact]
        public void RenameApplication()
        {
            UseClientFor(async client =>
            {
                await client.Apps.RenameApplicationAsync(appId, new ApplicationUpdateObject
                {
                    Name = "LUIS App name updated",
                    Description = "LUIS App description updated"
                });

                var app = await client.Apps.GetApplicationInfoAsync(appId);

                Assert.Equal("LUIS App name updated", app.Name);
                Assert.Equal("LUIS App description updated", app.Description);
            });
        }

        [Fact]
        public void DeleteApplication()
        {
            UseClientFor(async client =>
            {
                // Setup - Add app
                var appId = await client.Apps.AddApplicationAsync(new ApplicationCreateObject
                {
                    Name = "New LUIS App (DeleteTest)",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                // Test - Remove app
                await client.Apps.DeleteApplicationAsync(appId);

                // Assert
                var result = await client.Apps.GetApplicationsListAsync();
                Assert.DoesNotContain(result, o => o.Id == appId);
            });
        }

        [Fact]
        public void GetApplicationEndpoints()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetEndpointsAsync(appId);

                Assert.Equal("https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/86226c53-b7a6-416f-876b-226b2b5ab07b", result.Westus);
                Assert.Equal("https://eastus2.api.cognitive.microsoft.com/luis/v2.0/apps/86226c53-b7a6-416f-876b-226b2b5ab07b", result.Eastus2);
                Assert.Equal("https://westcentralus.api.cognitive.microsoft.com/luis/v2.0/apps/86226c53-b7a6-416f-876b-226b2b5ab07b", result.Westcentralus);
                Assert.Equal("https://southeastasia.api.cognitive.microsoft.com/luis/v2.0/apps/86226c53-b7a6-416f-876b-226b2b5ab07b", result.Southeastasia);
            });
        }

        [Fact]
        public void GetApplicationDomains()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetApplicationDomainsAsync();
                foreach (var domain in result)
                {
                    Assert.False(string.IsNullOrWhiteSpace(domain));
                }
            });
        }

        [Fact]
        public void GetApplicationCultures()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetApplicationCulturesAsync();
                foreach (var culture in result)
                {
                    var cult = new CultureInfo(culture.Code);
                    Assert.Equal(cult.Name.ToLowerInvariant(), culture.Code);
                }
            });
        }

        [Fact]
        public void GetApplicationUsageScenarios()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetApplicationUsageScenariosAsync();
                foreach (var scenario in result)
                {
                    Assert.False(string.IsNullOrWhiteSpace(scenario));
                }
            });
        }

        [Fact]
        public void PublishApplication()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.PublishApplicationAsync(appId, new ApplicationPublishObject
                {
                    IsStaging = false,
                    Region = AzureRegions.Westus.ToString().ToLowerInvariant(),
                    VersionId = "0.1"
                });

                Assert.Equal("https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/86226c53-b7a6-416f-876b-226b2b5ab07b", result.EndpointUrl);
                Assert.Equal("westus", result.EndpointRegion);
                Assert.False(result.IsStaging);
            });
        }

        [Fact]
        public void DownloadApplicationQueryLogs()
        {
            UseClientFor(async client =>
            {
                var downloadStream = await client.Apps.DownloadApplicationQueryLogsAsync(appId);
                var reader = new StreamReader(downloadStream);

                var csv = reader.ReadToEnd();
                Assert.False(string.IsNullOrEmpty(csv));
            });
        }

        [Fact]
        public void GetApplicationSettings()
        {
            UseClientFor(async client =>
            {
                var settings = await client.Apps.GetApplicationSettingsAsync(appId);

                Assert.Equal(appId, settings.Id);
                Assert.False(settings.PublicProperty);
            });
        }

        [Fact]
        public void UpdateApplicationSettings()
        {
            UseClientFor(async client =>
            {
                await client.Apps.UpdateApplicationSettingsAsync(appId, new ApplicationSettingUpdateObject
                {
                    PublicProperty = false
                });

                // Assert
                var settings = await client.Apps.GetApplicationSettingsAsync(appId);
                Assert.False(settings.PublicProperty);
            });
        }

        [Fact]
        public void GetAvailableCustomPrebuiltDomains()
        {
            UseClientFor(async client =>
            {
                var result = await client.Apps.GetAvailableCustomPrebuiltDomainsAsync();
                foreach (var prebuiltDomain in result)
                {
                    Assert.NotNull(prebuiltDomain);
                    Assert.False(string.IsNullOrWhiteSpace(prebuiltDomain.Description));
                    Assert.NotNull(prebuiltDomain.Intents);
                    Assert.NotNull(prebuiltDomain.Entities);
                }
            });
        }

        [Fact]
        public void GetAvailableCustomPrebuiltDomainsForCulture()
        {
            UseClientFor(async client =>
            {
                var resultsUS = await client.Apps.GetAvailableCustomPrebuiltDomainsForCultureAsync("en-US");
                var resultsCN = await client.Apps.GetAvailableCustomPrebuiltDomainsForCultureAsync("zh-CN");

                foreach (var resultUS in resultsUS)
                {
                    Assert.DoesNotContain(resultsCN, r => r.Description == resultUS.Description);
                }
                foreach (var resultCN in resultsCN)
                {
                    Assert.DoesNotContain(resultsUS, r => r.Description == resultCN.Description);
                }
            });
        }

        [Fact]
        public void AddCustomPrebuiltApplication()
        {
            UseClientFor(async client =>
            {
                var domain = new PrebuiltDomainCreateObject
                {
                    Culture = "en-US",
                    DomainName = "Calendar"
                };
                var result = await client.Apps.AddCustomPrebuiltApplicationAsync(domain);

                Assert.True(Guid.TryParse(result, out Guid appGuid));
                Assert.Equal(new Guid("5be09431-8360-4bba-b969-a33aa6093b5d"), appGuid);
            });
        }
    }
}
