using UnityEngine;
using System.Collections;

public class ActorModel : ActorComponent {

	GameObject _model;

	#region 重写

	protected override void OnAwake ()
	{
		base.OnAwake ();

		initModel ();
	}

	protected override void OnDespawn ()
	{
		ObjManager.instance.Despawn (_model);

		base.OnDespawn ();
	}



	#endregion

	#region Private

	void initModel(){
		_model = ObjManager.instance.GetGameObject (GamePath.ModelPath, JSONBointModelCard.instance.GetModeName(stageActor.actorId), transform);
	}

	#endregion


}
