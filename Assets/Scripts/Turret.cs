using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour,IShootable
{
    public GameObject ball;
    public Transform spawnPoint;
    public float range = 15f;
    public float speed;
    private float angle;
    void RotateTurret()
    {
        angle += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        Mathf.Clamp(angle, 0, 360);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
    // Update is called once per frame
    void Update()
    {
        RotateTurret();
        Shoot();
    }
    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instanciateBall = Instantiate(ball,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
                transform.rotation);
            instanciateBall.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
        }
    }
}
