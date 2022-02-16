using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCubeMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    private float _Speed=0;
    bool _SlideSwitch = false;
    Vector3 temp;
    public bool _AllDone = false;
    private bool _Stop = false;
    int _Counting = 0;
    private void Start()
    {
        temp = transform.position;
        temp.x = -1.8f;
        temp.z = CubeCut.instance._LastCubeCenter.z;
        transform.position = temp;
        if (SlideController.instance._Score % 2 == 1) //Only LEFT run
        {
            gameObject.SetActive(false);
            SlideDown.instance._Switch = "Right";//RIGHT stop
        }

        Vector3 tempScale = CubeCut.instance._CubeScale;
        tempScale.y = 0.1f;
        transform.localScale = tempScale;

    }
    // Update is called once per frame
    void Update()
    {
        _Speed = SlideController.instance._RightSpeed;
        if (_Stop == false)
        {
            if (_SlideSwitch == false)
            {
                _SlideToFront();
            }
            else if (_SlideSwitch == true)
            {
                _SlideToBack();
            }
        }
        
        if (Input.GetMouseButtonDown(0) && _Stop == false)
        {
            CubeCut.instance._CurrentCubeCenter.x = transform.position.x;
            //DropCubeSpawner.instance._CurrentCenter.x = transform.position.x;
            CubeCut.instance._StartXCut = true;
            _Stop = true;
        }

        if (_Stop == true && CubeCut.instance._StartXCut == false && _AllDone == false&& CubeCut.instance._GameOver==false)
        {
            Vector3 tempPosition = CubeCut.instance._LastCubeCenter;
            tempPosition.y = 0.54f;
            transform.position = tempPosition;

            CubeCut.instance._CubeScale.y = 0.1f;
            transform.localScale = CubeCut.instance._CubeScale;
            _AllDone = true;

            SlideDown.instance._Down = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _Counting++;
        }
        if (_Counting==1&& CubeCut.instance._GameOver == true)
        {
            gameObject.SetActive(false);
        }
    }

    void _SlideToFront()
    {
        temp = transform.position;
        if (temp.x - 1.2f < -0.01f)
        {
            temp.x += _Speed * Time.deltaTime;
            transform.position = temp;
        }
        else if (temp.x - 1.2f > -0.05f)
        {
            temp.x = 1.2f;
            transform.position = temp;
            _SlideSwitch = true;
        }

    }

    void _SlideToBack()
    {
        temp = transform.position;
        if (temp.x + 1.2f > 0.01f)
        {
            temp.x -= _Speed * Time.deltaTime;
            transform.position = temp;
        }
        else if (temp.x + 1.2f < 0.05f)
        {
            temp.x = -1.2f;
            transform.position = temp;
            _SlideSwitch = false;
        }
    }
}
