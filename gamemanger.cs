using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamemanger : MonoBehaviour
{
    public GameObject stand, Bed, YellowChair, BlueTable, BeanBag, pillow,standhead,Soundtrack,TimeFX;
    GameObject clone,clonestand;
    GameObject[] cloness,result;
    public GameObject UI,ui2;
    public Text time,score_text,countdown,TimerToWin;
    public int counterValueScore = 5;
    public float counterValue = 5;
    public int countdown_int = 3;
    public int TimerToWin_int = 30;
    public int objectsN1Round;
    int counter=0;
    int objectCounter = 0;
    bool checking = false;
    bool check1time = false;
    bool check1time2 = false;
    standScript objectsNscene;
    List<GameObject> objects = new List<GameObject>(4);
    float randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        // cloness=GameObject.FindGameObjectsWithTag("s");
        ui2.gameObject.SetActive(true);
        StartCoroutine("Counter");
        time.text = "2:00";
        TimerToWin.text = TimerToWin_int.ToString();
        objectsN1Round--;
        objectsNscene = standhead.GetComponent<standScript>();
        Soundtrack.gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectsNscene.objects.Count > 3)
        {
            checking = true;
           
        }
        else 
        { 
            checking = false;
            check1time = false;
            check1time2 = false;
        }

        if (checking)
        {
            if (!check1time)
            {
                check1time = true;
                StartCoroutine("Winner");
            }

        }
        if(!checking)
        {
            if (!check1time2)
            {
                TimerToWin_int = 30;
                TimerToWin.text = TimerToWin_int.ToString();
                StopCoroutine("Winner");
                check1time2 = true;
            }
        }
        

    }
    private void FixedUpdate()
    {
     if (clone)
        {
            cloness = GameObject.FindGameObjectsWithTag("s");

            for (int i=0; i<cloness.Length;i++)
            {
                cloness[i].transform.position = new Vector3(cloness[i].transform.position.x, cloness[i].transform.position.y, standhead.transform.position.z);

            }

        }
      


    }


    public void RandomSpawner ()
    {
        objects.Add(Bed);
        objects.Add(YellowChair);
        objects.Add(BlueTable);
        objects.Add(BeanBag);
        objects.Add(pillow);

        if (objectCounter < 5)
        {
            randomPosition = Random.Range(-0.5f, 0.5f);
            clone = Instantiate(objects[objectCounter], new Vector3(randomPosition, 3.5f, standhead.transform.position.z), Quaternion.identity);
            objectCounter++;
            
        }

         if (objectCounter == 5)
      {         
            if (!GameObject.Find("Bed(Clone)"))
            {
                  Invoke("instantiate0", 0.5f);

            }
         if (!GameObject.Find("YellowChair(Clone)"))
            {
                Invoke("instantiate1", 1f);
            }
         if (!GameObject.Find("BlueTable(Clone)"))
            {
                Invoke("instantiate2", 1.5f);

            }
         if (!GameObject.Find("BeanBag(Clone)"))
            {
                Invoke("instantiate3", 2.5f);
            }

         if (!GameObject.Find("pillow(Clone)"))
            {
                Invoke("instantiate4", 3f);
            }
        }
        

    }

    public void instantiate0()
    {
        randomPosition = Random.Range(-0.5f, 0.5f);
        clone = Instantiate(objects[0], new Vector3(randomPosition, 3.5f, standhead.transform.position.z), Quaternion.identity);

    }
    public void instantiate1()
    {
        randomPosition = Random.Range(-0.5f, 0.5f);

        clone = Instantiate(objects[1], new Vector3(randomPosition, 3.5f, standhead.transform.position.z), Quaternion.identity);

    }
    public void instantiate2()
    {
        randomPosition = Random.Range(-0.5f, 0.5f);

        clone = Instantiate(objects[2], new Vector3(randomPosition, 3.5f, standhead.transform.position.z), Quaternion.identity);

    }
    public void instantiate3()
    {
        randomPosition = Random.Range(-0.5f, 0.5f);

        clone = Instantiate(objects[3], new Vector3(randomPosition, 3.5f, standhead.transform.position.z), Quaternion.identity);

    }
    public void instantiate4()
    {
        randomPosition = Random.Range(-0.5f, 0.5f);

        clone = Instantiate(objects[4], new Vector3(randomPosition, 3.5f, standhead.transform.position.z), Quaternion.identity);

    }

    IEnumerator StartInstantiate()
    {
        RandomSpawner();
        counter++;
        yield return new WaitForSeconds(3f);
        StartCoroutine("StartInstantiate");

        //if (counter ==1)
        //{
        //    StartCoroutine("StartCounter");

        //    //yield return new WaitForSeconds(3f);
        //    //  StopCoroutine("StartInstantiate");
        //}
    }
    IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(1f);
        int min = Mathf.FloorToInt(counterValue / 60);
        int sec = Mathf.FloorToInt(counterValue % 60);
        time.text = min.ToString("0") + ":" + sec.ToString("00");
        counterValue--;
        counterValueScore--;
        StartCoroutine("StartCounter");
        if (counterValue == 4)
        {
            TimeFX.GetComponent<AudioSource>().Play();

        }
        if (counterValue==-1)
        {
            
            time.text = "0:00";
            score();
            StopCoroutine("StartCounter");
        }
        if (counterValueScore == -2)
        {
            score();
            StopCoroutine("StartCounter");
        }
    }
    IEnumerator Counter()
    {
        ui2.SetActive(false);

        yield return new WaitForSeconds(1f);
        countdown.text = countdown_int.ToString();
        countdown_int--;
        StartCoroutine("Counter");
        if (countdown_int == -1)
        {
            countdown.gameObject.SetActive(false);
            clonestand= Instantiate(stand, new Vector3(0, 3.5f, standhead.transform.position.z), Quaternion.identity);
        }
        if (countdown_int == -8)
        {

            standhead.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(clonestand.gameObject);
        }
        if (countdown_int == -10)
        {
            StartCoroutine("StartInstantiate");
            StartCoroutine("StartCounter");

        }
    }
    IEnumerator Winner()
    {

        yield return new WaitForSeconds(1f);
        TimerToWin.text = TimerToWin_int.ToString();
        TimerToWin_int--;
        StartCoroutine("Winner");
        //if (TimerToWin_int == 29)
        //{
        //    startCoundwonFX.GetComponent<AudioSource>().Play();
        //}


        if (TimerToWin_int == 4)
        {
            TimeFX.GetComponent<AudioSource>().Play();
        }
        if (TimerToWin_int==0)
        {
            TimerToWin.text = "0";
            StopCoroutine("StartCounter");
            StopCoroutine("StartInstantiate");
            score_text.text = "You      Won";
            Invoke("uistarter", 2f);

        }

    }


    public void checkWinner ()
    {
        


    }
    public void score ()
    {
            //result= GameObject.FindGameObjectsWithTag("s");
            //int x = result.Length;
            //score_text.text = x.ToString();
            //Invoke("uistarter", 2f);
       
       
        {
            score_text.text = "Better Luck Next Time";
            Invoke("uistarter", 2f);
        }
    }

    public void uistarter ()
    {
        UI.SetActive(true);
    }
}
