using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Settings of generating object", menuName = "Change generating settings")]
    public class ObjectSettings : ScriptableObject {
        public float MinForce;
        public float MaxForce;
        public GameObject GeneratedObject;
        public float MinScale;
        public float MaxScale;
    }
}
