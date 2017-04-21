using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script
{

    public interface IUseable
    {
        void use();
    }



    public class ObjectManager : MonoBehaviour
    {
        static private int countEntites;
        static private int countScaneObject;
        static private List<Entity> _entites;
        static private List<SceneObject> _sceneObjects;

        static private void tryUseObject(Entity entity)
        {
            SceneObject temp = null;
            foreach (var obj in _sceneObjects)
            {
                if (entity.getCollider2D().IsTouching(obj._collider) == true)
                {
                    Debug.Log("try");
                    temp = obj;
                    break;
                }
            }
            if (temp != null)
            {
                temp.use();
            }
        }

        public static SceneObject[] collisionDoor(Collider2D collider)
        {
            List<SceneObject> doors = new List<SceneObject>();

            foreach (var obj in _sceneObjects)
            {
                if (obj.ToString() == "Door")
                {
                    Debug.Log("Find");
                    doors.Add(obj);
                }
            }
            return doors.ToArray();
        }

        public void init(IEnumerable<Entity> entites, IEnumerable<SceneObject> sceneObjects)
        {
            _entites = entites.ToList<Entity>();
            _sceneObjects = sceneObjects.ToList<SceneObject>();

            //Debug.Log(ObjectManager.collisionDoor(_sceneObjects[0]._collider)[0].ToString());

            foreach (var entity in _entites)
            {
                entity.eventUseObject += tryUseObject;
            }
        }

        public void Start()
        {
            Debug.Log("StartBegin ObjectManager");
            init(FindObjectsOfType<Entity>(), FindObjectsOfType<SceneObject>());
            Debug.Log("StartEnd Object Manager");
        }
    }
}
