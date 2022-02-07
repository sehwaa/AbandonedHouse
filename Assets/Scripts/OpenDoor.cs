using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractionManager.instance.PullBookComplete && !InteractionManager.instance.OpenDoorButtonComplete)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.Touch) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger, OVRInput.Controller.Touch))
            {
                //Animation anim = gameObject.GetComponent<Animation>();
                //anim.Play("PushButton");

                transform.position = Vector3.Lerp(transform.position, InteractionManager.OpenDoorButtonTargetPosition, 0.1f);

                GameObject studyRoomDoor = GameObject.Find("StudyRoomDoor");
                Animation anim2 = studyRoomDoor.GetComponent<Animation>();
                anim2.Play("OpenDoor");

                AudioSource audio = studyRoomDoor.GetComponent<AudioSource>();
                audio.transform.position = studyRoomDoor.transform.position;
                audio.Play();
            }
        }
    }
}