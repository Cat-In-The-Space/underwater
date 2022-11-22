using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishHealthController : MonoBehaviour
{
    public int health = 0;
    public int maxHealth = 0;
    public float immunityTime = 0.0f;
    public float immunityTimeElapsed = 0.0f;
    public float immunityMeshShowTime = 0.0f;
    public float immunityMeshShowElapsedTime = 0.0f;
    public bool canRegenerate = false;
    public float regenerationTime = 0.0f;
    public float regenerationTimeElapsed = 0.0f;
    public SkinnedMeshRenderer[] meshes;
    public ProgressBarController healthBar;
    public float liveTime = 0.0f;
    public bool Damage(int amount)
    {
        if (immunityTimeElapsed > 0.0f)
        {
            return false;
        }
        health -= amount;
        healthBar.SetValue(health, maxHealth);
        if (health <= 0)
        {
            Utils.SetLevelLiveTime(liveTime);
            Utils.SetLevelBonus(GetComponent<FishBonusController>().bonuses);
            SceneManager.LoadScene("ResultScene");
        }
        else
        {
            immunityTimeElapsed += immunityTime;
        }

        if (canRegenerate)
        {
            if (regenerationTimeElapsed <= 0.0f)
            {
                regenerationTimeElapsed += regenerationTime;
            }
        }
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
        health = maxHealth;
        healthBar.SetValue(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (immunityTimeElapsed > 0.0f)
        {
            immunityTimeElapsed -= Time.deltaTime;
            immunityMeshShowElapsedTime -= Time.deltaTime;
            if (immunityMeshShowElapsedTime <= 0.0f)
            {
                foreach (SkinnedMeshRenderer mesh in meshes)
                {
                    mesh.enabled = !mesh.enabled;
                }
                immunityMeshShowElapsedTime += immunityMeshShowTime;
            }
        }
        else
        {
            foreach (SkinnedMeshRenderer mesh in meshes)
            {
                mesh.enabled = true;
            }
        }

        if (canRegenerate)
        {
            if (regenerationTimeElapsed <= 0.0f)
            {
                if (health < maxHealth)
                {
                    regenerationTimeElapsed += regenerationTime;
                    health += 1;
                    healthBar.SetValue(health, maxHealth);
                }
            }
            else
            {
                regenerationTimeElapsed -= Time.deltaTime;
            }
        }

        liveTime += Time.deltaTime;
    }
}
