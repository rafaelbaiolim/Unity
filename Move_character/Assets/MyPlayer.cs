using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class MyPlayer {
    public int myScene;
    public float velocidade;
    public float forcaPulo;
    public float upForce;

    public void SetDomain(int cena)
    {
        this.myScene = cena;
    }

    public MyPlayer()
    {

    }
}
