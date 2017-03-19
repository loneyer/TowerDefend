using UnityEngine;
using System.Collections;

public class ActorBuffAndSkill : ActorComponent , ISkillEnter {


	#region Buff

	public void OnSkillEnter(SkillData skillData){
		addBuff(skillData);
	}

	/// <summary>
	/// 添加buff
	/// </summary>
	void addBuff(SkillData _skillData){
		for(int i = 0;i < _skillData.buffs.Length;i++){
			BuffMgr.BuffData bd = new BuffMgr.BuffData ();
			bd.buffId = _skillData.buffs [i];
			bd.hiterData = _skillData.hiterData;
			bd.attackerData = _skillData.attackerData;
			bd.power = _skillData.power;
			stageActor.buffMgr.AddBuff (bd);
		}
	}

	#endregion
}
