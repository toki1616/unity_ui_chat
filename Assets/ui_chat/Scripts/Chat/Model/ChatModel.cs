using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

using MyEnum;

public class ChatModel 
{
    private readonly ReactiveProperty<ChatMessage> _sendMessage = new ReactiveProperty<ChatMessage>();
    public IReadOnlyReactiveProperty<ChatMessage> SendMessage => _sendMessage;

    public void SendMessageText(string message)
    {
        if (string.IsNullOrEmpty(message)) { return; }
        Debug.Log($"test : ChatModel : SendMessageText : {message}");

        ChatMessage chatMessage = new ChatMessage(message, messageSendUser, ChatEnum.Reaction.Good);

        _sendMessage.SetValueAndForceNotify(chatMessage);
    }

    private ChatEnum.MessageSendUser messageSendUser = ChatEnum.MessageSendUser.self;
    public void SetMessageSendUser(ChatEnum.MessageSendUser messageSendUser)
    {
        this.messageSendUser = messageSendUser;
    }
}
