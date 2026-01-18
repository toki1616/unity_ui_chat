using System;
using System.Collections.Generic;

namespace MyEnum
{
    public class ChatEnum
    {
        public enum MessageSendUser
        {
            self,
            Other
        }

        public enum Reaction
        {
            Good,
        }

        public static List<string> GetMessageSendUserTitleList()
        {
            List<string> titles = new List<string>();
            foreach (ChatEnum.MessageSendUser user in Enum.GetValues(typeof(ChatEnum.MessageSendUser)))
            { 
                titles.Add(user.GetMessageSendUserTitle());
            
            }

            return titles;
        }
    }

    public static class ChatEnumExtension
    {
        public static string GetMessageSendUserTitle(this ChatEnum.MessageSendUser messageSendUser)
        {
            switch (messageSendUser)
            {
                case ChatEnum.MessageSendUser.self:
                    return "自分";

                case ChatEnum.MessageSendUser.Other:
                    return "他人";

                default:
                    return "";
            }
        }
    }
}
