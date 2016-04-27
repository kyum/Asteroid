using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float buffer = 0.4f;
    public float turnspeed = 2.5f;
    public float speed = 3f;
    public GameObject shot;

    // Use this for initialization
    public Vector3 frontship;


    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //wraping screen
        Vector2 poz = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        if (Mathf.Abs(transform.position.x) > poz.x + buffer) transform.position = new Vector2(-transform.position.x, transform.position.y);
        if (Mathf.Abs(transform.position.y) > poz.y + buffer) transform.position = new Vector2(transform.position.x, -transform.position.y);


        //movement
        float turn = Input.GetAxis("Horizontal");
        float acceleration = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().AddTorque(-turn * turnspeed);
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * acceleration * speed, ForceMode2D.Force);


        //shoting
        Vector3 frontship= new Vector3(-0.55f*(Mathf.Sin(transform.localEulerAngles.z*Mathf.Deg2Rad)),0.55f*(Mathf.Cos(transform.localEulerAngles.z*Mathf.Deg2Rad)),0.0f);


        if (Input.GetKeyDown("space"))
        {
            GameObject newShot = (GameObject)Instantiate(shot, transform.position+frontship, transform.rotation);
            newShot.name = shot.name;
        }
    }
}
