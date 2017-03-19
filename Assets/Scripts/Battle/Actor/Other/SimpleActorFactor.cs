using UnityEngine;
using System.Collections;

public class SimpleActorFactor : MonoBehaviour {



	public static T1 InstantiateBoint<T1>() where T1 : BattleStageActor{
		var tactor = new GameObject (typeof(T1).Name).AddComponent<T1>();
		BattleStageActorPool.instance.AddActor (tactor);
		return tactor;
	}
}
