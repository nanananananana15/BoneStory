using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class ArborEnemyDamage : StateBehaviour {
	public StateLink nextState;

	public float maxLife;            // 最大HP

    public float life;        // 現在のＨＰ

    public Animator animator;

    public EnemyGauge HPGauge; //そのユニットの体力ゲージ 

    public float EnemyPower;
    public Rigidbody2D rigidBody2D;
	
	public GameObject chara;
	
	// Use this for initialization
	void Start () 
	{
	
	}

	// Use this for awake state
	public override void OnStateAwake() {

	}

	// Use this for enter state
	public override void OnStateBegin() 
  {
    
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

	public virtual void Damage(float power)
    {
        HPGauge.GaugeReduction(power);
        life -= power;

        EnemyPower = power;

        if (life <= 0)
        {
		  Destroy(chara);
        }
		StartCoroutine("Wait");
    }

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.5f);
		Transition(nextState);
	}

	protected void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Hand"))
		{
			Damage(1);
		}
		if (collision.gameObject.CompareTag("tree"))
		{
			Damage(1);
		}
		if (collision.gameObject.CompareTag("Sword"))
		{
			Damage(2);
		}
	}

}
