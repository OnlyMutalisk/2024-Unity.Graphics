using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Mob : MonoBehaviour
{
    public Animator anim;
    private NavMeshAgent nav;
    private bool isCorOn = false;
    protected virtual float attackDistance { get; set; }
    protected virtual float speed { get; set; }
    protected virtual float HP { get; set; }
    protected virtual float damage { get; set; }
    protected virtual int score { get; set; }
    private AudioSource attackedSound;
    private AudioSource hitSound;
    private bool isAlive = true;

    private void Awake()
    {
        attackedSound = GetComponents<AudioSource>()[0];
        hitSound = GetComponents<AudioSource>()[1];
        hitSound.clip = Resources.Load<AudioClip>("Sounds/Hit");
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = attackDistance;
        nav.speed = speed;
    }


    private void Update()
    {
        if (isAlive)
            nav.SetDestination(CharAnimation.trans.position);
        StartCoroutine(CorMobAction());
    }

    /// <summary>
    /// <br>몬스터의 행동을 결정합니다.</br>
    /// <br>동기화가 적용되었습니다.</br>
    /// </summary>
    private IEnumerator CorMobAction()
    {
        if (isCorOn == false)
        {
            isCorOn = true;
            nav.enabled = true;
            anim.SetBool("isNoPath", false);

            // 몬스터 사망 (Death)
            if (HP <= 0)
            {
                isAlive = false;
                anim.SetBool("isDeath", true);
                nav.enabled = false;
                Spawner.population_current--;
                UI.score += score;
                yield return new WaitForSeconds(GetAnimationClipLength("Death") + 1);
                Destroy(gameObject);
            }

            // 몬스터 공격 (Attack)
            else if (nav.remainingDistance < attackDistance && nav.hasPath && Vector3.Distance(this.transform.position, CharAnimation.trans.position) < attackDistance)
            {
                anim.SetBool("isAttack", true);
                transform.LookAt(CharAnimation.trans.position);
            }
            // 몬스터 이동 (Walk)
            else if (nav.hasPath)
            {
                anim.SetBool("isAttack", false);
            }
            else
            {
                anim.SetBool("isNoPath", true);
            }

            isCorOn = false;
        }
    }

    /// <summary>
    /// <br>몬스터의 체력을 깎고 피격 애니메이션을 재생합니다.</br>
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && HP > 0)
        {
            hitSound.Play();
            anim.Play("Damaged");

            // 리플렉션으로 Gun.currentGun 의 데미지를 GameManager 에서 가져옵니다.
            string fieldName = "damage_" + Gun.currentGun;
            Type gameManagerType = typeof(GameManager);
            FieldInfo fieldInfo = gameManagerType.GetField(fieldName, BindingFlags.Public | BindingFlags.Static);
            float damage_currentGun = (float)fieldInfo.GetValue(null);

            // 리플렉션으로 Gun.currentGun 의 거리 비례 데미지 손실 상수를 GameManager 에서 가져옵니다.
            string fieldName2 = "damageLossPerDistance_" + Gun.currentGun;
            Type gameManagerType2 = typeof(GameManager);
            FieldInfo fieldInfo2 = gameManagerType2.GetField(fieldName2, BindingFlags.Public | BindingFlags.Static);
            float damageLossPerDistance_currentGun = (float)fieldInfo2.GetValue(null);

            // 거리에 따라 데미지를 감소시킨 후 적용합니다.
            float distance = Vector3.Distance(this.transform.position, CharAnimation.trans.position);
            HP = HP - (damage_currentGun / (1 + (distance * damageLossPerDistance_currentGun)));

            Debug.Log("Mob HP : " + HP);
        }
    }

    /// <summary>
    /// <br>지정한 애니메이션 클립의 길이를 반환합니다.</br>
    /// </summary>
    protected float GetAnimationClipLength(string clipName)
    {
        foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips)
        {
            if (clip.name == clipName)
            {
                return clip.length;
            }
        }

        return 0;
    }

    /// <summary>
    /// <br>공격 애니메이션의 이벤트 메서드입니다.</br>
    /// </summary>
    protected void AnimationEvent_Attack()
    {
        if (nav.remainingDistance < attackDistance)
        {
            System.Random rand = new System.Random();
            int index = rand.Next(0, 7);
            attackedSound.clip = Resources.Load<AudioClip>("Sounds/Attacked" + index);
            attackedSound.Play();

            Character.HP = Character.HP - damage;
            Debug.Log(Character.HP);
        }
    }
}
