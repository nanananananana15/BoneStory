using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHP2 : MonoBehaviour
{
    public float life;
    public float maxLife;
    public Animator animator;
  Rigidbody2D rigidBody2D;

    bool damage = false;
 
    protected ZombieGauge2 zombieGauge2;
 
    private void Start()
    {
        zombieGauge2 = GameObject.FindObjectOfType<ZombieGauge2>();
        
    }
 
    public void Damage(float power)
    {
        zombieGauge2.GaugeReduction(power);
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
  

  this.animator.SetTrigger("Damage");
  
}
//追加
//敵に触れたらダメージ
protected void OnCollisionEnter2D(Collision2D collision)
{

  if (collision.gameObject.CompareTag("Player"))
  {
    Damage(1);
  }
  if(collision.gameObject.CompareTag("tree"))
  {
    Damage(2);
  }

}

void OnTriggerEnter2D(Collider2D collision)
{
  if(collision.gameObject.CompareTag("Hand"))
  {
    Damage(1);
    Debug.Log("手のダメージ");
  }


}

void Dead()
{
  Destroy (this.gameObject);
}
}

