using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : ICameraController
{
    private readonly ICameraView _cameraView;
    private ICameraModel _cameraModel;

    private float nextActionTime = 0.0f;
    public float period = 0.0025f;
 //   public event IBonusView.GotBonus _bonusCollect;
    [SerializeField] private float _duration = 0.85f;

    public CameraController(ICameraView cameraView, ICameraModel cameraModel, IBonusController bonusController)
    {
        _cameraView = cameraView;
        _cameraModel = cameraModel;

        
        bonusController.SpeedCollect += (x) => Shake();
    }

    public void Shake()    { Shake(1.0f); }
    public void Shake(float duration)
    {

        Debug.Log("Shake it");
        Quaternion _originalRotation = _cameraView.Camera.transform.localRotation;
        //ShakigCamera(duration);

        //****
        float StartTime = Time.time;
            Debug.Log($"time left {StartTime + duration} and { Time.time}");
        while (StartTime + duration < Time.time)

        {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            _cameraView.Camera.transform.localRotation = new Quaternion(_cameraView.Camera.transform.localRotation.x, UnityEngine.Random.Range(-0.02f, 0.02f), UnityEngine.Random.Range(-0.02f, 0.02f), 1.0f);
        }
        }
        _cameraView.Camera.transform.localRotation = _originalRotation;*/
    }



    IEnumerator ShakigCamera(float duration)
    {

        float timeLeft = Time.time;

        while ((timeLeft + duration) > Time.time)
        {
            Debug.Log("Shake");
            _cameraView.Camera.transform.localRotation = new Quaternion(_cameraView.Camera.transform.localRotation.x, UnityEngine.Random.Range(-0.02f, 0.02f), UnityEngine.Random.Range(-0.02f, 0.02f), 1.0f);
            yield return new WaitForSeconds(0.025f);

        }

    }

    public void OnInit()
    {
       
    }
}
