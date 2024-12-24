using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int damage = 10;
    public float range = 50f;
    public float fireRate = 2f;
    //This will be used later for hitting multiple enemies instead of one
    public float hitRadius = 2f;

    public Camera firstPersonCamera;
    public Animator animator;

    private float nextTimeToFire = 0f;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate; 
            Swing();
        }
    }

    void Swing()
    {
        animator.SetTrigger("Attack");
    }

    //Called as animation event
    void DealDamage()
    {
        RaycastHit hit;
        if(Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, range))
        {
            Debug.DrawLine(firstPersonCamera.transform.position, hit.point, Color.red, 1f);
            Enemy targetEnemy = hit.transform.GetComponent<Enemy>();
            if(targetEnemy != null)
            {
                targetEnemy.TakeDamage(damage);
            }
        }
    }

    public void HammerUpgraded(int newDamage, float newRange, float newFireRate)
    {
        Debug.Log($"Before Upgrade: Damage={damage}, Range={range}, FireRate={fireRate}");
        damage += newDamage;
        range += newRange;
        fireRate += newFireRate;
        Debug.Log($"After Upgrade: Damage={damage}, Range={range}, FireRate={fireRate}");
    }
}
