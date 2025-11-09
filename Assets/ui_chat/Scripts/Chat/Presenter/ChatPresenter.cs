using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

using MyEnum;

public class ChatPresenter
{
    private readonly ChatModel _chatModel;

    public ChatPresenter
        (
        ChatModel chatModel
        )
    {
        Debug.Log("ChatPresenter : Inject");
        _chatModel = chatModel;
    }

    public void SendMessage(string message)
    {
        Debug.Log($"test : ChatPresenter : SendMessage : {message}");
        _chatModel.SendMessageText(message);
    }

    public IObservable<ChatMessage> sendMessageAsObservable =>
            _chatModel.SendMessage
            .Skip(1)    //登録時に走らないように
            .Share();

    public void SendMessageSendUser(ChatEnum.MessageSendUser messageSendUser)
    {
        _chatModel.SetMessageSendUser(messageSendUser);
    }

    public void SendReaction(ChatEnum.Reaction reaction)
    {

    }
}
