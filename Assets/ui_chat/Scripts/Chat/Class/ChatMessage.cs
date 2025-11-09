using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyEnum;

public class ChatMessage
{
    private string message;
    public string Message
    {
        get
        {
            return message;
        }
    }

    private ChatEnum.MessageSendUser messageSendUser;
    public ChatEnum.MessageSendUser MessageSendUser
    {
        get
        {
            return messageSendUser;
        }
    }

    private ChatEnum.Reaction reaction;
    public ChatEnum.Reaction Reaction
    {
        get
        {
            return reaction;
        }
    }

    public ChatMessage(string message, ChatEnum.MessageSendUser messageSendUser, ChatEnum.Reaction reaction)
    {
        this.message = message;
        this.messageSendUser = messageSendUser;
        this.reaction = reaction;
    }
}
