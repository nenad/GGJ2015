using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class KontrolorMoveCompleted : RAINAction
{
    bool isAudioPlaying = false;
    float waitTime = 0f;
    EnemyConductor enemyConductor;
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
        enemyConductor = ai.Body.GetComponent<EnemyConductor>();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        enemyConductor = ai.Body.GetComponent<EnemyConductor>();
        
        enemyConductor.anim.Stop();
        if (!isAudioPlaying && waitTime > 15f)
        {
            enemyConductor.audio.clip = enemyConductor.shopraime;
            enemyConductor.audio.loop = false;
            enemyConductor.audio.Play();
            isAudioPlaying = true;
        }
        else if (waitTime > 25f)
        {
            AutoLevelSwitch.switchTime = -1f;
            Application.LoadLevel("BSOD");
            return ActionResult.SUCCESS;
        }
        waitTime += ai.DeltaTime;

        return ActionResult.RUNNING;
    }

    IEnumerator ShowBlueScreen()
    {
        yield return new WaitForSeconds(enemyConductor.audio.clip.length);
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}