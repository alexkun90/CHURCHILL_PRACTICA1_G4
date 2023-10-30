using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tanksKilled;

    //[SerializeField]
    //TextMeshProUGUI name;

    [SerializeField]
    TextMeshProUGUI tankspawn;

    protected virtual void Awake()
    {
        //name.text = StateManager.Instance.getName();
        tankspawn.text = StateManager.Instance.getTanksKilled().ToString();
        tanksKilled.text = StateManager.Instance.getTanksSpawned().ToString();
    }

    public void Reiniciar()
    {
        LevelManager.Instance.FirstScene();
    }

}