using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    #region Singleton
    private static Item instance;
    public static Item GetInstance()
    {
        if (!instance)
        {
            instance = FindObjectOfType<Item>();
        }

        return instance;
    }
    #endregion

    public float skillCharge;


	private void Update() {

        if (Input.GetKeyDown(KeyCode.Alpha1))
            UseSkill(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            UseSkill(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            UseSkill(3);
    }


    private void UseSkill(int skillNumber) {

        if (skillNumber == 3 && skillCharge >= 120) {

            for (int i = 0; i < 3; i++) {

                GameManager.GetInstance().redTeam[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            }
            StartCoroutine(Count());
            return;
        }
        else if (skillNumber == 2 && skillCharge >= 80) {

            for (int i = 0; i < 3; i++) {

                GameManager.GetInstance().blueTeam[i].GetComponent<PersonController>().speed = 4.5f;
            }
            return;
        }
        else if (skillNumber == 1 && skillCharge >= 40) {

            GameManager.GetInstance().time -= 10f;
            return;
        }
    }


    public void SkillCharge() {

        skillCharge += Time.deltaTime;
    }


    IEnumerator Count() {

        yield return new WaitForSeconds(3f);

        for (int i = 0; i < 3; i++) {

            GameManager.GetInstance().redTeam[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        yield return null;
    }
}
