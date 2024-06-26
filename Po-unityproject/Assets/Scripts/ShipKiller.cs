using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipKiller : ShipScript
{

    public string enemyTag;
    [SerializeField] public GameObject followedShip;
    public bool isFollowing = false;


        void Start()
    {
        Prepare();
    }


    void Update()
    {
        if(isFollowing && followedShip != null){
            Follow();
        }
        else{
            Move();
        }
        
    }

    //colider podstawowy - wielkosci sprita - sluzy do niszeczenia i bycia niszczonym
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == 6 && collision.gameObject.CompareTag(enemyTag) && !collision.gameObject.GetComponent<PoorShip>().isMining)
        {
            print("destroy");
            //warunek póki co nie pozwala zacząć przyjmowania surowców ponad górny limit, ale nie wyklucza ze zebrae za jedym podejsciem przekrocza ten limit
            if (ironCapacity + tytanCapacity < Capacity)
            {
                ironCapacity += collision.gameObject.GetComponent<ShipScript>().ironCapacity;
                tytanCapacity += collision.gameObject.GetComponent<ShipScript>().tytanCapacity;
            }
            ShipDestroyer(collision.gameObject);
        }
        else if (collision.gameObject.layer == 8 && collision.gameObject.CompareTag(enemyTag)) 
        {
            ShipDestroyer(collision.gameObject);
        }
        
    }

    private new void Prepare(){
        world = GameObject.Find("World");
        SetBasePosition();
        gameManager = world.GetComponent<GameManager>();
        SetFollowPosition();
        x = followPosition.x;
        y = followPosition.y;

        //ustawienie poszukiwanego tagu na przeciwnika
        if(gameObject.tag == "Red"){enemyTag = "Blue";}
        else{enemyTag = "Red";}
    }

    private void Follow(){
        transform.position = Vector2.MoveTowards(transform.position, followedShip.transform.position, shipSpeed * Time.deltaTime);
    }
}
