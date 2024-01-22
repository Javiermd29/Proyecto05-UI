using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] private float lifeTime = 2f;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.Remove(transform.position);
    }

}
