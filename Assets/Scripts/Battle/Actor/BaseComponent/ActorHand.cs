using UnityEngine;
using System.Collections;

/// <summary>
///  大脑让手发起攻击，攻击什么时候结束由手通知大脑
/// </summary>
public class ActorHand : ActorComponent {

	#region Member

	ActorWeapon weapon;

	WeaponData cachedWeaponData = new WeaponData ();

	float cachedTime;
	/// <summary>
	/// 攻击动画时长
	/// </summary>
	float attackingTime;


	float _maxAttackRange = 0; 
	float maxAttackRange{
		get{
			if (_maxAttackRange == 0) {
				for(int i = 0;i < weapon.skills.Count;i++){
					if (weapon.skills [i].weaponSkill.skillCondition == Tags.Condition_Dis && weapon.skills [i].weaponSkill.value > _maxAttackRange) {
						_maxAttackRange = weapon.skills [i].weaponSkill.value;
					}
				}
			}
			return _maxAttackRange;
		}
	}
	#endregion

	#region 重写

	protected override void OnAwake ()
	{
		base.OnAwake ();
		cachedTime = Time.time;
		weapon = gameObject.AddComponent<ActorWeapon> ();
	}

	protected override void OnStart ()
	{
		base.OnStart ();

		if(stageActor.actordata.actorCamp == enActorCamp.enPlayer)
			BattleStageActorFactor.instance.DrawWireSphere (transform, maxAttackRange);
	}

	#endregion

	#region Interface

	public bool CheckCanAttack(){
		cachedWeaponData = weapon.GetWeaponData ();

		return !(cachedWeaponData.target == null);
	}

	public void Attack(){
		attackingTime = 2.0f;
		cachedTime = Time.time;
		#if EditorDebug
		EditorDebug.Log (stageActor.actordata.logName + "  发起攻击 目标 : [" + cachedWeaponData.target.actordata.logName + "]");
		#endif

		SkillData sd = new SkillData ();
		sd.skillId = cachedWeaponData.skillId;
		sd.attackerData = stageActor.actordata;
		sd.hiterData = cachedWeaponData.target.actordata;
		sd.targetPos = cachedWeaponData.target.transform.position;
		sd.power = 100;
			

		SkillMgr.instance.PlaySkill (sd);
	}

	public bool IsAttackFinish(){
		if (Time.time - cachedTime > attackingTime)
			return true;

		return false;
	}

	#endregion


	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, maxAttackRange);
	}
}
