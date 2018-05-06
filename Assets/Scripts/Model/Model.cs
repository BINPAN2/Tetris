using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {

    public const int MAX_ROWS = 23;
    public const int MAX_COLUMNS = 10;

    private int score = 0;
    private int highscore = 0;
    private int numbersGame = 0;

    public int Score { get { return score; } }
    public int Highscore { get { return highscore; } }
    public int NumbersGame { get { return numbersGame; } }

    public bool isDataUpdate = false;

    private Transform[,] map = new Transform[MAX_COLUMNS, MAX_ROWS];

    private void Awake()
    {
        LoadData();
    }

    public bool IsValidMapPosition(Transform t)
    {
        foreach (Transform child in t)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            if (IsInsidemap(pos)==false) return false;
            if (map[(int)pos.x, (int)pos.y] != null) return false;
        }
        return true;
    }

    public bool IsInsidemap(Vector2 pos)
    {
        return(pos.x >= 0 && pos.x < MAX_COLUMNS && pos.y >= 0);
    }

    public bool IsGameOver()
    {
        for (int i = 20; i < MAX_ROWS; i++)
        {
            for (int j = 0;  j < MAX_COLUMNS;  j++)
            {
                if (map[j, i] != null)
                {
                    numbersGame++;
                    SaveData();
                    return true;
                }
            }
        }
        return false;
    }

    public bool  PlaceShape(Transform t)
    {
        foreach (Transform child in t)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            map[(int)pos.x, (int)pos.y] = child;
        }
        return CheckMap();
    }

    //检查地图是否需要消除行
    private bool CheckMap()
    {
        int count = 0;
        for (int i = 0; i < MAX_ROWS; i++)
        {
           bool isFull= CheckIsRowFull(i);
            if (isFull==true)
            {
                count++;
                DeleteRow(i);
                MoveDownRowsAbove(i+1);
                i--;
            }
        }
        if (count > 0)
        {
            score += (count * 100);
            if (score > highscore)
            {
                highscore = score;
            }
            isDataUpdate = true;
            return true;
        }
        else return false;
    }

    private bool CheckIsRowFull(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i, row] == null) return false;
        }
        return true;
    }

    private void DeleteRow(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            Destroy(map[i, row].gameObject);
            map[i, row] = null;
        }
    }

    private void MoveDownRowsAbove(int row)
    {
        for (int i = row; i < MAX_ROWS; i++)
        {
            MoveDownrow(i);
        }
    }

    private void MoveDownrow(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i, row] !=null)
            {
                map[i, row-1] = map[i, row];
                map[i, row] = null;
                map[i, row-1].position += new Vector3(0, -1, 0);
            }
        }
    }

    private void LoadData()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        numbersGame = PlayerPrefs.GetInt("numbersGame", 0);
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("highscore", highscore);
        PlayerPrefs.SetInt("numbersGame", numbersGame);
    }

    public void Restart()
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            for (int j = 0; j < MAX_ROWS; j++)
            {
                if (map[i,j]!=null)
                {
                    Destroy(map[i, j].gameObject);
                    map[i, j] = null;
                }
            }
        }
        score = 0;
    }
}
