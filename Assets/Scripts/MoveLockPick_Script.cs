using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLockPick_Script : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.transform.position;

        if (CountDownScript.currTime > 0)
        {
            if (position.x < 800)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {

                    position.x += 90;
                    this.transform.position = position;
                }


                else if (position.x > 507)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        position.x -= 90;
                        this.transform.position = position;
                    }
                }
            }
            else if (position.x > 507)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    position.x -= 90;
                    this.transform.position = position;
                }
            }

        }
    }
}
