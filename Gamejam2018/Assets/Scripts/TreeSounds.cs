using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SoundManager.Instance.PlaySingleDistance(this.gameObject,"Vomit2");
	}
}
