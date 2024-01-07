using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class GameData : MonoBehaviour

{

    private static Vector3 _mousePos;
    private static float _padding = 0f;
    private static int _playerHealth = 10;
    private static int _score = 0;
    public static Vector3Int _roomIndex;

    public static int PlayerHealth
    {
        get { return _playerHealth; }
        set { _playerHealth = value; }
    }

    public static int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public static Vector3Int RoomIndex
    {
        get { return _roomIndex; }
        set { _roomIndex = value; }
    }

    public static Vector3 MousePos

    {
        get { return GetMousePos(); }
    }

    private static Vector3 GetMousePos()

    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f);
        return _mousePos;

    }

    public static float XMin

    {

        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _padding; }

    }

    public static float YMin

    {

        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + _padding; }

    }

    public static float XMax

    {

        get { return Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _padding; }

    }

    public static float YMax

    {

        get { return Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - _padding; }

    }


}