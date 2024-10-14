using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _lifetime;
    [SerializeField] private float _width;
    private float _remainingLifetime;

    public Collider2D Shoot(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 100, ~LayerMask.GetMask("Player", "UI", "Interactable"));
        
        Debug.Log("HIT: " + hit.collider + " AT " + hit.point);
        _lineRenderer.SetPosition(1, hit.collider ? hit.point - (Vector2)transform.position : direction * 100);
        
        StartCoroutine(Decay());
        
        return hit.collider;
    } 
    
    
    private IEnumerator Decay()
    {
        _remainingLifetime = _lifetime;
        
        while (_remainingLifetime > 0)
        {
            _lineRenderer.widthMultiplier = _remainingLifetime/_lifetime * _width;
            _remainingLifetime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);
    }
}
