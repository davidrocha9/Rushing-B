using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Obstacles 
{
  Coins,
  TrashCans,
  LightBulbs,
  Notebooks,
  Coffees,
  Masks,
}


public class Deploy : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject maskPrefab;
    public GameObject coffeePrefab;
    public GameObject notebookPrefab;
    public GameObject trashCanPrefab;
    public GameObject lightBulbPrefab;
    public Player player;
    private Vector2 screenBounds;
    private List<Obstacles> obstacles = new List<Obstacles>();
    int obstacleCnt = 0;
    private static System.Timers.Timer aTimer;

    private void QuickSort(int[] arr, int start, int end)
    {
        int i;
        if (start < end)
        {
            i = Partition(arr, start, end);
    
            QuickSort(arr, start, i - 1);
            QuickSort(arr, i + 1, end);
        }
    }
    
    private int Partition(int[] arr, int start, int end)
    {
        int temp;
        int p = arr[end];
        int i = start - 1;
    
        for (int j = start; j <= end - 1; j++)
        {
            if (arr[j] <= p)
            {
                i++;
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    
        temp = arr[i + 1];
        arr[i + 1] = arr[end];
        arr[end] = temp;
        return i + 1;
    }
    
    // Use this for initialization
    void Start () {
        int cnt = 0;
        for (int y = 0; y < 60; y++) {
            switch(cnt){
                case 0:
                    obstacles.Add(Obstacles.Coins);
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    obstacles.Add(Obstacles.LightBulbs);
                    break;
                default:
                    break;
            }
            cnt++;
            if (cnt > 4)
            {
                cnt = 0;
            }
        }

        int[] arr = new int[60];
        for (int x = 0; x < 60; x++) 
        {
            arr[x] = x;
        }
        QuickSort(arr, 0, 59);
        List<Obstacles> temp = new List<Obstacles>(new Obstacles[60]);

        for (int x = 0; x < 60; x++) {
            temp[x] = obstacles[arr[x]];
        }

        InvokeRepeating("spawnTrashCans", 2.0f, 7.0f);
        InvokeRepeating("spawnNotebook", 5.0f, 15.0f);
        InvokeRepeating("spawnCoffee", 2.0f, 4.0f);
        InvokeRepeating("spawnMask", 2.0f, 4.0f);

        StartCoroutine(wave());
    }

    public double GetRandomNumber(double minimum, double maximum)
    { 
        System.Random random = new System.Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    private void spawn()
    {
        Obstacles o = obstacles[obstacleCnt % 60];
        switch(o)
        {
            case Obstacles.Coins:
                spawnCoins();
                break;
            case Obstacles.LightBulbs:
                spawnLightBulbs();
                break;
            default:
                break;
        }

        obstacleCnt++;
    }

    private void spawnNotebook()
    {
        GameObject notebook = Instantiate(notebookPrefab) as GameObject;
        notebook.transform.position = new Vector2(10, 0);
    }

    private void spawnMask()
    {
        float choice = (float) GetRandomNumber(0, 100);
        if (choice > 50) {
            GameObject mask = Instantiate(maskPrefab) as GameObject;
            mask.transform.position = new Vector2(10, 0);
        }
    }

    private void spawnCoffee()
    {
        float choice = (float) GetRandomNumber(0, 100);
        if (choice > 75) {
            GameObject coffee = Instantiate(coffeePrefab) as GameObject;
            coffee.transform.position = new Vector2(10, 0);
        }
    }

    private void spawnCoins()
    {
        float y = (float) GetRandomNumber(-1, 4);

        float choice = (float) GetRandomNumber(0, 100);

        if (choice > 75)
            feupPattern(y);
        else if (choice > 50)
            ddjdPattern(y);
        else if (choice > 25)
            dnaPattern(y);
        else
            arrowPattern(y);
    }

    private void spawnTrashCans()
    {
        GameObject trashCan = Instantiate(trashCanPrefab) as GameObject;
        GameObject player = GameObject.Find("Player");
        trashCan.transform.position = new Vector2(10, player.transform.position.y);
    }

    private void spawnLightBulbs(){
        float y = (float) GetRandomNumber(3, 7);
        GameObject lightBulb = Instantiate(lightBulbPrefab) as GameObject;
        lightBulb.transform.position = new Vector2(10, y);
    }

    private void feupPattern(float y)
    {
        // F
        List<int> list = new List<int>(new int[]{0, 1, 2, 3, 6, 7, 8, 9, 12});
        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (list.Contains(3*i + j))
                {
                    GameObject obj = Instantiate(coinPrefab) as GameObject;
                    obj.transform.position = new Vector2(10 + 0.5f*j, y - 0.5f*i);
                }
            }
        }

        // E
        list = new List<int>(new int[]{0, 1, 2, 3, 6, 7, 8, 9, 12, 13, 14});
        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (list.Contains(3*i + j))
                {
                    GameObject obj = Instantiate(coinPrefab) as GameObject;
                    obj.transform.position = new Vector2(12 + 0.5f*j, y - 0.5f*i);
                }
            }
        }

        // U
        list = new List<int>(new int[]{0, 2, 3, 5, 6, 8, 9, 11, 12, 13, 14});
        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (list.Contains(3*i + j))
                {
                    GameObject obj = Instantiate(coinPrefab) as GameObject;
                    obj.transform.position = new Vector2(14 + 0.5f*j, y - 0.5f*i);
                }
            }
        }

        // P
        list = new List<int>(new int[]{0, 1, 2, 3, 5, 6, 7, 8, 9, 12});
        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (list.Contains(3*i + j))
                {
                    GameObject obj = Instantiate(coinPrefab) as GameObject;
                    obj.transform.position = new Vector2(16 + 0.5f*j, y - 0.5f*i);
                }
            }
        }
    }

    private void ddjdPattern(float y)
    {
        // D
        List<int> list = new List<int>(new int[]{0, 1, 3, 5, 6, 8, 9, 11, 12, 13});
        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (list.Contains(3*i + j))
                {
                    GameObject obj = Instantiate(coinPrefab) as GameObject;
                    obj.transform.position = new Vector2(10 + 0.5f*j, y - 0.5f*i);
                }
            }
        }

        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (list.Contains(3*i + j))
                {
                    GameObject obj = Instantiate(coinPrefab) as GameObject;
                    obj.transform.position = new Vector2(12 + 0.5f*j, y - 0.5f*i);
                }
            }
        }

        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (list.Contains(3*i + j))
                {
                    GameObject obj = Instantiate(coinPrefab) as GameObject;
                    obj.transform.position = new Vector2(16 + 0.5f*j, y - 0.5f*i);
                }
            }
        }

        // J
        list = new List<int>(new int[]{0, 1, 2, 4, 7, 10, 12, 13});
        for (int i = 0; i < 5; i++) 
        {
            for (int j = 0; j < 3; j++) 
            {
                if (list.Contains(3*i + j))
                {
                    GameObject obj = Instantiate(coinPrefab) as GameObject;
                    obj.transform.position = new Vector2(14 + 0.5f*j, y - 0.5f*i);
                }
            }
        }
    }

    private void dnaPattern(float y)
    {
        for (int i = 0; i < 3; i++) 
        {
            GameObject obj = Instantiate(coinPrefab) as GameObject;
            GameObject obj1 = Instantiate(coinPrefab) as GameObject;
            GameObject obj2 = Instantiate(coinPrefab) as GameObject;
            GameObject obj3 = Instantiate(coinPrefab) as GameObject;
            GameObject obj4 = Instantiate(coinPrefab) as GameObject;
            GameObject obj5 = Instantiate(coinPrefab) as GameObject;
            GameObject obj6 = Instantiate(coinPrefab) as GameObject;
            GameObject obj7 = Instantiate(coinPrefab) as GameObject;

            obj.transform.position = new Vector2(10 + 5*i + i, y);
            obj1.transform.position = new Vector2(10 + 5*i + i + 0.5f, y);
            obj2.transform.position = new Vector2(10 + 5*i + i, y - 2.5f);
            obj3.transform.position = new Vector2(10 + 5*i + i + 0.5f, y - 2.5f);
            obj4.transform.position = new Vector2(10 + 5*i + i + 5, y);
            obj5.transform.position = new Vector2(10 + 5*i + i + 0.5f + 5, y);
            obj6.transform.position = new Vector2(10 + 5*i + i + 5, y - 2.5f);
            obj7.transform.position = new Vector2(10 + 5*i + i + 0.5f + 5, y - 2.5f);
        }

        for (int i = 0; i < 3; i++) 
        {
            GameObject obj = Instantiate(coinPrefab) as GameObject;
            GameObject obj1 = Instantiate(coinPrefab) as GameObject;
            GameObject obj2 = Instantiate(coinPrefab) as GameObject;
            GameObject obj3 = Instantiate(coinPrefab) as GameObject;
            GameObject obj4 = Instantiate(coinPrefab) as GameObject;
            GameObject obj5 = Instantiate(coinPrefab) as GameObject;
            GameObject obj6 = Instantiate(coinPrefab) as GameObject;
            GameObject obj7 = Instantiate(coinPrefab) as GameObject;

            obj.transform.position = new Vector2(11 + 5*i + i, y - 0.5f);
            obj1.transform.position = new Vector2(11 + 5*i + i + 0.5f, y - 0.5f);
            obj2.transform.position = new Vector2(11 + 5*i + i, y - 0.5f - 1.5f);
            obj3.transform.position = new Vector2(11 + 5*i + i + 0.5f, y - 0.5f - 1.5f);
            obj4.transform.position = new Vector2(11 + 5*i + i + 3, y - 0.5f);
            obj5.transform.position = new Vector2(11 + 5*i + i + 0.5f + 3, y - 0.5f);
            obj6.transform.position = new Vector2(11 + 5*i + i + 3, y - 0.5f - 1.5f);
            obj7.transform.position = new Vector2(11 + 5*i + i + 0.5f + 3, y - 0.5f - 1.5f);
        }

        for (int i = 0; i < 3; i++) 
        {
            GameObject obj = Instantiate(coinPrefab) as GameObject;
            GameObject obj1 = Instantiate(coinPrefab) as GameObject;
            GameObject obj2 = Instantiate(coinPrefab) as GameObject;
            GameObject obj3 = Instantiate(coinPrefab) as GameObject;
            GameObject obj4 = Instantiate(coinPrefab) as GameObject;
            GameObject obj5 = Instantiate(coinPrefab) as GameObject;
            GameObject obj6 = Instantiate(coinPrefab) as GameObject;
            GameObject obj7 = Instantiate(coinPrefab) as GameObject;

            obj.transform.position = new Vector2(12 + 5*i + i, y - 1);
            obj1.transform.position = new Vector2(12 + 5*i + i + 0.5f, y - 1);
            obj2.transform.position = new Vector2(12 + 5*i + i, y - 1 - 0.5f);
            obj3.transform.position = new Vector2(12 + 5*i + i + 0.5f, y - 1 - 0.5f);
            obj4.transform.position = new Vector2(13 + 5*i + i, y - 1);
            obj5.transform.position = new Vector2(13 + 5*i + i + 0.5f, y - 1);
            obj6.transform.position = new Vector2(13 + 5*i + i, y - 1 - 0.5f);
            obj7.transform.position = new Vector2(13 + 5*i + i + 0.5f, y - 1 - 0.5f);
        }
    }

    private void arrowPattern(float y)
    {
        // F
        List<int> list = new List<int>(new int[]{0, 1, 5, 6, 10, 11, 14, 15, 17, 18, 20, 21});
        for (int k = 0; k < 3; k++)
        { 
            for (int i = 0; i < 6; i++) 
            {
                for (int j = 0; j < 4; j++) 
                {
                    if (list.Contains(4*i + j))
                    {
                        GameObject obj = Instantiate(coinPrefab) as GameObject;
                        obj.transform.position = new Vector2(10 + 0.5f*j + 2.5f*k, y - 0.5f*i);
                    }
                }
            }
        }
    }

    IEnumerator wave() 
    {
        while(true) {
            yield return new WaitForSeconds(2);
            if (!player.alive) 
            {
                CancelInvoke("spawnTrashCans");
                CancelInvoke("spawnNotebook");
                CancelInvoke("spawnCoffee");
                CancelInvoke("spawnMask");
                break;
            }
            spawn();
        }
    }
}