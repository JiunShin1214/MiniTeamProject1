using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncinessBySpeed : MonoBehaviour
{
    private Collider ballCd;
    private Rigidbody ballRb;
    public float maxBounciness = 1f;      // �ִ� bounciness ��
    public float speedFactor = 5f;        // �ӵ��� �����ϴ� ���� (�� ū ���� �� ���� ��ȭ�� �ʷ���)
    private PhysicMaterial ballPMaterial;

    void Start()
    {
        ballCd = GetComponent<Collider>();
        ballCd.material.bounciness = 1;
        ballRb = GetComponent<Rigidbody>();
        ballPMaterial = ballCd.GetComponent<PhysicMaterial>();
    }


    void Update()
    {
        if (ballPMaterial)
        {
            float speed = ballRb.velocity.magnitude;
            ballPMaterial.bounciness = maxBounciness / (1 + speed/speedFactor);
        }
    }
}
