using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class man1 : MonoBehaviour
{
    
    GameObject currentfloor;
    public float Rmove=3f;
    public float Lmove=-3f;
    public float Hmove=5f;
    [SerializeField] int hp;
    [SerializeField] GameObject hpall;
    [SerializeField] Text scoreText;
    // Start is called before the first frame update!
    float scoretime;
    int score;
    void Start()
    {
      hp =10;
      score = 1;
      scoretime = 0;
    }
   
    // Update is called once per frame.
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
 transform.Translate(Rmove*Time.deltaTime,0,0);
  GetComponent<SpriteRenderer>().flipX = false;
  GetComponent<Animator>().SetBool("move",true);
        }
        else if(Input.GetKey(KeyCode.A)){
 transform.Translate(Lmove*Time.deltaTime,0,0);
 GetComponent<SpriteRenderer>().flipX = true;
 GetComponent<Animator>().SetBool("move",true);
        }
//          else if(Input.GetKey(KeyCode.W)){
//  transform.Translate(0,Hmove*Time.deltaTime,0);
//         }
         else{
            GetComponent<Animator>().SetBool("move",false);
         }
        updatescore();

    }
    void OnCollisionEnter2D(Collision2D othe){
        if(othe.gameObject.tag=="floor1"){

        if (othe.contacts[0].normal== new Vector2(0,1f)){
currentfloor = othe.gameObject;
Modifyhp(1);
        }
        }

 else if(othe.gameObject.tag=="floor2"){
 if (othe.contacts[0].normal== new Vector2(0,1f)){
currentfloor = othe.gameObject;
Modifyhp(-2);
GetComponent<Animator>().SetTrigger("hurt");
othe.gameObject.GetComponent<AudioSource>().Play();
        }
        }
        else if(othe.gameObject.tag=="hurt"){
            // currentfloor.GetComponent<BoxCollider2D>().enabled=false;
            GetComponent<Animator>().SetTrigger("hurt");
        Modifyhp(-3);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.tag=="death"){
Debug.Log("end");
        }
    }
     void Modifyhp(int num){
        hp+=num;
        if(hp>10){
            hp=10;
        }
        else if (hp<0){
            hp=0;
        }
        updatehp();
    }
    void updatehp(){
        for(int i=0;i<hpall.transform.childCount;i++){
            if(hp>i){
                hpall.transform.GetChild(i).gameObject.SetActive(true);
            }
            else{
                hpall.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    void updatescore(){
        scoretime+=Time.deltaTime;
        if(scoretime>4f){
            score++;
            scoretime=0;
            scoreText.text="地下"+ score.ToString() + "層";
        }

    }
}
