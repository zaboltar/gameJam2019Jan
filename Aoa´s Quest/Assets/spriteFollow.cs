using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteFollow : MonoBehaviour {

    public Transform target;
    public float zOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate() {

        transform.localPosition = new Vector3(target.localPosition.x, target.localPosition.y, target.localPosition.z+ zOffset);
            
    }
}
