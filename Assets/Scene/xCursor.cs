﻿
using UnityEngine;

namespace Assets.Scene {

    public class xCursor : MonoBehaviour {

        private MeshRenderer meshRenderer;

        // Use this for initialization
        void Start () {
            meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        }
	
        // Update is called once per frame
        void Update () {
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;

            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo)) {
                meshRenderer.enabled = true;

                transform.position = hitInfo.point;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            }
            else
                meshRenderer.enabled = false;
        }

    }

}