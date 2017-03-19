using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorPool<T1, T2> : Singleton<T1> where T1 : MonoBehaviour where T2 : Actor
{

	#region Member

	List<T2> actors = new List<T2> ();
	List<T2> cachedActors = new List<T2> ();

	#endregion

	#region Interface

	public void AddActor (T2 _t)
	{
		_t.transform.parent = transform;
		actors.Add (_t);
	}

	/// <summary>
	/// 搜索满足条件的单位
	/// </summary>
	/// <returns>The actors by bool callback.</returns>
	/// <param name="bcb">Bcb.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public List<T2> SearchActorsByBoolCallback (BoolDelegateActor bcb)
	{
		cachedActors.Clear ();
		for (int i = 0; i < actors.Count; i++) {
			if (bcb (actors [i]))
				cachedActors.Add (actors [i]);
		}
		return cachedActors;
	}



		public List<Actor> SearchActorsByBoolCallbackEx(BoolDelegateActor bcb) {
			List<Actor> result = new List<Actor>();
			for(int i = 0;i < actors.Count;i++){
				if (bcb (actors [i]))
					result.Add ((Actor)actors[i]);
			}
			return result;
		}

	public List<T2> GetAllActors ()
	{
		cachedActors.Clear ();
		for (int i = 0; i < actors.Count; i++) {
			cachedActors.Add (actors [i]);
		}
		return cachedActors;
	}

	#endregion
}
