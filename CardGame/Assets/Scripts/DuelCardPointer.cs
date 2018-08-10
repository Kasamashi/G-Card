using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelCardPointer : MonoBehaviour {
    Image myImage;
    public GameObject card;

    private void Start()
    {
        myImage = GetComponent<Image>();
    }

    private void Update () {
        if (card)
        {
            Vector2 v = card.transform.position;
            transform.position = v;
            myImage.enabled = true;
        }
        else
        {
            myImage.enabled = false;
        }
	}
}
