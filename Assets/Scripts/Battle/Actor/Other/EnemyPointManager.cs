using UnityEngine;
using System.Collections;

public class EnemyPointManager : MonoBehaviour {

	static EnemyPointManager _instance;
	public static EnemyPointManager instance{
		get{ 
			if (_instance == null)
				_instance = GameObject.Find("EnemyPointManager").GetComponent<EnemyPointManager> ();
			return _instance;
		}
	}

	public Transform birthPos;
	public Transform[] movePos;

	public Vector3 GetBirthPos(){
		return birthPos.position;
	}

	/// <summary>
	/// 获取下一个移动点
	/// </summary>
	/// <returns>The next position.</returns>
	/// <param name="movePosIndex">Move position index.</param>
	public Vector3 GetNextPos(int movePosIndex){
		if (movePosIndex >= movePos.Length)
			return Vector3.zero;

		return movePos [movePosIndex].position;
	}


}
