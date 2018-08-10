using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICardMain : MonoBehaviour, IPointerClickHandler
{
    public int number = -1;
    public GameObject manager;
    SelectMaker selectMaker;

    private void Start()
    {
        selectMaker = manager.GetComponent<SelectMaker>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selectMaker.HandCardSelected(number);
    }
}
