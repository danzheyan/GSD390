using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    float XInput;
    float YInput;

    int score;
    int t = 4;

    public GameObject win;
    public GameObject lose;

    Rigidbody rb;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        XInput = Input.GetAxis("Horizontal");
        YInput = Input.GetAxis("Vertical");

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
            if (score >= 6)
            {
                return;
            }
            StartCoroutine(ShowLoseAndRestart());

            //lose.gameObject.SetActive(true);
            //SceneManager.LoadScene(1);
            
        }

        IEnumerator ShowLoseAndRestart()
        {
            // Activate the lose text
            lose.SetActive(true);

            // Wait for 4 seconds
            yield return new WaitForSeconds(4f);

            // Reload the scene (current scene index)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(XInput * MoveSpeed, 0, YInput * MoveSpeed);
    }
    //trigger collider to count coints
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            score++;
            other.gameObject.SetActive(false);
        }

        if (score >= 6)
        {
            win.SetActive(true);
            StartCoroutine(ShowWinAndRestart());

        }

        IEnumerator ShowWinAndRestart()
        {
            // Activate the lose text
            win.SetActive(true);

            // Wait for 4 seconds
            yield return new WaitForSeconds(4f);

            // Reload the scene (current scene index)
            SceneManager.LoadScene(0);
        }
    }
}
