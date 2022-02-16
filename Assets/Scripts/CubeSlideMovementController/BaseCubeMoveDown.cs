using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCubeMoveDown : MonoBehaviour
{
    [SerializeField]
    private GameObject _BaseCube;
    private float _Speed = 0.3f;
    bool _DownSwitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SlideDown.instance._Down == true|| SlideDown.instance._DownSwitch>0)
        {
            _DownSwitch = true;
        }
        if (_DownSwitch == true && CubeCut.instance._GameOver == false)
        {
            _BaseCubeMoveDown();
        }
    }

    void _BaseCubeMoveDown()
    {
        if(_BaseCube.transform.position.y+ SlideController.instance._Score*0.1 >= 0.01f&&CubeCut.instance._GameOver == false)
        {
            Vector3 temp = _BaseCube.transform.position;
            temp.y -= Time.deltaTime * _Speed;
            _BaseCube.transform.position = temp;
        }
        if (_BaseCube.transform.position.y + SlideController.instance._Score*0.1 <= 0.01f && CubeCut.instance._GameOver == false)
        {
            Vector3 temp = _BaseCube.transform.position;
            temp.y = -SlideController.instance._Score * 0.1f;
            _BaseCube.transform.position = temp;
            SlideController.instance._DownSwitch = false;
            _DownSwitch = false;
        }
    }
}
