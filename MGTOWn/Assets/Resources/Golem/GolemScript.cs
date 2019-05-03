using System.Collections;
using UnityEngine;

public class GolemScript : MonoBehaviour
{
    Animator animator;    

    void Start()
    {
        animator = GetComponent<Animator>();      
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1.5f) * Time.deltaTime);
        
    }

}
