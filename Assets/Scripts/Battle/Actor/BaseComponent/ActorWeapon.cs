using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class ActorWeapon : ActorComponent {

	#region Member

	public List<WeaponSkill> skills = new List<WeaponSkill>();



	#endregion

	#region 重写

	protected override void OnAwake ()
	{
		base.OnAwake ();

		var tSkills = JSONBointModelCard.instance.GetSkills (stageActor.actorId);
		for(int i = 0;i < tSkills.Count;i++){
			skills.Add (new WeaponSkill (tSkills [i].ToString (), stageActor));
		}
	}

	#endregion


	#region Interface

	public WeaponData GetWeaponData(){
		WeaponData tData = new WeaponData ();
		int tSkillIndex = -1;

		// 检测某个技能CD 满足
		for(int i = 0;i < skills.Count;i++){
			if (skills [i].GetSkillId () != "-1") {
				tData.skillId = skills [i].GetSkillId ();
				tSkillIndex = i;
				break;
			}
		}

		// 检测技能条件满足
		if (tSkillIndex != -1) {
			tData.target = skills [tSkillIndex].SearchTarget ();
		}

		return tData;

	}

	#endregion
}

public struct WeaponData{
	public string skillId;
	public BattleStageActor target;

}

public class WeaponSkill{
	public BattleStageActor actor;
	public string id;
	float CD;
	public WeaponContent weaponSkill;
	float cachedTime;

	public WeaponSkill(string totalSkillId, BattleStageActor _actor){
		id = totalSkillId;
		actor = _actor;
		weaponSkill = new WeaponContent();
		weaponSkill.skillCondition = "Distance";
		weaponSkill.value = 8.0f;
		weaponSkill.compareValue = (CompareValue)4;

		cachedTime = Time.time;
	}


	#region Interface

	public string GetSkillId(){
		if (Time.time - cachedTime >= CD) {
			cachedTime = Time.time;
			return id;
		}

		return "-1";
	}

	public BattleStageActor SearchTarget(){
		var allActors = actor.threat.GetAllTargets();
		var target = SkillFilter.SimpleFilter (allActors, actor, this);
		return target;
	}

	#endregion

}

public struct WeaponContent{
	public string skillCondition;
	public float value;
	public CompareValue compareValue;
}


public enum CompareValue{
	/// <summary>
	/// 大于等于
	/// </summary>
	enGreaterEquals,
	/// <summary>
	/// 大于
	/// </summary>
	enGreater,
	/// <summary>
	/// 等于
	/// </summary>
	enEquals,
	/// <summary>
	/// 小于
	/// </summary>
	enLess,
	/// <summary>
	/// 小于等于
	/// </summary>
	enLessEquals
}



