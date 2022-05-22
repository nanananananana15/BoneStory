using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
public float maxLife;            // 最大HP

public float life;        // 現在のＨＰ

public Animator animator;

public float EnemyPower;
public Rigidbody2D rigidBody2D;

public EnemyGauge enemyGauge;
 

bool damage = false;

    private void Start()
    {
        enemyGauge = GameObject.FindObjectOfType<EnemyGauge>();
        
    }



     public void Damage(float power)
    {
        enemyGauge.GaugeReduction(power);
        life -= power;
        
        //ヒットポイントを-1
  //Hpプロパティにより、HPが0になると自動的にDead()が呼ばれる（※BaseCharacterController参照）
  if(life > 0)
  {
    StartCoroutine("DamageTimer");
  }
  else
  {
      Dead();
  }
    }

    //追加
//ダメージを受けた瞬間の無敵時間のタイマー
protected IEnumerator DamageTimer()
{
    //既にダメージ状態なら終了
  if (damage)
  
  {
    yield break;
  }
  

  //this.animator.SetTrigger("Damage");
  
}

//敵に触れたらダメージ
protected void OnCollisionEnter2D(Collision2D collision)
    {
  if (collision.gameObject.CompareTag("Player"))
  {
    Damage(1);
  }
  if(collision.gameObject.CompareTag("Hand"))
  {
    Damage(1);
  }
  if(collision.gameObject.CompareTag("tree"))
  {
    Damage(2);
  }
  }
  

  void Dead()
{
  Destroy (this.gameObject);
}
}
