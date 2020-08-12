using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    //タイトル画面を参照する変数：titleScreen
    public GameObject titleScreen;

    //ワールドツアーモードの画面を参照する変数：worldTourScreen
    public GameObject worldTourScreen;

    //身体探しモードの画面を参照する変数：questionModeScreen
    public GameObject questionModeScreen;

    //推測画面を参照する変数：guessScreen
    public GameObject guessScreen;


    //砂漠シナリオを表示する画像を参照する変数：desertImage
    public GameObject desertImage;

    //南極シナリオを表示する画像を参照する変数：arcticImage
    public GameObject arcticImage;

    //熱帯雨林シナリオを表示する画像を参照する変数：rainforestImage
    public GameObject rainforestImage;

    //砂漠シナリオを表示する画像を参照する変数：desertImage2
    public GameObject desertImage2;

    //南極シナリオを表示する画像を参照する変数：arcticImage
    public GameObject arcticImage2;

    //熱帯雨林シナリオを表示する画像を参照する変数：rainforestImage
    public GameObject rainforestImage2;


    //タイトル画面か否か参照する変数：isTitle
    public bool isTitle;

    //ワールドツアー画面か否か参照する変数：isWorldTour
    public bool isWorldTour;

    //身体探しモード画面か否かを参照する変数：isQuestion
    public bool isQuestion;

    //推測画面か否かを参照する変数：isGuess
    public bool isGuess;


    //ワープ中の画像を参照する変数：warpingImage
    public GameObject warpingImage;

    //タイトル画面へ戻るボタンを参照する変数：returnTitleButton
    public GameObject returnTitleButton;

    //熱帯雨林シナリオ用ボタンその１
    public GameObject rainforestButton;

    //熱帯雨林シナリオ用ボタンその２
    public GameObject rainforestButton2;

    //背景画像を参照する変数：backGroundImage
    public GameObject backGroundImage;

    //ルーレットを参照する変数：roulette
    public GameObject roulette;

    //ルーレットの回転速度
    private float rouletteSpeed;

    //ファイナルアンサーの画像を参照する変数：finalAnswearImage
    public GameObject finalAnswearImage;

    private string ansScene;

    public GameObject expText;

    public static bool displayAns;


    //最初に呼び出される関数
    void Start()
    {
        //タイトル画面を表示
        isTitle = true;
        isWorldTour = false;
        isQuestion = false;
        isGuess = false;

        //タイトル画面へ戻るボタンを非アクティブ化
        returnTitleButton.gameObject.SetActive(false);

        //熱帯雨林シナリオ用ボタンの初期化
        rainforestButton.gameObject.SetActive(true);
        rainforestButton2.gameObject.SetActive(false);

        //ルーレットの回転速度を初期化
        rouletteSpeed = 0;

        displayAns = false;
    }


    //フレームごとに呼び出される関数
    void Update()
    {
        //タイトル画面
        if (isTitle)
        {
            //タイトル画面をアクティブ化
            titleScreen.gameObject.SetActive(true);

            //ワールドツアーモード画面を非アクティブ化
            worldTourScreen.gameObject.SetActive(false);

            //身体探しモード画面を非アクティブ化
            questionModeScreen.gameObject.SetActive(false);

            //推測モード画面を非アクティブ化
            guessScreen.gameObject.SetActive(false);

            //背景をアクティブ化
            backGroundImage.gameObject.SetActive(true);
        }

        //ワールドツアーモード
        else if(isWorldTour)
        {
            //タイトル画面を非アクティブ化
            titleScreen.gameObject.SetActive(false);

            //ワールドツアーモード画面をアクティブ化
            worldTourScreen.gameObject.SetActive(true);

            //身体探しモード画面を非アクティブ化
            questionModeScreen.gameObject.SetActive(false);

            //推測モード画面を非アクティブ化
            guessScreen.gameObject.SetActive(false);

            //背景をアクティブ化
            backGroundImage.gameObject.SetActive(true);
        }

        //身体探しモード
        else if (isQuestion)
        {
            //タイトル画面を非アクティブ化
            titleScreen.gameObject.SetActive(false);

            //ワールドツアーモード画面を非アクティブ化
            worldTourScreen.gameObject.SetActive(false);

            //身体探しモード画面をアクティブ化
            questionModeScreen.gameObject.SetActive(true);

            //推測モード画面を非アクティブ化
            guessScreen.gameObject.SetActive(false);

            //背景をアクティブ化
            backGroundImage.gameObject.SetActive(true);

            //回転
            roulette.gameObject.transform.Rotate(0, 0, rouletteSpeed);
            rouletteSpeed *= 0.97f;
        }

        //推測モード
        else if (isGuess)
        {
            //タイトル画面を非アクティブ化
            titleScreen.gameObject.SetActive(false);

            //ワールドツアーモード画面を非アクティブ化
            worldTourScreen.gameObject.SetActive(false);

            //身体探しモード画面を非アクティブ化
            questionModeScreen.gameObject.SetActive(false);

            //推測モード画面をアクティブ化
            guessScreen.gameObject.SetActive(true);

            //背景をアクティブ化
            backGroundImage.gameObject.SetActive(true);
        }
    }


    //ワールドツアーモードへ遷移する関数
    public void WorldTourStart()
    {
        //画面設定
        isTitle = false;
        isWorldTour = true;

        //タイトル画面へ戻るボタンをアクティブ化
        returnTitleButton.gameObject.SetActive(true);
    }


    //シナリオ選択における画像のアクティブ化を司る関数
    public void ActiveImage(GameObject activeImage, bool flag)
    {
        //砂漠の画像を非アクティブ化
        desertImage.gameObject.SetActive(false);

        //南極の画像を非アクティブ化
        arcticImage.gameObject.SetActive(false);

        //熱帯雨林の画像を非アクティブ化
        rainforestImage.gameObject.SetActive(false);

        //引数の画像のみアクティブ化
        //フラグが立っていないときはすべてを非アクティブ化
        if(flag) activeImage.gameObject.SetActive(true);

        //熱帯雨林シナリオ用ボタンの初期化
        rainforestButton.gameObject.SetActive(true);
        rainforestButton2.gameObject.SetActive(false);
    }


    public void ActiveImage2(GameObject activeImage, bool flag)
    {
        //砂漠の画像を非アクティブ化
        desertImage2.gameObject.SetActive(false);

        //南極の画像を非アクティブ化
        arcticImage2.gameObject.SetActive(false);

        //熱帯雨林の画像を非アクティブ化
        rainforestImage2.gameObject.SetActive(false);

        //引数の画像のみアクティブ化
        //フラグが立っていないときはすべてを非アクティブ化
        if (flag) activeImage.gameObject.SetActive(true);
    }


    //ワープを実行する関数
    public void Warping(string sceneName)
    {
        //ワープ中の画像を表示
        warpingImage.gameObject.SetActive(true);

        //コルーチン開始
        StartCoroutine(TimeCoroutine(sceneName, 5.0f));
    }


    //時間停止のコルーチン
    private IEnumerator TimeCoroutine(string sceneName, float waitTime)
    {
        //5秒間待機
        yield return new WaitForSeconds(waitTime);

        //ワープ中の画像を非表示に
        warpingImage.gameObject.SetActive(false);

        //引数で指定したシナリオへ遷移
        SceneManager.LoadScene(sceneName);
    }


    //砂漠シナリオを選択する関数
    public void SelectDesertScenario()
    {
        if (!desertImage.activeSelf)
        {
            // 砂漠シナリオの画像をアクティブ化
            ActiveImage(desertImage, true);
        }
        else
        {
            // 砂漠シナリオの画像を非アクティブ化
            ActiveImage(desertImage, false);

            //ワープを実行
            Warping("DesertScene");
        }
    }


    //南極シナリオを選択する関数
    public void SelectArcticScenario()
    {
        if (!arcticImage.activeSelf)
        {
            //南極シナリオの画像をアクティブ化
            ActiveImage(arcticImage, true);
        }
        else
        {
            //南極の画像を非アクティブ化
            arcticImage.gameObject.SetActive(false);

            //ワープを実行
            Warping("ArcticScene");
        }
    }


    //熱帯雨林シナリオを選択する関数
    public void SelectRainforestScenario()
    {
        // 熱帯雨林シナリオの画像をアクティブ化
        ActiveImage(rainforestImage, true);

        //ボタンの切り替え
        rainforestButton.gameObject.SetActive(false);
        rainforestButton2.gameObject.SetActive(true);
    }


    public void RainforestFunc()
    {
        // 熱帯雨林シナリオの画像を非アクティブ化
        ActiveImage(rainforestImage, false);

        //熱帯雨林シナリオ用ボタンの初期化
        rainforestButton.gameObject.SetActive(true);
        rainforestButton2.gameObject.SetActive(false);

        //ワープを実行
        Warping("RainforestScene");
    }


    //タイトル画面へ選択する関数
    public void TitleStart()
    {
        //すべてのシナリオ画像を非アクティブ化
        ActiveImage(desertImage, false);

        //タイトル画面を表示
        isTitle = true;
        isWorldTour = false;
        isQuestion = false;
        isGuess = false;

        //タイトル画面へ戻るボタンを非アクティブ化
        returnTitleButton.gameObject.SetActive(false);
    }


    //身体探しモードへ遷移する関数
    public void QuestionModeStart()
    {
        //タイトル画面へ戻るボタンをアクティブ化
        returnTitleButton.gameObject.SetActive(true);

        //画面設定
        isTitle = false;
        isQuestion = true;

        float rn = UnityEngine.Random.value;

        //ルーレットスタート
        rouletteSpeed = -1000000 * rn;

        Debug.Log(rn);

        if (rn < 0.33) ansScene = "DesertScene";
        else if (rn < 0.66) ansScene = "ArcticScene";
        else ansScene = "RainforestScene";

        StartCoroutine("TimeCoroutine2");
    }

    //時間停止のコルーチンその２
    private IEnumerator TimeCoroutine2()
    {
        //3秒間待機
        yield return new WaitForSeconds(3.0f);

        isQuestion = false;
        isGuess = true;
    }

    public void AnsDesert()
    {
        // 砂漠シナリオの画像をアクティブ化
        ActiveImage2(desertImage2, true);

        finalAnswearImage.gameObject.SetActive(true);
    }

    public void AnsArctic()
    {
        //南極シナリオの画像をアクティブ化
        ActiveImage2(arcticImage2, true);

        finalAnswearImage.gameObject.SetActive(true);
    }

    public void AnsRainforest()
    {
        // 熱帯雨林シナリオの画像をアクティブ化
        ActiveImage2(rainforestImage2, true);

        finalAnswearImage.gameObject.SetActive(true);
    }

    public void ToAnsScene()
    {
        StartCoroutine("TimeCoroutine3");
    }

    //時間停止のコルーチンその3
    private IEnumerator TimeCoroutine3()
    {
        ActiveImage2(desertImage, false);

        finalAnswearImage.gameObject.SetActive(false);

        expText.gameObject.SetActive(true);

        //3秒間待機
        yield return new WaitForSeconds(3.0f);

        expText.gameObject.SetActive(false);

        displayAns = true;

        //引数で指定したシナリオへ遷移
        SceneManager.LoadScene(ansScene);
    }

    public static bool getDisplayAns()
    {
        return displayAns;
    }
}

