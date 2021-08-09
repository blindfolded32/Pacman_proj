using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bonuses : MonoBehaviour, IDisposable
{

    public bool expiresImmediately;
    GameObject go;
    protected PlayerControl _playerControl;
    protected enum Bonus_state
    {
        InAttractMode,
        IsCollected,
        IsExpiring
    }

    protected Bonus_state _bonus_state;
  void Start()
    {
        _bonus_state = Bonus_state.InAttractMode;
        go = GameObject.FindGameObjectWithTag("Player");
    }

     void OnTriggerEnter(Collider other)
    {
        BonusCollected(other.gameObject);

    }

     void BonusCollected(GameObject go_player)
    {
        
        if (go_player.tag != "Player")
        {
            return;
        }

        if (_bonus_state == Bonus_state.IsCollected || _bonus_state == Bonus_state.IsExpiring)
        {
            return;
        }
        _bonus_state = Bonus_state.IsCollected;

        // We must have been collected by a player, store handle to player for later use      
        _playerControl = go_player.GetComponent<PlayerControl>();
  
        PowerUpPayload();
   
            ExecuteEvents.Execute<IBonusCollected>(go, null, (x, y) => x.OnBonusCollected(this, _playerControl));
      
    }

    protected virtual void PowerUpPayload()
    {
        Debug.Log("Power Up collected, issuing payload for: " + gameObject.name);

        // If we're instant use we also expire self immediately
        if (expiresImmediately)
        {
            BonusEnding();
        }
    }

    protected virtual void BonusEnding()
    {
        if (_bonus_state == Bonus_state.IsExpiring)
        {
            return;
        }
        _bonus_state = Bonus_state.IsExpiring;

        // Send message to any listeners
      
            ExecuteEvents.Execute<IBonusCollected>(go, null, (x, y) => x.OnBonusExpired(this, _playerControl));
   

    }

    public void Dispose(GameObject obj)
    {
        Destroy(obj);
    }
}
