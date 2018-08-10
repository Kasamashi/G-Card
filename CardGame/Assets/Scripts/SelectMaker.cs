using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMaker : MonoBehaviour {
    public GameObject pointer;
    public GameObject handParent;
    public GameObject uiCard;

    DuelCardPointer duelCardPointer;
    CardExplainManager cardExplainManager;
    List<int> cardIndex = new List<int>();
    List<GameObject> cardGameObject = new List<GameObject>();

    private void Start()
    {
        duelCardPointer = pointer.GetComponent<DuelCardPointer>();
        cardExplainManager = GetComponent<CardExplainManager>();
        cardIndex = new List<int>();
        cardGameObject = new List<GameObject>();
    }

    public IEnumerator Show(List<int> cardIndex)
    {
        this.cardIndex = cardIndex;
        for (int i=0; i < cardGameObject.Count; i++)
        {
            Destroy(cardGameObject[i]);
            
        }
        cardGameObject.Clear();
        for (int i = 0; i < cardIndex.Count; i++)
        {
            GameObject g = Instantiate(uiCard, handParent.transform);
            Image image = g.GetComponent<Image>();
            image.sprite = Resources.Load<Sprite>(CardData.cardDataBase[cardIndex[i]].image);
            UICardMain uiCardMain = g.GetComponent<UICardMain>();
            uiCardMain.number = i;
            uiCardMain.manager = gameObject;
            cardGameObject.Add(g);
        }
        yield break;
    }

    public void HandCardSelected(int handNumber)
    {
        cardExplainManager.setExplain(cardIndex[handNumber]);
        duelCardPointer.card = cardGameObject[handNumber].gameObject;
    }

}
