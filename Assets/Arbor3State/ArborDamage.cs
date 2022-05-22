using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using UnityEngine.SceneManagement;

[AddComponentMenu("")]
public class ArborDamage : StateBehaviour {
	public StateLink nextState;
	public StateLink nextDeath;

	public float maxLife;            // 最大HP

    public float life;        // 現在のＨＰ

    public Animator animator;

    public PlayerGauge HPGauge; //そのユニットの体力ゲージ 

    public float EnemyPower;
    public Rigidbody2D rigidBody2D;

	//GameOverのパネル
    public GameObject Panel;
	
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
          animator.SetTrigger("Dead");
		  Panel.SetActive(true);
          Invoke("Return",3.0f);
          life = 0;
		  Death();
        }

		if (life > 0 )
		{
		StartCoroutine("Wait");
		}
    }

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.5f);
		Transition(nextState);
	}

	public void Death()
	{
		Transition(nextDeath);
	}

	protected void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("1");
			Damage(1);
		}
		if (collision.gameObject.CompareTag("100Damage"))
		{
			Damage(100);
		}
	}

	void Return()
    {
    SceneManager.LoadScene("Tittle");
    }

}
