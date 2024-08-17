using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floormanager : MonoBehaviour
{
    [SerializeField] GameObject[] floor; 
 public void SpawnFloor(){
 int r=Random.Range(0,floor.Length);
 GameObject floort = Instantiate(floor[r],transform);
 floort.transform.position =new Vector3(Random.Range(-7f,7f),-5f,0);

 }
}
