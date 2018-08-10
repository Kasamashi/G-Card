using UnityEngine;
using GameSettings;

public static class CardData
{
    // 内容はcardDataBaseのIndex
    public static int[] playerDeckList =
    { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8 };
    // cpuまたは通信対戦相手
    public static int[] cpuDeckList =
    { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8 };

    // 全てのカードデータindex:0はnoimage確定
    public static readonly CardDataBase[] cardDataBase =
    {
        new CardDataBase((int)Type.Base,          "noimage", "ここに説明文が表示されます", ""),
        new CardDataBase((int)Type.Unit, 1, 2, 1, "gu01", "イノシシ", "(01)ユニット"),
        new CardDataBase((int)Type.Unit, 2, 1, 5, "gu02", "メガテリウム", "(02)ユニット"),
        new CardDataBase((int)Type.Unit, 1, 0, 5, "gu04", "ビスカッチャ", "(03)ユニット"),
        new CardDataBase((int)Type.Base,          "nk01", "魔導書", "(04)ドローカード"),
        new CardDataBase((int)Type.Base,          "gk01", "ジビエ", "(05)バフカード"),
        new CardDataBase((int)Type.Unit, 1, 1, 3, "bu01", "ふぐ提灯", "(06)ユニット"),
        new CardDataBase((int)Type.Unit, 2, 2, 2, "bu02", "ナリアナスネイル", "(07)ユニット"),
        new CardDataBase((int)Type.Unit, 3, 3, 7, "bu03", "ラブカ", "(08)ユニット")
    };
}
