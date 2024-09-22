using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat
{
    public void Shoot(GameObject bullet, Player player)
    {
        Debug.Log("shoot started");
        GameObject bulletCopy = Object.Instantiate(bullet, player.transform.position, player.transform.rotation);
        Bullet bulletProperties = bulletCopy.GetComponentInChildren<Bullet>();
        Rigidbody bulletRb = bulletCopy.GetComponentInChildren<Rigidbody>();
        bulletRb.AddForce(bulletCopy.transform.forward * bulletProperties.Speed, ForceMode.Impulse);
        Debug.Log(bulletProperties.Speed);
        IEnumerator DestroyOnLifetimeExpire()
        {
            Debug.Log("coroutine started");
            yield return new WaitForSeconds(bulletProperties.Lifetime);
            Object.Destroy(bulletCopy);
            Debug.Log("CoroutineEnded");
        }
        bulletProperties.StartCoroutine(DestroyOnLifetimeExpire());
        Debug.Log("shoot ended");
        
    }
}
