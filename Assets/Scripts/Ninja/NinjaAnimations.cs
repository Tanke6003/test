using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string layerWalkName = "Walk";
    [SerializeField] private string layerIdleName = "Idle";
    private Animator animator;
    private NinjaMoviment ninjaMoviment;
    
    private readonly int xHash = Animator.StringToHash("x");
    private readonly int yHash = Animator.StringToHash("y");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        ninjaMoviment = GetComponent<NinjaMoviment>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLayer();
        if(!ninjaMoviment.isMoving)
            return ;
        animator.SetFloat(xHash, ninjaMoviment.movementDirection.x);
        animator.SetFloat(yHash, ninjaMoviment.movementDirection.y);


    }
    private void ActivateLayer(string layerName)
    {
        for(int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }

    private void UpdateLayer()
    {
        if(ninjaMoviment.isMoving)
            ActivateLayer(layerWalkName);
        else
            ActivateLayer(layerIdleName);
    }
}
