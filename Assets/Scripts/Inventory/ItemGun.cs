using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Gun")]
public class ItemGun : Item
{
    [field: Space] 
    [field: SerializeField] public int BulletDamage { get; private set; }
    [field: SerializeField] public int Spread { get; private set; }
    [field: SerializeField] public int BulletNumber { get; private set; }
    [field: Space] 
    [field: SerializeField] public float CooldownTime { get; private set; }
    [field: SerializeField] public float SalveTimeBetweenBullets { get; private set; }

    [Space] 
    [SerializeField] private GameObject bullet;


    public bool _isOnCooldown; // TODO

    public IEnumerator Shoot(Vector2 start, Vector2 direction)
    {
        if (_isOnCooldown) yield break;
        
        _isOnCooldown = true;
        
        for (int i = 0; i < BulletNumber; i++)
        {
            direction.Normalize();

            float spread = RandomGaussian(-0.5f * Spread, 0.5f * Spread);
            direction = Quaternion.AngleAxis(spread, Vector3.forward) * direction;
            
            Instantiate(bullet, start + Vector2.up, Quaternion.identity).GetComponent<Bullet>().Shoot(direction);
            yield return new WaitForSeconds(SalveTimeBetweenBullets);
        }

        yield return new WaitForSeconds(CooldownTime);

        _isOnCooldown = false;

    }
    
    
    
    
    public static float RandomGaussian(float minValue, float maxValue)
    {
        float u, v, S;

        do
        {
            u = 2.0f * Random.value - 1.0f;
            v = 2.0f * Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }
}
