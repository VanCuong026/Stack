using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCubeSpawner : MonoBehaviour
{
    public static DropCubeSpawner instance;
    [SerializeField]
    private GameObject _DropCube;

    //public float _LastXmax=0.5f, _LastXmin=-0.5f, _LastZmax=0.5f, _LastZmin=-0.5f, _CurrentXmax = 0.5f, _CurrentXmin =-0.5f, _CurrentZmax = 0.5f, _CurrentZmin = -0.5f;
    public Vector3 _CurrentScale=new Vector3(1f,1f,1f), _CurrentCenter=new Vector3(0f, 0.45f, 0f);
    public bool _DropCubeSpawner = false, _DontSpawner = false,_LastCubeFall=false,_SetActiveDone=false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        _DropCube.transform.localScale = _CurrentScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeCut.instance._XCutCalDone)
        {
            _CurrentScale.z = CubeCut.instance._CubeScale.z;
            CubeCut.instance._XCutCalDone = false;
            _DropCubeSpawner = true;
        }

        if (CubeCut.instance._ZCutCalDone)
        {
            _CurrentScale.x = CubeCut.instance._CubeScale.x;
            CubeCut.instance._ZCutCalDone = false;
            _DropCubeSpawner = true;
        }

        if (_DropCubeSpawner == true && CubeCut.instance._GameOver == false&& _DontSpawner == false && _CurrentScale.x != 0 && _CurrentScale.z != 0)
        {
            GameObject _gob = Instantiate(_DropCube, _CurrentCenter,Quaternion.identity);
            _gob.transform.localScale = _CurrentScale;
            _gob.transform.position = _CurrentCenter;
            Renderer _Cube;
            _Cube = _gob.GetComponent<Renderer>();
            _Cube.material.color = Color.HSVToRGB(SlideController.instance._Score * 0.02f + 0.5f - 0.02f, 1f, 1f);
            _gob.SetActive(true);
            _DropCubeSpawner = false;
        }
        if(CubeCut.instance._GameOver == true&& _LastCubeFall==false&& _CurrentScale.x!=0&& _CurrentScale.z != 0) //Neu GameOver thi se xoa cai Cube cuoi cung va thay bang dropCube
        {
            _CurrentCenter = CubeCut.instance._CurrentCubeCenter;
            GameObject _gob = Instantiate(_DropCube, _CurrentCenter, Quaternion.identity);
            _gob.transform.localScale = _CurrentScale;
            _gob.transform.position = _CurrentCenter;
            _gob.SetActive(true);
            _LastCubeFall = true;
        }

        
    }
}
