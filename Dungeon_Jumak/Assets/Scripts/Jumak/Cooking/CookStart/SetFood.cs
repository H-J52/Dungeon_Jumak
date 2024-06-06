//System
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

//Unity
using UnityEngine;
using UnityEngine.UI;

//������ ������ Confirmâ�� �̹����� �����ֱ� ���� ��ũ��Ʈ
[DisallowMultipleComponent]
public class SetFood : MonoBehaviour
{
    //Is free or is not free
    [Header("�⺻ ���� ����")]
    public bool freeFood;

    //SetMenu of Gukbabs
    [Header("�� ���� ��ư �迭")]
    [SerializeField] private SetMenu[] gukbabs;

    //SetMenu of Pajeons
    [Header("�� ���� ��ư �迭")]
    [SerializeField] private SetMenu[] pajeons;

    //SetMenu of RiceJuice
    [Header("�� ���� ��ư �迭")]
    [SerializeField] private SetMenu[] riceJuices;

    //Prefabs
    [Header("���� ������ �迭")]
    [SerializeField] private GameObject[] gukbabPrefabs;

    [Header("���� ������ �迭")]
    [SerializeField] private GameObject[] pajeonsPrefabs;

    [Header("���� ������ �迭")]
    [SerializeField] private GameObject[] riceJuicePrefabs;

    //Confirm Popup
    [Header("Ȯ�� �˾� ���� ������Ʈ")]
    [SerializeField] private GameObject confirmPopup;

    //Confirm Popup Food Image
    [Header("Ȯ�� �˾� ���� �̹���")]
    [SerializeField] private Image foodImage;

    [Header("�丮�� ������ ������ ǥ���� �ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI countTMP;

    //Confirm Popup Max Cook Count
    [Header("�ִ� �丮 ���� ����")]
    [SerializeField] private int maxCookCount;

    //Want Cooking Food Count
    [Header("���ϴ� ���� �丮 ����")]
    [SerializeField] private int wantCookingFood;

    //Gukbab Generator
    [Header("������ �����ϴ� Gukbab Generator ��ũ��Ʈ")]
    [SerializeField] private GukbabGenerator gukbabGenerator;

    //Confrim Images in Confirm Frame
    [Header("Ȯ�� ������ ���� �̹��� �迭")]
    [SerializeField] private Image[] confirmImagesInFrame;

    //On Objects to start game
    [Header("���� ���۽� ������ ������Ʈ �迭")]
    [SerializeField] private GameObject[] onObjectsWhenStart;

    //Off Objects to start game
    [Header("���� ���۽� ������ ������Ʈ �迭")]
    [SerializeField] private GameObject[] offObjectsWhenStart;

    //Count of currnet confirmed food
    private int confirmCount;

    //Confirm Popup
    [Header("Ȯ�� �˾� ������Ʈ")]
    [SerializeField] private GameObject confirmPopUp;

    [Header("�ָ� ��")]
    [SerializeField] private JumakScene jumakScene;

    //Init Data
    private int[] initIngredient;

    //Select Food to reference category
    private SelectCategory selectCategory;

    //Choosed Food Index
    private int foodIndex;

    //Data
    private Data data;

    private void Start()
    {
        //Get Component and Init
        selectCategory = GetComponent<SelectCategory>();

        data = DataManager.Instance.data;

        //Save Init Ingredient
        initIngredient = new int[5];

        for (int i = 0; i < initIngredient.Length; i++)
        {
            initIngredient[i] = data.ingredient[i];
        }
    }

    private void Update()
    {
        //Check JumakStart
        CheckJumakStart();

        //On Confirm Popup
        CheckOnConfrimPopUp();
    }

    //Check Start
    public void CheckJumakStart()
    {
        //if all food is confirmed
        if (confirmCount >= 3)
        {
            //initialize confirm count
            confirmCount = 0;

            //on objects 
            for (int i = 0; i < onObjectsWhenStart.Length; i++)
            {
                onObjectsWhenStart[i].SetActive(true);
            }

            //off objects
            for (int j = 0; j < offObjectsWhenStart.Length; j++)
            {
                offObjectsWhenStart[j].SetActive(false);
            }
        }

        jumakScene.JumakStart();
    }

    //Method to Check and Active Confirm Popup
    public void CheckOnConfrimPopUp()
    {
        //Change Text
        if (freeFood) countTMP.text = "����";
        else countTMP.text = wantCookingFood.ToString();

        //Check Category
        switch (selectCategory.category)
        {
            //Gukbab
            case "Gukbab":
                for (int i = 0; i < gukbabs.Length; i++)
                {
                    if (gukbabs[i].onClick)
                    {
                        //Avoid duplication
                        gukbabs[i].OffClick();

                        //Confrim Popup Active
                        confirmPopup.SetActive(true);

                        //Change Confirm Popup's food Image
                        foodImage.sprite = gukbabs[i].foodImage.sprite;

                        //Assign max cook count
                        maxCookCount = gukbabs[i].maxCookCount;

                        //If is free is not free
                        freeFood = gukbabs[i].freeMenu;

                        //Change Index
                        foodIndex = i;
                    }
                }
                break;

            //Pajeon
            case "Pajeon":
                for (int i = 0; i < pajeons.Length; i++)
                {
                    if (pajeons[i].onClick)
                    {
                        //Avoid duplication
                        pajeons[i].OffClick();

                        //Confrim Popup Active
                        confirmPopup.SetActive(true);

                        //Change Confirm Popup's food Image
                        foodImage.sprite = pajeons[i].foodImage.sprite;

                        //Assign max cook count
                        maxCookCount = pajeons[i].maxCookCount;

                        //If is free is not free
                        freeFood = pajeons[i].freeMenu;

                        //Change Index
                        foodIndex = i;
                    }
                }
                break;

            //RiceJuice
            case "RiceJuice":
                for (int i = 0; i < riceJuices.Length; i++)
                {
                    if (riceJuices[i].onClick)
                    {
                        //Avoid duplication
                        riceJuices[i].OffClick();

                        //Confrim Popup Active
                        confirmPopup.SetActive(true);

                        //Change Confirm Popup's food Image
                        foodImage.sprite = riceJuices[i].foodImage.sprite;

                        //Assign max cook count
                        maxCookCount = riceJuices[i].maxCookCount;

                        //If is free is not free
                        freeFood = riceJuices[i].freeMenu;

                        //Change Index
                        foodIndex = i;
                    }
                }
                break;

            default:
                break;
        }
    }
    
    //Increase Food Count
    public void IncreaseCount()
    {
        //if not freeFood
        if(!freeFood)
        {
            //increase want cooking food count
            wantCookingFood++;

            //modular arithmetic -> if count greater than max count, count is zero 
            wantCookingFood %= maxCookCount + 1;
        }
    }

    //Decrease Food Count
    public void DecreaseCount()
    {
        //if not freeFood
        if (!freeFood)
        {
            //decrease want cooking food count
            wantCookingFood--;

            //modular arithmetic -> if count greater than max count, count is zero 
            wantCookingFood %= maxCookCount + 1;
        }
    }

    //Confirm Food and Subtract Ingredients count
    public void ConfirmCookingFood()
    {
        //Switch Category
        switch (selectCategory.category)
        {
            case "Gukbab":
                if (!freeFood)
                {
                    //Subtract Ingredient
                    SubIngredient();

                    //Update new Gukbab Count
                    gukbabGenerator.wantGukbabCount = wantCookingFood;

                    //Change Gukbab Prefab
                    gukbabGenerator.gukbabPrefab = gukbabPrefabs[foodIndex];
                }

                //Button Blocking
                ButtonBlocker();

                //Update Confirm Image in Frame
                confirmImagesInFrame[0].sprite = gukbabs[foodIndex].foodImage.sprite;

                //Increase Confirm Count
                confirmCount++;
                break;

            case "Pajeon":
                if (!freeFood)
                {
                    //Subtract Ingredient
                    SubIngredient();
                }

                //Button Blocking
                ButtonBlocker();

                //Update Confirm Image in Frame
                confirmImagesInFrame[1].sprite = pajeons[foodIndex].foodImage.sprite;

                //Increase Confirm Count
                confirmCount++;
                break;

            case "RiceJuice":
                if (!freeFood)
                {
                    //Subtract Ingredient
                    SubIngredient();
                }

                //Button Blocking
                ButtonBlocker();

                //Update Confirm Image in Frame
                confirmImagesInFrame[2].sprite = riceJuices[foodIndex].foodImage.sprite;

                //Increase Confirm Count
                confirmCount++;
                break;
        }

        CloseConfirmPopUp();
    }

    //Close Confirm Popup
    public void CloseConfirmPopUp()
    {
        confirmPopUp.SetActive(false);
    }

    //Canel Jumak
    public void CancelJumak()
    {
        //Undo ingredients
        for (int i = 0; i < initIngredient.Length; i++)
        {
            data.ingredient[i] = initIngredient[i];
        }

        //Back Waiting Scene
        GameManager.Scene.LoadScene(Define.Scene.WaitingScene);
    }

    //Method for Subtract Ingredient
    public void SubIngredient()
    {
        //Switch Category
        switch (selectCategory.category)
        {
            //Subtract ingredient
            case "Gukbab":
                for (int i = 0; i < data.ingredient.Length; i++)
                {
                    if (gukbabs[foodIndex].needIngredients[i] <= data.ingredient[i])
                        data.ingredient[i] -= gukbabs[foodIndex].needIngredients[i] * wantCookingFood;
                }
                break;

            case "Pajeon":
                for (int i = 0; i < data.ingredient.Length; i++)
                {
                    if (pajeons[foodIndex].needIngredients[i] <= data.ingredient[i])
                        data.ingredient[i] -= pajeons[foodIndex].needIngredients[i] * wantCookingFood;
                }
                break;

            case "RiceJuice":
                for (int i = 0; i < data.ingredient.Length; i++)
                {
                    if (riceJuices[foodIndex].needIngredients[i] <= data.ingredient[i])
                        data.ingredient[i] -= riceJuices[foodIndex].needIngredients[i] * wantCookingFood;
                }
                break;
        }

    }

    //When confirm food, blocking buttons
    public void ButtonBlocker()
    {
        //Check Category
        switch (selectCategory.category)
        {
            //noninteractable
            case "Gukbab":
                for (int j = 0; j < gukbabs.Length; j++)
                {
                    gukbabs[j].gameObject.GetComponent<Button>().interactable = false;
                }
                break;

            case "Pajeon":
                for (int j = 0; j < pajeons.Length; j++)
                {
                    pajeons[j].gameObject.GetComponent<Button>().interactable = false;
                }
                break;

            case "RiceJuice":
                for (int j = 0; j < riceJuices.Length; j++)
                {
                    riceJuices[j].gameObject.GetComponent<Button>().interactable = false;
                }
                break;
        }
    }
}