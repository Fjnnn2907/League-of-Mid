using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class Skill
{
    public Image skillIcon;
    public KeyCode skillKey;
    public TextMeshProUGUI skillText; 
    public float skillCoolDown;
    [HideInInspector]public bool isSkillOnCooldown = false;
    [HideInInspector]public float currentCoolDown;

}

public class SkillUI : MonoBehaviour
{
    public List<Skill> skillList;
    public HeroesSkill heroesSkill;

    private void Start()
    {
        foreach (Skill skill in skillList)
        {
            skill.skillIcon.fillAmount = 0;
            if (skill.skillText != null)
                skill.skillText.text = "";
        }
    }

    private void Update()
    {
        foreach (Skill skill in skillList)
        {
            HandleSkillInput(skill);
            UpdateSkillCooldown(skill);
        }
    }

    public void HandleSkillInput(Skill skill)
    {
        if (Input.GetKeyDown(skill.skillKey) && !skill.isSkillOnCooldown)
        {
            if(skill.skillKey == KeyCode.W)
                heroesSkill.SkillTwo(skill.skillKey);
            skill.isSkillOnCooldown = true;
            skill.currentCoolDown = skill.skillCoolDown;
        }
    }

    private void UpdateSkillCooldown(Skill skill)
    {
        if (skill.isSkillOnCooldown)
        {
            skill.currentCoolDown -= Time.deltaTime;

            if (skill.currentCoolDown <= 0f)
            {
                skill.isSkillOnCooldown = false;
                skill.currentCoolDown = 0f;

                if (skill.skillIcon != null)
                    skill.skillIcon.fillAmount = 0f;
                if (skill.skillText != null)
                    skill.skillText.text = "";

            }
            else
            {
                if (skill.skillIcon != null)
                    skill.skillIcon.fillAmount = skill.currentCoolDown / skill.skillCoolDown;
                if (skill.skillText != null)
                    skill.skillText.text = Mathf.Ceil(skill.currentCoolDown).ToString();
            }
        }
    }
}
