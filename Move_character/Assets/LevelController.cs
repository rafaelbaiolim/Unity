using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelController : MonoBehaviour {
    public GameObject oPlayer;
    public GameObject enemy;
    private GameObject refPlayer;
    private GameObject refEnemy;

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 40, 80, 20), "Save Game"))
        {
            this.SaveGame();
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 70, 80, 20), "Load Game"))
        {
            this.LoadGame();
        }
    }

    public void LoadGame()
    {

        if (File.Exists(Application.persistentDataPath + "/Player.dat"))
        {

            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream fl = File.Open(Application.persistentDataPath + "/player.dat",FileMode.Open);
            MyPlayer loadedPlayer = (MyPlayer)bf.Deserialize(fl);
            fl.Close();
            getLoadState(loadedPlayer.myScene);

        }
     

    }


    public void SaveGame()
    {

        MyPlayer ply = new MyPlayer();
        ply.SetDomain(SceneManager.GetActiveScene().buildIndex);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fl = File.Create(Application.persistentDataPath + "/player.dat");
        
        bf.Serialize(fl, ply);
        fl.Close();
       
    }



    // Use this for initialization
    void Start () {
        refPlayer = GameObject.FindWithTag("Player");
        
        if (refPlayer == null)
        {
            
            if (mapaController.mapa0WasLived == 1 && SceneManager.GetActiveScene().buildIndex == 0)
            {
                Quaternion rotation = new Quaternion();
                rotation.x = oPlayer.transform.rotation.x;
                rotation.y = 180f;
                rotation.z = oPlayer.transform.rotation.z;
                Instantiate(oPlayer, new Vector3(3.34062f, -0.2f, -7.5f), rotation);
            }
            else
            {
                Instantiate(oPlayer, new Vector3(-4f, -0.2f, -7.5f), oPlayer.transform.rotation);
                
            }
        }
        refEnemy = GameObject.FindWithTag("EnemySkull");
        if (refEnemy == null)
        {
            Instantiate(enemy, new Vector3(2, 0.2f, -7.5f), enemy.transform.rotation);
        }

    }


    private void getLoadState(int stage)
    {
        SceneManager.LoadScene(stage);
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
