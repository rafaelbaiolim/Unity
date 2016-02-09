using UnityEngine;
using System.Collections;

public class cenario : MonoBehaviour {

    public Texture[] frames;
    public float framesPerSecond = 5f;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int index  = (int)(Time.time * framesPerSecond) % frames.Length;
        GetComponent<Renderer>().material.mainTexture = frames[index];
    }
}
