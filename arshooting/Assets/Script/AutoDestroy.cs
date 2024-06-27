using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class AudoDestroy : MonoBehaviour
{
    public bool OnlyDeactivate;

    void OnEnable()
    {
        StartCoroutine("CheckIfAlive");        
    }

    IEnumerator CheckIfAlive()
    {
        ParticleSystem p = this.GetComponent<ParticleSystem>();

        while(true&&p!=null)
        {
            yield return new WaitForSeconds(0.5f);
            if(!p.IsAlive(true))
            {
                if(OnlyDeactivate)
                {
                    #if Unity_3_5
                        this.gameObject.SetActiveRecursively(false);
                    #else
                    this.gameObject.SetActive(false);
                    #endif
                }
                else
                {
                    GameObject.Destroy(this.gameObject);
                    break;
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
