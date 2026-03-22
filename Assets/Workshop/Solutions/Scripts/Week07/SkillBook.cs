using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class SkillBook : MonoBehaviour
    {
        public SkillTree attackSkillTree;

        Skill Fighter;
        Skill F_S;
        Skill S_S;
        Skill T_S;
        Skill Dash;
        Skill ShadowDash;
    Skill Blocking;
    Skill Parry;
    Skill CounterAttack;
        public void Start()
        {
            // สร้างสกิล
            Fighter = new Skill("Fighter");
            Fighter.isAvailable = true;
            F_S = new Skill("First Strike");
            S_S = new Skill("Second Strike");
            T_S = new Skill("Third Strike");
            Dash = new Skill("Dashing");
            ShadowDash = new Skill("Shadow dash");
        Blocking = new Skill("Blocking");
        Parry = new Skill("Parry");
        CounterAttack = new Skill("CounterAttack");
            // build skill tree
            // └── Attack
            //     └── FireStorm
            //         ├── FireBlast
            //         └── FireBall
            //             └── FireWave
            //                 └── FireExplosion


        // 1. set the nextSkills for each skill

        // [0] Attack -> FireStorm
            Fighter.nextSkills.Add(F_S);
        // [1] FireStorm -> FireBlast
            F_S.nextSkills.Add(S_S);
        // [2] FireStorm -> FireBall
            S_S.nextSkills.Add(T_S);
        // [3] FireBall -> FireWave
            Fighter.nextSkills.Add(Dash);
        // [4] FireWave -> FireExplosion
           Dash.nextSkills.Add(ShadowDash);

           Fighter.nextSkills.Add(Blocking);

        Blocking.nextSkills.Add(Parry);

        Parry.nextSkills.Add(CounterAttack);
        this.attackSkillTree = new SkillTree(Fighter);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                //attackSkillTree.rootSkill.PrintSkillTreeHierarchy("");
                attackSkillTree.rootSkill.PrintSkillTree();
                Debug.Log("====================================");
            } 
        }
    }

