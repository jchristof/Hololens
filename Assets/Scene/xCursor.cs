
using UnityEngine;

namespace Assets.Scene {

    public class xCursor : MonoBehaviour {

        private MeshRenderer meshRenderer;
        public GameObject FocusedObject { get; private set; }

        // Use this for initialization
        void Start () {
            meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        }
	
        // Update is called once per frame
        void Update () {
            meshRenderer.enabled = true;
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;

            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo)) {
                meshRenderer.enabled = true;

                transform.position = hitInfo.point;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

                var newFocusedObject = hitInfo.collider.gameObject;

                if (FocusedObject != null && newFocusedObject != FocusedObject) {
                    FocusedObject.SendMessage("OnReset");
                }

                FocusedObject = newFocusedObject;
                FocusedObject.SendMessage("OnSelect");

            }
            else {
                meshRenderer.enabled = false;

                if(FocusedObject != null)
                    FocusedObject.SendMessage("OnReset");

                FocusedObject = null;
            }
        }

    }

}
