using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour
{
    float speed = 5.0f;

    // camera setting
    public Camera firstPersonCamera;
    public Camera overheadCamera;
    public GameObject crossHair;
    public GameObject bullet;
    public GameObject firePoint;
    public GameObject explosion;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BasicCtrl();
        PerspectiveCtrl();
        AttackCtrl();
        Debug.Log(firePoint.transform.right);

    }

    void BasicCtrl()
    {
        // condtrol tank's transform
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0.0f, -5.0f * speed * Time.deltaTime, 0.0f);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0.0f, 5.0f * speed * Time.deltaTime, 0.0f);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0.0f, 0.0f, -speed * Time.deltaTime);

        // control tank's gun
        if (Input.GetKey(KeyCode.RightArrow))
            transform.GetChild(0).Rotate(0.0f, 0.0f, 5.0f * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.GetChild(0).Rotate(0.0f, 0.0f, -5.0f * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.GetChild(0).Rotate(-5.0f * speed * Time.deltaTime, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.GetChild(0).Rotate(05.0f * speed * Time.deltaTime, 0.0f, 0.0f);
    }

    void PerspectiveCtrl()
    {
        if (Input.GetKey(KeyCode.Q))
            ShowFirstPersonView();
        else if (Input.GetKey(KeyCode.E))
            ShowOverheadView();
    }

    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
        crossHair.SetActive(false);
    }
    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
        crossHair.SetActive(true);
    }

    public void AttackCtrl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clone;
            clone = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(firePoint.transform.right*1000);
        }
            
    }
}
