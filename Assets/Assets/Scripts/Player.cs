using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speedMovement;
    public float speedRotation;
    Rigidbody2D rb;

    public GameObject bala;
    public GameObject particulasMuerte;

    Animator anim;

    Collider2D coll;

    public GameManager gameManager;
    private bool isDead;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        horizontal *= speedRotation * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, horizontal);
        
        float vertical = Input.GetAxis("Vertical");
        //transform.position += new Vector3(0, vertical * speedMovement * Time.deltaTime);
        if (vertical > 0)
        {
            rb.AddForce(transform.up * vertical * speedMovement * Time.deltaTime);
        }

        anim.SetBool("Movement", vertical > 0);

        if (Input.GetButtonUp("Jump") && coll.enabled)
        {
            GameObject temp = Instantiate(bala, transform.position , transform.rotation);

            Destroy (temp, 1);
        }
    }

    public void Muerte()
    {
        GameObject temp = Instantiate(particulasMuerte, transform.position, transform.rotation);
        Destroy(temp, 3);

        if (GameManager.instance.life > 1)
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;

            StartCoroutine(Respawn_Corutine());
        }
        else if (GameManager.instance.life == 1 && !isDead)
        {
            isDead = true;
            Destroy(gameObject);
            gameManager.gameOver();
        }
    }

    IEnumerator Respawn_Corutine()
    {
        GameManager.instance.life--;
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        coll.enabled = false;
        yield return new WaitForSeconds(3);
        coll.enabled = true;
        
    }
}
