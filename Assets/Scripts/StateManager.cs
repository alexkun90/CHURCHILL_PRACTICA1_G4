using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    string _name;
    int _tanksKilled;
    int _tanksSpawned;
    
    //Esto es un comentario


    public string getName()
    {
        return _name;
    }

    public void setName(string newName)
    {
        _name = newName;
    }

    public int getTanksKilled()
    {
        return _tanksKilled;
    }

    public void setTanksKilled(int newTanksKilled)
    {
        _tanksKilled = newTanksKilled;
    }
    public int getTanksSpawned()
    {
        return _tanksSpawned;
    }

    public void setTanksSpawned(int newTanksSpawn)
    {
        _tanksSpawned = newTanksSpawn;
    }
}