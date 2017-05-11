using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Assets.Script
{

    public interface IUseable
    {
        void use(Entity entity);
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
                if (entity.getCollider2D().IsTouching(obj.getCollider2D()) == true)
                {
                    temp = obj;
                    break;
                }
            }
            if (temp != null)
            {
                temp.use(entity);
            }
        }

        public static SceneObject[] collisionDoor(Collider2D collider) //TODO :rename vars, make better.
        {
            List<SceneObject> doors = new List<SceneObject>();
            Collider2D[] collisionWithRoom = Physics2D.OverlapBoxAll(collider.transform.position, collider.bounds.size, 0);
            //Debug.Log(collisionWithRoom.Length);
            foreach (var obj in _sceneObjects)
            {
                if (obj.ToString() == "Door")
                {

                    foreach (var col in collisionWithRoom)
                    {
                        Debug.Log("ObjectManager");
                        Debug.Log(obj.getCollider2D() == null);
                        if (SceneObject.equels(col,obj.getCollider2D()))
                        {
                           // Debug.Log("find");
                            //col.Equals(obj.getCollider2D()
                            //Physics2D.IsTouching(col,obj.getCollider2D())
                            //  Debug.Log("Find");
                            doors.Add(obj);
                        }
                    }
                }
            }
            return doors.ToArray();
        }

        public void init(IEnumerable<Entity> entites, IEnumerable<SceneObject> sceneObjects)
        {
            _entites = entites.ToList();
            _sceneObjects = sceneObjects.ToList();
            foreach (var entity in _entites)
            {
                entity.eventUseObject += tryUseObject;
            }
        }

        public void Start()
        {
            Debug.Log("ObjectManager");
            init(FindObjectsOfType<Entity>(), FindObjectsOfType<SceneObject>());
        }
    }
}
