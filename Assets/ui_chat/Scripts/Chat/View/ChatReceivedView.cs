using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using Cysharp.Threading.Tasks;

using MyEnum;

public class ChatReceivedView : MonoBehaviour
{
    [SerializeField]
    private GameObject _chatMessageLeftIconPanel;

    [SerializeField]
    private GameObject _chatMessageRightIconPanel;

    [SerializeField]
    private RectTransform _scrollRectTransform;

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
        _chatPresenter.sendMessageAsObservable.Subscribe(_ => ReceivedMesssage(_)).AddTo(this);

        _layoutGroup = this.GetComponent<LayoutGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReceivedMesssage(ChatMessage chatMessage)
    {
        Debug.Log($"test : ChatReceivedView : ReceivedMesssage : {chatMessage}");

        CreateMessagePanel(chatMessage);
    }

    private void CreateMessagePanel(ChatMessage chatMessage)
    {
        GameObject spawnObject;
        if (chatMessage.MessageSendUser == ChatEnum.MessageSendUser.self)
        {
            spawnObject = Instantiate(_chatMessageRightIconPanel, this.transform);
            //spawnObject.GetComponent<SelectMenuButtonView>().SetMenuEnum(menuValue);
        }
        else
        {
            spawnObject = Instantiate(_chatMessageLeftIconPanel, this.transform);
        }

        spawnObject.GetComponent<ChatView>().changeMessageText(chatMessage.Message);

        RefreshLayout();
    }

    private async void RefreshLayout()
    {
        // スクロールビューの高さ調整
        Vector2 offsetMin = _scrollRectTransform.offsetMin;
        _scrollRectTransform.offsetMin = offsetMin;

        _layoutGroup.CalculateLayoutInputHorizontal();
        _layoutGroup.CalculateLayoutInputVertical();
        _layoutGroup.SetLayoutHorizontal();
        _layoutGroup.SetLayoutVertical();

        await ScrollToBottom();
    }
    private async UniTask ScrollToBottom()
    {
        await UniTask.DelayFrame(10);
        // スクロールを一番下まで移動
        ScrollRect scrollRect = _scrollRectTransform.GetComponentInParent<ScrollRect>();
        if (scrollRect != null)
        {
            Canvas.ForceUpdateCanvases(); // レイアウト更新を強制
            scrollRect.verticalNormalizedPosition = 0f; // 一番下へ
        }
    }
}
