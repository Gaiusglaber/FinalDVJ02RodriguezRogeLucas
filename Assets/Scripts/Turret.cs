using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour,IShootable
{
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
    }
    public void Shoot()
    {

    }
}
