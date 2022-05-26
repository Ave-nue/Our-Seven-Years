using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkGameManager : MonoBehaviour
{
    //总共8*8个格子，左侧是女生的粉色格子，右侧是男生的蓝色格子，各自4*8的数量，中间可以空一列出来
    //女生有一个独特的内容，是跳舞，男生有一个独特的，是打游戏，这两个最后也消不掉
    //最后需要留一对一样的和这一对不一样的，才能获胜
    static private LinkGameManager m_instance;
    static public LinkGameManager Instance
    {
        get { return m_instance; }
    }

    public GameObject gridPrefab;
    public Transform gridParent;
    public List<Sprite> commonGrids;
    public List<Sprite> girlGrids;
    public List<Sprite> boyGrids;

    private LinkGameGrid[,] m_girlGrids;
    private LinkGameGrid[,] m_boyGrods;

    private void Awake()
    {
        m_instance = this;
    }

    private void OnDestroy()
    {
        m_instance = null;
    }

    private void Start()
    {
        this.Restart();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 selectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.Select(selectPos.x, selectPos.y);
        }
    }

    public void Restart()
    {
        //初始化数据
        m_girlGrids = new LinkGameGrid[4, 8];
        m_boyGrods = new LinkGameGrid[4, 8];
        int maxCommonCount = commonGrids.Count;
        int curCommonCount = 0;
        int curSexCount = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                m_girlGrids[i, j] = Instantiate(gridPrefab, gridParent).GetComponent<LinkGameGrid>();
                m_boyGrods[i, j] = Instantiate(gridPrefab, gridParent).GetComponent<LinkGameGrid>();

                if (curCommonCount < maxCommonCount)
                {
                    m_girlGrids[i, j].SetSprite(0, commonGrids[curCommonCount]);
                    m_boyGrods[i, j].SetSprite(1, commonGrids[curCommonCount]);
                    curCommonCount++;
                    continue;
                }

                m_girlGrids[i, j].SetSprite(0, girlGrids[curSexCount % girlGrids.Count]);
                m_boyGrods[i, j].SetSprite(1, boyGrids[curSexCount % boyGrids.Count]);
                curSexCount++;
            }
        }

        //打乱数据
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int curIndex = i * 8 + j;
                if (curIndex > 30)
                    break;

                int swapIndex = Random.Range(curIndex, 32);
                int swapI = Mathf.FloorToInt(swapIndex / 8);
                int swapJ = swapIndex % 8;
                LinkGameGrid item = m_girlGrids[swapI, swapJ];
                m_girlGrids[swapI, swapJ] = m_girlGrids[i, j];
                m_girlGrids[i, j] = item;

                swapIndex = Random.Range(curIndex, 32);
                swapI = Mathf.FloorToInt(swapIndex / 8);
                swapJ = swapIndex % 8;
                item = m_boyGrods[swapI, swapJ];
                m_boyGrods[swapI, swapJ] = m_boyGrods[i, j];
                m_boyGrods[i, j] = item;
            }
        }

        //布置格子
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                m_girlGrids[i, j].transform.SetPositionAndRotation(new Vector3(i - 4, j - 3.5f, 0f), Quaternion.identity);
                m_girlGrids[i, j].SetCoor(new Vector2Int(i, j));

                m_boyGrods[i, j].transform.SetPositionAndRotation(new Vector3(i + 1, j - 3.5f, 0f), Quaternion.identity);
                m_boyGrods[i, j].SetCoor(new Vector2Int(i, j));
            }
        }
    }

    public void Select(float x, float y)
    {
        float absX = Mathf.Abs(x);
        if (absX < 0.5f || absX > 4.5f)
            return;
        float absY = Mathf.Abs(y);
        if (absY > 4f)
            return;

        LinkGameGrid[,] curGrids = x < 0 ? m_girlGrids : m_boyGrods;
        x = x < 0 ? x : x - 1;
        int indexH = (Mathf.RoundToInt(x) + 4) % 4;
        int indexV = (Mathf.FloorToInt(y) + 4);
        curGrids[indexH, indexV].Select();
    }

    public bool Check2Eliminate(LinkGameGrid from, LinkGameGrid to)
    {
        if (from.Sex == to.Sex)
            return false;

        if (from.sprite.sprite != to.sprite.sprite)
            return false;

        LinkGameGrid girl, boy;
        girl = from.Sex == 0 ? from : to;
        boy = to.Sex == 0 ? from : to;

        //todo 去尝试找可行线路
        //横向去找哪一列可以完成线路
        //1-同时通向中间列的情况
        if (CheckRow(m_girlGrids, girl.Y, girl.X, 4) && CheckRow(m_boyGrods, boy.Y, -1, boy.X))
            return true;

        //2-拐点在女生这边
        for (int i = -1; i < 4; i++)
        {
            int minX = Mathf.Min(i, girl.X);
            int maxX = Mathf.Max(i, girl.X);
            if (!CheckRow(m_girlGrids, girl.Y, minX, maxX))
            {
                continue;
            }
            if (!CheckRow(m_girlGrids, boy.Y, i, 4))
            {
                continue;
            }
            if (!CheckRow(m_boyGrods, boy.Y, -1, boy.X))
            {
                continue;
            }
            if (i == -1)
                return true;
            int minY = Mathf.Min(girl.Y, boy.Y);
            int maxY = Mathf.Max(girl.Y, boy.Y);
            if (i == girl.X)
            {
                if (minY == girl.Y)
                    minY++;
                if (maxY == girl.Y)
                    maxY--;
            }
            if (CheckCol(m_girlGrids, i, minY - 1, maxY + 1))
                return true;
        }

        //3-拐点在男生这边
        for (int i = 0; i < 5; i++)
        {
            int minX = Mathf.Min(i, boy.X);
            int maxX = Mathf.Max(i, boy.X);
            if (!CheckRow(m_girlGrids, girl.Y, girl.X, 4))
            {
                continue;
            }
            if (!CheckRow(m_boyGrods, boy.Y, minX, maxX))
            {
                continue;
            }
            if (!CheckRow(m_boyGrods, boy.Y, 0, i))
            {
                continue;
            }
            if (i == 4)
                return true;
            int minY = Mathf.Min(girl.Y, boy.Y);
            int maxY = Mathf.Max(girl.Y, boy.Y);
            if (i == boy.X)
            {
                if (minY == boy.Y)
                    minY++;
                if (maxY == boy.Y)
                    maxY--;
            }
            if (CheckCol(m_boyGrods, i, minY - 1, maxY + 1))
                return true;
        }

        //纵向去找哪一行可以完成线路
        for (int i = -1; i < 9; i++)
        {
            int minY = Mathf.Min(i, girl.Y);
            int maxY = Mathf.Max(i, girl.Y);

            if (!CheckCol(m_girlGrids, girl.X, minY, maxY))
                continue;

            minY = Mathf.Min(i, boy.Y);
            maxY = Mathf.Max(i, boy.Y);
            if (!CheckCol(m_boyGrods, boy.X, minY, maxY))
                continue;

            if (i == -1 || i == 8)
                return true;

            if (!CheckRow(m_girlGrids, i, girl.X, 4))
                continue;
            if (!CheckRow(m_boyGrods, i, -1, boy.X))
                continue;

            return true;
        }

        return false;
    }

    public void RemoveOneItem(int boyOrGirl, LinkGameGrid item)
    {
        LinkGameGrid[,] curGrids = boyOrGirl == 0 ? m_girlGrids : m_boyGrods;
        if (curGrids[item.X, item.Y] != item)
            return;

        curGrids[item.X, item.Y] = null;
        return;
    }

    private bool CheckRow(LinkGameGrid[,] grids, int y, int minX, int maxX)
    {
        Debug.Log("Row y = " + y + " x = " + minX + " ~ " + maxX);
        for (int x = minX + 1; x < maxX; x++)
        {
            if (grids[x, y] != null)
                return false;
        }
        return true;
    }

    private bool CheckCol(LinkGameGrid[,] grids, int x, int minY, int maxY)
    {
        Debug.Log("Col x = " + x + " y = " + minY + " ~ " + maxY);
        for (int y = minY + 1; y < maxY; y++)
        {
            if (grids[x, y] != null)
                return false;
        }
        return true;
    }
}
