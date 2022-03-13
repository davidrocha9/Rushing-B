using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploy : MonoBehaviour
{
    public GameObject coinPrefab;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start () {
        StartCoroutine(wave());
    }

    private void spawn(){
        System.Random rnd = new System.Random();
        int y  = rnd.Next(-1, 4);
        //feupPattern(y);
        //ddjdPattern(y);
        //dnaPattern(y);
        arrowPattern(y);
    }

    private void feupPattern(int y)
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

    private void ddjdPattern(int y)
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

    private void dnaPattern(int y)
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

    private void arrowPattern(int y)
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

    IEnumerator wave(){
        spawn();
        while(true){
            yield return new WaitForSeconds(10);
            spawn();
        }
    }
}
