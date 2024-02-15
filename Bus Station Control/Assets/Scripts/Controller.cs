using UnityEngine;
using System;

public class Controller : MonoBehaviour
{

    RaycastHit2D hit;
    private bool isDrawing = false;
    public bool InPortal = false;
    private LineRenderer lineRenderer;
    private Vector3[] linePoints;
    private int linePointCount = 0;
    public float movementSpeed = 1.2f;
    private GameObject thistruck;
    private GameObject thisnottruck;
    

    private float turnSpeed = 8f;

    public AudioSource ChooseAsc;

    private void Awake()
    {
        
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineRenderer.endWidth = 0.03f;
    }

    private void Update()
    {
       
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward));



        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (isDrawing == true)
                {
                    MovePlaneAlongLine();
                }
                if (hit.collider != null)
                {

                    if (hit.collider.tag == "Ground" || hit.collider.tag == "Truck")
                    {
                        if (hit.collider.tag == "Truck")
                        {
                            if (hit.collider.gameObject == this.gameObject)
                            {
                                thistruck = this.gameObject;
                                StartDrawing();
                            }
                        }

                    }
                    else
                    {
                        FinishDrawing();
                    }
                }
            }
        }
        else
       
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isDrawing == true)
                {
                    MovePlaneAlongLine();
                }
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Ground" || hit.collider.tag == "Truck")
                    {
                        if (hit.collider.tag == "Truck")
                        {
                            if (hit.collider.gameObject == this.gameObject)
                            {
                                thistruck = this.gameObject;
                                StartDrawing();
                            }
                        }

                    }
                    else
                    {
                        FinishDrawing();
                    }
                }

            }
        }


       
         if (Input.GetMouseButton(0) && isDrawing)
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Ground" || hit.collider.tag == "Truck" || hit.collider.tag == "Portal")
                {
                    ContinueDrawing();
                }
                else if (hit.collider.tag == "GasFront" )
                {
                    if (hit.collider.gameObject.transform.parent.GetComponent<Station>().isLock == false)
                    {
                        if (this.gameObject.GetComponent<TruckAI>().TruckRequestActive == 0)
                        {
                            ChooseAsc.Play();
                            lineRenderer.SetPosition(linePointCount - 1, hit.collider.transform.parent.position);
                            FinishDrawing();
                        }
                    }
                     
                    
                }
                else if (hit.collider.tag == "FixFront")
                {
                    if (hit.collider.gameObject.transform.parent.GetComponent<Station>().isLock == false)
                    {
                        if (this.gameObject.GetComponent<TruckAI>().TruckRequestActive == 1)
                        {
                            ChooseAsc.Play();
                            lineRenderer.SetPosition(linePointCount - 1, hit.collider.transform.parent.position);
                            FinishDrawing();
                        }
                    }
                    

                }
                else if (hit.collider.tag == "CargoFront")
                {
                    if (hit.collider.gameObject.transform.parent.GetComponent<Station>().isLock == false)
                    {
                        if (this.gameObject.GetComponent<TruckAI>().TruckRequestActive == 2)
                        {
                            ChooseAsc.Play();
                            lineRenderer.SetPosition(linePointCount - 1, hit.collider.transform.parent.position);
                            FinishDrawing();
                        }
                    }
                    

                }
                else if (hit.collider.tag == "FinishFront")
                {
                    
                        if (this.gameObject.GetComponent<TruckAI>().TruckRequestActive == 10)
                        {
                            ChooseAsc.Play();
                            lineRenderer.SetPosition(linePointCount - 1, hit.collider.transform.parent.position);
                            FinishDrawing();
                        }
                    
                    

                }
                else if (hit.collider.tag == "FoodFront")
                {
                    if (hit.collider.gameObject.transform.parent.GetComponent<Station>().isLock == false)
                    {
                        if (this.gameObject.GetComponent<TruckAI>().TruckRequestActive == 3)
                        {
                            ChooseAsc.Play();
                            lineRenderer.SetPosition(linePointCount - 1, hit.collider.transform.parent.position);
                            FinishDrawing();
                        }
                    }
                    

                }
                else
                {
                    
                    FinishDrawing();
                }
                
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            
            FinishDrawing();
        }
    }

    private void StartDrawing()
    {
        isDrawing = true;
        lineRenderer.positionCount = 0;
        linePointCount = 0;
    }

    private void ContinueDrawing()
    {
        if (hit.collider.gameObject != thistruck && hit.collider.tag == "Ground") // Yalnýzca "Ground" nesnesinin üzerine çizgi çiz
        {
            
            Vector3 mousePosition = GetWorldPosition();
            linePointCount++;

            if (linePointCount > lineRenderer.positionCount)
            {
                lineRenderer.positionCount = linePointCount;
            }

            lineRenderer.SetPosition(linePointCount - 1, mousePosition);
        }
    }


    private void FinishDrawing()
    {
        if (thistruck == this.gameObject)
        {
            isDrawing = false;
            linePoints = new Vector3[linePointCount];
            lineRenderer.GetPositions(linePoints);

            MovePlaneAlongLine();
            thistruck = thisnottruck;


        }

    }

    private Vector3 GetWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = transform.position.z - Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void MovePlaneAlongLine()
    {
        StartCoroutine(MovePlane());
        
    }
    public void ClearLine()
    {
        lineRenderer.positionCount = 0;
        linePointCount = 0;
    }
    
    
    private System.Collections.IEnumerator MovePlane()
    {
        for (int i = 0; i < linePoints.Length; i++)
        {
            if (isDrawing )
            {
                
                yield break; // Eðer çizim iþlemi sýrasýnda çizgi çizme devam ediyorsa, döngüden çýkýn
            }
            if (InPortal)
            {
                ClearLine();
                InPortal = false;
                yield break;
            }

            Vector3 targetPosition = linePoints[i];
            Vector3 targetDirection = (targetPosition - transform.position).normalized;
            targetDirection = new Vector3(targetDirection.x, targetDirection.y, transform.position.z);
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetDirection);
            float distance = Vector3.Distance(transform.position, targetPosition);
            float duration = distance / movementSpeed;

            float elapsedTime = 0f;
            Vector3 initialPosition = transform.position;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;
                transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
                yield return null;

                if (isDrawing)
                {
                    
                    yield break; // Eðer çizim iþlemi sýrasýnda çizgi çizme devam ediyorsa, döngüden çýkýn
                }
                if (InPortal)
                {
                    ClearLine();
                    InPortal = false;
                    yield break;
                }
            }

            if (linePointCount > 1)
            {
                Vector3[] positions = new Vector3[linePointCount - 1];

                for (int j = 1; j < linePointCount; j++)
                {
                    positions[j - 1] = lineRenderer.GetPosition(j);
                }

                linePointCount--;
                lineRenderer.positionCount = linePointCount;
                lineRenderer.SetPositions(positions);
            }
        }

        lineRenderer.positionCount = 0;
        linePointCount = 0;
    }


}