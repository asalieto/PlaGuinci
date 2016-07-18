using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
// Script that Lerp the color of a image depending of the scale of the transform
public class colorChangeByScale : MonoBehaviour {
 
 public enum SelectedAxis{
  xAxis,
  yAxis,
  zAxis
 }
 public SelectedAxis selectedAxis = SelectedAxis.xAxis;

Image image;
 

 public float minValue = 0.0f;
 public float maxValue = 1.0f;
 public Color minColor = Color.red;
 public Color maxColor = Color.green;
 
 void Start(){
  if (image == null){
   image = GetComponent<Image>();
  }
 }
  
 void Update () {
  switch (selectedAxis){
  case SelectedAxis.xAxis:

          image.color = Color.Lerp(minColor,
                                   maxColor,
                                   Mathf.Lerp(minValue,
                            maxValue,
                            transform.localScale.x));
   break;

  case SelectedAxis.yAxis:
   image.color = Color.Lerp(minColor,
                            maxColor,
                            Mathf.Lerp(minValue,
                            maxValue, transform.localScale.y));
   break;
  case SelectedAxis.zAxis:
   image.color = Color.Lerp(minColor,
                            maxColor,
                            Mathf.Lerp(minValue,
                     maxValue,
                     transform.localScale.z));
   break;
  }
 }
}
