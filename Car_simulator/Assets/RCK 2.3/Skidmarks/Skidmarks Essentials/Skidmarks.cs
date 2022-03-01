using UnityEngine;
using System.Collections;

public class Skidmarks : MonoBehaviour
{


    //@script RequireComponent(MeshFilter)
    //@script RequireComponent(MeshRenderer)

    public int maxMarks = 1024;			// Maximum number of marks total handled by one instance of the script.
    public float markWidth = 0.275f;		// The width of the skidmarks. Should match the width of the wheel that it is used for. In meters.
    public float groundOffset = 0.02f;	// The distance the skidmarks is places above the surface it is placed upon. In meters.
    public float minDistance = 0.1f;        // The minimum distance between two marks places next to each other. 
    int numMarks = 0;

    // Variables for each mark created. Needed to generate the correct mesh.
    class markSection
    {

        public Vector3 pos = Vector3.zero;
        public Vector3 normal = Vector3.zero;
        public Vector4 tangent = Vector4.zero;
        public Vector3 posl = Vector3.zero;
        public Vector3 posr = Vector3.zero;
        public float intensity = 0.0f;
        public int lastIndex = 0;
    }

    private markSection[] skidmarks;

    private bool updated = false;

    // Function called by the wheels that is skidding. Gathers all the information needed to
    // create the mesh later. Sets the intensity of the skidmark section b setting the alpha
    // of the vertex color.
    public int AddSkidMark(Vector3 pos, Vector3 normal, float intensity, int lastIndex)
    {
        if (intensity > 1)
            intensity = 1.0f;
        if (intensity < 0)
            return -1;

        markSection curr = skidmarks[numMarks % maxMarks];
        curr.pos = pos + normal * groundOffset;
        curr.normal = normal;
        curr.intensity = intensity;
        curr.lastIndex = lastIndex;

        if (lastIndex != -1)
        {
            markSection last = skidmarks[lastIndex % maxMarks];
            Vector3 dir = (curr.pos - last.pos);
            Vector3 xDir = Vector3.Cross(dir, normal).normalized;

            curr.posl = curr.pos + xDir * markWidth * 0.5f;
            curr.posr = curr.pos - xDir * markWidth * 0.5f;
            curr.tangent = new Vector4(xDir.x, xDir.y, xDir.z, 1);

            if (last.lastIndex == -1)
            {
                last.tangent = curr.tangent;
                last.posl = curr.pos + xDir * markWidth * 0.5f;
                last.posr = curr.pos - xDir * markWidth * 0.5f;
            }
        }
        numMarks++;
        updated = true;
        return numMarks - 1;
    }

    // If the mesh needs to be updated, i.e. a new section has been added,
    // the current mesh is removed, and a new mesh for the skidmarks is generated.

    public bool skidmake = false;
}
