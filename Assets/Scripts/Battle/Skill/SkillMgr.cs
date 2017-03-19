using UnityEngine;
using System.Collections;

public class SkillMgr : Singleton<SkillMgr> {


	public BaseSkillClip PlaySkill(SkillData skillData){

		var baseSkill = new GameObject ("skill:[" + skillData.skillId + "]").AddComponent<NormalSkillClip> ();
		baseSkill.transform.parent = transform;
		baseSkill.transform.position = skillData.attackerData.actorTr.position;
		baseSkill.Init (skillData);
		return baseSkill;

	}

}
