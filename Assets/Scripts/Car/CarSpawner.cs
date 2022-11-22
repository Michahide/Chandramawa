using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject carPrefab;
    [SerializeField] GameObject terrain;
    [SerializeField] float minSpawnDuration = 2;
    [SerializeField] float maxSpawnDuration = 4;

    bool isRight;

    float timer;

    private void Start() {
        //Inisiasi awal mobilnya hadep ke kanan atau kiri
        isRight = Random.value > 0.5f ? true : false;
        timer = Random.Range(minSpawnDuration, maxSpawnDuration);
    }
    private void Update() {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        timer = Random.Range(minSpawnDuration, maxSpawnDuration);
        /*atur posisi spawn biar sama panjangnya kayak road(terrain), kalau dia bergerak ke kanan, 
        spawn nya di kiri, begitu sebaliknya*/
        // var spawnPos = 
            // this.transform.position + Vector3.right * (isRight ? - (terrain.Extent + 1) : terrain.Extent + 1);

        // var go = Instantiate(
        //     original: carPrefab,
        //     position: spawnPos,
        //     //muter buat mobilnya biar menghadap ke kanan atau kiri
        //     rotation: Quaternion.Euler(0, isRight ? 90 : -90, 0),
        //     parent: this.transform
        // );

        // var car = go.GetComponent<Car>();
        // car.setup(terrain.Extent);
    }
}
