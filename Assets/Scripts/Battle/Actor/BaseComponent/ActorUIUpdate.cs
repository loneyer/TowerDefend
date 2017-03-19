using UnityEngine;
using System.Collections;

public class ActorUIUpdate : ActorComponent {

	#region Member

	Transform _model;
	Transform model{
		get{
			return transform;
		}
	}

	Transform _hppos;
	Transform hppos{
		get{
			if (_hppos == null)
				_hppos = stageActor.myobj.GetObj ("HPPos").transform;

			return _hppos;
		}
	}

	#endregion

	#region Callback Event

	void onHPChange(ValueFloat vi, float v1){
		Debug.Log ("血量发生改变  value :[" + v1 + "]");
		MessageProvider.Instance.Execute (enBattleUIAction.enUpdateHP, hppos, vi.GetProportion());
	}

	#endregion

	#region Awake 等重写

	protected override void OnStart ()
	{
		base.OnStart ();

		MessageProvider.Instance.Execute (enBattleUIAction.enCreateHP, hppos);

		stageActor.actordata.AddValueChange (Tags.HP, onHPChange);
	}

	protected override void OnDespawn ()
	{
		MessageProvider.Instance.Execute (enBattleUIAction.enRemoveHP, hppos);
		base.OnDespawn ();
	}
	#endregion

}
