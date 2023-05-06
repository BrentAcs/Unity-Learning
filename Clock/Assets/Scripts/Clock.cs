using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
   [SerializeField]
   private Transform hoursPivot;
   
   [SerializeField]
   private Transform minutesPivot;

   [SerializeField]
   private Transform secondsPivot;

   private const float HoursToDegrees = -30f;
   private const float MinutesToDegrees = -6f;
   private const float SecondsToDegrees = -6f;
   
   private void Awake()
   {
      UpdateClock();
   }

   // Start is called before the first frame update
   void Start()
   {
   }

   // Update is called once per frame
   void Update()
   {
      UpdateClock();
   }

   private void UpdateClock()
   {
      var time = DateTime.Now.TimeOfDay;
      hoursPivot.localRotation = Quaternion.Euler(0f,0f,(float) (HoursToDegrees * time.TotalHours));
      minutesPivot.localRotation = Quaternion.Euler(0f,0f,(float) (MinutesToDegrees * time.TotalMinutes));
      secondsPivot.localRotation = Quaternion.Euler(0f,0f,(float) (SecondsToDegrees * time.TotalSeconds));
   }
}
