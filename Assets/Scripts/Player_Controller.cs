using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private float Speed = 20.0f;
    public GameObject Player;
    public GameObject Camera;
    private Vector3 Offset = new Vector3(-1, 4.12f, -4.6f);
    private float Turn_Speed = 100.0f;
    private float Horizontal_Input;
    private float Forward_Input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Horizontal_Input = Input.GetAxis("Horizontal");
        Forward_Input = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * Speed * Forward_Input);
        transform.Rotate(Vector3.up * Time.deltaTime * Turn_Speed * Horizontal_Input);
    }
    void LateUpdate()
    {
        Camera.transform.position = Player.transform.position + Offset;
        Camera.transform.rotation = Player.transform.rotation;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
        else if(other.gameObject.tag == "Check_Point")
        {
            Destroy(other.gameObject);
            Debug.Log("Package Delivered Succcessfully!");
        }
    }
}
// took me so much time to setup environment so I couldn't add much in code and it was already a week late ;_;