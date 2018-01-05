namespace Connector.Tests
{
    using System.Threading.Tasks;
    using Microsoft.Azure.BotFramework.Connector;
    using Microsoft.Azure.BotFramework.Connector.Models;
    using Xunit;

    public class ConversationsTest : BaseTest
    {
        [Fact]
        public void CreateConversation()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Create Conversation"
            };

            var param = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot,
                Activity = activity
            };

            UseClientFor(async client =>
            {
                var result = await client.Conversations.CreateConversationAsync(param);
                Assert.NotNull(result.ActivityId);
            });
        }

        [Fact]
        public void CreateConversationWithInvalidBot()
        {
            var invalidBot = new ChannelAccount() { Id = "invalid-id" }; ;

            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Create Conversation"
            };

            var param = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = invalidBot,
                Activity = activity
            };

            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.CreateConversationAsync(param));
                Assert.Equal("ServiceError", ex.Body.Error.Code);
                Assert.StartsWith("Invalid userId", ex.Body.Error.Message);
            });
        }
    }
}
