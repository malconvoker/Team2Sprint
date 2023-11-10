using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MoveReverse : MonoBehaviour
{
    private MoveBackAndForth mover;
    [SerializeField] private float waitMultiplier = 1f;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if colliding object is the correct type
        if (other.gameObject.GetComponent<MoveBackAndForth>() != null)
        {
            mover = other.gameObject.GetComponent<MoveBackAndForth>();
            mover.TurnAround(waitMultiplier);
        }
    }
}
