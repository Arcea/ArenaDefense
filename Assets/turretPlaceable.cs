using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class turretPlaceable : Placeable
{
    private GameObject[] enemies;

    private GameObject target;
    public GameObject bullet;
    private bool allowFire;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", lifeTime);
        enemies = new GameObject[0];
        allowFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        if (enemies.Length > 0)
        {
            target = GetClosestEnemy(enemies);
        }


        if (target != null) 
        {

            if (target != null)
            {
                Vector3 dir = target.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                StartCoroutine(FireWeapon());
            }
        }
        else
        {
            transform.Rotate(new Vector3(15, 0, 45) * Time.deltaTime);
        }
    }

    IEnumerator FireWeapon()
    {
        if (allowFire)
        {
            allowFire = false;
            var rotation = transform.rotation;
            GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), rotation *= Quaternion.Euler(0, 0, -90));
            yield return new WaitForSeconds(0.5f);
            allowFire = true;
        }
    }

    GameObject GetClosestEnemy(GameObject[] enemies)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        if (Vector3.Distance(currentPosition, bestTarget.transform.position) < 25f)
        {
            return bestTarget;
        }

        return null;
    }
}
