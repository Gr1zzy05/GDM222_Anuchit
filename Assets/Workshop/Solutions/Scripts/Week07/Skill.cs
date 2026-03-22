using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill
{
    public string name;
    public bool isUnlocked;
    public bool isAvailable;
    public List<Skill> nextSkills;

        
    public Skill(string name)
    {
    // 1. set the name of the skill, 
        this.name = name;
    // initialize isUnlocked to false, 
        isUnlocked = false;
    // and create an empty list of nextSkills
        nextSkills = new List<Skill>();
    }

    public void Unlock()
    {
        if (!isAvailable)
        {
            // 2. throw an exception if the skill is not available to unlock
            throw new System.Exception("Skill is not available to unlock");
        }

        if (isUnlocked)
        {
            Debug.Log($"Skill {name} is already unlocked");
            return;
            // 3. if the skill is already unlocked, log message and return
        }

        // 4. set isUnlocked to true
        isUnlocked = true;

        // 5. set isAvailable to true for all nextSkills
        for (int i = 0; i < nextSkills.Count; i++)
        {
            nextSkills[i].isAvailable = true;
        }
    }


    public void PrintSkillTree()
    {
        // 6. log the name of the skill, isAvailable, and isUnlocked
        // and call PrintSkillTree() on all nextSkills
        Debug.Log($"Skill: {name} available: {isAvailable} unlocked: {isUnlocked}");
        for (int i = 0; i < nextSkills.Count; i++)
        {
            nextSkills[i].PrintSkillTree();
        }
    }

    public void PrintSkillTreeHierarchy(string indent)
    {
        // 7. log the name of the skill, isAvailable, and isUnlocked with indentation
        // and call PrintSkillTreeHierarchy() on all nextSkills
        Debug.Log($"{indent} -Skill: {name} available: {isAvailable} unlocked: {isUnlocked}");
        foreach (Skill skill in nextSkills) {
            skill.PrintSkillTreeHierarchy(indent + "***");
        }
    }

}

public class SkillTree
{
    public Skill rootSkill;

    public SkillTree(Skill rootSkill)
    {
        this.rootSkill = rootSkill;
    }
}

