using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageManager : MonoBehaviour
{
    public Text HP_text; //textオブジェクト
    public GameObject HPtext;

    public GameObject PlayerGage;
    PlayerGauge Gauge;
    public ArborDamage player;

    void Start()
    {
        GameObject.Find("PlayerGage");
        Gauge = PlayerGage.GetComponent<PlayerGauge>();
    }

    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text HP_text = HPtext.GetComponent<Text> ();
        
        float BoneHP = player.life;
        float BoneMaxHP = player.maxLife;
        //float型からstring型に変換
        string charaHP = BoneHP.ToString();
        string charaMaxHP = BoneMaxHP.ToString();
        HP_text.text = string.Format("HP" + charaHP + "/" + charaMaxHP);
    }
}
