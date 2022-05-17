using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform target;
    private Enemy enemyTarget;

    [Header("Turret Stats")]
    [SerializeField]private float range = 15;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Turret Turn")]
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private Transform rotationPart;

    [Header("Tag")]
    public string enemyTag = "Enemy";

    [Header("Laser Turret")]
    [SerializeField] private bool useLaser = false;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int damageOverTime = 10;
    [SerializeField] private float slowPercentage = 0.3f;


    [Header("Extras")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private void Start()
    {
        InvokeRepeating("TargetUpdate", 0f, 0.5f);
    }
    private void TargetUpdate()
    {
        if (GameManager.gameEnded) return;

        //Find Enemies to lock
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            //Lock to enemies by distance
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            enemyTarget = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (GameManager.gameEnded) return;

        //See if the target isn't null and disable the lineRenderer
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }
            return;
        }

        TargetLockOn();

        //See if the Turret is using a Laser
        if (useLaser)
        {
            LaserFire();
        }
        else
        {

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    private void TargetLockOn()
    {
        //Lock to target and rotate
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationPart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotationPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void LaserFire()
    {
        //Lock to target and apply DOT
        enemyTarget.TakeDamage(damageOverTime * Time.deltaTime);
        enemyTarget.Slow(slowPercentage);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }
    void Shoot()
    {
        GameObject ActiveBullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        StandardBullet bullet = ActiveBullet.GetComponent<StandardBullet>();

        if(bullet != null)
        {
            bullet.Chase(target);
        }   
    }

    //Gizmos to see the range of towers
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
