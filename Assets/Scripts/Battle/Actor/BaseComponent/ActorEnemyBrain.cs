using UnityEngine;
using System.Collections;

public class ActorEnemyBrain : ActorBrain {

	#region 状态 重写

	protected override void onIdleEnter ()
	{
		base.onIdleEnter ();
		foot.ToSearchState ();
	}

	protected override void onIdleUpdate (float dt)
	{
		base.onIdleUpdate (dt);
		if (foot.target == Vector3.zero) {
			Debug.Log (gameObject.name + "  走到终点");
			return;
		}

		if (isNearFootTarget ()) {
			foot.ToSearchState ();
		}

		if (!isNearFootTarget ()) {
			setState (_run_state);
		}
	}

	protected override void onRunEnter ()
	{
		base.onRunEnter ();
		foot.canMove = true;
	}
	protected override void onRunUpdate (float dt)
	{
		base.onRunUpdate (dt);
		if (isNearFootTarget ()) {
			setState (_idle_state);
		}
	}
	protected override void onRunExit ()
	{
		foot.canMove = false;	
		base.onRunExit ();
	}

	protected override void onSleepEnter ()
	{
		base.onSleepEnter ();
	}



	#endregion
}
