using UnityEngine;
using System.Collections;

public class YValue : MonoBehaviour {

	public float yValue;
	public static YValue ins;

	void Awake(){
		ins = this;
	}
}
