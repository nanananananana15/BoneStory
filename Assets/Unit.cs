using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
public float maxLife;            // 最大HP

public float life;        // 現在のＨＰ

public Animator animator;

public PlayerGauge HPGauge; //そのユニットの体力ゲージ 

public float EnemyPower;
public Rigidbody2D rigidBody2D;
 

bool damage = false;

    private void Start()
    {
        
    }



    public virtual void Damage(float power)
    {
        HPGauge.GaugeReduction(power);
        life -= power;

        EnemyPower = power;

        
        //ヒットポイントを-1
        //Hpプロパティにより、HPが0になると自動的にDead()が呼ばれる（※BaseCharacterController参照）
        if(life > 0)
        {
         StartCoroutine("DamageTimer");
        }
        else if (life <= 0)
        {
          animator.SetTrigger("Dead");
        }
    }


//ダメージを受けた瞬間の無敵時間のタイマー
protected IEnumerator DamageTimer()
{
    //既にダメージ状態なら終了
  if (damage == true)
  {
        Debug.Log("既にダメージ状態");
    yield break;

  }
  else
  {
      GameObject playerUnit = GameObject.FindGameObjectWithTag("Player");
  animator.SetTrigger("Damage");
yield return new WaitForSeconds(0.5f);
damage = false;
Debug.Log("ダメージ状態ではなくなった");
GetComponent<CharaMove>().enabled = true;
  }
}

//敵に触れたらダメージ
protected void OnCollisionEnter2D(Collision2D collision)
{
  if(damage == false)
  {
  foreach (ContactPoint2D point in collision.contacts)
  {
    //当たった敵の向き
    Vector3 relativePoint = transform.TransformPoint(point.point);
    //自分の向き
    Vector3 playerPoint = transform.InverseTransformPoint(point.point);
    // Collisionと衝突した際の座標
    Vector3 hitPoint;
    
    foreach(ContactPoint2D contact2D in collision.contacts)
    {
        // 衝突した座標を取得
        hitPoint = contact2D.point;
  
  if (collision.gameObject.CompareTag("Enemy"))
  {

    	// ここにノックバック処理
      //敵が右　自分が右
    if ((relativePoint.x < -0.2)  && (hitPoint.x > transform.position.x) )
    {
      this.rigidBody2D.MovePosition(transform.position - transform.right * 250.0f * Time.deltaTime);
      Damage(1);
      damage = true;
      Debug.Log("2");
      GetComponent<CharaMove>().enabled = false;
    }
    else if ((relativePoint.x < -0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rigidBody2D.MovePosition(transform.position + transform.right * 250.0f * Time.deltaTime);
      Damage(1);
      damage = true;
      Debug.Log("8");
      GetComponent<CharaMove>().enabled = false;
    }


    //敵が→　自分が←のとき
    else if ((relativePoint.x < -0.2) &&  (hitPoint.x > transform.position.x))
    {
      this.rigidBody2D.MovePosition(transform.position + transform.right * 250.0f * Time.deltaTime);
      Damage(1);
      damage = true;
      Debug.Log("3");
      GetComponent<CharaMove>().enabled = false;
    }

    //敵が←　自分が←のとき
    else if ((relativePoint.x > 0.2) && (hitPoint.x > transform.position.x) )
    {
      this.rigidBody2D.MovePosition(transform.position - transform.right * 250.0f * Time.deltaTime);
      Damage(1);
      damage = true;
      Debug.Log("4");
      GetComponent<CharaMove>().enabled = false;
    }
    //敵が左、自分が左
    else if((relativePoint.x > 0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rigidBody2D.MovePosition(transform.position + transform.right * 250.0f * Time.deltaTime);
      Damage(1);
      damage = true;
      Debug.Log("5");
      GetComponent<CharaMove>().enabled = false;
    }

    //敵が左　自分が右
    else if((relativePoint.x > 0.2)  && (hitPoint.x > transform.position.x))
    {
      
      this.rigidBody2D.MovePosition(transform.position - transform.right * 250.0f * Time.deltaTime);
      Damage(1);
      damage = true;
      Debug.Log("6");
      GetComponent<CharaMove>().enabled = false;
    }


  }

}
  }
  }
}
}
