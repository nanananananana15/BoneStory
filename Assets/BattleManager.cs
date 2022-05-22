using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject DamageUI;
    public static BattleManager instance;


    //playerのRigidbody
    public Rigidbody2D rb2D;


  protected void OnCollisionEnter2D(Collision2D coll)
  {
    if (coll.gameObject.CompareTag("Enemy"))
    {
    //被ダメージ値のテキストprefab生成
		var obj = Instantiate<GameObject>(DamageUI);
    }
  }
}
