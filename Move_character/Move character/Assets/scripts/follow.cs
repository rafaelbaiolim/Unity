using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {
    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (player != null)
        {

            Vector3 novaPosicao = new Vector3(player.position.x + 1, player.position.y + 1, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.time);
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("PlayerTransform").transform;
        }
        
      
    }
}
