using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class ArborEnemyChase : StateBehaviour {

	public StateLink nextState;
	public StateLink nextState2;

	public GameObject target;

	float speed = 2f;

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
	public override void OnStateLateUpdate() 
	{
		
	}

	public void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
		}

	}
}
