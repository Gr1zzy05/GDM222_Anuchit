using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment02.StudentSolution.LCT01
{
    public class Car
    {
        public void write(string word)
        {
            Debug.Log("Car is " + word);
        }
    }

    public class LCT01SyntaxClass : Car
    {
        public void Start()
        {
            write("moving");
            write("turning");
            write("honking");
        }
    }
}
