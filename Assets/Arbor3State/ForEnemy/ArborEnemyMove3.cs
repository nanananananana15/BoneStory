using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using DG.Tweening;

[AddComponentMenu("")]
public class ArborEnemyMove3 : StateBehaviour {

	public StateLink nextState2;

	Tween tween;
    public Rigidbody2D rb;

    public bool EnemyGround = false;

	// Use this for initialization
	void Start () 
	{
		PlayMoveTween();
	}

	// Use this for awake state
	public override void OnStateAwake() {
	}

	// Use this for enter state
	public override void OnStateBegin() {
	}

	// Use this for exit state
	public override void OnStateEnd() {
	}
	
	// OnStateUpdate is called once per frame
	public override void OnStateUpdate() 
  {

	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}

	void PlayMoveTween()
    {
      rb = GetComponent<Rigidbody2D>();

        // 地面に触れてなければ方向転換
        if (EnemyGround == true)
        {
                    float[] x = {-4, -3, -2, 2, 3, 4 };
            float x2 = x.Random();
            Vector3 force = new Vector3(x2,0f,0f);
            rb.AddForce(force, ForceMode2D.Impulse);
            Debug.Log("3");
        if(x2<=0)
          {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.5f);
          }
        else
          {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.5f);
          }

            
        }
        else if (EnemyGround == false)
        {

                    //キャラが左向きならば
          if(transform.localScale.x >= 0f)
          {
            float[] x = { 6, 8 };
            float x2 = x.Random();
            Vector3 force = new Vector3(x2,0f,0f);
            rb.AddForce(force, ForceMode2D.Impulse);
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.5f);
            Debug.Log("1");
          }
          else if(transform.localScale.x <= 0f)
          {
            float[] x = { -6, -8 };
            float x2 = x.Random();
            Vector3 force = new Vector3(x2,0f,0f);
            rb.AddForce(force, ForceMode2D.Impulse);
            transform.localScale = new Vector3(0.4f, 0.4f, 0.5f);
            Debug.Log("2");
          }
        }


        Sequence sequence = DOTween.Sequence();
        
        
        
           

        // ループの終わりにまたこのメソッドを呼ぶように指定
        sequence.OnComplete(PlayMoveTween).SetDelay(2);


    }

protected void OnCollisionEnter2D(Collision2D collision)
{
  if (collision.gameObject.CompareTag("Ground"))
      {
         EnemyGround = true;
         Debug.Log("地面の上にいるよ");
      } 
    else if (collision.gameObject.CompareTag("NotGround"))
      {
         EnemyGround = false;
         Debug.Log("地面の上にいないよ");
      
    }

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
  
  if (collision.gameObject.CompareTag("Hand"))
  {

    	// ここにノックバック処理
      //敵が右　自分が右
    if ((relativePoint.x < -0.2)  && (hitPoint.x > transform.position.x) )
    {
      this.rb.MovePosition(transform.position - transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }
    else if ((relativePoint.x < -0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rb.MovePosition(transform.position + transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }


    //敵が→　自分が←のとき
    else if ((relativePoint.x < -0.2) &&  (hitPoint.x > transform.position.x))
    {
      this.rb.MovePosition(transform.position + transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }

    //敵が←　自分が←のとき
    else if ((relativePoint.x > 0.2) && (hitPoint.x > transform.position.x) )
    {
      this.rb.MovePosition(transform.position - transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }
    //敵が左、自分が左
    else if((relativePoint.x > 0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rb.MovePosition(transform.position + transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }

    //敵が左　自分が右
    else if((relativePoint.x > 0.2)  && (hitPoint.x > transform.position.x))
    {
      
      this.rb.MovePosition(transform.position - transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }


  }
    if (collision.gameObject.CompareTag("Sword"))
  {

    	// ここにノックバック処理
      //敵が右　自分が右
    if ((relativePoint.x < -0.2)  && (hitPoint.x > transform.position.x) )
    {
      this.rb.MovePosition(transform.position - transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }
    else if ((relativePoint.x < -0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rb.MovePosition(transform.position + transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }


    //敵が→　自分が←のとき
    else if ((relativePoint.x < -0.2) &&  (hitPoint.x > transform.position.x))
    {
      this.rb.MovePosition(transform.position + transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }

    //敵が←　自分が←のとき
    else if ((relativePoint.x > 0.2) && (hitPoint.x > transform.position.x) )
    {
      this.rb.MovePosition(transform.position - transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }
    //敵が左、自分が左
    else if((relativePoint.x > 0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rb.MovePosition(transform.position + transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }

    //敵が左　自分が右
    else if((relativePoint.x > 0.2)  && (hitPoint.x > transform.position.x))
    {
      
      this.rb.MovePosition(transform.position - transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }


  }
    if (collision.gameObject.CompareTag("tree"))
  {

    	// ここにノックバック処理
      //敵が右　自分が右
    if ((relativePoint.x < -0.2)  && (hitPoint.x > transform.position.x) )
    {
      this.rb.MovePosition(transform.position - transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }
    else if ((relativePoint.x < -0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rb.MovePosition(transform.position + transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }


    //敵が→　自分が←のとき
    else if ((relativePoint.x < -0.2) &&  (hitPoint.x > transform.position.x))
    {
      this.rb.MovePosition(transform.position + transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }

    //敵が←　自分が←のとき
    else if ((relativePoint.x > 0.2) && (hitPoint.x > transform.position.x) )
    {
      this.rb.MovePosition(transform.position - transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }
    //敵が左、自分が左
    else if((relativePoint.x > 0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rb.MovePosition(transform.position + transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }

    //敵が左　自分が右
    else if((relativePoint.x > 0.2)  && (hitPoint.x > transform.position.x))
    {
      
      this.rb.MovePosition(transform.position - transform.right * 20.0f * Time.deltaTime);
      Transition(nextState2);
    }


  }
  }
  }
  
}

    


}
