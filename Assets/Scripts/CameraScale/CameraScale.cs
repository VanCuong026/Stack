using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScale : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    float _angle = 25f;

    [SerializeField]
    private GameObject _RestartButton;

    [SerializeField]
    private GameObject _RestartText;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.orthographicSize = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeCut.instance._GameOver == true)
        {
            _RestartButton.SetActive(true);
            _RestartText.SetActive(true);
        }
        if (CubeCut.instance._GameOver == true && SlideController.instance._Score>=15)
        {
            
            if (_camera.orthographicSize<= SlideController.instance._Score * 0.08f)
            {
                _camera.orthographicSize += Time.deltaTime/3f;
            }
            if (_angle>20)
            {
                _angle -= Time.deltaTime*4f;
                transform.rotation = Quaternion.Euler(_angle, -135f, 0);
            }
            if (transform.position.y > 0.5f)
            {
                Vector3 temp = transform.position;
                temp.y-= Time.deltaTime;
                transform.position = temp;
            }
        }
    }

    public void _TapToRestart()
    {
        _RestartButton.SetActive(false);
        _RestartText.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
    }
}
