using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_Zombie : MonoBehaviour
{
    public GameObject player;
    public GameObject nextZombie;
    NavMeshAgent agent;
    public Animator anim;
    public float attackDistance = 1f;

    public enum State
    {
        Search,
        Move,
        Attack,
        Death
    }
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.Search;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Search: UpdateSearch(); break;
            case State.Move: UpdateMove(); break;
            case State.Attack: UpdateAttack(); break;
            case State.Death: UpdateDeath(); break;
            default: break;
        }

        if (FlashLight.instance.isZombieDestroyTimeOver)
        {
            UpdateDeath();
            agent.isStopped = true;
        }
    }

    private void UpdateSearch()
    {
        //�÷��̾ ã��
        player = GameObject.Find("OVRPlayerController");

        //�״��� ������ &&(1�� å -> �÷��� ���� ��ü ������ ���)�̺�Ʈ bool &&�� �߰�
        //�׳� ���� ������ ��.
        if (player != null)
        {
            state = State.Move;
            anim.SetTrigger("Move");//�̰� animator�� parameter��.
        }
    }

    private void UpdateMove()
    {
        //agent�� �������� player��.
        agent.SetDestination(player.transform.position);
        //����Ÿ�ٰ��� �Ÿ��� ���� ���� �Ÿ����� �۴ٸ�
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < attackDistance)
        {
            //���ݻ��·� �����ϰ�ʹ�
            state = State.Attack;
            anim.SetTrigger("Attack");//�̰� animator�� parameter��.
        }
    }

    private void UpdateAttack()
    {
        agent.SetDestination(transform.position);
        //agent.isStopped = true;
        //Player�̵��� Ÿ��(Player)�� �ٶ󺸰� �ʹ�(�ε巴�� ȸ����)
        //enemy�� �ٶ� ����=Ÿ��-��
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        //targetRotation enemy�� ȸ���� ����,transform.rotation�� ���� ���������Ѵ�.
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        //transform.rotation�� ��������(Lerp)�Ѵ�.
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5);

        ////Gameoverscene �̵�
        //SceneManager.LoadScene("GameoverScene");
    }

    private void UpdateDeath()
    {
        if (state == State.Death)
        {
            // �Լ��� �ٷ� �����ϰ�ʹ�.
            return;
        }
        Destroy(gameObject, 1.5f);
        state = State.Death;
        anim.SetTrigger("Death");
        FlashLight.instance.isZombieDestroyTimeOver = false;
        nextZombie.gameObject.SetActive(true);
    }
}
