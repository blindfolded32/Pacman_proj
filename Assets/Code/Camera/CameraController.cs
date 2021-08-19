using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : ICameraController
{
    private readonly ICameraView _cameraView;
    private ICameraModel _cameraModel;

   public CameraController(ICameraView cameraView, ICameraModel cameraModel)
    {
        _cameraView = cameraView;
        _cameraModel = cameraModel;
    }

    public void Shake(float duration)
    {
        Quaternion _originalRotation = _cameraModel.Rotation;
        ShakigCamera(duration, _originalRotation);
        _cameraView.Camera.transform.localRotation = _originalRotation;
    }

    IEnumerator ShakigCamera(float duration, Quaternion rotation)
    {

        float timeLeft = Time.time;

        while ((timeLeft + duration) > Time.time)
        {
            _cameraView.Camera.transform.localRotation = new Quaternion(rotation.x, Random.Range(-0.02f, 0.02f), Random.Range(-0.02f, 0.02f), 1.0f);
            yield return new WaitForSeconds(0.025f);

        }

    }
}
