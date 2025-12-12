using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public class LookAtMouse2D : MonoBehaviour
    {
        private Camera mainCamera;
        void Start()
        {
        
        }

        void Update()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = transform.position.z - mainCamera.transform.position.z;
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            Vector2 direction = new Vector2(
                mouseWorldPos.x - transform.position.x,
                mouseWorldPos.y - transform.position.y);
            float angle =Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            angle -= 90;
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
    }
}
