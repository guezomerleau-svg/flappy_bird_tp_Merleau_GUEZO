using UnityEngine;

public class PipePairSetup : MonoBehaviour
{
    public Transform pipeTop;
    public Transform pipeBottom;

    // Configure l'écart vertical entre les deux tuyaux
    public void SetGap(float gapSize)
    {
        // Écarte chaque tuyau de la moitié du gap, de part et d'autre du centre
        pipeTop.localPosition = new Vector3(pipeTop.localPosition.x, gapSize / 2f, 0);
        pipeBottom.localPosition = new Vector3(pipeBottom.localPosition.x, -gapSize / 2f, 0);
    }
}
