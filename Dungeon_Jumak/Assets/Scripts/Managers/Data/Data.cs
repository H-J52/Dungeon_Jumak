using System;
using System.Threading;
using UnityEngine.Rendering;

[Serializable]
public class Data
{
    //데이터 사용법
    //게임 진행에 있어 전반적으로 필요한 데이터는 Data.cs에 public접근 지정자로 변수로서 둘 것
    //ex) 레벨, 설정 값 등등
    //데이터에 있는 값을 다른 스크립트를 사용하기 위해서는 싱글톤으로서 사용하면 됨
    //ex) Data data = DataManager.Instance.data; => 이를 통해 Data.cs에 있는 변수값을 사용할 수 있음

    public bool isFirstStart = true;

    public string playerName = "";
    
    public float curXP = 0;
    public float maxXP = 5;

    public int curPlayerLV = 1;
    public int maxPlayerLV;

    //---설정 관련---//
    public bool isPlayBGM = true;
    public bool isSound = true;

    public float pitch = 0f;

    public bool isPause = false;

    //---CustomerSystem---//
    public int maxSeatSize = 12;
    public int customerHeadCount = 0;

    public bool[] isAllocated = new bool[12];
    public bool[] isCustomer = new bool[12];            //고객 테이블에 도착했는지 체크하기 위한 변수
    public bool[] onTables = new bool[12];              //테이블 위에 음식을 체크하기 위한 변수
    public bool[] isFinEat = new bool[12];              //다 먹었음을 알리는 변수
    public bool[] tableMiniGame = new bool[12];         //미니게임을 진행중인 테이블

    public string[] menuCategories = new string[12]; //각 자리에 있는 메뉴의 카테고리
    public int[] menuLV = new int[12];              //각 테이블에 있는 메뉴의 벨류
    public int[] ingredient = new int[5] {10, 0, 0, 0, 0};           //0: 돼지고기, 1: 부추, 2: 콩나물, 3: 오징어, 4: 소고기

    public int curCoin = 0;
    public int maxCoin = 999999;

    //---해금 관련---//
    public bool[] unlockMenuIndex = new bool[10];
    

    //---미니게임 관련---//
    public float fireSize = 100f;
    public bool successRiceJuiceMiniGame = false; //식혜 미니게임 성공 여부
    public bool isMiniGame;

    //--정산 관련--//
    public int gukbapCount;
    public int pajeonCount;
    public int riceJuiceCount;
    public int nowGukbapPrice;
    public int nowPajeonPrice;
    public int nowRiceJuicePrice;
    public int currentTotalPrice;
    public int yesterdayTotalPrice;

    //--상점 관련--//
    public int[] chairPrice = new int[3];

    public int[] tablePrice = new int[3];

    public int[] backgroundPrice = new int[3];

    //--가구 관련--//
    public int houseLV = 0;
    public int dansangLV = 0;
    public int tableLV = 0;

    //--시간 관련--//
    public string[] time = new string[2] {"오전", "오후"};
    public int timeNum = 0; // 0 or 1

    public int day = 1;
    public int maxDay = 20;

    public string[] season = new string[4] { "봄", "여름", "가을", "겨울" };
    public int seasonNum = 0;

    public int year = 0;

    //--도감 관련--//
    public int EncyclopediaIndex = 0;

}