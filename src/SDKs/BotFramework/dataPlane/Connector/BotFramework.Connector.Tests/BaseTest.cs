﻿namespace Connector.Tests
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.BotFramework.Connector;
    using Microsoft.Azure.BotFramework.Connector.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class BaseTest
    {
        private const HttpRecorderMode mode = HttpRecorderMode.Playback;

        protected const string clientId = "[MSAPP_ID]";
        protected const string clientSecret = "[MSAPP_PASSWORD]";
        protected const string userId = "U8H8E2HSB:T03CWQ0QB";
        protected const string botId = "B21S8SG7J:T03CWQ0QB";
        protected static Uri hostUri = new Uri("https://slack.botframework.com", UriKind.Absolute);

        private readonly string token;

        public ChannelAccount Bot { get; private set; }

        public ChannelAccount User { get; private set; }

        private string ClassName => GetType().FullName;


        public BaseTest()
        {
            if (mode == HttpRecorderMode.Record)
            {
                var credentials = new MicrosoftAppCredentials(clientId, clientSecret);
                var task = credentials.GetTokenAsync();
                task.Wait();
                this.token = task.Result;
            }
            else
            {
                this.token = "STUB_TOKEN";
            }

            Bot = new ChannelAccount() { Id = botId };
            User = new ChannelAccount() { Id = userId };
        }

        public async void UseClientFor(Func<IBotConnector, Task> doTest, string className = null, [CallerMemberName] string methodName = "")
        {
            using (MockContext context = MockContext.Start(className ?? ClassName, methodName))
            {
                HttpMockServer.Initialize(className ?? ClassName, methodName, mode);

                using (var client = new BotConnector(hostUri, new BotAccessTokenStub(token), handlers: HttpMockServer.CreateInstance()))
                {
                    await doTest(client);
                }

                context.Stop();
            }
        }
    }

    public class BotAccessTokenStub : ServiceClientCredentials
    {
        private readonly string token;

        public BotAccessTokenStub(string token)
        {
            this.token = token;
        }

        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.token);
            await base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
