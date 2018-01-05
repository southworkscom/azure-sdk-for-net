namespace Connector.Tests
{
    using System.IO;
    using Microsoft.Azure.BotFramework.Connector;
    using Microsoft.Azure.BotFramework.Connector.Models;
    using Microsoft.Rest;
    using Xunit;

    public class AttachmentsTests : BaseTest
    {
        protected const string conversationId = "B21UTEF8S:T03CWQ0QB:D2369CT7C";

        [Fact]
        public void UploadAttachmentAndGetAttachment()
        {

            UseClientFor(async client =>
            {
                var attachment = new AttachmentData("image/png", ReadFile("bot.png"), "Bot.png", ReadFile("bot_icon.png"));
                var response = await client.Conversations.UploadAttachmentAsync(conversationId, attachment);
                var attachmentId = response.Id;
                var attachmentInfo = await client.Attachments.GetAttachmentInfoAsync(attachmentId);

                Assert.NotNull(attachmentInfo);
                Assert.Equal("Bot.png", attachmentInfo.Name);
                Assert.Equal("image/png", attachmentInfo.Type);
                Assert.Equal(2, attachmentInfo.Views.Count);
            });
        }

        [Fact]
        public void UploadAttachmentWithoutOriginalFails()
        {
            UseClientFor(async client =>
            {
                var attachment = new AttachmentData()
                {
                    Name = "Bot.png",
                    Type = "image/png"
                };

                var ex = await Assert.ThrowsAsync<ValidationException>(() => client.Conversations.UploadAttachmentAsync(conversationId, attachment));
                Assert.Contains("OriginalBase64", ex.Message);
            });
        }

        [Fact]
        public void UploadAttachmentWithoutTypeFails()
        {
            UseClientFor(async client =>
            {
                var attachment = new AttachmentData()
                {
                    Name = "Bot.png",
                    OriginalBase64 = ReadFile("Bot.png")
                };

                var ex = await Assert.ThrowsAsync<ValidationException>(() => client.Conversations.UploadAttachmentAsync(conversationId, attachment));
                Assert.Contains("Type", ex.Message);
            });
        }

        [Fact]
        public void GetAttachmentInfoWithInvalidIdFails()
        {
            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Attachments.GetAttachmentInfoAsync("bt13796-GJS4yaxDLI"));
                Assert.Contains("NotFound", ex.Message);
            });
        }

        ////[Fact]
        ////public void GetAttachmentView()
        ////{

        ////    UseClientFor(async client =>
        ////    {
        ////        var attachment = new AttachmentData("image/png", ReadFile("bot.png"), "Bot.png", ReadFile("bot_icon.png"));
        ////        var response = await client.Conversations.UploadAttachmentAsync(conversationId, attachment);
        ////        var attachmentId = response.Id;
        ////        var stream = await client.Attachments.GetAttachmentAsync(attachmentId, "original");
        ////        using (var ms = new MemoryStream())
        ////        {
        ////            stream.CopyTo(ms);
        ////            Assert.Equal(attachment.OriginalBase64.Length, ms.ToArray().Length);
        ////        }
        ////    });
        ////}

        private byte[] ReadFile(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "resources", fileName);
            return File.ReadAllBytes(path);
        }
    }
}
