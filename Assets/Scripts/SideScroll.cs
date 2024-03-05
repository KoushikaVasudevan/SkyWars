using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroll : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float disappearingXPos;

    private void Start()
    {

    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        
        if(gameObject.tag == "flock")
        {
            if (transform.position.x >= disappearingXPos)
            {
                gameObject.transform.position = new Vector2(-6.7f, -1.7f);
                gameObject.SetActive(false);
            }

        }
        else if(gameObject.tag != "flock")
        {
            if (transform.position.x <= disappearingXPos)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
