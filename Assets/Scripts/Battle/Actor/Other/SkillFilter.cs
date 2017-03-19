using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillFilter {

	/// <summary>
	/// 基础过滤
	/// </summary>
	/// <returns>The filter.</returns>
	/// <param name="_actor">Actor.</param>
	public static List<BattleStageActor> BasicFilter(BattleStageActor _actor){
		var allActors = BattleStageActorPool.instance.SearchActorsByBoolCallback(delegate(Actor _act) {
			BattleStageActor bsa = (BattleStageActor) _act;
			if(bsa.DifferentCamp(_actor))
				return true;
			return false;
		});

		return allActors;
	}

	/// <summary>
	/// 条件过滤 （单过滤）
	/// </summary>
	/// <returns>The filter.</returns>
	/// <param name="_actors">Actors.</param>
	/// <param name="_actor">Actor.</param>
	/// <param name="_ws">Ws.</param>
	public static BattleStageActor SimpleFilter(List<BattleStageActor> _actors, BattleStageActor _actor, WeaponSkill _ws){
		BattleStageActor result = null;
		for(int i = 0;i < _actors.Count;i++){

			if (_ws.weaponSkill.skillCondition == Tags.Condition_Dis) {
				switch(_ws.weaponSkill.compareValue){
				case CompareValue.enGreaterEquals:
				case CompareValue.enGreater:
					if (zTools.DistanceZeroY (_actor.transform.position, _actors [i].transform.position) >= _ws.weaponSkill.value)
						result = _actors [i];
					break;
				case CompareValue.enEquals:
					if (zTools.DistanceZeroY (_actor.transform.position, _actors [i].transform.position) == _ws.weaponSkill.value)
						result = _actors [i];
					break;
				case CompareValue.enLess:
				case CompareValue.enLessEquals:
					if (zTools.DistanceZeroY (_actor.transform.position, _actors [i].transform.position) <= _ws.weaponSkill.value)
						result = _actors [i];
					break;

				}
			}


		}

		return result;
	}

	/// <summary>
	/// 技能基础条件过滤
	/// </summary>
	/// <returns><c>true</c>, if basic filter was skilled, <c>false</c> otherwise.</returns>
	public static bool SkillBasicFilter(ActorData _hiter, ActorData _attacker, enCampCompare _compare){
		// 暂时只有过滤阵营， 后期可拓展为 锁定目标，或其他过滤
		bool result = false;
		switch (_compare) {
		case enCampCompare.enNull:
			result = true;
			break;
		case enCampCompare.enEqual:
			result = _hiter.actorCamp == _attacker.actorCamp;
			break;
		case enCampCompare.enDifferent:
			result = _hiter.actorCamp != _attacker.actorCamp;
			break;
		default:
			break;
		}

		return result;
		
	}
}
