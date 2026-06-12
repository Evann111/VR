using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetButton : UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable
{
    private bool pressed = false;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        if (pressed) return;
        pressed = true;

        foreach (var fruit in FindObjectsByType<Fruit>(FindObjectsSortMode.None))
            Destroy(fruit.gameObject);

        NinjaGameManager.Instance.ResetGame();
        Invoke(nameof(ResetPress), 0.5f);
    }

    void ResetPress() => pressed = false;
}