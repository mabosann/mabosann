using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// プレイヤー操作のコントロール
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>空</summary>
    private const int Empty = 0;

    /// <summary>加減度</summary>
    private float accelDecel = 1;

    /// <summary>移動</summary>
    private float dash = Empty;

    /// <summary>移動できるスピード</summary>
    private const float DashLine = 10;

    /// <summary>カーブの速さ</summary>
    private float cube = Empty;

    /// <summary>ブレーキしてるか</summary>
    private bool onBrake = false;

    /// <summary>W、Sキー離してるか</summary>
    private bool onDashBrake = false;

    /// <summary>A、Dキー離してるか</summary>
    private bool onCubeBrake = false;

    /// <summary>テスト用スピード</summary>
    [SerializeField] private float TestSpeed;

    /// <summary>テスト用スピード制限</summary>
    [SerializeField] private float TestSpeedLimit;

    /// <summary>テスト用カーブ</summary>
    [SerializeField] private float TestCube;

    /// <summary>テスト用移動加減速</summary>
    [SerializeField] private float TestMoveAccelDecel;

    /// <summary>プレイヤーのリギットボディ</summary>
    private Rigidbody playerRigidBody;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    public void PlayerEngin()
    {
        //playerRigidBody.linearVelocity = new Vector3(cube, playerRigidBody.linearVelocity.y,  dash);
        //if (playerRigidBody.linearVelocity.magnitude <= 100)
        //{
        //    playerRigidBody.AddForce(new Vector3(TestCube, playerRigidBody.linearVelocity.y, TestSpeed), ForceMode.Force);
        //}
        if(TestSpeed >= DashLine)
        {
            playerRigidBody.linearVelocity = new Vector3(cube, playerRigidBody.linearVelocity.y, dash);
        }
    }

    /// <summary>加速</summary>
    /// <param>なし</param>
    /// <returns>なし</returns>
    public void Acceleration()
    {
        //速度制限まで加速度＋時間で速度が上がる
        onBrake = false;
        if(TestSpeed <= TestSpeedLimit)
        {
            TestSpeed += accelDecel * Time.deltaTime;
        }
        
        Debug.Log("速度：" + TestSpeed);
    }

    
    /// <summary>前に移動</summary>
    /// <param>なし</param>
    /// <returns>なし</returns>
    public void UpDash()
    {
        //現在の速度まで加速度＋時間で移動の力が上がる
        onDashBrake = false;
        if(dash >= -TestSpeed)
        {
            dash += -(TestMoveAccelDecel * Time.deltaTime);
        }
        
    }

    /// <summary>後ろに移動</summary>
    /// <param>なし</param>
    /// <returns>なし</returns>
    public void Back()
    {
        //現在の速度まで加速度＋時間で移動の力が上がる
        onDashBrake = false;
        if(dash <= TestSpeed)
        {
            dash += TestMoveAccelDecel * Time.deltaTime;
        }
    }

   

    /// <summary>右に曲がる</summary>
    /// <param>なし</param>
    /// <returns>なし</returns>
    public void LeftCube()
    {
        //playerTransform.Rotate(Empty, TestCube, Empty);
        //現在の速度まで加速度＋時間で移動の力が上がる
        onCubeBrake = false;
        if (cube >= -TestSpeed)
        {
            cube += -(TestMoveAccelDecel * Time.deltaTime);
        }

    }

    /// <summary>左に曲がる</summary>
    /// <param>なし</param>
    /// <returns>なし</returns>
    public void RightCube()
    {
        //playerTransform.Rotate(Empty, TestCube, Empty);
        //現在の速度まで加速度＋時間で移動の力が上がる
        onCubeBrake = false;
        if (cube <= TestSpeed)
        {
            cube += TestMoveAccelDecel * Time.deltaTime;
        }
    }

    //下記の特定キーを離すとtrueになりブレーキがかかる

    /// <summary>移動ブレーキ</summary>
    /// <param>なし</param>
    /// <returns>なし</returns>
    public void PressTheBrake()
    {
        onDashBrake = true;
    }

    /// <summary>加速ブレーキ</summary>
    /// <param>なし</param>
    /// <returns>なし</returns>
    public void AccelerationBrake()
    {
        onBrake = true;
    }

    /// <summary>カーブブレーキ</summary>
    /// <param>なし</param>
    /// <returns>なし</returns>
    public void CubeBrake()
    {
        onCubeBrake = true;
    }


    /// <summary>減速</summary>
    /// <param>なし</param>
    /// <returns>なし</returns>
    public void SlowDown()
    {
        if(TestSpeed >= Empty && onBrake)
        {
            TestSpeed -= accelDecel * Time.deltaTime;
        }

        if(dash >= Empty && onDashBrake)
        {
            dash -= TestMoveAccelDecel * Time.deltaTime;
        }
        else if(dash <= Empty && onDashBrake)
        {
            dash += TestMoveAccelDecel * Time.deltaTime;
        }

        if(cube >= Empty && onCubeBrake)
        {
            cube -= TestMoveAccelDecel * Time.deltaTime;
        }
        else if (cube <= Empty && onCubeBrake)
        {
            cube += TestMoveAccelDecel * Time.deltaTime;
        }

    }
}
