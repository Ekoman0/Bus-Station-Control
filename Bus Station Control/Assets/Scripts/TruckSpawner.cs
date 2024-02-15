using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;


[System.Serializable]
public class TruckWave
{
        [System.Serializable]
        public class TruckItem
        {
        public float NextTruckSpawnTimer;
        public int TruckRequest;
        public bool NeedTime;
        public float DoitTime;
        }
        public TruckWave.TruckItem[] TruckItems;




}


public class TruckSpawner : MonoBehaviour
{
    public Vector3 SpawnPoint;
    public TruckWave[] TruckWaves;
    public GameObject Truck;

    private TruckWave.TruckItem CurrentTruck;
    private int CurrentTruckNumber = 0;

    public AudioSource HornAsc;

    public TextMeshProUGUI RemainingTruckTMP;
    private int RemainingTruck;

    void Start()
    {
        RemainingTruck = TruckWaves[0].TruckItems.Length;
        RemainingTruckTMP.text = RemainingTruck.ToString();
        CurrentTruck = TruckWaves[0].TruckItems[CurrentTruckNumber];
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTruck.NextTruckSpawnTimer -= Time.deltaTime;
        if (CurrentTruck.NextTruckSpawnTimer <= 0 && CurrentTruckNumber < TruckWaves[0].TruckItems.Length)
        {
            GameObject SpawnedTruck = Instantiate(Truck, SpawnPoint, Quaternion.identity);
            SpawnedTruck.GetComponent<TruckAI>().TruckRequest = TruckWaves[0].TruckItems[CurrentTruckNumber].TruckRequest;
            SpawnedTruck.GetComponent<TruckAI>().NeedTime = TruckWaves[0].TruckItems[CurrentTruckNumber].NeedTime;
            SpawnedTruck.GetComponent<TruckAI>().DoitTime = TruckWaves[0].TruckItems[CurrentTruckNumber].DoitTime;

            RemainingTruck -= 1;
            RemainingTruckTMP.text = RemainingTruck.ToString();

            this.gameObject.GetComponent<GameManager>().RemainingTruck = RemainingTruck;

            CurrentTruckNumber++;
            if (CurrentTruckNumber < TruckWaves[0].TruckItems.Length)
            {
                CurrentTruck = TruckWaves[0].TruckItems[CurrentTruckNumber];
                HornAsc.Play();
            }
            

        }
    }
}
