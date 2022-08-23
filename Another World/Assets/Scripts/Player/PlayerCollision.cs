using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
    }

    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log("ENTRANDO EN COLISION CON ->" + other.gameObject.name);
        if (other.gameObject.CompareTag("Gems"))
        {
            Destroy(other.gameObject);
            //sumar vida
            playerData.Healing(other.gameObject.GetComponent<Gems>().HealPoints);
        }

        if (other.gameObject.CompareTag("Enemies"))
        {
            Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
            playerData.Damage(other.gameObject.GetComponent<EnemyDamage>().DamagePoints);
            Destroy(other.gameObject);
            if (playerData.HP <= 0)
            {
                Debug.Log("GAME OVER");
            }


        }


    }
}