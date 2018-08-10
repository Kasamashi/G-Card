using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSettings;

public class ShowPlayerStats : MonoBehaviour {

    public GameObject manager;
    public Text health;
    public Text deck;
    public Text mana;
    public Text hand;
    public Text trash;

    public bool isPlayer;
    DuelManager duelManager;
    DuelChildData data;

    private void Start () {
        duelManager = manager.GetComponent<DuelManager>();
        if (isPlayer)
        {
            data = duelManager.player;
        }
        else
        {
            data = duelManager.cpu;
        }
	}
	
	private void Update () {
        health.text = data.life.ToString();
        deck.text = data.deck.Count.ToString();
        mana.text = data.mana.ToString();
        hand.text = data.hand.Count.ToString();
        trash.text = data.trash.Count.ToString();
    }
}
