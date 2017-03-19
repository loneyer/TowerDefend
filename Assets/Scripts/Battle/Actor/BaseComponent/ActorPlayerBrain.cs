using UnityEngine;
using System.Collections;

public class ActorPlayerBrain : ActorBrain {

	#region 重写

	protected override void onIdleEnter ()
	{
		base.onIdleEnter ();
		setState (_waitAttack_state);
	}
	protected override void onIdleUpdate (float dt)
	{
		base.onIdleUpdate (dt);



	}

	protected override void onWaitAttackEnter ()
	{
		base.onWaitAttackEnter ();
	}
	protected override void onWaitAttackUpdate (float dt)
	{
		base.onWaitAttackUpdate (dt);

		if (hand.CheckCanAttack ())
			setState (_attack_state);
	}
	protected override void onWaitAttackExit ()
	{
		base.onWaitAttackExit ();
	}

	protected override void onAttackEnter ()
	{
		base.onAttackEnter ();
		toAttack ();
	}
	protected override void onAttackUpdate (float dt)
	{
		base.onAttackUpdate (dt);
		if (hand.IsAttackFinish ())
			setState (_idle_state);
	}
	protected override void onAttackExit ()
	{
		base.onAttackExit ();
	}



	#endregion

}
