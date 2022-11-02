using System;
using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    private ObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>
        (
            CreateBullet,
            OnGet,
            OnRelease,
            OnDestroy,
            maxSize: 5
        );
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bulletPool.Get();
        }
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab);

        bullet.SetPool(bulletPool);

        return bullet;
    }   

    private void OnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position;
    }

    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
