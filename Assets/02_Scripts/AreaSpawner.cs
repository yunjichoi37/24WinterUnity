using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] areaPrefabs; // 구역 프리팹 배열
    [SerializeField] private Transform player; // 플레이어의 Transform 정보(새로운 구역 생성용)
    [SerializeField] private int spawnAreaAtStart = 2; // 게임 시작 시 최초 생성되는 구역 개수
    [SerializeField] private float distanceToNext = 30; // 구역 사이의 거리
    
    private int areaIndex = 0; // 구역 인덱스(배치되는 구역의 위치 연산에 활용)

    private void Awake()
    {
        for (int i = 0; i < spawnAreaAtStart; ++ i)
        {
            SpawnArea();
        }
    }

    private void SpawnArea()
    {
        // 여러 개의 구역 중 임의의 구역 인덱스 선택
        int index = Random.Range(0, areaPrefabs.Length);

        // 선택된 index번째 구역 생성
        GameObject clone = Instantiate(areaPrefabs[index]);

        // 구역이 배치되는 위치 설정 (0, distanceToNext * areaIndex, 0)
        clone.transform.position = Vector3.up * distanceToNext * areaIndex;

        // 구역이 배치되는 y 위치를 계속 증가시켜주기 위해 구역이 생성될 때마다 증가
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
