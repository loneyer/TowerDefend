﻿using UnityEngine;
using System.Collections;

public class Dogface : BattleStageActor {

	public override void InitData ()
	{
		base.InitData ();

		actordata.logName = JSONBointModelCard.instance.GetName (actorId);
		actordata.SetValue (Tags.HP, JSONBointModelCard.instance.GetHP(actorId), "Base");
		actordata.SetMaxValue (Tags.HP, JSONBointModelCard.instance.GetHP(actorId));
		actordata.SetValue (Tags.MoveSpeed, JSONBointModelCard.instance.GetMoveSpeed(actorId), "Base");
		actordata.SetValue (Tags.AttackValue, JSONBointModelCard.instance.GetAttackValue(actorId), "Base");
		actordata.SetValue (Tags.SeekDistance, JSONBointModelCard.instance.GetSeekDistance(actorId), "Base");
	}

	protected override void InitComponent ()
	{
		base.InitComponent ();

		gameObject.AddComponent<ActorEnemyBrain> ();
		gameObject.AddComponent<ActorModel> ();
		gameObject.AddComponent<ActorUIUpdate> ();

		gameObject.AddComponent<BaseDataAttribute> ();
	}

}
