using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {

    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (transform.position.x <= -10f)
        {
            Destroy(this.gameObject);
        }
    }
}
