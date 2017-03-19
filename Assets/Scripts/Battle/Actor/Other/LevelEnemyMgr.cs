using UnityEngine;
using System.Collections;
using JSON;

/// <summary>
/// 读取对应关卡敌人数据，生成敌人
/// </summary>
public class LevelEnemyMgr : MonoBehaviour {

	string challengeId = "1001"; // 关卡暂定1001

	int allEnemyCount; // 所有怪物的数量
	int showedEnemyCount; // 已召唤的怪物数量
	int allWave; // 总波次
	int curWave; // 当前波次
	int curWaveBointCount; // 当前波次怪物数量
	int curCreateIndex = -1; // 当前波次进度


	JSONNode waveData; // 当前关卡怪物数据
	JSONNode curWaveData; // 当前波次怪物数据



	float createTime = 10.0f;
	int[] data = new int[]{101,101,101,101,101,101,101,101,101,101,101,101,101};




	float timer;

	// Use this for initialization
	void Start () {
		waveData = JSONNode.Parse (JSONChallenge.instance.GetMonsterData(challengeId));
		curWaveData = waveData [curWave] ["data"];
		allWave = waveData.Count;
		curWave = 0;
		curCreateIndex = 0;
		createTime = waveData [curWave] ["time"].AsFloat;

		Debug.Log ("当前波次数据 :[" + curWaveData.ToString () + "]  allWake :[" + allWave);



		UIManager.instance.Init ();
		timer = createTime;




	}
	
	// Update is called once per frame
	void Update () {
		if (curCreateIndex >= data.Length)
			return;
		

		timer += Time.deltaTime;

		if(timer > createTime){
			timer -= createTime;
			curCreateIndex++;
//			BattleStageActorFactor.instance.CreateBoint<Dogface> (data [curCreateIndex].ToString (), EnemyPointManager.instance.GetBirthPos (), enActorCamp.enEnemy, enEnterStageWay.enAppearance);
		}
	}
}
