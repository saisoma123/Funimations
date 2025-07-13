using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchToMenu : MonoBehaviour
{
   void OnMouseDown()
   {
       SceneManager.LoadScene("SampleScene");
   }
}
