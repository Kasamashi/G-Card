using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using GameSettings;

public class DuelManager : MonoBehaviour {
    SelectMaker select;
    ShowMessege messege;
    Action<IEnumerator> Push;
    public DuelChildData player;
    public DuelChildData cpu;
    
    
    private void Start () {
        select = GetComponent<SelectMaker>();
        messege = GetComponent<ShowMessege>();
        Push = GetComponent<CardEffectManager>().stack.Push;
        player = new DuelChildData(10, CardData.playerDeckList);
        cpu = new DuelChildData(10, CardData.cpuDeckList);

        Push(select.Show(player.hand));
        Push(cpu.Draw(5));
        Push(cpu.DeckShuffle());
        Push(player.Draw(5));
        Push(player.DeckShuffle());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Push(select.Show(player.deck));
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Push(select.Show(player.hand));
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Push(select.Show(player.trash));
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Push(messege.Show("メッセージだよ。メッセージだよ。\nこのメッセージはひょうじされないはずだよ。"));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Push(messege.Show("呼び覚ますものは！"));
            Push(messege.Show("深く眠りし魂を！"));
            Push(messege.Show("誰だ、わが名を呼ぶのは！"));
        }
    }
}
