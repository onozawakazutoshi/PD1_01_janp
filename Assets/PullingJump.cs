using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpPower = 10;
    private Vector3 clickPosition;
    private bool isCanJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (isCanJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;

            if(dist.sqrMagnitude == 0)
            {
                return;
            }
            rb.velocity = dist.normalized * jumpPower;
            isCanJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCanJump = true;
        Debug.Log("�Փ˂���");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("�ڐG��");
    }

    private void OnCollisionExit(Collision collision)
    {
        //isCanJump = false;
        Debug.Log("���E����");
    }
}
