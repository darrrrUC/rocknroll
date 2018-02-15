using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour {

    public float speed;
    private Camera cam;
    public Material playerSkin;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (isLocalPlayer)
        {
            
            return;
        }

        cam.enabled = false;
        

    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        var tmp = cam.transform.position = this.transform.position;
        tmp.y = this.transform.position.y +5;
        tmp.z = this.transform.position.z -10;
        cam.transform.position = tmp;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }


    public override void OnStartLocalPlayer()
    {
        cam = Camera.main;

        var render = GetComponent<Renderer>();
        render.material = playerSkin;
    }
}
