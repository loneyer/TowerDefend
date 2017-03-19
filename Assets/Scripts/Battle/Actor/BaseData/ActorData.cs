using UnityEngine;
using System.Collections;

public class ActorData : BaseData {

	public Transform actorTr;
	public string logName;
	enActorCamp _actorCamp;
	public enActorCamp actorCamp{
		get{ 
			return _actorCamp;
		}
		set{ 
			_actorCamp = value;
		}
	}

}
