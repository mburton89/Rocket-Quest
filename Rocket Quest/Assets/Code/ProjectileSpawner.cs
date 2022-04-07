using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireRate;
    [SerializeField] float spawnDelay;
    [SerializeField] float projectileSpeed;
    [SerializeField] Vector3 direction;

    void Start()
    {
        StartCoroutine(DelaySpawnProjectile());
    }

    private IEnumerator SpawnProjectile()
    {
        yield return new WaitForSeconds(spawnDelay);
        yield return new WaitForSeconds(fireRate);
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation, transform);
        projectile.GetComponent<Projectile>().Init(direction, projectileSpeed);
        StartCoroutine(SpawnProjectile());
    }

    private IEnumerator DelaySpawnProjectile()
    {
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnProjectile());
    }
}
