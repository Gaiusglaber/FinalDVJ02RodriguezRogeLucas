using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour,IShootable
{
    public IEnumerator activeCourutine;
    public float rotationspeed;
    public GameObject ball;
    public Transform spawnPoint;
    public float rangeX = 15f;
    public float speed;
    private float angle;
    public LayerMask layer;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetInstance() != null && !GameManager.GetInstance().pause)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycasthit, float.MaxValue, layer))
                {
                    Vector3 dir = raycasthit.point;
                    AimToShoot(dir);
                }
            }
        }
    }
    public void AimToShoot(Vector3 dir)
    {
        StartCoroutine(AimTurret(dir));
    }

    IEnumerator AimTurret(Vector3 dir)
    {
        Quaternion startingRotation = transform.rotation;
        Quaternion finalRotation = Quaternion.identity;
        Vector3 aimDirection = dir - transform.position;
        finalRotation.SetLookRotation(aimDirection, transform.up);
        float t = 0;
        while (t < 1)
        {
            transform.rotation = Quaternion.Slerp(startingRotation, finalRotation, t);
            t += Time.deltaTime * rotationspeed;
            yield return null;
        }
        Shoot();
    }
    public void Shoot()
    {
        GameObject instanciateBall = Instantiate(ball,spawnPoint.position,transform.rotation);
        instanciateBall.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*rangeX, ForceMode.Impulse);
    }
}
