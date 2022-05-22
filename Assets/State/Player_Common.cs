using UnityEngine;

// ステート以外の処理部分
public partial class Player : MonoBehaviour
{
        /// 変数一覧 ///
    //最大HP
    public static float maxLife;         
    //現在のHP
    public static float life;        
    //主人公のアニメーター
    public Animator animator;
    //主人公のHPゲージ
    public static PlayerGauge HPGauge; 
    public static float EnemyPower;
    //主人公のリジッドボディ
    public Rigidbody2D rigidBody2D;



        private void Start()
    {
        maxLife = 15;
        life = maxLife;
        OnStart();
    }

	private void Update()
	{
        OnUpdate();
    }


    
    	// 敵との接触時にダメージ
	private void OnCollisionEnter2D(Collision2D collision)
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
      ChangeState(stateDamage);
    }
    else if ((relativePoint.x < -0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rigidBody2D.MovePosition(transform.position + transform.right * 250.0f * Time.deltaTime);
      ChangeState(stateDamage);
    }


    //敵が→　自分が←のとき
    else if ((relativePoint.x < -0.2) &&  (hitPoint.x > transform.position.x))
    {
      this.rigidBody2D.MovePosition(transform.position + transform.right * 250.0f * Time.deltaTime);
      ChangeState(stateDamage);
    }

    //敵が←　自分が←のとき
    else if ((relativePoint.x > 0.2) && (hitPoint.x > transform.position.x) )
    {
      this.rigidBody2D.MovePosition(transform.position - transform.right * 250.0f * Time.deltaTime);
      ChangeState(stateDamage);
    }
    //敵が左、自分が左
    else if((relativePoint.x > 0.2)  && (hitPoint.x < transform.position.x) )
    {
      this.rigidBody2D.MovePosition(transform.position + transform.right * 250.0f * Time.deltaTime);
      ChangeState(stateDamage);
    }

    //敵が左　自分が右
    else if((relativePoint.x > 0.2)  && (hitPoint.x > transform.position.x))
    {
      this.rigidBody2D.MovePosition(transform.position - transform.right * 250.0f * Time.deltaTime);
      ChangeState(stateDamage);
    }


  }

}
  }

  
}
}