using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _messageObject;
    private Coroutine _textGenerator;

    public void ShowMessage(string text)
    {
        CloseMessage();
        _messageObject.SetActive(true);
        _textGenerator = StartCoroutine(TextGenerator(text));
    }

    private IEnumerator TextGenerator(string text)
    {
        char[] letters = text.ToCharArray();
        string newText = "";
        foreach(var letter in letters)
        {
            yield return new WaitForSeconds(.02f);
            newText += letter;
            _text.text = newText;
        }
        yield return new WaitForSeconds(2f);
        CloseMessage();
    }

    public void CloseMessage()
    {
        _text.text = "";
        _messageObject.SetActive(false);
        if(_textGenerator != null) StopCoroutine(_textGenerator);
    }
}
