using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScore 
{
    void ScoreIncrease();
    void ChangeMulti(float value);
    delegate void Collected();
     event Collected OnCollect;
     float score { get; }
     float multi { set; }
}
