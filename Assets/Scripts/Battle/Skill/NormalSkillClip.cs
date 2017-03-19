using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class NormalSkillClip : BaseSkillClip {
	#region Member

	Dictionary<GameObject, ActorBuffAndSkill> cachedActors = new Dictionary<GameObject, ActorBuffAndSkill>();
	StringBuilder sb = new StringBuilder();

	float firingSpeed = 10.0f;
	#endregion

	#region Trigger

	protected override void onSkillTriggerEnter (Collider _collider)
	{
		base.onSkillTriggerEnter (_collider);

		var bsa = _collider.GetComponentInParent<BattleStageActor> ();
		if (bsa != null) {
			#if EditorDebug
			sb.Append("技能 :[" + skillMapId +"]" + "碰撞到目标  [" + bsa.actordata.logName + "] \n");
			#endif

			bool ispass = SkillFilter.SkillBasicFilter (bsa.actordata, skillData.attackerData, skillData.compareContent);
			if(ispass){
				bsa.buffAndSkill.OnSkillEnter (skillData);
				setState (fireFinish_state);
			}

			#if EditorDebug
			sb.Append(ispass ? "命中有效" : "命中无效");
			EditorDebug.Log(sb.ToString());
			#endif
		
		}
	}

	#endregion


	#region 重写FSM

	protected override void onFireEnter ()
	{
		base.onFireEnter ();
		setState (firing_state);
	}

	protected override void onFiringEnter ()
	{
		base.onFiringEnter ();
	}
	protected override void onFiringUpdate (float dt)
	{
		if (skillData.hiterData.actorTr == null)
			setState (fireFinish_state);

		transform.position = Vector3.Lerp (transform.position, skillData.hiterData.actorTr.position, dt * firingSpeed);
		if (zTools.DistanceZeroY (transform.position, skillData.hiterData.actorTr.position) <= 0.03f)
			setState (fireFinish_state);
	}

	protected override void onFireFinishEnter ()
	{
		base.onFireFinishEnter ();
		setState (destory_state);
	}

	#endregion

}
