using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public GameObject TankRespaw;
    public float minX, maxX, minY, maxY;

    void Start()
    {
        // Instanciar 5 tanques al comienzo del juego
        for (int i = 0; i < 4; i++)
        {
            InstantiateTankAtRandomPosition();
        }

        // Iniciar una rutina para instanciar tanques nuevos cada 15 segundos
        StartCoroutine(InstantiateNewTanks());
    }

    void InstantiateTankAtRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        Instantiate(TankRespaw, randomPosition, Quaternion.identity);
    }

    IEnumerator InstantiateNewTanks()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f); // Esperar 15 segundos
            for (int i = 0; i < 3; i++)
            {
                InstantiateTankAtRandomPosition();
            }
        }
    }

}
