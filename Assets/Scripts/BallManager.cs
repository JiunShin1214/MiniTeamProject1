using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Ball _ballCs;
    public bool isTurn = false;
    public float velocityThreshold = 0.1f;
    public List<GameObject> ballObjs = null;
    
    // �̱��� �ν��Ͻ�
    private static BallManager _instance;

    // �ܺο��� ���� ������ �ν��Ͻ� ������Ƽ
    public static BallManager Instance
    {
        get
        {
            // _instance�� null�̸� ������ BallManager Ÿ���� ã�� �Ҵ�
            if (_instance == null)
            {
                _instance = FindObjectOfType<BallManager>();

                // ������ null�̸� �� ���� ������Ʈ�� BallManager ������Ʈ�� ����
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "BallManager";
                    _instance = obj.AddComponent<BallManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        // �ٸ� BallManager �ν��Ͻ��� �̹� ������ ���� �ν��Ͻ��� �ı�
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
    }

    void Start()
    {
        isTurn = true;

        _ballCs = FindAnyObjectByType<Ball>();
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Ball").Length; ++i)
        {
            ballObjs.Add(GameObject.FindGameObjectsWithTag("Ball")[i]);
        }
    }

    void Update()
    {
        isTurn = AreBallsStopped();
    }

    public bool AreBallsStopped()
    {
        foreach (var ball in ballObjs)
        {
            if (ball != null)
            {
                Rigidbody ballRb = ball.GetComponent<Rigidbody>();

                if (ballRb.velocity.magnitude > velocityThreshold ||
                ballRb.angularVelocity.magnitude > velocityThreshold)
                {
                    return false; // �ϳ��� �����̴� ���� �ִٸ� false ��ȯ
                }
            }
        }
        return true; // ��� ���� ����ٸ� true ��ȯ
    }
}
