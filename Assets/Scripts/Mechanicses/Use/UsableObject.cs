using System.Collections;
using Hints;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AbstractClasses
{
    [RequireComponent(typeof(SphereCollider))]
    public abstract class UsableObject : MonoBehaviour
    {
        [Header("Hints")] [Space]
        [SerializeField] protected GameObject HintPrefab;
        protected Hint Hint;
        protected Transform HintPoint;
        
        [Header("Parameters")] [Space]
        [SerializeField] protected KeyCode UseKey;
        [SerializeField] protected float PauseBehindUses,RadiusOfUse;

        protected bool IsCanUse;

        protected void Start()
        {
            GetComponent<SphereCollider>().radius = RadiusOfUse;
            
            
            foreach (Transform child in transform.GetComponentsInChildren<Transform>())
            {
                if (child.CompareTag("HintPoint"))
                {
                    HintPoint = child;
                }
            }
            
            Hint = HintSpawner.SpawnHint(HintPrefab,HintPoint.position).GetComponent<Hint>();
            
            Hint.SetHintPoint(HintPoint);
        }

        protected void Update()
        {
            Debug.Log(IsCanUse);
            if (Input.GetKeyDown(UseKey) && IsCanUse)
            {
                Use();
            }
        }

        public abstract void Use();

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>() != null)
            {
                IsCanUse = true;
                Hint.SetHintVisible(true);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerController>() != null)
            {
                StopAllCoroutines();
                IsCanUse = false;
                Hint.SetHintVisible(false);
            }
        }
        
        protected IEnumerator MakePauseBehindUses()
        {
            Hint.SetHintVisible(false);
            IsCanUse = false;

            yield return new WaitForSeconds(PauseBehindUses);
            
            Hint.SetHintVisible(true);
            IsCanUse = true;
        }
    }
}
