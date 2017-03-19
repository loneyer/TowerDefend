using UnityEngine;
using System.Collections;

public class zTools
{

	//	static zTools _instance;
	//	public static zTools instance{
	//		get{
	//			if (_instance == null)
	//				_instance = new zTools ();
	//			return _instance;
	//		}
	//	}


	public static float DistanceZeroY (Vector3 self, Vector3 target)
	{
		self.y = 0;
		target.y = 0;
		return Vector3.Distance (self, target);
	}
}


