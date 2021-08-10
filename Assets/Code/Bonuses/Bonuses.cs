using UnityEngine;
using static UnityEngine.Debug;
using UnityEngine.EventSystems;

namespace Scripts.Game 
{
public class Bonuses : MonoBehaviour, IDisposable
{
        GameObject go;
        protected PlayerControl _playerControl;
    protected enum Bonus_state
    {
        IsExpiring,
        IsCollected
    }

   protected Bonus_state _bonus_state;
  void Start()
    {
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

        if (_bonus_state == Bonus_state.IsCollected || _bonus_state != Bonus_state.IsExpiring)
        {
            return;
        }
        _bonus_state = Bonus_state.IsCollected;
        _playerControl = go_player.GetComponent<PlayerControl>();
        GotBonus();
        ExecuteEvents.Execute<IBonusCollected>(go, null, (x, y) => x.OnBonusCollected(this, _playerControl));
        ExecuteEvents.Execute<IBonusCollected>(go, null, (x, y) => x.OnPillBonusCollected(this, _playerControl));
        }

    protected virtual void GotBonus()
    {
       Log("Got It: ");
    }

    protected virtual void BonusEnding()
    {
        if (_bonus_state == Bonus_state.IsExpiring)
        {
            return;
        }
        _bonus_state = Bonus_state.IsExpiring;
            ExecuteEvents.Execute<IBonusCollected>(go, null, (x, y) => x.OnBonusExpired(this, _playerControl));
               
    }

    public void Dispose(GameObject obj)
    {
        Destroy(obj);
    }
}
}
