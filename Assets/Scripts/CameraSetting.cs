using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSetting : MonoBehaviour
{

    public CinemachineVirtualCameraBase vcam;
    public CinemachineVirtualCameraBase vCamEvent;
    public CinemachineVirtualCameraBase vcamEventBoss;
    public CinemachineVirtualCameraBase vcamEnding;
    public AudioClip collision_sound;
    public AudioClip clear_sound;
    private bool soundCheck1 = false;
    private bool soundCheck2 = false;
    private bool soundCheck3 = false;

    // Start is called before the first frame update
    void Start()
    {
        /*vcamObj = GameObject.Find("vcam");
        vCamEventObj = GameObject.Find("CM vcam2");
        vcam = vcamObj.GetComponent<CinemachineVirtualCamera>();
        vCamEvent = vCamEventObj.GetComponent<CinemachineVirtualCamera>();*/

        changeToCam();
    }


    public void changeToCam()
    {
        vcam.MoveToTopOfPrioritySubqueue();
    }

    public void changeToCamEvent()
    {
        if (!soundCheck1)
        {
            AudioSource.PlayClipAtPoint(collision_sound, this.transform.position);
            soundCheck1 = true;

        }

        vCamEvent.MoveToTopOfPrioritySubqueue();
    }

    public void changeToCamBoss()
    {
        if (!soundCheck2)
        {
            AudioSource.PlayClipAtPoint(collision_sound, this.transform.position);
            soundCheck2 = true;
        }

        vcamEventBoss.MoveToTopOfPrioritySubqueue();
    }

    public void changeToCamEnd()
    {
        if (!soundCheck3)
        {
            AudioSource.PlayClipAtPoint(clear_sound, this.transform.position);
            soundCheck3 = true;
        }

        vcamEnding.MoveToTopOfPrioritySubqueue();
    }
}
