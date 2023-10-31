using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public GameObject TankRespawn;
    private GameObject _copy;
    public float minX, maxX, minY, maxY;

    [SerializeField]
    TextMeshProUGUI tanksSpawn;

    [SerializeField] GameObject Player;

    [SerializeField]
    int _countTankSpawn = 1;

    void Awake()
    {
        _copy = Instantiate(TankRespawn);
        _copy.SetActive(false);
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
        Vector3 randomPosition;
        do
        {
            randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        }
        while (isInCircle(randomPosition, Player.transform.position, 5.0F));

        GameObject newInstance = Instantiate(_copy, randomPosition, Quaternion.identity);
        newInstance.SetActive(true);
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

    private bool isInCircle(Vector3 point, Vector3 center, float radius)
    {
        return Mathf.Sqrt(Mathf.Pow((center.x - point.x),2) + Mathf.Pow((center.y - point.y), 2)) <= radius;
    }

}
