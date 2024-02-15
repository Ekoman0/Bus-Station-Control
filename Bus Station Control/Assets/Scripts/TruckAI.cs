using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TruckAI : MonoBehaviour
{
    
    
    public GameObject[] Stop;
    public bool[] StopBool;
    public float speed = 2f;
    private int TruckInWhichStop=5;
    private GameObject GameManager;

    List<int> TruckRequestList = new List<int> { 0,1,2 };
    public int TruckRequest;
    public int TruckRequestActive;
    public GameObject TruckRequestGas;
    public GameObject TruckRequestFix;
    public GameObject TruckRequestCargo;
    public GameObject TruckRequestFood;
    public GameObject TruckRequestFinish;
    private float WorkTimer;
    private bool GasBool;
    private bool FixBool;
    private bool CargoBool;
    private bool FoodBool;
    private bool FinishBool = false;
    private bool TruckLeaving;
    private bool inEnd;
    private GameObject ActiveStation;


    Transform StationCanvas;
    Canvas canvasComponent;
    Transform StationSlider;
    Slider SliderComponent;

    public bool NeedTime;
    public float DoitTime;
    public Slider DoitTimeSlider;

    public AudioSource GainMoneyAsc;
    public AudioSource AccidentAsc;

    public GameObject[] finishfronts;
    

    private void Awake()
    {
        NewTruckRequest();
    }

    void Start()
    {

        GameManager = GameObject.Find("GameManager");



        Stop[0] = GameObject.Find("TruckStop (4)");
        Stop[1] = GameObject.Find("TruckStop");
        Stop[2] = GameObject.Find("TruckStop (1)");
        Stop[3] = GameObject.Find("TruckStop (2)");
        Stop[4] = GameObject.Find("TruckStop (3)");
        GiveTruckRequest();

        if (NeedTime == true)
        {
            DoitTimeSlider.maxValue = DoitTime;
            DoitTimeSlider.value = DoitTime;
            this.gameObject.transform.GetChild(4).gameObject.SetActive(true);

        }
        else
        {
            this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        finishfronts = GameObject.FindGameObjectsWithTag("FinishFront");
        if (NeedTime == true)
        {
            DoitTime -= Time.deltaTime;
            DoitTimeSlider.value -= Time.deltaTime;

            if (DoitTime <= 0)
            {
                this.gameObject.GetComponent<Controller>().movementSpeed = 0f;
                Color red = new Color(1f, 0f, 0f);
                this.gameObject.GetComponent<SpriteRenderer>().color = red;

                this.gameObject.GetComponent<Controller>().enabled = false;              
                GameManager.GetComponent<GameManager>().Hearth -= 1;
                Handheld.Vibrate();
                GameManager.GetComponent<GameManager>().HearthUI();
                Destroy(this.gameObject, 1f);
                this.gameObject.GetComponent<TruckAI>().enabled = false;
            }
        }

        StopBool[0] = Stop[0].GetComponent<TruckStop>().TruckStoped; 
        StopBool[1] = Stop[1].GetComponent<TruckStop>().TruckStoped;
        StopBool[2] = Stop[2].GetComponent<TruckStop>().TruckStoped; 
        StopBool[3] = Stop[3].GetComponent<TruckStop>().TruckStoped; 
        StopBool[4] = Stop[4].GetComponent<TruckStop>().TruckStoped;

        GoStop();


        DoitTruckRequest();

        if (TruckLeaving == true)
        {
            TruckLeave();
        }
    }
    public void GoStop()
    {
        if (TruckInWhichStop -1 >= 0)
        {
            if (StopBool[TruckInWhichStop - 1] == false)
            {
                
                // hedef objenin pozisyonunu ve kendi pozisyonunu al
                Vector3 targetPos = Stop[TruckInWhichStop - 1].transform.position;
                Vector3 selfPos = transform.position;

                targetPos = new Vector3(targetPos.x, targetPos.y, selfPos.z);
                // hedef objeye doðru bak
                transform.up = targetPos - selfPos;

                // objeyi hedef objeye doðru hareket ettir
                transform.position = Vector2.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);
            }
            else if (TruckInWhichStop == 5 && StopBool[TruckInWhichStop - 1] == true)
            {
                // hedef objenin pozisyonunu ve kendi pozisyonunu al
                Vector3 targetPos = Stop[TruckInWhichStop - 1].transform.position;
                Vector3 selfPos = transform.position;

                targetPos = new Vector3(targetPos.x, targetPos.y, selfPos.z);
                // hedef objeye doðru bak
                transform.up = targetPos - selfPos;

                // objeyi hedef objeye doðru hareket ettir
                transform.position = Vector2.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);
            }
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Stop[0])
        {
            TruckInWhichStop = 0;
            this.gameObject.GetComponent<Controller>().enabled = true;

        }
        if (collision.gameObject == Stop[1])
        {
            TruckInWhichStop = 1;
        }
        if (collision.gameObject == Stop[2])
        {
            TruckInWhichStop = 2;
        }
        if (collision.gameObject == Stop[3])
        {
            TruckInWhichStop = 3;
        }
        if (collision.gameObject == Stop[4])
        {
            TruckInWhichStop = 4;
        }

        if (collision.gameObject.tag == "Truck")
        {
            if ((TruckInWhichStop <= 0 && collision.gameObject.GetComponent<TruckAI>().TruckInWhichStop <=0) ||(TruckInWhichStop == 4 || TruckInWhichStop == 5))
            {

                AccidentAsc.Play();
                this.gameObject.GetComponent<Controller>().movementSpeed = 0f;
                Color red = new Color(1f, 0f, 0f);
                this.gameObject.GetComponent<SpriteRenderer>().color = red;

                this.gameObject.GetComponent<Controller>().enabled = false;
                GameManager.GetComponent<GameManager>().Hearth += 0.5f;
                GameManager.GetComponent<GameManager>().Hearth -= 1;
                Handheld.Vibrate();
                GameManager.GetComponent<GameManager>().HearthUI();
                Destroy(this.gameObject,1f);
                this.gameObject.GetComponent<TruckAI>().enabled = false;


            }
        }

        if (collision.gameObject.tag == "FinishFront")
        {
            if (TruckRequestActive == 10)
            {
                FinishBool = true;
            }
           
        }
        if (collision.gameObject.tag == "Gas")
        {
            

            ActiveStation = collision.gameObject;

            StationCanvas = ActiveStation.transform.GetChild(3);
            canvasComponent = StationCanvas.GetComponent<Canvas>();
            StationSlider = StationCanvas.transform.GetChild(0);
            SliderComponent = StationSlider.GetComponent<Slider>();

            GasBool = true;
        }
        if (collision.gameObject.tag == "Fix")
        {
            

            ActiveStation = collision.gameObject;

            StationCanvas = ActiveStation.transform.GetChild(3);
            canvasComponent = StationCanvas.GetComponent<Canvas>();
            StationSlider = StationCanvas.transform.GetChild(0);
            SliderComponent = StationSlider.GetComponent<Slider>();

            FixBool = true;
        }
        if (collision.gameObject.tag == "Cargo")
        {
            

            ActiveStation = collision.gameObject;
            
            StationCanvas = ActiveStation.transform.GetChild(3);
            canvasComponent = StationCanvas.GetComponent<Canvas>();
            StationSlider = StationCanvas.transform.GetChild(0);
            SliderComponent = StationSlider.GetComponent<Slider>();

            CargoBool = true;
        }
        if (collision.gameObject.tag == "Food")
        {


            ActiveStation = collision.gameObject;

            StationCanvas = ActiveStation.transform.GetChild(3);
            canvasComponent = StationCanvas.GetComponent<Canvas>();
            StationSlider = StationCanvas.transform.GetChild(0);
            SliderComponent = StationSlider.GetComponent<Slider>();

            FoodBool = true;
        }
       

        if (collision.gameObject.tag =="StationExit")
        {
            if (TruckLeaving  == true)
            {
                TruckLeaving = false;
                ActiveStation = null;
            }
            
            



        }

        if (collision.gameObject.tag == "End")
        {

            inEnd = true;
            GameManager.GetComponent<GameManager>().Money += 100;
            GainMoneyAsc.Play();
            
        }
        if (collision.gameObject.tag == "End2")
        {

            Destroy(this.gameObject);


        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gas")
        {
            
            GasBool = false;
        }
        if (collision.gameObject.tag == "Fix")
        {
            
            FixBool = false;
        }
        if (collision.gameObject.tag == "Cargo")
        {
            
            CargoBool = false;
        }
        if (collision.gameObject.tag == "Food")
        {

            FoodBool = false;
        }
       
    }
    private void GiveTruckRequest()
    {
         WorkTimer = -30;
        if (TruckRequest>0)
        {
            int index = Random.Range(0, TruckRequestList.Count);
            TruckRequestActive = TruckRequestList[index];
            TruckRequestList.RemoveAt(index);
            TruckRequest--;
            TruckRequests();
        }
        else
        {
            TruckRequestActive = 10;
            TruckRequests();
        }
            


    }

    private void TruckRequests()
    {
        if (TruckRequestActive == 0)
        {
            TruckRequestsImageDisable();
            TruckRequestGas.active = true;

        }
        else if (TruckRequestActive == 1)
        {
            TruckRequestsImageDisable();
            TruckRequestFix.active = true;
        }
        else if (TruckRequestActive == 2)
        {
            TruckRequestsImageDisable();
            TruckRequestCargo.active = true;
        }
        else if (TruckRequestActive == 3)
        {
            TruckRequestsImageDisable();
            TruckRequestFood.active = true;
        }
        else if (TruckRequestActive == 10)
        {
            TruckRequestsImageDisable();
            TruckRequestFinish.active = true;
        }
    }
    private void TruckRequestsImageDisable()
    {
        TruckRequestCargo.active = false;
        TruckRequestFix.active = false;
        TruckRequestGas.active = false;
        TruckRequestFood.active = false;
        TruckRequestFinish.active = false;
    }
    private void DoitTruckRequest()
    {
        if (TruckRequestActive == 0)
        {
            if (GasBool == true)
            {
                this.gameObject.GetComponent<Controller>().enabled = false;
                if (WorkTimer<=-5)
                {
                    WorkTimer = ActiveStation.GetComponent<Station>().WorkTimer;
                    SliderComponent.maxValue = WorkTimer;
                }
                WorkRequest();
            }

        }
        else if (TruckRequestActive == 1)
        {
            if (FixBool == true)
            {
                this.gameObject.GetComponent<Controller>().enabled = false;
                if (WorkTimer <= -5)
                {
                    WorkTimer = ActiveStation.GetComponent<Station>().WorkTimer;
                    SliderComponent.maxValue = WorkTimer;
                }
                WorkRequest();
            }
        }
        else if (TruckRequestActive == 2)
        {
            if (CargoBool == true)
            {
                this.gameObject.GetComponent<Controller>().enabled = false;
                if (WorkTimer <= -5)
                {
                    WorkTimer = ActiveStation.GetComponent<Station>().WorkTimer;
                    SliderComponent.maxValue = WorkTimer;
                }
               
                WorkRequest();
            }
        }
        else if (TruckRequestActive == 3)
        {
            if (FoodBool == true)
            {
                this.gameObject.GetComponent<Controller>().enabled = false;
                if (WorkTimer <= -5)
                {
                    WorkTimer = ActiveStation.GetComponent<Station>().WorkTimer;
                    SliderComponent.maxValue = WorkTimer;
                }
                WorkRequest();
            }
        }
        else if (TruckRequestActive == 10)
        {
            if (FinishBool == true)
            {
                WorkRequest();
            }
        }
    }

    private void WorkRequest()
    {
        if (TruckRequestActive != 10)
        {
            WorkTimer -= Time.deltaTime;

            if (NeedTime == true)
            {
                StopNeedTime();
            }

            SliderComponent.value += Time.deltaTime;

            if (WorkTimer <= 0)
            {
                SliderComponent.value = 0;
                TruckLeaving = true;
                this.gameObject.GetComponent<Controller>().enabled = true;

                GiveTruckRequest();

            }
        }
        else
        {
            if (FinishBool == true)
            {
                if (inEnd == false)
                {
                    
                        this.gameObject.GetComponent<Controller>().enabled = false;
                        GameObject End = GameObject.FindWithTag("End");

                        // hedef objenin pozisyonunu ve kendi pozisyonunu al
                        Vector3 targetPos = End.transform.position;
                        Vector3 selfPos = transform.position;

                        // hedef objeye doðru bak
                        transform.up = targetPos - selfPos;

                        // objeyi hedef objeye doðru hareket ettir
                        transform.position = Vector2.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);
                    
                    
                }
                else
                {

                    
                        
                        GameObject End = GameObject.FindWithTag("End2");

                        // hedef objenin pozisyonunu ve kendi pozisyonunu al
                        Vector3 targetPos = End.transform.position;

                        Scene currentScene = SceneManager.GetActiveScene();
                        string sceneName = currentScene.name;
                        if (sceneName != "Lvl13" && sceneName != "Lvl14")
                        {
                            targetPos.y += 3;
                        }
                        
                        Vector3 selfPos = transform.position;

                        // hedef objeye doðru bak
                        transform.up = targetPos - selfPos;

                        // objeyi hedef objeye doðru hareket ettir
                        transform.position = Vector2.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);
                    
                    
                }
            }
            
            
        }
        
    }
    private void TruckLeave()
    {
        if (ActiveStation != null)
        {
            Vector3 targetPos = ActiveStation.transform.GetChild(1).position;
            Vector3 selfPos = transform.position;
            targetPos = new Vector3(targetPos.x, targetPos.y, selfPos.z);

            transform.up = targetPos - selfPos;

            Vector3 direction = targetPos - selfPos;
            float moveSpeed = 2f;
            
 
             transform.position += direction.normalized * moveSpeed * Time.deltaTime;
           
        }
    

    }
    private void StopNeedTime()
    {
        NeedTime = false;
        this.gameObject.transform.GetChild(4).gameObject.active = false;
    }

    private void NewTruckRequest()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Lvl2" || sceneName == "Lvl10" || sceneName == "Lvl5" || sceneName == "Lvl7")
        {
            TruckRequestList.Add(3);
        }
        else if (sceneName == "Lvl6" || sceneName == "Lvl9")
        {
            TruckRequestList.Add(3);
            TruckRequestList.RemoveAt(0);
            TruckRequestList.RemoveAt(1);
            
        }
        else if (sceneName == "Lvl8")
        {           
            
            TruckRequestList.RemoveAt(1);
            
        }
        else if (sceneName == "Lvl4"|| sceneName == "Lvl15")
        {

            TruckRequestList.RemoveAt(0);
            TruckRequestList.RemoveAt(0);
            TruckRequestList.RemoveAt(0);
            TruckRequestList.Add(3);

        }
        else if (sceneName == "Lvl11")
        {

            TruckRequestList.RemoveAt(1);
            TruckRequestList.RemoveAt(1);
             
            TruckRequestList.Add(3);

        }
        else if (sceneName == "Lvl12" || sceneName == "Lvl13")
        {
            TruckRequestList.RemoveAt(0);
        }
        else if(sceneName == "Lvl14")
        {
            TruckRequestList.RemoveAt(0);
            TruckRequestList.RemoveAt(1);
        }
        else if (sceneName == "Lvl16" || sceneName == "Lvl17" || sceneName == "Lvl18")
        {
            TruckRequestList.RemoveAt(0);
            TruckRequestList.RemoveAt(0);

            TruckRequestList.Add(3);
        }
    }
}
