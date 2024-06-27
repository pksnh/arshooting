using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject camera;
    public GameObject prefab;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))// out: 출력 전용 매개 변수, 할당된 변수에 값 줘야 함, 값 초기화 필요 없음, ray가 물체와 충돌하는 지점인 Hit Point를 RayCastHit 구조체 변수 hit에 담아줌
        {
            if(hit.transform.tag=="ball")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));

                audio.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
