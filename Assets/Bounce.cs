using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce
{
    public static void bounce(Transform self, Transform target, float bounceSelf, float bounceTarget) {
        Vector3 diffVector = target.position - self.position;
        diffVector.Normalize();
        self.position += -bounceSelf * diffVector;
        target.position += bounceTarget * diffVector;
    }
}
