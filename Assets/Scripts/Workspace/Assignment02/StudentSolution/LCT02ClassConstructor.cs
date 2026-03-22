using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;


// SKIP Lecture ...
namespace Assignment02.StudentSolution.LCT02
{
    public class Dog
    {
        // properties including name, breed, age ...

        public string name;
        public string breed;
        public int age;

        // end of properties ...

        // สร้าง constructor ที่รับ parameter 3 ตัว และกำหนดค่าให้กับ properties ของ class
        // โดยทั้ง 3 parameter คือ name, breed, age ตามลำดับ
        public Dog(string name,string breed,int age)
        {

        }

        /// behaviors ...

        public void Bark(string name,string action)
        {
            Debug.Log($"{name} is {action}");
        }

        public void WagTail(string name, string action)
        {
            Debug.Log($"{name} is {action}");
        }

        public void StopBarking(string name, string action)
        {
            Debug.Log($"{name} stopped {action}");
        }

        // end of behaviors ...
    }

    public class LCT02ClassConstructor
    {
        Dog dog1;

        public void Start()
        {
            // สร้าง object dog1 ของ class Dog โดยใช้ constructor ที่รับ parameter 3 ตัว
            // และกำหนดค่าให้กับ properties ของ object นั้น
            // กำหนดให้ name = "Buddy", breed = "Golden Retriever", age = 3

            // Student code starts HERE ...
            // ...
            Dog dog1 = new Dog("Buddy","Golden Retriver",3);
            // ...
            // Student code ends HERE ...

            // เรียกใช้ method ของ object นั้น

            dog1.Bark("Buddy","barking");
            dog1.WagTail("Buddy","wagging tail");
            dog1.StopBarking("Buddy","barking");
        }
    }
}
