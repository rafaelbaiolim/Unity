﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class Player : MonoBehaviour {

    public int myScene;
    public float velocidade;
    public float forcaPulo;
    public float upForce;
    private bool estaNoChao;
    private bool isParedeEsquerda;
    private bool isParedeDireita;
    public Transform chaoVerificador;
    public Transform wallLeftVerify;
    public Transform wallRightVerify;
    public Transform spritePlayer;
    private Animator animator;
    public GameObject prefab;
    public GameObject transformation;
    public MyPlayer oPlayer;
    

    //Tudo que ocorre quando o personagem e criado
    void Start()
    {
       
        oPlayer = new MyPlayer();
        estaNoChao = true;
        animator = spritePlayer.GetComponent<Animator>();
    }

    //Tudo que ocorre enquanto o personagem existe
    void Update()
    {
        Movimentacao();
        Combos();
    }


    private IEnumerator KillOnAnimationEnd(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.13f);
        Destroy(gameObject);
    }


    private void hitStart()
    {
        GameObject obj;
        GameObject myPlayer = GameObject.FindWithTag("Player");
        obj = (GameObject)Instantiate(prefab, myPlayer.transform.position, myPlayer.transform.rotation);
        //StartCoroutine(Die());

        StartCoroutine(KillOnAnimationEnd(obj));
    }


    
    private void setTransformation()
    {
        GameObject obj;
        GameObject myPlayer = GameObject.FindWithTag("Player");
        obj = (GameObject)Instantiate(transformation, myPlayer.transform.position, myPlayer.transform.rotation);
        //StartCoroutine(Die());

        StartCoroutine(KillOnAnimationEnd(myPlayer));
    }



    //Responsavel pelos hits do personagem
    void Combos()
    {
        if (Input.GetKey("q"))
        {
            animator.Play("player_hit_q");
       
            // Collider2D collider = GetComponent<Collider2D>();
            // print(collider.isActiveAndEnabled.Equals(true));

        }


        if (Input.GetKey("e"))
        {
            animator.Play("player_transform");

            // Collider2D collider = GetComponent<Collider2D>();
            // print(collider.isActiveAndEnabled.Equals(true));

        }


    }

    //Responsavel pela movimentacao do personagem
    void Movimentacao()
    {

        //Seta no paramentro movimento, um valor 0 ou maior que 0. Ira ativar a condicao para mudar de animacao
        animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        isParedeEsquerda = Physics2D.Linecast(transform.position, wallLeftVerify.position, 1 << LayerMask.NameToLayer("ParedeEsquerda"));
        isParedeDireita = Physics2D.Linecast(transform.position, wallRightVerify.position, 1 << LayerMask.NameToLayer("ParedeDireita"));
        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));

        if (isParedeDireita)
        {
            LevelController.getNextLevel("DIREITA");
        }

        if (isParedeEsquerda)
        {
            LevelController.getNextLevel("ESQUERDA");

        }

        
        if (Input.GetAxisRaw("Horizontal") > 0 && !isParedeDireita)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            
        }

        //Anda para a esquerda
        if (Input.GetAxisRaw("Horizontal") < 0 && !isParedeEsquerda)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if ((Input.GetButtonDown("Jump") && (estaNoChao == true)))
        {   
            
            GetComponent<Rigidbody2D>().AddForce((transform.up * forcaPulo));

        }
        

    }

  
}

