using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
    public Transform spriteEnemy;
    private Transform target;
    private Animator animator;
    private Vector3 initialPosition;
    private int velocidade;
    private float movimento;
    private float totalAndado;
    private float controle;
    private bool canWalkFoward;

    // Use this for initialization
    void Start () {
        velocidade = 1;
        controle = 0;
        canWalkFoward = true;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = spriteEnemy.GetComponent<Animator>();
        initialPosition = spriteEnemy.position;
        totalAndado = initialPosition.x;
    }
	
	// Update is called once per frame
	void Update () {
        walkPatrol();
       setMovment();
    }

    void walkPatrol()
    {


        if (totalAndado == initialPosition.x || totalAndado < -initialPosition.x + controle)
        {
            controle = 0;
            canWalkFoward = true;
            totalAndado = initialPosition.x;
            animator.SetFloat("movimento", 1);

            transform.Translate(-(Vector2.right * velocidade * Time.deltaTime));
        }

        if (totalAndado <= initialPosition.x + 150 && canWalkFoward)
        {
            totalAndado++;
            animator.SetFloat("movimento", 1);

            transform.Translate(-(Vector2.right * velocidade * Time.deltaTime));
           
        }
        else
        {
            canWalkFoward = false;
            totalAndado--;
            animator.SetFloat("movimento", -0.9f);
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        
    }

    void OnCollisionEnter2D(Collision2D colisor) {
            if (colisor.gameObject.tag == "PlayerHit")
            {          
            }
     }

    private void setMovment()
    {
        if (target != null)
        {
            
            if (Mathf.Abs((target.position.x - spriteEnemy.position.x)) < 2)
            {
                controle = controle + (target.position.x - spriteEnemy.position.x) ;
                totalAndado = target.position.x;
            }   

        }
        else
        {

            target = GameObject.FindGameObjectWithTag("PlayerTransform").transform;
        }


        
    }

    private void KillOnAnimationEnd()
    {   
        Destroy(gameObject);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        animator.Play("enemy_destroyed");
        animator.SetBool("isParado", true);
        animator.SetFloat("movimento", 0);
        transform.Translate(new Vector3(0, 0, 0));
    }
}

