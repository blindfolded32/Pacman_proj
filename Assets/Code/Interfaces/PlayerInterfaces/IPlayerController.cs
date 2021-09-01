using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerController 
{
    void OnUpdate();

    void SpeedModify(float multi);
}
