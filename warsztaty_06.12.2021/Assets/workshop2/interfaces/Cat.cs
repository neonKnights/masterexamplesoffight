using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Cat : Animal, IBeing
{
    public void Eat() {
        hunger--;
    }

    public void Drink() {

    }
}
