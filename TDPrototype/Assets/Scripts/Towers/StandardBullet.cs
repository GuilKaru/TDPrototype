using UnityEngine;

public class StandardBullet : MonoBehaviour
{
    private Transform target;

    [Header("Stats of Bullets")]
    public float speed = 50f;
    public int damage = 50;
    public void Chase(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float actualDistance = speed * Time.deltaTime;

        if(dir.magnitude <= actualDistance)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * actualDistance, Space.World);
    }

    private void HitTarget()
    {
        DamageEnemy(target);
    }

    void DamageEnemy(Transform enemy)
    {
        //Damage enemies and destrois the Bullet Object
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }

        Destroy(gameObject);
        
    }
}
