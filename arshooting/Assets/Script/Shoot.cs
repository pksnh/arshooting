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
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))// out: ��� ���� �Ű� ����, �Ҵ�� ������ �� ��� ��, �� �ʱ�ȭ �ʿ� ����, ray�� ��ü�� �浹�ϴ� ������ Hit Point�� RayCastHit ����ü ���� hit�� �����
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
