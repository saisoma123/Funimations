using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public List<Camera> cameras;
    private int curr;

    // Start is called before the first frame update
    void Start()
    {
        Disable();

        cameras[0].enabled = true;
        curr = 0;
    }

    private void Disable() {
        cameras[0].enabled = false;
        cameras[1].enabled = false;
    }

    private void Switch() {
        if (curr == 0) {
            cameras[0].enabled = false;
            cameras[1].enabled = true;
            curr = 1;
        }
        else {
            cameras[0].enabled = true;
            cameras[1].enabled = false;
            curr = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
           Switch();
        }
    }
}
