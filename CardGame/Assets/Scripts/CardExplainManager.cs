using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSettings;

public class CardExplainManager : MonoBehaviour {
    public Text explainText;
    public Image explainImage;
    
	private void Start () {
        setExplain(0);
    }

    public void setExplain(int number)
    {
        CardDataBase cdb = CardData.cardDataBase[number];
        if(cdb.type == (int)Type.Unit)
        {
            explainText.text = cdb.name + "\n" + "Lv:" + cdb.level + " 力:" + cdb.attack + " 命:" + cdb.health + "\n\n" + cdb.explain;
        }
        else
        {
            explainText.text = cdb.name + "\n" + cdb.explain;

        }
        Sprite s = Resources.Load<Sprite>(cdb.image);
        explainImage.sprite = s;
    }


}
