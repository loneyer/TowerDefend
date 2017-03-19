using UnityEngine;
using System.Collections;

public class BattleStageActorFactor : ActorFactor<BattleStageActorFactor>{

	#region Interface

	public GameObject DrawWireSphere(Transform tr, float range){
		var go = ObjManager.instance.GetGameObject (GamePath.ModelPath, "WireSphere");
		go.transform.parent = tr;
		go.transform.localPosition = Vector3.zero;
		go.transform.localScale = Vector3.one * range;
		return go;
	}


	#endregion

}
