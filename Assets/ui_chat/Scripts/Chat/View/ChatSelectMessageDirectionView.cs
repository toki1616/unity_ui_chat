using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

using MyEnum;
using MyExtension;

public class ChatSelectMessageDirectionView : MonoBehaviour
{
    [SerializeField]
    private Dropdown dropdown;

    private ChatPresenter _chatPresenter;
    private LayoutGroup _layoutGroup;

    [Inject]
    public void Construct
            (
            ChatPresenter chatPresenter
            )
    {
        _chatPresenter = chatPresenter;
    }

    // Start is called before the first frame update
    void Start()
    {
        dropdown.ClearAddOptions(ChatEnum.GetMessageSendUserTitleList());
        dropdown.onValueChanged.AsObservable().Subscribe(value => OnChangeDropbox(value)).AddTo(this);
    }

    private void OnChangeDropbox(int value)
    {
        ChatEnum.MessageSendUser messageSendUser = (ChatEnum.MessageSendUser)value;
        _chatPresenter.SendMessageSendUser(messageSendUser);
        Debug.Log($"Dropdown value changed to: {messageSendUser}");
    }
}
