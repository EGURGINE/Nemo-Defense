using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private float money;
    public float Money
    {
        get { return money; }
        set { money = value; }
    }

}
