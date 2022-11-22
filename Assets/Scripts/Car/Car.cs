using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    int extent;

    public float Speed { get => speed; set => speed = value; }

    private void Update() {
        //Mengatur majunya mobil
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        //Mengatur kapan dihapusnya mobil, dengan kondisi terhapus kalau udah kena area abu
        if (this.transform.position.x < - (extent + 1) || this.transform.position.x > extent + 1){
            Destroy(this.gameObject);
        }
    }

    public void setup(int extent){
        this.extent = extent;
    }
}
