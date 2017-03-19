using UnityEngine;
using System.Collections;

public class ActorEye : ActorComponent {

	#region Interface

	/// <summary>
	/// 更新满足条件的仇恨目标
	/// </summary>
	public void UpdateThreatDataBySeekDistance(){
		var actors = SkillFilter.BasicFilter (stageActor);
		for(int i = 0;i < actors.Count;i++){
			if (stageActor.DistanceLessLength (actors [i], stageActor.actordata.GetValue (Tags.SeekDistance))
			    && !stageActor.threat.CheckHasThreat (actors [i]))
				stageActor.threat.AddThreatTarget (actors [i]);
		}
	}

	#endregion
}
