using UnityEngine;
using AbstractClasses;

namespace Door
{
    [RequireComponent(typeof(Animator))]
    public class Door : UsableObject
    {
        private Animator _animator;
        
        [SerializeField] private bool isOpeningTowards; 
        
        private bool isOpen;

        private void Start()
        {
            base.Start();
            _animator = GetComponent<Animator>();
            
            _animator.SetBool("isOpenTowards",isOpeningTowards);
        }

        public override void Use()
        {
            _animator.SetTrigger(isOpen ? "Close" : "Open");

            isOpen = !isOpen;
            StartCoroutine(MakePauseBehindUses());
        }

       
    }
}
