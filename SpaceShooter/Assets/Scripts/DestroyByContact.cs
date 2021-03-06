﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosionEffect, playerExplosionEffect;
    public int scoreValue;
    GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("GameController bulunamadı.");
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("boundry") || other.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        if(explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        
        gameController.AddScore(scoreValue);

        if (other.CompareTag("Player"))
        {
            Debug.Log("gemi vuruldu");
            Instantiate(playerExplosionEffect, other.transform.position, Quaternion.identity);
            gameController.GameOver();
            
        }

        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
