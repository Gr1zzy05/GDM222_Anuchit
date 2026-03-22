using System.Globalization;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment02.StudentSolution.LCT03
{
    public class Animal
    {
        public string name;

        public virtual void MakeSound()
        {
            Debug.Log($"Animal {name} is making sound");
        }
    }

    // class Dog inherits from Animal
    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Debug.Log($"Animal {name} is making sound");
        }
        public void walk()
        {
            Debug.Log($"Dog {name} is walking");
        }
        
        
    }

    // class Bird inherits from Animal
    public class Bird : Animal
    {
        public override void MakeSound()
        {
            Debug.Log($"Animal {name} is making sound");
        }

        public void flying()
        {
            Debug.Log($"Bird {name} is flying");
        }

    }

    public class LCT03Inheritance : Animal
    {

        public void Start()
        {
            // 1. สร้าง instance ของ class Dog โดยกำหนดชื่อตัวแปรว่า dog
            // + กำหนดชื่อ (name) ว่า "Buddy"
            // + เรียกใช้ method MakeSound() ของ dog
            // + เรียกใช้ method Walk() ของ dog
            Dog dog = new Dog();
            dog.name = "Buddy";
            dog.MakeSound();
            dog.walk();


            // 2. สร้าง instance ของ class Bird โดยกำหนดชื่อตัวแปรว่า bird
            // + กำหนดชื่อ (name) ว่า "Twitty"
            // + เรียกใช้ method MakeSound() ของ bird
            // + เรียกใช้ method Fly() ของ bird
            Bird bird = new();
            bird.name = "Twitty";
            bird.MakeSound();
            bird.flying();
        }
    }
}
