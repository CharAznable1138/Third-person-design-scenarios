using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContextualMessageController : MonoBehaviour
{
    [SerializeField]
    float fadeOutDuration = 1;

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
        float fadeElapsedTimed = 0;
        float fadeStartTime = Time.time;
        while(fadeElapsedTimed < fadeOutDuration)
        {
            fadeElapsedTimed = Time.time - fadeStartTime;
            canvasGroup.alpha = 1 - fadeElapsedTimed / fadeOutDuration;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }

    private void OnContextualMessageTriggered(string _message, float _messageDuration)
    {
        StopAllCoroutines();
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
