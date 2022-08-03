
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace auttr
{
    /// <summary>
    /// 點擊生成物件
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class TapToSpawOBJ : MonoBehaviour
    {
        [SerializeField, Header("要生成的物件")]
        private GameObject GoSpawOBJ;

        private Vector2 touchPoint;
        private ARRaycastManager arManager;
        private List<ARRaycastHit> hits = new List<ARRaycastHit>();
        private void Update()
        {
            TapandSpaw();
        }

        private void Awake()
        {
            arManager = GetComponent<ARRaycastManager>();
        }
        void TapandSpaw()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                touchPoint = Input.mousePosition;
                }
            if (arManager.Raycast(touchPoint,hits,TrackableType.PlaneWithinPolygon))
            {
                Pose pose = hits[0].pose;
                GameObject temp =  Instantiate(GoSpawOBJ,pose.position,Quaternion.identity);
                Vector3 camerapos = transform.position;
                camerapos.y = temp.transform.position.y;
                temp.transform.LookAt(camerapos);

            }
        }
    }

    



}

