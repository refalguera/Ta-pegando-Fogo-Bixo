using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private float _speed = 6;

    [HideInInspector]
    public bool _objectDirection;

    private bool _facingright = false;
    
    //Control weapon movement
    void Update()
    {
        if (_objectDirection)
            {
                flip();
                transform.Translate(Vector3.right * _speed * Time.deltaTime);

            }
            else if (!_objectDirection)
            {
                flip();
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
        Destroy(this.gameObject, 2f);
    }
    //Checks for collisions with objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Building" || collision.collider.tag == "Thorugh")
        { 
            Destroy(this.gameObject);
        }
        else if(collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Damage();
            Destroy(this.gameObject);
        }
        
    }
    private void flip()
    {
        _facingright = !_facingright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
