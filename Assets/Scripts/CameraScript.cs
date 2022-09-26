using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private Camera _camera;
    private float _r = 0.196f;
    private float _g = 0.850f;
    private float _b = 0.196f;

    void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.backgroundColor = new Color(_r, _g, _b, 1);
    }

    void Update()
    {
        Rainbow();
    }

    void Rainbow()
    {

        if (_r < 0.850f && _g >= 0.850f && _b <= 0.196f)
        {
            _r += 0.001f;
        }
        else if (_r >= 0.850f && _g > 0.196f && _b <= 0.196f)
        {
            _g -= 0.001f;
        }
        else if (_r >= 0.850f && _g <= 0.196f && _b < 0.850f)
        {
            _b += 0.001f;
        }
        else if (_r > 0.196f && _g <= 0.196f && _b >= 0.850f)
        {
            _r -= 0.001f;
        }
        else if (_r <= 0.196f && _g < 0.850f && _b >= 0.850f)
        {
            _g += 0.001f;
        }
        else if (_r <= 0.196f && _g >= 0.850f && _b > 0.196f)
        {
            _b -= 0.001f;
        }

        _camera.backgroundColor = new Color(_r, _g, _b, 1);
       
    }

}
