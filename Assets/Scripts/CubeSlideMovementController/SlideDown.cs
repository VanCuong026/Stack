using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDown : MonoBehaviour
{
    public static SlideDown instance;
    public bool _Down = false;
    public int _DownSwitch = 0;
    float _Target = 0;
    float _DownSpeed = 0.3f;
    public bool _LeftDone, _RightDone;
    [SerializeField]
    private GameObject _RightCube, _LeftCube;
    public string _Switch = "";
    float _RightTarget, _LeftTarget;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _DownSwitch++;
            _Target = transform.position.y - 0.1f;
            _RightTarget= _Target + 0.05f;
            _LeftTarget = _Target + 0.05f;
        }
        if((_Down == true||_DownSwitch>0) && CubeCut.instance._GameOver == false)
        {
            _SlideDown();
        }
    }
    void _SlideDown()
    {
        Vector3 temp = transform.position;
        if (temp.y - _Target >= 0.0001f)
        {
            temp.y -= Time.deltaTime*_DownSpeed;
            transform.position = temp;
        }
        if (temp.y - _Target <= 0.0001f)
        {
            temp.y =_Target;
            transform.position = temp;
            _Down = false;
            
            if(_Switch == "Left")
            {
                Vector3 tempRightPosition = _RightCube.transform.position;
                tempRightPosition.y = _Target + 0.05f;
                _RightCube.transform.position = tempRightPosition;
            }

            if (_Switch == "Right")
            {
                Vector3 tempLeftPosition = _LeftCube.transform.position;
                tempLeftPosition.y = _Target + 0.05f;
                _LeftCube.transform.position = tempLeftPosition;
            }
               
        }

        /*if (_Switch == "Left")
        {
            Vector3 tempRightPosition = _RightCube.transform.position;
            if(tempRightPosition.y- _RightTarget>0.01f)
            {
                tempRightPosition.y -= Time.deltaTime*1f;
                _RightCube.transform.position = tempRightPosition;
            }
            if (tempRightPosition.y - _RightTarget<=0.01f)
            {
                tempRightPosition.y = _RightTarget;
                _RightCube.transform.position = tempRightPosition;
            }

        }

        if (_Switch == "Right")
        {
            Vector3 tempLeftPosition = _LeftCube.transform.position;
            if (tempLeftPosition.y - _LeftTarget>0.01f)
            {
                tempLeftPosition.y -= Time.deltaTime*1f;
                _LeftCube.transform.position = tempLeftPosition;
            }
            if (tempLeftPosition.y - _LeftTarget<=0.01f)
            {
                tempLeftPosition.y = _LeftTarget;
                _LeftCube.transform.position = tempLeftPosition;
            }

        }*/
    }
}
