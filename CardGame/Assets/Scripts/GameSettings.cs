using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameSettings
{
    public enum Type
    {
        Unit,
        Base,
        Action,
        Counter
    }

    public enum Scene
    {
        StartUp,    // 先攻後攻決め、デッキシャッフル、初期手札ドロー、誘発発動(ゲーム開始時)
        PlayerTurn, // 誘発発動(ターン開始時)、先行の1ターン目なら次はMain2
        Draw,       // ドロー
        Main1,      // 発動(Unit、Base、Action)
        Defense,    // 発動(Counter)
        Battle,     // 効果使用(Unit)
        Main2,      // 発動(Unit、Base、Action)
        TurnEnd     // 相手のPlayerTurnへ
    }

    public class CardDataBase
    {
        public int type = -1;
        public int level = -1;
        public int attack = -1;
        public int health = -1;
        public string image;
        public string name;
        public string explain;

        public CardDataBase() { }
        public CardDataBase(int type, string image, string name, string explain)
        {
            this.type = type;
            this.image = image;
            this.name = name;
            this.explain = explain;
        }

        public CardDataBase(int type, int level, int attack, int health, string image, string name, string explain)
        {
            this.type = type;
            this.level = level;
            this.attack = attack;
            this.health = health;
            this.image = image;
            this.name = name;
            this.explain = explain;
        }
    }
    
    public class Unit
    {
        int index;          // cardDataBaseのIndex
        int level;
        int attack;
        int health;
        List<int> effect;   // 付与された効果

        public Unit() { }
        public Unit(int index, int level, int attack, int health)
        {
            this.index = index;
            this.level = level;
            this.attack = attack;
            this.health = health;
        }
    }

    public class FieldData
    {
        List<Unit> unit;
        List<int> Base;     // cardDataBaseのIndex

        public FieldData() { }
        public FieldData(List<Unit> unit, List<int> Base)
        {
            this.unit = unit;
            this.Base = Base;
        }
    }

    /*  GameObject,Imageデータ等を除いた、仮想的にゲーム全体を表す事ができるデータクラス
     *  プレイヤー人数分配列にする1vs1なら[2]となる(1:自分,2:相手)
     *  DuelManagerが使う&カード効果関数やCPUの考慮の材料として渡す    */
    public class DuelChildData
    {
        public int life = 10;
        public int mana = 0;
        public List<int> deck;      // cardDataBaseのIndexで表す(1枚目のid:1のカード,2枚目のid:1のカードは区別する必要がない)
        public List<int> hand;      // deckと同じ
        public List<int> trash;     // deckと同じ
        public FieldData[] field;   // フィールドの数は自分と相手で2個

        public DuelChildData() { }
        public DuelChildData(int life, int mana, List<int> deck)
        {
            this.life = life;
            this.mana = mana;
            this.deck = deck;
            this.hand = new List<int>();
            this.trash = new List<int>();
            this.field = new FieldData[] { };
        }
        public DuelChildData(int life, int mana, List<int> deck, List<int> hand, List<int> trash, FieldData[] field)
        {
            this.life = life;
            this.mana = mana;
            this.deck = deck;
            this.hand = hand;
            this.trash = trash;
            this.field = field;
        }

        public DuelChildData(int life, int[] deck)
        {
            this.life = life;
            this.mana = 0;
            this.deck = deck.ToList<int>();
            this.hand = new List<int>();
            this.trash = new List<int>();
            this.field = new FieldData[] { };
        }

        public IEnumerator DeckShuffle()
        {
            deck = deck.OrderBy(i => Guid.NewGuid()).ToList();
            yield break;
        }

        public bool CheckDrawable(int number = 1)
        {
            if (deck.Count() < number)
            {
                return false;
            }
            return true;
        }

        public IEnumerator Draw(int number=1)
        {
            for (int i = 0; i < number; i++)
            {
                if (deck.Count() != 0)
                {
                    hand.Add(deck[0]);
                    deck.RemoveAt(0);
                }
            }
            yield break;
        }

    }
}