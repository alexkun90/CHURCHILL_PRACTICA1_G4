using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tanksKilled;

    [SerializeField]
    TextMeshProUGUI name;

    [SerializeField]
    TextMeshProUGUI tankspawn;

    protected virtual void Awake()
    {
        name.text = StateManager.Instance.getName();
        tankspawn.text = StateManager.Instance.getTanksSpawned().ToString();
        tanksKilled.text =  StateManager.Instance.getTanksKilled().ToString();
    }

    public void Reiniciar()
    {
        StateManager.Instance.setTanksKilled(0);
        StateManager.Instance.setTanksSpawned(0);
        LevelManager.Instance.FirstScene();
    }

}