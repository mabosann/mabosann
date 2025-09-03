using UnityEngine;

/// <summary>
/// プレイヤー用マネージャー
/// </summary>
public class PlayerManager : MonoBehaviour
{
    /// <summary>
    /// インスタンス
    /// </summary>
    public static PlayerManager instance = null;

    /// <summary>
    /// プレイヤー
    /// </summary>
    [SerializeField] private PlayerBehaviour playerBehaviour;


    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        playerBehaviour.SlowDown();
        playerBehaviour.PlayerEngin();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            playerBehaviour.Acceleration();
        }

        if(Input.GetKey(KeyCode.W))
        {
            playerBehaviour.UpDash();
        }
        else if(Input.GetKey(KeyCode.S))
        {
            playerBehaviour.Back();
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerBehaviour.LeftCube();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerBehaviour.RightCube();
        }

        if(Input.GetKeyUp(KeyCode.Return))
        {
            playerBehaviour.AccelerationBrake();
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            playerBehaviour.PressTheBrake();
        }

        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            playerBehaviour.CubeBrake();
        }
    }
}
