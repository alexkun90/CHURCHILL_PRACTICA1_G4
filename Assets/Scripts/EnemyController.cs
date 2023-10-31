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
    void Awake()
    {
        tanksKilled.text = _countTankKill.ToString();
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
            LevelManager.Instance.NextScene();
        }
    }
}
