using UnityEngine;
using System.Collections;

public class limit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}


    void OnCollisionEnter2D(Collision2D colisor)
    {
        
        colisor.gameObject.transform.Translate(-Vector2.right);
    }


}
