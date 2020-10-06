using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContextualMessageController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private TMP_Text messageText;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        messageText = GetComponent<TMP_Text>();

        canvasGroup.alpha = 0;
    }

    private IEnumerator ShowMessage(string _message, float _duration)
    {
        canvasGroup.alpha = 1;
        messageText.text = _message;
        yield return new WaitForSeconds(_duration);
        canvasGroup.alpha = 0;
    }

    private void OnContextualMessageTriggered(string _message, float _messageDuration)
    {
        StartCoroutine(ShowMessage(_message, _messageDuration));
    }

    private void OnEnable()
    {
        ContextualMessageTrigger.ContextualMessageTriggered += OnContextualMessageTriggered;
    }

    private void OnDisable()
    {
        ContextualMessageTrigger.ContextualMessageTriggered -= OnContextualMessageTriggered;
    }
}
