using UnityEngine;

internal class Dice
{
    internal Face[] faces;

    internal Dice(Face[] faces)
    {
        this.faces = faces;
    }

    internal (Face, int) Roll()
    {
        int faceIndex = Random.Range(1,7);
        
        Face face = faces[faceIndex];

        face.OnLand();

        return (face, faceIndex);
    }

    internal Face ChangeFace(Face newFace, int faceIndex)
    {
        Face oldFace = faces[faceIndex];

        faces[faceIndex] = newFace;

        return oldFace;
    }
}