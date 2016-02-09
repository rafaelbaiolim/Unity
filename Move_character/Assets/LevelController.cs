using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;
    private GameObject refPlayer;
    private GameObject refEnemy;
    
    // Use this for initialization
    void Start () {
        refPlayer = GameObject.FindWithTag("Player");
        
        if (refPlayer == null)
        {
            
            if (mapaController.mapa0WasLived == 1 && SceneManager.GetActiveScene().buildIndex == 0)
            {
                Quaternion rotation = new Quaternion();
                rotation.x = player.transform.rotation.x;
                rotation.y = 180f;
                rotation.z = player.transform.rotation.z;
                Instantiate(player, new Vector3(3.34062f, -0.2f, -7.5f), rotation);
            }
            else
            {
                Instantiate(player, new Vector3(-4f, -0.2f, -7.5f), player.transform.rotation);
                
            }
        }
        refEnemy = GameObject.FindWithTag("EnemySkull");
        if (refEnemy == null)
        {
            Instantiate(enemy, new Vector3(2, 0.2f, -7.5f), enemy.transform.rotation);
        }

    }


    public static void getNextLevel(string referencia)
    {

        if(referencia == "DIREITA")
        {
            mapaController.mapa0WasLived = 1;
            SceneManager.LoadScene("map1");
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene("main");
            }
        }


    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
