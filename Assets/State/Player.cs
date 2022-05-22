using UnityEngine;

public partial class Player
{
    // ステートのインスタンス
	private static readonly StateStanding stateStanding = new StateStanding();
	private static readonly StateJumping stateJumping = new StateJumping();
	private static readonly StateDead stateDead = new StateDead();
    private static readonly StateDamage stateDamage = new StateDamage();
	private static readonly StateWalk stateWalk = new StateWalk();

    public bool IsDead => currentState is StateDead;

	/// <summary>
	/// 現在のステート
	/// </summary>
	private PlayerStateBase currentState = stateWalk;



	// Start()から呼ばれる
	private void OnStart()
	{
		currentState.OnEnter(this, null);
	}

    // Update()から呼ばれる
	private void OnUpdate()
	{
		currentState.OnUpdate(this);
	}

	// ステート変更
	private void ChangeState(PlayerStateBase nextState)
	{
		currentState.OnExit(this, nextState);
		nextState.OnEnter(this, currentState);
		currentState = nextState;
	}

    // 死亡した時に呼ばれる
	private void OnDeath()
	{
		ChangeState(stateDead);
	}



}
