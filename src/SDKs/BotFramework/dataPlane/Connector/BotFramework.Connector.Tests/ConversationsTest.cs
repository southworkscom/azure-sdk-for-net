﻿namespace Connector.Tests
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
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Create Conversation with invalid Bot"
            };

            var param = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = new ChannelAccount() { Id = "invalid-id" },
                Activity = activity
            };

            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.CreateConversationAsync(param));
                Assert.Equal("ServiceError", ex.Body.Error.Code);
                Assert.StartsWith("Invalid userId", ex.Body.Error.Message);
            });
        }

        [Fact]
        public void CreateConversationWithoutMembers()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Create Conversation without members"
            };

            var param = new ConversationParameters()
            {
                Members = new ChannelAccount[] { },
                Bot = Bot,
                Activity = activity
            };

            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.CreateConversationAsync(param));
                Assert.Equal("BadArgument", ex.Body.Error.Code);
                Assert.StartsWith("Conversations", ex.Body.Error.Message);
            });
        }

        [Fact]
        public void CreateConversationWithBotMember()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Create Conversation with Bot member"
            };

            var param = new ConversationParameters()
            {
                Members = new ChannelAccount[] { Bot },
                Bot = Bot,
                Activity = activity
            };

            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.CreateConversationAsync(param));
                Assert.Equal("BadArgument", ex.Body.Error.Code);
            });
        }

        [Fact]
        public void GetConversationMembers()
        {
            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var members = await client.Conversations.GetConversationMembersAsync(conversation.Id);

                var hasUser = false;

                foreach (var member in members)
                {
                    hasUser = member.Id == User.Id;
                    if (hasUser) break;
                }

                Assert.True(hasUser);
            });
        }

        [Fact]
        public void GetConversationMembersWithInvalidConversationId()
        {

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.GetConversationMembersAsync(string.Concat(conversation.Id, "M")));
                Assert.Equal("ServiceError", ex.Body.Error.Code);
                Assert.Contains("The specified channel was not found", ex.Body.Error.Message);
            });
        }

        [Fact]
        public void SendToConversation()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Name  = "acticity",
                Text = "TEST Send to Conversation"
            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot,
                Activity = activity
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var response = await client.Conversations.SendToConversationAsync(conversation.Id, activity);
                Assert.NotNull(response.Id);
            });
            
        }

        [Fact]
        public void SendToConversationWithInvalidConversationId()
        {

            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Name = "acticity",
                Text = "TEST Send to Conversation with invalid conversation id"
            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot,
                Activity = activity
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.SendToConversationAsync(string.Concat(conversation.Id, "M"), activity));
                Assert.Equal("ServiceError", ex.Body.Error.Code);
                Assert.Contains("The specified channel was not found", ex.Body.Error.Message);
            });
        }

        [Fact]
        public void SendToConversationWithInvalidBotId()
        {
            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var activity = new Activity()
                {
                    Type = ActivityType.Message,
                    Recipient = User,
                    FromProperty = new ChannelAccount() { Id = "B21S8SG7K:T03CWQ0QB" },
                    Name = "acticity",
                    Text = "TEST Send to Conversation"
                };
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.SendToConversationAsync(string.Concat(conversation.Id, "M"), activity));
                Assert.Equal("MissingProperty", ex.Body.Error.Code);
                Assert.Equal("The bot referenced by the 'from' field is unrecognized", ex.Body.Error.Message);
            });
        }

        [Fact]
        public void SendCardToConversation()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Name = "acticity",
                Text = "TEST Send Card to Conversation",
                Attachments = new Attachment[]
                {
                    new Attachment()
                    {
                        ContentType = CardContentType.Hero.ToString(),
                        Content = new HeroCard()
                        {
                            Title = "A static image",
                            Subtitle = "JPEG image",
                            Images = new CardImage[] { new CardImage() { Url = "https://docs.microsoft.com/en-us/bot-framework/media/designing-bots/core/dialogs-screens.png" } }
                        }
                    },
                    new Attachment()
                    {
                        ContentType = CardContentType.Hero.ToString(),
                        Content = new HeroCard()
                        {
                            Title = "An animation",
                            Subtitle = "GIF image",
                            Images = new CardImage[] { new CardImage() { Url = "http://i.giphy.com/Ki55RUbOV5njy.gif" } }
                        }
                    },
                }

            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var response = await client.Conversations.SendToConversationAsync(conversation.Id, activity);
                Assert.NotNull(response.Id);
            });
        }

        [Fact]
        public void GetActivityMembers()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Get Activity Members"
            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot,
                Activity = activity
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var members = await client.Conversations.GetActivityMembersAsync(conversation.Id, conversation.ActivityId);

                var hasUser = false;

                foreach (var member in members)
                {
                    hasUser = member.Id == User.Id;
                    if (hasUser) break;
                }

                Assert.True(hasUser);
            });
        }

        [Fact]
        public void GetActivityMembersWithInvalidConversationId()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Get Activity Members with invalid conversation id"
            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot,
                Activity = activity
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.GetActivityMembersAsync(string.Concat(conversation.Id, "M"), conversation.ActivityId));
                Assert.Equal("ServiceError", ex.Body.Error.Code);
                Assert.Contains("The specified channel was not found", ex.Body.Error.Message);
            });
        }

        [Fact]
        public void ReplyToActivity()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Activity gets a reply"
            };

            var reply = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Reply to Activity"
            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var response = await client.Conversations.SendToConversationAsync(conversation.Id, activity);
                var replyResponse = await client.Conversations.ReplyToActivityAsync(conversation.Id, response.Id, reply);

                Assert.NotNull(replyResponse.Id);
            });
        }

        [Fact]
        public void ReplyToActivityWithInvalidConversationId()
        {

            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Reply activity with invalid conversation id"
            };

            var reply = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Reply mustn't shown"
            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var response = await client.Conversations.SendToConversationAsync(conversation.Id, activity);
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.ReplyToActivityAsync(string.Concat(conversation.Id, "M"), response.Id, reply));
                Assert.Equal("ServiceError", ex.Body.Error.Code);
                Assert.Contains("The specified channel was not found", ex.Body.Error.Message);
            });
        }

        [Fact]
        public void DeleteActivity()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Activity to be deleted"
            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot,
                Activity =  activity
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                await client.Conversations.DeleteActivityAsync (conversation.Id, conversation.ActivityId);
                Assert.NotNull(conversation.ActivityId);
            });
        }

        [Fact]
        public void DeleteActivityWithInvalidConversationId()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Activity to be deleted with invalid conversation Id"
            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot,
                Activity = activity
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.DeleteActivityAsync("B21S8SG7K:T03CWQ0QB", conversation.ActivityId));
                Assert.Equal("ServiceError", ex.Body.Error.Code);
                Assert.Contains("Invalid ConversationId", ex.Body.Error.Message);
            });
        }

        [Fact]
        public void UpdateActivity()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Activity to be updated"
            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var response = await client.Conversations.SendToConversationAsync(conversation.Id, activity);
                var update = new Activity()
                {
                    Id = response.Id,
                    Type = ActivityType.Message,
                    Recipient = User,
                    FromProperty = Bot,
                    Text = "TEST Successfully activity updated"
                };
                var updateResponse = await client.Conversations.UpdateActivityAsync(conversation.Id, response.Id, update);
                Assert.NotNull(updateResponse.Id);
            });

        }

        [Fact]
        public void UpdateActivityWithInvalidConversationId()
        {
            var activity = new Activity()
            {
                Type = ActivityType.Message,
                Recipient = User,
                FromProperty = Bot,
                Text = "TEST Activity to be updated with invalid conversation Id"
            };

            var createMessage = new ConversationParameters()
            {
                Members = new ChannelAccount[] { User },
                Bot = Bot
            };

            UseClientFor(async client =>
            {
                var conversation = await client.Conversations.CreateConversationAsync(createMessage);
                var response = await client.Conversations.SendToConversationAsync(conversation.Id, activity);
                var update = new Activity()
                {
                    Id = response.Id,
                    Type = ActivityType.Message,
                    Recipient = User,
                    FromProperty = Bot,
                    Text = "TEST Activity mustn't be updated"
                };
                var ex = await Assert.ThrowsAsync<ErrorResponseException>(() => client.Conversations.UpdateActivityAsync("B21S8SG7K:T03CWQ0QB", response.Id, update));
                Assert.Equal("ServiceError", ex.Body.Error.Code);
                Assert.Contains("Invalid ConversationId", ex.Body.Error.Message);
            });
        }

    }
}
