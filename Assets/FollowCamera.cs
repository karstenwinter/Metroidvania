using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public GameObject target;
	public Vector3 offset = new Vector3(0,0,-1);
	public float fadeSpeed = 0.01f;
    void Update()
    {
    	var toGoTo = target.transform.position + offset;
        gameObject.transform.position = gameObject.transform.position 
		+ (toGoTo - gameObject.transform.position) * fadeSpeed;
    }
}