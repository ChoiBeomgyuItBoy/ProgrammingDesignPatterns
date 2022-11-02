using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 speed;

    private ObjectPool<Bullet> bulletPool;

    public void SetPool(ObjectPool<Bullet> bulletPool)
    {
        this.bulletPool = bulletPool;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        bulletPool.Release(this);
    }
}
