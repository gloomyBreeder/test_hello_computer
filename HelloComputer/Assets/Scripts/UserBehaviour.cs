using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class UserBehaviour : MonoBehaviour
    {
        public ObjectSettings Settings;
        private readonly float _distance = 1f;
        private Ray _ray;

        private void FixedUpdate () {
            if (Input.GetMouseButtonDown(0))
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 point2d = new Vector2(point.x, point.y);
                RaycastHit2D raycast2d = Physics2D.Raycast(point2d, point2d);
                if (raycast2d.collider != null)
                {
                    PushObject(raycast2d.collider.transform);
                }
                else
                {
                    SpawnObject();
                }
            }
        }

        private void PushObject(Transform objTransform)
        {
            var force = Random.Range(Settings.MinForce, Settings.MaxForce);
            if (objTransform.GetComponent<Rigidbody2D>() == null)
                return;
            objTransform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0,360), Random.Range(0, 360)) * force);
        }

        private void SpawnObject()
        {
            var obj = Instantiate(Resources.Load("Prefabs/" + Settings.GeneratedObject.name), 
                _ray.origin + (_ray.direction * _distance), 
                Quaternion.Euler(0, 0, Random.Range(0, 360))) as GameObject;
            var randomScale = Random.Range(Settings.MinScale, Settings.MaxScale);

            if (obj == null)
            {
                Debug.LogError("something goes wrong");
                return;
            }
            obj.AddComponent<ObjectBehaviour>();
            obj.transform.localScale = new Vector2(randomScale, randomScale);
        }
    }
}
