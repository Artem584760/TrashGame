using UnityEngine;

namespace Hints
{
    public static class HintSpawner
    {
        private static Canvas s_Canvas;

        static HintSpawner()
        {
            s_Canvas = GameObject.FindWithTag("GlobalCanvas").GetComponent<Canvas>();
        }

        public static GameObject SpawnHint(GameObject hintPrefab, Vector3 position = default)
        {
            return MonoBehaviour.Instantiate(hintPrefab,
                position,
                Quaternion.identity, s_Canvas.transform);
        }
    }
}
