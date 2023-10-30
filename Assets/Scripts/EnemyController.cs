using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    int _countTankKill = 0;
    [SerializeField]
    TextMeshProUGUI tanksKilled;

    public GameObject TankRespaw;
    public float minX, maxX, minY, maxY;

    [SerializeField]
    TextMeshProUGUI tanksSpawn;

    [SerializeField]
    int _countTankSpawn = 1;

    void Awake()
    {
        tanksKilled.text = _countTankKill.ToString();
    }

    

    void Start()
    {

        // Instanciar 5 tanques al comienzo del juego
        for (int i = 0; i < 4; i++)
        {
            _countTankSpawn++;
            tanksSpawn.text = _countTankSpawn.ToString();
            StateManager.Instance.setTanksSpawned(_countTankSpawn);

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
                _countTankSpawn++;
                tanksSpawn.text = _countTankSpawn.ToString();
                StateManager.Instance.setTanksSpawned(_countTankSpawn);
                InstantiateTankAtRandomPosition();
            }
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            _countTankKill++;
            tanksKilled.text = _countTankKill.ToString();
            StateManager.Instance.setTanksKilled(_countTankKill);
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject); //esto es para destruir el el player
            //LevelManager.Instance.NextScene();
        }
    }
}
