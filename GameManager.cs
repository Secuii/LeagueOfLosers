using UnityEngine;

public class GameManager : MonoBehaviour
{



    static public void GameFinish(int _playerIndex)
    {
        Debug.Log("ha ganado el jugador: " + _playerIndex);
    }
}