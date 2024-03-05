using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField] private float missileSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x - missileSpeed * Time.deltaTime, transform.position.y);

        if (transform.position.x <= -10f)
        {
            Destroy(this.gameObject);
        }
    }
}
