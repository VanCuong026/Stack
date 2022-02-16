using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCubeColorChange : MonoBehaviour
{
    float _ColorCode;
    private Renderer _Cube;
    public bool _ChangeColorDone = false;
    // Start is called before the first frame update
    void Start()
    {
        _Cube = gameObject.GetComponent<Renderer>();
        _ColorCode = SlideController.instance._Score * 0.02f + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        _ColorCode = SlideController.instance._Score * 0.02f + 0.5f-0.02f;
        if (_ColorCode > 1) _ColorCode = _ColorCode % 1f;
        if (_ChangeColorDone == false)
        {
            _Cube.material.color = Color.HSVToRGB(_ColorCode, 1f, 1f);
            _ChangeColorDone = true;
            DropCubeSpawner.instance._SetActiveDone = true;
        }
        if (transform.position.y < -SlideController.instance._Score-50f) //Neu DropCube roi xuong sau thi xoa di
        {
            Destroy(gameObject);
        }
    }
}
