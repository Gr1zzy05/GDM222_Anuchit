using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment02.StudentSolution.LCT05
{
    public class Animal
    {
        // 0. make MakeSound method to virtual method
        public virtual void MakeSound()
        {
            Debug.Log("Generic animal sound");
        }
    }

    public class Dog : Animal
    {
        // student code here ...
        // 1. declare overridden MakeSound() method
        public override void MakeSound()
        {
            Debug.Log("Woof!");
        }
        // student code ends ...
    }

    public class Cat : Animal
    {
        // student code here ...
        // 2. declare overridden MakeSound() method
        public override void MakeSound()
        {
            Debug.Log("Meow!");
        }
        // student code ends ...    
    }



    public class LCT05VirtualOverride : Animal
    {
        public void Start()
        {
            // 3. create instance of Dog and call MakeSound()
               Dog dog = new Dog();
            dog.MakeSound();
            // 4. create instance of Cat and call MakeSound()
            Cat cat = new Cat();
            cat.MakeSound();
            // 5. create instance of Animal and call MakeSound()
            Animal animal = new Animal();
            animal.MakeSound();
        }
    }
}
