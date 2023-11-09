using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera cameraToShake;
    [SerializeField] private CameraShake cameraShakeScript;
    public GameObject player;
    public GameObject monster;
    private float distanceToMonster;
    private float newShakeAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMonster = Vector2.Distance(player.transform.position, monster.transform.position);
        newShakeAmount =  1/(distanceToMonster);
        newShakeAmount = Mathf.Min(newShakeAmount, 0.9f);
        if (distanceToMonster > 6f)
        {
            newShakeAmount = 0;
        }
        cameraShakeScript.shakeAmount = newShakeAmount;


    }
}
