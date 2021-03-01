using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockPickingScript : MonoBehaviour
{
    public GameObject Win_Panel;
    [SerializeField] Text SkillLevel;
    public float PlayerSkill = 1;
    
    [SerializeField] Transform LockPiece;
    [SerializeField] Transform LockPiece1;
    [SerializeField] Transform LockPiece2;
    [SerializeField] Transform LockPiece3;
    [SerializeField] Transform LockPiece4;
    [SerializeField] Transform pick;
    bool hit;
    bool hit1;
    bool hit2;
    bool hit3;
    bool hit4;
    bool unlock = false;
    bool unlock1 = false;
    bool unlock2 = false;
    bool unlock3 = false;
    bool unlock4 = false;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animator1;
    [SerializeField] private Animator animator2;
    [SerializeField] private Animator animator3;
    [SerializeField] private Animator animator4;

    float pickX;
    float LockPieceX;
    float LockPiece1X;
    float LockPiece2X;
    float LockPiece3X;
    float LockPiece4X;
    float LPY;
    float LPY1;
    float LPY2;
    float LPY3;
    float LPY4;

    public void ResetGame()
    {
        Win_Panel.SetActive(false);
        StopAllCoroutines();
        hit = false;
        hit1 = false; 
        hit2 = false;
        hit3 = false;
        hit4 = false;
        unlock = false;
        unlock1 = false;
        unlock2 = false;
        unlock3 = false;
        unlock4 = false;
        animator.SetBool("Open", true);
        animator1.SetBool("Open", true);
        animator2.SetBool("Open", true);
        animator3.SetBool("Open", true); 
        animator4.SetBool("Open", true);


    }

    void ResetAnim()
    {
        if (hit == true && LPY < 591)
        {
            animator.SetBool("Open", false);
            animator.SetBool("Open1", false);
            animator.SetBool("Open2", false);
            hit = false;
        }

        if (hit1 == true && LPY1 < 591)
        {
            animator1.SetBool("Open", false);
            animator1.SetBool("Open1", false);
            animator1.SetBool("Open2", false);
            hit1 = false;
        }

        if (hit2 == true && LPY2 < 591)
        {
            animator2.SetBool("Open", false);
            animator2.SetBool("Open1", false);
            animator2.SetBool("Open2", false);
            hit2 = false;
        }

        if (hit3 == true && LPY3 < 591)
        {
            animator3.SetBool("Open", false);
            animator3.SetBool("Open1", false);
            animator3.SetBool("Open2", false);
            hit3 = false;
        }

        if (hit4 == true && LPY4 < 591)
        {
            animator4.SetBool("Open", false);
            animator4.SetBool("Open1", false);
            animator4.SetBool("Open2", false);
            hit4 = false;
        }
    }

    void LateUpdate()
    {
        LPY = LockPiece.position.y;
        LPY1 = LockPiece1.position.y;
        LPY2 = LockPiece2.position.y;
        LPY3 = LockPiece3.position.y;
        LPY4 = LockPiece4.position.y;

        if (LPY > 600)
        {
            hit = true;
            StartCoroutine("MoveLP");
        }

        if (LPY1 > 600)
        {
            hit1 = true;
            StartCoroutine("MoveLP1");
        }

        if(LPY2 > 600)
        {
            hit2 = true;
            StartCoroutine("MoveLP2");
        }

        if(LPY3 > 600)
        {
            hit3 = true;
            StartCoroutine("MoveLP3");
        }

        if(LPY4 > 600)
        {
            StartCoroutine("MoveLP4");
            hit4 = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LPY = LockPiece.position.y;
            if (LPY > 660)
            {
                print("SUCCESS");
                animator.SetBool("Open", false);
                animator.SetBool("Open1", false);
                animator.SetBool("Open2", false);
                unlock = true;
                MoveLP();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LPY1 = LockPiece1.position.y;
            if (LPY1 > 660)
            {
                print("SUCCESS");
                animator1.SetBool("Open", false);
                animator1.SetBool("Open1", false);
                animator1.SetBool("Open2", false);
                unlock1 = true;
                MoveLP1();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LPY2 = LockPiece2.position.y;
            if (LPY2 > 660)
            {
                print("SUCCESS");
                animator2.SetBool("Open", false);
                animator2.SetBool("Open1", false);
                animator2.SetBool("Open2", false);
                unlock2 = true;
                MoveLP2();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LPY3 = LockPiece3.position.y;
            if (LPY3 > 660)
            {
                print("SUCCESS");
                animator3.SetBool("Open", false);
                animator3.SetBool("Open1", false);
                animator3.SetBool("Open2", false);
                unlock3 = true;
                MoveLP3();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LPY4 = LockPiece4.position.y;
            if (LPY4 > 660)
            {
                print("SUCCESS");
                animator4.SetBool("Open", false);
                animator4.SetBool("Open1", false);
                animator4.SetBool("Open2", false);
                unlock4 = true;
                MoveLP4();
            }
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pickX = pick.position.x + 313;
            LockPieceX = LockPiece.position.x;
            LockPiece1X = LockPiece1.position.x;
            LockPiece2X = LockPiece2.position.x;
            LockPiece3X = LockPiece3.position.x;
            LockPiece4X = LockPiece4.position.x;

            if (pickX == LockPieceX)
            {
                if(PlayerSkill == 1)
                {
                    EasySkill(1);
                }
                if (PlayerSkill == 2)
                {
                    MedSkill(1);
                }
                if (PlayerSkill == 3)
                {
                    HardSkill(1);
                }
                LateUpdate();
                
            }

            if (pickX == LockPiece1X)
            {
                if (PlayerSkill == 1)
                {
                    EasySkill(2);
                }
                if (PlayerSkill == 2)
                {
                    MedSkill(2);
                }
                if (PlayerSkill == 3)
                {
                    HardSkill(2);
                }
                LateUpdate();

            }

            if (pickX == LockPiece2X)
            {
                if (PlayerSkill == 1)
                {
                    EasySkill(3);
                }
                if (PlayerSkill == 2)
                {
                    MedSkill(3);
                }
                if (PlayerSkill == 3)
                {
                    HardSkill(3);
                }
                LateUpdate();

            }

            if (pickX == LockPiece3X)
            {
                if (PlayerSkill == 1)
                {
                    EasySkill(4);
                }
                if (PlayerSkill == 2)
                {
                    MedSkill(4);
                }
                if (PlayerSkill == 3)
                {
                    HardSkill(4);
                }
                LateUpdate();

            }

            if (pickX == LockPiece4X)
            {
                if (PlayerSkill == 1)
                {
                    EasySkill(5);
                }
                if (PlayerSkill == 2)
                {
                    MedSkill(5);
                }
                if (PlayerSkill == 3)
                {
                    HardSkill(5);
                }
                LateUpdate();

            }
        }

        if(unlock == true && unlock1 == true && unlock2 == true && unlock3 == true && unlock4 == true)
        {
            Unlocked();
        }

        SkillLevel.text = PlayerSkill.ToString();

    }

    IEnumerator MoveLP()
    {
        while (hit == true)
        {
            ResetAnim();
            yield return null;
        }
    }

    IEnumerator MoveLP1()
    {
        while (hit1 == true)
        {
            ResetAnim();
            yield return null;
        }
    }

    IEnumerator MoveLP2()
    {
        while (hit2 == true)
        {
            ResetAnim();
            yield return null;
        }
    }

    IEnumerator MoveLP3()
    {
        while (hit3 == true)
        {
            ResetAnim();
            yield return null;
        }
    }

    IEnumerator MoveLP4()
    {
        while (hit4 == true)
        {
            ResetAnim();
            yield return null;
        }
    }

    void Unlocked()
    {
        print("YOU WIN!!");
        Win_Panel.SetActive(true);
        StopAllCoroutines();
        CountDownScript.currTime = 1;
    }

    void EasySkill(int a)
    {
        int n = a;
        int rng = Random.Range(0, 10);
        if(rng <= 5)
        {
            if(n == 1)
                animator.SetBool("Open1", true);
            if(n == 2)
                animator1.SetBool("Open1", true);
            if (n == 3)
                animator2.SetBool("Open1", true);
            if (n == 4)
                animator3.SetBool("Open1", true);
            if (n == 5)
                animator4.SetBool("Open1", true);
        }
        else if(rng == 6)
        {
            if (n == 1)
                animator.SetBool("Open", true);
            if (n == 2)
                animator1.SetBool("Open", true);
            if (n == 3)
                animator2.SetBool("Open", true);
            if (n == 4)
                animator3.SetBool("Open", true);
            if (n == 5)
                animator4.SetBool("Open", true);
        }
        else if (rng == 7)
        {
            if (n == 1)
                animator.SetBool("Open", true);
            if (n == 2)
                animator1.SetBool("Open", true);
            if (n == 3)
                animator2.SetBool("Open", true);
            if (n == 4)
                animator3.SetBool("Open", true);
            if (n == 5)
                animator4.SetBool("Open", true);
        }
        else if (rng == 8)
        {
            if (n == 1)
                animator.SetBool("Open", true);
            if (n == 2)
                animator1.SetBool("Open", true);
            if (n == 3)
                animator2.SetBool("Open", true);
            if (n == 4)
                animator3.SetBool("Open", true);
            if (n == 5)
                animator4.SetBool("Open", true);
        }
        else if(rng >= 9)
        {
            if (n == 1)
                animator.SetBool("Open2", true);
            if (n == 2)
                animator1.SetBool("Open2", true);
            if (n == 3)
                animator2.SetBool("Open2", true);
            if (n == 4)
                animator3.SetBool("Open2", true);
            if (n == 5)
                animator4.SetBool("Open2", true);
        }
    }

    void MedSkill(int a)
    {
        int n = a;
        int rng = Random.Range(0, 10);
        if (rng <= 3)
        {
            if (n == 1)
                animator.SetBool("Open1", true);
            if (n == 2)
                animator1.SetBool("Open1", true);
            if (n == 3)
                animator2.SetBool("Open1", true);
            if (n == 4)
                animator3.SetBool("Open1", true);
            if (n == 5)
                animator4.SetBool("Open1", true);
        }
        else if(rng == 4)
        {
            if (n == 1)
                animator.SetBool("Open", true);
            if (n == 2)
                animator1.SetBool("Open", true);
            if (n == 3)
                animator2.SetBool("Open", true);
            if (n == 4)
                animator3.SetBool("Open", true);
            if (n == 5)
                animator4.SetBool("Open", true);
        }
        else if (rng == 5)
        {
            if (n == 1)
                animator.SetBool("Open", true);
            if (n == 2)
                animator1.SetBool("Open", true);
            if (n == 3)
                animator2.SetBool("Open", true);
            if (n == 4)
                animator3.SetBool("Open", true);
            if (n == 5)
                animator4.SetBool("Open", true);
        }
        else if (rng == 6)
        {
            if (n == 1)
                animator.SetBool("Open", true);
            if (n == 2)
                animator1.SetBool("Open", true);
            if (n == 3)
                animator2.SetBool("Open", true);
            if (n == 4)
                animator3.SetBool("Open", true);
            if (n == 5)
                animator4.SetBool("Open", true);
        }
        else if (rng == 7)
        {
            if (n == 1)
                animator.SetBool("Open", true);
            if (n == 2)
                animator1.SetBool("Open", true);
            if (n == 3)
                animator2.SetBool("Open", true);
            if (n == 4)
                animator3.SetBool("Open", true);
            if (n == 5)
                animator4.SetBool("Open", true);
        }
        else if(rng >= 8)
        {
            if (n == 1)
                animator.SetBool("Open2", true);
            if (n == 2)
                animator1.SetBool("Open2", true);
            if (n == 3)
                animator2.SetBool("Open2", true);
            if (n == 4)
                animator3.SetBool("Open2", true);
            if (n == 5)
                animator4.SetBool("Open2", true);
        }

    }
    
    void HardSkill(int a)
    {
        int n = a;
        int rng = Random.Range(0, 10);
        if (rng <= 2)
        {
            if (n == 1)
                animator.SetBool("Open1", true);
            if (n == 2)
                animator1.SetBool("Open1", true);
            if (n == 3)
                animator2.SetBool("Open1", true);
            if (n == 4)
                animator3.SetBool("Open1", true);
            if (n == 5)
                animator4.SetBool("Open1", true);
        }
        else if(rng == 3)
        {
            if (n == 1)
                animator.SetBool("Open", true);
            if (n == 2)
                animator1.SetBool("Open", true);
            if (n == 3)
                animator2.SetBool("Open", true);
            if (n == 4)
                animator3.SetBool("Open", true);
            if (n == 5)
                animator4.SetBool("Open", true);
        }
        else if (rng == 4)
        {
            if (n == 1)
                animator.SetBool("Open", true);
            if (n == 2)
                animator1.SetBool("Open", true);
            if (n == 3)
                animator2.SetBool("Open", true);
            if (n == 4)
                animator3.SetBool("Open", true);
            if (n == 5)
                animator4.SetBool("Open", true);
        }
        else if (rng == 5)
        {
            if (n == 1)
                animator.SetBool("Open", true);
            if (n == 2)
                animator1.SetBool("Open", true);
            if (n == 3)
                animator2.SetBool("Open", true);
            if (n == 4)
                animator3.SetBool("Open", true);
            if (n == 5)
                animator4.SetBool("Open", true);
        }
        else if(rng >= 6)
        {
            if (n == 1)
                animator.SetBool("Open2", true);
            if (n == 2)
                animator1.SetBool("Open2", true);
            if (n == 3)
                animator2.SetBool("Open2", true);
            if (n == 4)
                animator3.SetBool("Open2", true);
            if (n == 5)
                animator4.SetBool("Open2", true);
        }
    }

    public void SkillUp()
    {
        if (PlayerSkill < 3)
        {
            PlayerSkill = PlayerSkill + 1;
            SkillLevel.text = PlayerSkill.ToString();
            print(PlayerSkill);
        }
    }

    public void SkillDown()
    {
        if (PlayerSkill > 1)
        {
            PlayerSkill = PlayerSkill - 1;
            SkillLevel.text = PlayerSkill.ToString();
            print(PlayerSkill);
        }
    }
}
