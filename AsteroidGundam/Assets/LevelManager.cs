using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject player;
    Equipement equipementManager;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject cameraPrefab;
    [SerializeField] GameObject miniMapCameraPrefab;
    [SerializeField] GameObject uiPrefab;
    [SerializeField] GameObject endPage;

    GameObject uiIns;

    private void Awake()
    {
        player = Instantiate(playerPrefab, transform.position, transform.rotation);
        equipementManager = GameObject.FindGameObjectWithTag("Equipement").GetComponent<Equipement>();

        var playerMain = player.GetComponent<PlayerMain>();
        playerMain.SetNewMS(equipementManager.GetMs());
        playerMain.InitNewWeapons(equipementManager.GetWeapons());

        var cameraIns = Instantiate(cameraPrefab, player.transform.position, player.transform.rotation);
        cameraIns.GetComponentInChildren<SmoothCamera>().Init(player);

        var miniMapCameraIns = Instantiate(miniMapCameraPrefab, player.transform.position, player.transform.rotation);
        miniMapCameraIns.GetComponentInChildren<SmoothCamera>().Init(player);

        uiIns = Instantiate(uiPrefab, transform.position, transform.rotation);
        uiIns.GetComponent<PlayerUiManager>().Init(player, cameraIns.GetComponent<Camera>());
    }

    public void GameOver()
    {
        uiIns.SetActive(false);

        GetComponent<EnemyManager>().PlayerDied();

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothCamera>().enabled = false;

        var endPageIns = Instantiate(endPage, transform.position, transform.rotation);
        int nbEnemeyDestroyed = GetComponent<EnemyManager>().nbEnemyDestroyed;
        endPageIns.GetComponent<EndPage>().InitUI(nbEnemeyDestroyed * 200, nbEnemeyDestroyed);
    }

    public void LevelUp()
    {
        uiIns.GetComponent<PlayerUiManager>().InitUpgradeUi();
    }
}
