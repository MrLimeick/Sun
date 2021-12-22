using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraController : MonoBehaviour
{
    public GameObject EnemyPrefab,HeartPrefab,StarsCount,HeartCount,BestCount;
    public static int Stars,Hp = 3,best = 0;
    public static Vector2 MousePos,ScreenSize;
    void Start()
    {
        StartCoroutine(SpawnNew());
        StartCoroutine(SpawnHeart());

        best = PlayerPrefs.GetInt("Best");
        BestCount.GetComponent<Text>().text = "Best:"+best.ToString();
    }
    void Update()
    {
        StarsCount.GetComponent<Text>().text = "Stars:" + Stars.ToString();
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        HeartCount.GetComponent<Text>().text = Hp.ToString();
        ScreenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        if (Hp <= 0)
        {
            foreach (GameObject i in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(i);
            }
            if (best < Stars) PlayerPrefs.SetInt("Best",Stars);
            best = PlayerPrefs.GetInt("Best");
            BestCount.GetComponent<Text>().text = "Best:" + best.ToString();
            Stars = 0;
            Hp = 3;
        }
    }
    IEnumerator SpawnNew()
    {
        Instantiate(EnemyPrefab, new Vector2(Random.Range(-(ScreenSize.x / 2), ScreenSize.x / 2), Random.Range(-(ScreenSize.y / 2), ScreenSize.y / 2)), Quaternion.identity);
        if(Stars == 0) yield return new WaitForSeconds(2);
        else if(Stars <= 29) yield return new WaitForSeconds(3 - Stars * 9.5f * 0.01f);
        else yield return new WaitForSeconds(0.1f);
        StartCoroutine(SpawnNew());
    }
    IEnumerator SpawnHeart()
    {
        Instantiate(HeartPrefab, new Vector2(Random.Range(-(ScreenSize.x / 2), ScreenSize.x), Random.Range(-(ScreenSize.y / 2), ScreenSize.y)), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(4,15));
        StartCoroutine(SpawnHeart());
    }
}
