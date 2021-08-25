using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusView : MonoBehaviour, IBonusView, IDisposable
{
   
    public event IBonusView.GotBonus bonusPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>())
        {
            Debug.Log("in BonusView");
            bonusPickedUp?.Invoke();
            Dispose(gameObject);
        }

    }

    public void Dispose(GameObject obj) => Destroy(obj);

}
