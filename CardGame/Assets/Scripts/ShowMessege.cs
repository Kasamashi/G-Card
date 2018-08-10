using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMessege : MonoBehaviour {
    public Text text;
    public GameObject messegePanel;
    private bool close;

    public IEnumerator Show(string text)
    {
        messegePanel.SetActive(true);
        this.text.text = text;
        close = false;
        while (!close)
        {
            yield return null;
        }
        messegePanel.SetActive(false);
    }


    public void OnClick()
    {
        close = true;
    }
}
