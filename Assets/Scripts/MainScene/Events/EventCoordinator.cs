using UnityEngine;
using System.Collections;

public class EventCoordinator : MonoBehaviour {

    ProjectorTimer timer;

	// Use this for initialization
	void Start () {
        timer = GameObject.FindObjectOfType<ProjectorTimer>();
        StartCoroutine(IEStartEvents());
	}

    private IEnumerator IEStartEvents()
    {
        timer.StartTimer();
        yield return new WaitForSeconds(20);
        PossesedPeople();
        yield return new WaitForSeconds(10);
        ClearPossesedPeople();
        SetNormalAtmosphere();
        yield return new WaitForSeconds(5);
        RagdolPeople();
        yield return new WaitForSeconds(10);
        ClearRagdolPeople();
        SetNormalAtmosphere();
        yield return new WaitForSeconds(5);
        SetUpConductors();
        yield return new WaitForSeconds(15);
        ClearConductors();
        SetNormalAtmosphere();
        yield return new WaitForSeconds(5);
        SetUpZombies();
        yield return new WaitForSeconds(15);
        ClearZombies();
        SetNormalAtmosphere();
        yield return new WaitForSeconds(5);
        InFrontOfTimer();
        yield return new WaitForSeconds(10);
        ShowBluescreen();
    }

    private void InFrontOfTimer()
    {
        throw new System.NotImplementedException();
    }

    private void ShowBluescreen()
    {
        throw new System.NotImplementedException();
    }

    private void ClearZombies()
    {
        throw new System.NotImplementedException();
    }

    private void SetUpZombies()
    {
        throw new System.NotImplementedException();
    }

    private void ClearConductors()
    {
        throw new System.NotImplementedException();
    }

    private void SetUpConductors()
    {
        throw new System.NotImplementedException();
    }

    private void ClearRagdolPeople()
    {
        throw new System.NotImplementedException();
    }

    private void RagdolPeople()
    {
        throw new System.NotImplementedException();
    }

    private void SetNormalAtmosphere()
    {
        throw new System.NotImplementedException();
    }

    private void ClearPossesedPeople()
    {
        throw new System.NotImplementedException();
    }

    void PossesedPeople()
    {

    }

	

}
