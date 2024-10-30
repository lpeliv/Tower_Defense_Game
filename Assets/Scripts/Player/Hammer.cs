using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int damage = 10;
    public float range = 50f;
    public float fireRate = 15f;

    public Camera firstPersonCamera;

    private float nextTimeToFire = 0f;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate; 
            Swing();
        }
    }

    void Swing()
    {
        RaycastHit hit;
        if(Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, range))
        {
            Enemy targetEnemy = hit.transform.GetComponent<Enemy>();
            if(targetEnemy != null)
            {
                targetEnemy.TakeDamage(damage);
            }
        }
    }
}
