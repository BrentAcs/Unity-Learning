using UnityEngine;

// Reference: https://catlikecoding.com/unity/tutorials/basics/building-a-graph/

public class Graph : MonoBehaviour
{
   [SerializeField]
   private Transform pointPrefab;

   [SerializeField]
   [Range(10,100)]
   private int resolution = 10;

   private Transform[] points;

   private void Awake()
   {
      float step = 2f / resolution;
      var position = Vector3.zero;
      var scale = Vector3.one * step;
      points = new Transform[resolution];
      for (int i = 0; i < points.Length; i++)
      {
         Transform point = Instantiate(pointPrefab);
         points[ i ] = point;
         position.x = (i + 0.5f) * step - 1f;
         point.localPosition = position;
         point.localScale = scale;
         point.SetParent(transform, false);
      }
   }

   // my silly idea, probably WAY wrong.
   // private const int DelayCount = 25;
   // private int currentDelay = 0;
   
   private void Update()
   {
      // if (currentDelay++ < DelayCount)
      //    return;
      // currentDelay = 0;
      
      var time = Time.time;
      for (int i = 0; i < points.Length; i++)
      {
         var point = points[ i ];
         var position = point.localPosition;
         position.y = Mathf.Sin(Mathf.PI * (position.x + time));
         point.localPosition = position;
      }
   }
}
