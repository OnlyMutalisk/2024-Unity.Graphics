using System.Collections;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private float speed = GameManager.speed_char;
    private float jumpPower = GameManager.jumpPower_char;
    private float sensitivity = GameManager.sensitive;
    private float duration = GameManager.zoomDuration;
    private float moveFB, moveLR;
    private float rotX, rotY;
    private bool isJump = false;
    private bool isTop = false;
    private float gravity = 9.8f;
    private bool isCorOn = false;

    public CharacterController character;
    public Rigidbody rigid;
    public GameObject cam;
    public GameObject gun;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        CameraRotation(cam, rotX, rotY);

        moveFB = Input.GetAxis("Horizontal") * speed;
        moveLR = Input.GetAxis("Vertical") * speed;

        Vector3 movement;

        if (Input.GetKeyDown(KeyCode.Space) == true && isJump == false && isTop == false) { isJump = true; }

        if (isJump == true)
        {
            movement = new Vector3(moveFB, jumpPower, moveLR);
            movement = transform.rotation * movement;
            jumpPower -= 10f * Time.deltaTime;
            gravity = 0;

            // jumpPower 가 0 이 되는 시점이 점프의 정점 입니다.
            if (jumpPower <= 0)
            {
                jumpPower = GameManager.jumpPower_char;
                isJump = false;
                isTop = true;
            }
        }
        else
        {
            movement = new Vector3(moveFB, -gravity, moveLR);
            movement = transform.rotation * movement;

            // 점프의 정점에서, 중력을 조금씩 늘리며 내려옵니다.
            if (gravity < 9.8f) { gravity += 9.8f * Time.deltaTime; }
            else { isTop = false; }
        }

        character.Move(movement * Time.deltaTime);
    }

    /// <summary>
    /// <br>카메라가 캐릭터를 따라 회전합니다.</br>
    /// </summary>
    private void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        if (isCorOn == false) { transform.Rotate(0, rotX * Time.deltaTime, 0); } // 캐릭터 좌우 회전, 항상 On-line

        Vector3 camPos = new Vector3();
        Vector3 camAngle = new Vector3();
        IEnumerator cor;

        // 우클릭 시작 시
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            camPos = new Vector3(0, 2.4f, 0.4f);
            camAngle = new Vector3(20, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);

            cor = CorMoveCam(camPos, camAngle, true);
            StopCoroutine(cor);
            StartCoroutine(cor);
        }
        // 우클릭 중
        if (Input.GetKey(KeyCode.Mouse1) && isCorOn == false)
        {
            gun.transform.Rotate(-rotY * Time.deltaTime, 0, 0); // 총 상하 회전
            cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0); // 카메라 상하 회전
        }
        // 우클릭 종료 시
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            camPos = new Vector3(0, 8, -3.5f);
            camAngle = new Vector3(60, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);

            cor = CorMoveCam(camPos, camAngle, false);
            StopCoroutine(cor);
            StartCoroutine(cor);
        }
    }

    /// <summary>
    /// 카메라의 부드러운 줌 인 / 줌 아웃을 지원합니다.
    /// </summary>
    private IEnumerator CorMoveCam(Vector3 camPos, Vector3 camAngle, bool isStart)
    {
        isCorOn = true;

        Vector3 initialPosition = cam.transform.localPosition;
        Vector3 initialEulerAngles = cam.transform.eulerAngles;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            cam.transform.localPosition = Vector3.Lerp(initialPosition, camPos, elapsedTime / duration);
            cam.transform.eulerAngles = Vector3.Lerp(initialEulerAngles, camAngle, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cam.transform.localPosition = camPos;

        if (isStart == true) { cam.transform.localRotation = Quaternion.Euler(new Vector3(20, 0, 0)); }
        if (isStart == false) { cam.transform.localRotation = Quaternion.Euler(new Vector3(60, 0, 0)); }
        gun.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        isCorOn = false;
    }
}
