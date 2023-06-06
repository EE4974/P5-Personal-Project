using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float speed = 11.0f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 11.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        { 
            transform.Translate( Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        { 
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
