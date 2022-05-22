using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class ArborMove2 : StateBehaviour {

	public StateLink nextState2;

	
    public Rigidbody2D rigidBody2D;
	// Use this for initialization
	void Start () {
	
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
	public override void OnStateUpdate() {
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
	//敵に触れたらダメージ
protected void OnCollisionEnter2D(Collision2D collision)
{
	Debug.Log("hit");
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
      Transition(nextState2);
    }
    else if ((relativePoint.x < -0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rigidBody2D.MovePosition(transform.position + transform.right * 250.0f * Time.deltaTime);
      Transition(nextState2);
    }


    //敵が→　自分が←のとき
    else if ((relativePoint.x < -0.2) &&  (hitPoint.x > transform.position.x))
    {
      this.rigidBody2D.MovePosition(transform.position + transform.right * 250.0f * Time.deltaTime);
      Transition(nextState2);
    }

    //敵が←　自分が←のとき
    else if ((relativePoint.x > 0.2) && (hitPoint.x > transform.position.x) )
    {
      this.rigidBody2D.MovePosition(transform.position - transform.right * 250.0f * Time.deltaTime);
      Transition(nextState2);
    }
    //敵が左、自分が左
    else if((relativePoint.x > 0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rigidBody2D.MovePosition(transform.position + transform.right * 250.0f * Time.deltaTime);
      Transition(nextState2);
    }

    //敵が左　自分が右
    else if((relativePoint.x > 0.2)  && (hitPoint.x > transform.position.x))
    {
      
      this.rigidBody2D.MovePosition(transform.position - transform.right * 250.0f * Time.deltaTime);
      Transition(nextState2);
    }


  }
  }
  }
  
}
}
