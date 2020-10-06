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

        StartCoroutine(ShowMessage("TESTING", 5));
    }

    private IEnumerator ShowMessage(string _message, float _duration)
    {
        canvasGroup.alpha = 1;
        messageText.text = _message;
        yield return new WaitForSeconds(_duration);
        canvasGroup.alpha = 0;
    }
}
