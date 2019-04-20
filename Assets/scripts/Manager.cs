using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Manager
{

  public enum Side
  {
    Left,
    Right
  }

  public static Dictionary<Side, int> scores = new Dictionary<Side, int>();

}
