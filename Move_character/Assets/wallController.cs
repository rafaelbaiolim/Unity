using UnityEngine;
using System.Collections;

public class wallController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "MainTag")
        {
            other.gameObject.transform.Translate(Vector2.zero);

        }

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerTransform")
        {
            print("Ok");
            other.gameObject.GetComponent<Rigidbody2D>().velocity.Set(0,0);
           
        }
    }

}
