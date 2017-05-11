using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{

    public class RoomCurtain : MonoBehaviour
    {
        private bool isInside;
        private bool isOpen;
        private SpriteRenderer WallPict;
        private Collider2D _collider;
        private Color alpha;
        private SceneObject[] doors;
        // Use this for initialization

        public void Start()
        {
            Debug.Log("RoomCurtain");
            isInside = false;
            isOpen = false;
            _collider = GetComponent<BoxCollider2D>();
            doors = (ObjectManager.collisionDoor(_collider));
            //Debug.Log("doors.Length: " + doors.Length);
            WallPict = GetComponent<SpriteRenderer>();
            WallPict.enabled = true;
            alpha = WallPict.color;
        }

        // Update is called once per frame
        public void Update()
        {
            if (isInside || isOpen)
            {
                CurtainUp();
            }
            else
            {
                CurtainDown();
            }

            isOpen = false;

            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].getStatus())
                {
                    isOpen = true;
                    break;
                }
            }
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                isInside = true;
            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                isInside = false;
            }
        }
        private void CurtainUp()
        {

            if (alpha.a > 0.2f)
            {
                alpha.a -= (Time.deltaTime);
                alpha.a = Mathf.Clamp(alpha.a, 0.2f, 1);
                WallPict.color = alpha;
            }

        }
        private void CurtainDown()
        {
            if (alpha.a < 1)
            {
                alpha.a += (Time.deltaTime);
                alpha.a = Mathf.Clamp(alpha.a, 0, 1);
                WallPict.color = alpha;
            }
        }

    }
}