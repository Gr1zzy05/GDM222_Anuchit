using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment02.StudentSolution.LCT04
{
    public class Animal
    {
        /// <summary>
        /// name เป็น public จึงสามารถเข้าถึงได้จากภายนอก class
        /// รวมถึงภายใน method ของ class ที่สืบทอด Animal ไปด้วย
        /// </summary>
        public string name = "";

        /// <summary>
        /// specie เป็น protected จึงสามารถเข้าถึงได้จากภายใน class ที่สืบทอด Animal
        /// จากการออกแบบนี้ จะทำให้การกำหนดค่าให้กับ specie จะต้องทำผ่าน class ที่สืบทอด Animal เท่านั้น
        /// เช่นผ่าน constructor ของ Dog เพื่อกำหนดค่า specie = "Dog"
        /// ไม่สามารถกำหนดค่าให้กับ specie จากภายนอก class ได้
        /// </summary>
        protected  string specie = "";

        /// <summary>
        /// health เป็น private จึงสามารถเข้าถึงได้เฉพาะภายใน class นี้ (Animal) เท่านั้น
        /// </summary>
        private int health = 10;

        public void Feed(int food)
        {
            health += food;
            Debug.Log($"{name} got {food} food");
        }

        /// <summary>
        /// MakeSound method จะ Debug.Log ข้อความออกมาด้วยเงื่อนไข
        /// + ถ้า health > 50 จะพิมพ์ "{name} happy!"
        /// + ถ้า health <= 50 จะพิมพ์ "{name} weak!"
        /// </summary>
        public void MakeSound()
        {
            if (health > 50)
            {
                Debug.Log($"{name} happy!");
            }
            else
            {
                Debug.Log($"{name} weak!");
            }
        }
    }

    public class Dog : Animal
    {
        public Dog(string name)
        {
            this.specie = "Dog";
            this.name = name;
        }
    }

    public class LCT04AccessModifier : Animal
    {
        public void Start()
        {
            Dog dog = new Dog("Buddy");

            Debug.Log($"my name is {dog.name}");
    
            dog.MakeSound();

            dog.Feed(50);

            dog.MakeSound();
        }
    }
}
