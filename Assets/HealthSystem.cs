using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public string healthStatus;
    public string ShowHUD()
    {
        // Implement HUD display
        return "Health: " + health + " | Status: " + healthStatus;
    }
    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health = health - damage;
            // Implement damage logic
            if (health <= 0)
            {
                gameObject.SetActive(true);
            }
        }
        if (health > 100)
        {
            health = 100;
        }
        if (health < 0)
        {
            health = 0;
        }
        if (health <= 100)
        {
            healthStatus = "Perfect Health";
        }
        else if (health <= 90)
        {
            healthStatus = "Healthy";
        }
        else if (health <= 75)
        {
            healthStatus = "Hurt!";
        }
        else if (health <= 50)
        {
            healthStatus = "Badly Hurt!!";
        }
        else if (health <= 10)
        {
            healthStatus = "Imminent Danger!!!";
        }
        else if (health <= 0)
        {
            healthStatus = "Dead!";
        }
    }
}
