using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IPlayerAffix : IEventSystemHandler
{
    public void Speeding_player(float speedaffix);
    public void Scoring_player(float scoreaffix);
        
}
