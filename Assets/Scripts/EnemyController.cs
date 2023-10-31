using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI tanksKilled;

    private bool _isCollide = false;

    void Awake()
    {
        tanksKilled.text = "0";
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (!_isCollide)
            {
                _isCollide = true;
                StateManager.Instance.setTanksKilled(StateManager.Instance.getTanksKilled() + 1);
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject); //esto es para destruir el el player
            LevelManager.Instance.NextScene();
        }
    }

    private void Update()
    {
        tanksKilled.text = StateManager.Instance.getTanksKilled().ToString();
    }
}
