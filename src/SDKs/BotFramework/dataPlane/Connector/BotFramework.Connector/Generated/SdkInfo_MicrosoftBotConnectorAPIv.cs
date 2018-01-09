
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_MicrosoftBotConnectorAPIv
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("MicrosoftBotConnectorAPIv", "Attachments", "3.0"),
                new Tuple<string, string, string>("MicrosoftBotConnectorAPIv", "Conversations", "3.0"),
            }.AsEnumerable();
        }
    }
}
