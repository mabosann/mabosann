using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �v���C���[����̃R���g���[��
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>��</summary>
    private const int Empty = 0;

    /// <summary>�����x</summary>
    private float accelDecel = 1;

    /// <summary>�ړ�</summary>
    private float dash = Empty;

    /// <summary>�ړ��ł���X�s�[�h</summary>
    private const float DashLine = 10;

    /// <summary>�J�[�u�̑���</summary>
    private float cube = Empty;

    /// <summary>�u���[�L���Ă邩</summary>
    private bool onBrake = false;

    /// <summary>W�AS�L�[�����Ă邩</summary>
    private bool onDashBrake = false;

    /// <summary>A�AD�L�[�����Ă邩</summary>
    private bool onCubeBrake = false;

    /// <summary>�e�X�g�p�X�s�[�h</summary>
    [SerializeField] private float TestSpeed;

    /// <summary>�e�X�g�p�X�s�[�h����</summary>
    [SerializeField] private float TestSpeedLimit;

    /// <summary>�e�X�g�p�J�[�u</summary>
    [SerializeField] private float TestCube;

    /// <summary>�e�X�g�p�ړ�������</summary>
    [SerializeField] private float TestMoveAccelDecel;

    /// <summary>�v���C���[�̃��M�b�g�{�f�B</summary>
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

    /// <summary>����</summary>
    /// <param>�Ȃ�</param>
    /// <returns>�Ȃ�</returns>
    public void Acceleration()
    {
        //���x�����܂ŉ����x�{���Ԃő��x���オ��
        onBrake = false;
        if(TestSpeed <= TestSpeedLimit)
        {
            TestSpeed += accelDecel * Time.deltaTime;
        }
        
        Debug.Log("���x�F" + TestSpeed);
    }

    
    /// <summary>�O�Ɉړ�</summary>
    /// <param>�Ȃ�</param>
    /// <returns>�Ȃ�</returns>
    public void UpDash()
    {
        //���݂̑��x�܂ŉ����x�{���Ԃňړ��̗͂��オ��
        onDashBrake = false;
        if(dash >= -TestSpeed)
        {
            dash += -(TestMoveAccelDecel * Time.deltaTime);
        }
        
    }

    /// <summary>���Ɉړ�</summary>
    /// <param>�Ȃ�</param>
    /// <returns>�Ȃ�</returns>
    public void Back()
    {
        //���݂̑��x�܂ŉ����x�{���Ԃňړ��̗͂��オ��
        onDashBrake = false;
        if(dash <= TestSpeed)
        {
            dash += TestMoveAccelDecel * Time.deltaTime;
        }
    }

   

    /// <summary>�E�ɋȂ���</summary>
    /// <param>�Ȃ�</param>
    /// <returns>�Ȃ�</returns>
    public void LeftCube()
    {
        //playerTransform.Rotate(Empty, TestCube, Empty);
        //���݂̑��x�܂ŉ����x�{���Ԃňړ��̗͂��オ��
        onCubeBrake = false;
        if (cube >= -TestSpeed)
        {
            cube += -(TestMoveAccelDecel * Time.deltaTime);
        }

    }

    /// <summary>���ɋȂ���</summary>
    /// <param>�Ȃ�</param>
    /// <returns>�Ȃ�</returns>
    public void RightCube()
    {
        //playerTransform.Rotate(Empty, TestCube, Empty);
        //���݂̑��x�܂ŉ����x�{���Ԃňړ��̗͂��オ��
        onCubeBrake = false;
        if (cube <= TestSpeed)
        {
            cube += TestMoveAccelDecel * Time.deltaTime;
        }
    }

    //���L�̓���L�[�𗣂���true�ɂȂ�u���[�L��������

    /// <summary>�ړ��u���[�L</summary>
    /// <param>�Ȃ�</param>
    /// <returns>�Ȃ�</returns>
    public void PressTheBrake()
    {
        onDashBrake = true;
    }

    /// <summary>�����u���[�L</summary>
    /// <param>�Ȃ�</param>
    /// <returns>�Ȃ�</returns>
    public void AccelerationBrake()
    {
        onBrake = true;
    }

    /// <summary>�J�[�u�u���[�L</summary>
    /// <param>�Ȃ�</param>
    /// <returns>�Ȃ�</returns>
    public void CubeBrake()
    {
        onCubeBrake = true;
    }


    /// <summary>����</summary>
    /// <param>�Ȃ�</param>
    /// <returns>�Ȃ�</returns>
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
