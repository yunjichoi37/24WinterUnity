using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] areaPrefabs; // ���� ������ �迭
    [SerializeField] private Transform player; // �÷��̾��� Transform ����(���ο� ���� ������)
    [SerializeField] private int spawnAreaAtStart = 2; // ���� ���� �� ���� �����Ǵ� ���� ����
    [SerializeField] private float distanceToNext = 30; // ���� ������ �Ÿ�
    
    private int areaIndex = 0; // ���� �ε���(��ġ�Ǵ� ������ ��ġ ���꿡 Ȱ��)

    private void Awake()
    {
        for (int i = 0; i < spawnAreaAtStart; ++ i)
        {
            SpawnArea();
        }
    }

    private void SpawnArea()
    {
        // ���� ���� ���� �� ������ ���� �ε��� ����
        int index = Random.Range(0, areaPrefabs.Length);

        // ���õ� index��° ���� ����
        GameObject clone = Instantiate(areaPrefabs[index]);

        // ������ ��ġ�Ǵ� ��ġ ���� (0, distanceToNext * areaIndex, 0)
        clone.transform.position = Vector3.up * distanceToNext * areaIndex;

        // ������ ��ġ�Ǵ� y ��ġ�� ��� ���������ֱ� ���� ������ ������ ������ ����
        areaIndex ++;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        int playerIndex = (int)(player.position.y / distanceToNext);

        if (playerIndex == areaIndex - 1)
        {
            SpawnArea();
        }
    }
}
