using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool indestructible = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit(){
        if(!indestructible){
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null){
            player.Hit();
        }
    }

}
