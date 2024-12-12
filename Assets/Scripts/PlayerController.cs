using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float Jump;
    public float gravityScale = 2;
    public bool Grounded = true;
   


    float XInput;
    float YInput;


    int score;
    int groundCount = 0;

    public GameObject win;
    public GameObject lose;

    Rigidbody rb;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //if (coinAudio == null)
        //{
        //    Debug.LogError("No AudioSource found on the player object. Please attach one!");
        //} else
        //{
        //    coinAudio = GetComponent<AudioSource>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        XInput = Input.GetAxis("Horizontal");
        YInput = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            rb.AddForce(Vector2.up * Jump, ForceMode.Impulse);
        };


        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene(0);

        }

        if (Input.GetKey(KeyCode.R)) 
        {
            SceneManager.LoadScene(1);

        }

        if (transform.position.y <= -5f)
        {   
            //already won, dont switch to lose
            if (score >= 7)
            {
                return;
            }
            StartCoroutine(ShowLoseAndRestart());

            //lose.gameObject.SetActive(true);
            //SceneManager.LoadScene(1);
            
        }

        IEnumerator ShowLoseAndRestart()
        {
            lose.SetActive(true);

            // wait for 4 seconds
            yield return new WaitForSeconds(4f);

            // reload the scene 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Debug.Log(Grounded);
    }
    
    private void FixedUpdate()
    {
        rb.AddForce(XInput * MoveSpeed, 0, YInput * MoveSpeed);
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
    }
    // check for collision with ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundCount++;
            Grounded = groundCount > 0; // player is touching the ground, can jump again
        }
    }
   
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundCount--;
            Grounded = groundCount > 0; // player is no longer touching the ground
        }
    }
    //trigger collider to count coints

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            score++;
            // if (coinAudio != null && coinSound != null)
            //{
            //    coinAudio.PlayOneShot(coinSound);
            //}
            //else
            //{
            //    Debug.LogWarning("Coin sound or AudioSource is not set up correctly!");
            //}
            //coinAudio.clip = coinSound;
            //coinAudio.Play();

            other.gameObject.SetActive(false);
            Grounded = true;
        }

        if (score >= 7)
        {
            win.SetActive(true);
            StartCoroutine(ShowWinAndRestart());

        }

        IEnumerator ShowWinAndRestart()
        {
            win.SetActive(true);

            // wait for 4 seconds
            yield return new WaitForSeconds(4f);

            // load menu
            SceneManager.LoadScene(0);
        }
    }
}
