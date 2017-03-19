using UnityEngine;
using System.Collections;

public class ActorFactor<T1> : Singleton<T1> where T1 : MonoBehaviour {

	#region Interface

	public T CreateBoint<T>(string _id, Vector3 _pos, enActorCamp _camp, enEnterStageWay _way) where T : BattleStageActor{
		var tactor = SimpleActorFactor.InstantiateBoint<T>();

		tactor.Init (_id);
		tactor.EnterStage (_way);
		tactor.SetPosition (_pos);
		tactor.actordata.actorCamp = _camp;
		return tactor;
	}

	#endregion
}
