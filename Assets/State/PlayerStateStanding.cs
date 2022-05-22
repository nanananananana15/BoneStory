using UnityEngine;

public partial class Player
{
	/// <summary>
	/// 通常状態
	/// </summary>

    
	public class StateStanding : PlayerStateBase
	{
        public override void OnUpdate(Player owner)
        {
            owner.ChangeState(stateWalk);
        }
        

	}
}
