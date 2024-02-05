using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private int points;
    [SerializeField] private int lifes;

    [SerializeField]private GameObject explosionParticle;

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
        if (!gameManager.IsGameOver())
        {
            gameManager.UpdateScore(points);
            gameManager.UpdateLifes(lifes);
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
        
    }

    private void OnDestroy()
    {
        gameManager.targetPositionsInScene.Remove(transform.position);
    }

    public void SetLifeTime(int newLifeTime)
    {
        lifeTime = newLifeTime;
    }

}
