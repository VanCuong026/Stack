using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCut : MonoBehaviour
{
    public static  CubeCut instance;
    public float _Xmax=0.5f, _Xmin=-0.5f, _Zmax=0.5f, _Zmin=-0.5f;
    public Vector3 _CurrentCubeCenter = new Vector3(0f, 0f, 0f);
    public Vector3 _LastCubeCenter = new Vector3(0f, 0f, 0f);
    public bool _StartXCut = false, _StartZCut = false,_StartSpawner=false,_StartGameOver=false;
    public Vector3 _CubeScale = new Vector3(1f, 0.1f, 1f);
    public Vector3 _LastCubeScale = new Vector3(1f, 0.1f, 1f);
    public bool _GameOver = false;
    public bool _XCutCalDone = false, _ZCutCalDone = false;
    float _PerfectLength = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (_StartXCut == true)
        {
            _XCut();
        }

        if (_StartZCut == true)
        {
            _ZCut();
        }
    }

    void _XCut()
    {
        string _DropCubePosition = "";
        _PerfectLength = _CubeScale.x * 0.02f;
        
        
        

        if (Mathf.Abs(_LastCubeCenter.x - _CurrentCubeCenter.x) > _PerfectLength) //So sanh neu vi tri lech nho hon 5% thi bo qua
        {
                if (_CurrentCubeCenter.x - _LastCubeCenter.x > ((_PerfectLength < _CubeScale.x) ? _PerfectLength : _CubeScale.x / 5))
                {
                    _Xmin = _Xmin + (_CurrentCubeCenter.x - _LastCubeCenter.x);
                    _DropCubePosition = "+X";
                }
                if (_LastCubeCenter.x - _CurrentCubeCenter.x > ((_PerfectLength < _CubeScale.x) ? _PerfectLength : _CubeScale.x / 5))
                {
                    _Xmax = _Xmax - (_LastCubeCenter.x - _CurrentCubeCenter.x);
                    _DropCubePosition = "-X";
                }

                if (_Xmax > _Xmin)
                {
                    _CubeScale.x = _Xmax - _Xmin;
                    DropCubeSpawner.instance._CurrentScale.x = _LastCubeScale.x - _CubeScale.x;//Tinh Scale của Cube bi bo di

                    if (_DropCubePosition == "+X")
                    {
                        DropCubeSpawner.instance._CurrentCenter.x = _Xmax + DropCubeSpawner.instance._CurrentScale.x / 2f;
                        DropCubeSpawner.instance._CurrentCenter.z = _LastCubeCenter.z;
                    }
                    if (_DropCubePosition == "-X")
                    {
                        DropCubeSpawner.instance._CurrentCenter.x = _Xmin - DropCubeSpawner.instance._CurrentScale.x / 2f;
                        DropCubeSpawner.instance._CurrentCenter.z = _LastCubeCenter.z;
                    }
                }
                else
                {
                    _GameOver = true;
                }

                _LastCubeScale = _CubeScale;
                _LastCubeCenter.x = (_LastCubeCenter.x + _CurrentCubeCenter.x) / 2f;
                DropCubeSpawner.instance._DontSpawner = false;
        }
        else 
        {
            _CurrentCubeCenter.x=_LastCubeCenter.x;
            DropCubeSpawner.instance._DontSpawner = true;

        }   
        

        _StartXCut = false;
        _StartSpawner = true;
        _XCutCalDone = true;

        if (_CurrentCubeCenter.x == _LastCubeCenter.x)
        {
            //PerfectSign.instance._StartPerfect = true;
        }
    }
    void _ZCut()
    {
        string _DropCubePosition = "";
        _PerfectLength = _CubeScale.z * 0.02f;
        
        

        if (Mathf.Abs(_LastCubeCenter.z - _CurrentCubeCenter.z) > _PerfectLength)
            {

                if (_CurrentCubeCenter.z - _LastCubeCenter.z > ((_PerfectLength < _CubeScale.z) ? _PerfectLength : _CubeScale.z / 5))
                {
                    _DropCubePosition = "+Z";
                    _Zmin = _Zmin + (_CurrentCubeCenter.z - _LastCubeCenter.z);
                }
                if (_LastCubeCenter.z - _CurrentCubeCenter.z > ((_PerfectLength < _CubeScale.z) ? _PerfectLength : _CubeScale.z / 5))
                {
                    _DropCubePosition = "-Z";
                    _Zmax = _Zmax - (_LastCubeCenter.z - _CurrentCubeCenter.z);
                }

                if (_Zmax > _Zmin)
                {
                    _CubeScale.z = _Zmax - _Zmin;
                    DropCubeSpawner.instance._CurrentScale.z = _LastCubeScale.z - _CubeScale.z;//Tinh Scale của Cube bi bo di

                    if (_DropCubePosition == "+Z")
                    {
                        DropCubeSpawner.instance._CurrentCenter.z = _Zmax + DropCubeSpawner.instance._CurrentScale.z / 2f;
                        DropCubeSpawner.instance._CurrentCenter.x = _LastCubeCenter.x;
                    }
                    if (_DropCubePosition == "-Z")
                    {
                        DropCubeSpawner.instance._CurrentCenter.z = _Zmin - DropCubeSpawner.instance._CurrentScale.z / 2f;
                        DropCubeSpawner.instance._CurrentCenter.x = _LastCubeCenter.x;
                    }
                }
                else
                {
                    _GameOver = true;
                }

                _LastCubeScale = _CubeScale;
                _LastCubeCenter.z = (_LastCubeCenter.z + _CurrentCubeCenter.z) / 2f;
                DropCubeSpawner.instance._DontSpawner = false;
        }
        else 
        {
            _CurrentCubeCenter.z=_LastCubeCenter.z;
            DropCubeSpawner.instance._DontSpawner = true;
        }
            
        
        
        _StartZCut = false;
        _StartSpawner = true;
        _ZCutCalDone = true;
    }
}
