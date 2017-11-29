﻿namespace LUIS.Programmatic.Tests.Luis
{
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models;
    using System.Linq;
    using Xunit;

    public class VersionsTests: BaseTest
    {
        [Fact]
        public void GetApplicationVersions()
        {
            UseClientFor(async client =>
            {
                var results = await client.Versions.GetApplicationVersionsAsync(appId);

                Assert.True(results.Count > 0);
                foreach (var version in results)
                {
                    Assert.NotNull(version.Version);
                }
            });
        }

        [Fact]
        public void GetApplicationVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.GetApplicationVersionsAsync(appId);
                foreach (var version in versions)
                {
                    var result = await client.Versions.GetApplicationVersionAsync(appId, version.Version);
                    Assert.Equal(version.Version, result.Version);
                    Assert.Equal(version.TrainingStatus, result.TrainingStatus);
                }
            });
        }

        [Fact]
        public void RenameApplicationVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.GetApplicationVersionsAsync(appId);
                var first = versions.FirstOrDefault();
                var versionToUpdate = new TaskUpdateObject
                {
                    Version = "test"
                };

                await client.Versions.RenameApplicationVersionAsync(appId, first.Version, versionToUpdate);
                var versionsWithUpdate = await client.Versions.GetApplicationVersionsAsync(appId);

                Assert.Contains(versionsWithUpdate, v => v.Version.Equals(versionToUpdate.Version));
                Assert.DoesNotContain(versionsWithUpdate, v => v.Version.Equals(first.Version));

                await client.Versions.RenameApplicationVersionAsync(appId, versionToUpdate.Version, new TaskUpdateObject
                {
                    Version = first.Version
                });
            });
        }


        [Fact]
        public void DeleteApplicationVersion()
        {
            UseClientFor(async client =>
            {
                var versions = await client.Versions.GetApplicationVersionsAsync(appId);
                var first = versions.FirstOrDefault();
                var testVersion = new TaskUpdateObject
                {
                    Version = "test"
                };

                await client.Versions.CloneVersionAsync(appId, first.Version, testVersion);

                var versionsWithTest = await client.Versions.GetApplicationVersionsAsync(appId);

                Assert.Contains(versionsWithTest, v => v.Version.Equals(testVersion.Version));

                await client.Versions.DeleteApplicationVersionAsync(appId, testVersion.Version);

                var versionsWithoutTest = await client.Versions.GetApplicationVersionsAsync(appId);

                Assert.DoesNotContain(versionsWithoutTest, v => v.Version.Equals(testVersion.Version));
            });
        }
    }
}
