using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AssignmentSystem.Services;
using System;

namespace Assignment01
{
    public class Assignment_Testcase
    {
        private IAssignment assignment;

        [SetUp]
        public void Setup()
        {
            // This will need to be set to the actual implementation class
            GameObject solutionGo = new($"Solution-{Guid.NewGuid()}");
            assignment = solutionGo.AddComponent<StudentSolution>();
            AssignmentDebugConsole.Clear();
        }

        [TearDown]
        public void Teardown()
        {
            if (assignment is MonoBehaviour)
            {
                var remainingGOs = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
                foreach (var go in remainingGOs)
                {
                    GameObject.DestroyImmediate(go);
                }
            }
        }

        [Test]
        [Category("Lecture")]
        public void Test_LCT01_SyntaxArray()
        {
            // Act
            assignment.LCT01_SyntaxArray();
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            string expected = @"TonyStark Wear: Mark I
Room size: 2
Mark I
Mark II";

            TestUtils.AssertMultilineEqual(expected, output);
        }

        [Test]
        [Category("Lecture")]
        public void Test_LCT02_ArraySize()
        {
            // Act
            assignment.LCT02_ArrayInitialize();
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            string expected = @"Room size: 3
Classic SpiderMan
Black Suit
Iron Spider Suit
Room size: 2
Classic BatMan
White bat";

            TestUtils.AssertMultilineEqual(expected, output);
        }


        [Category("Lecture")]
        [Test]
        public void Test_LCT03_SyntaxLoop()
        {
            // Act
            assignment.LCT03_SyntaxLoop();
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            string expected = @"<10 : 0
<10 : 1
<10 : 2
<10 : 3
<10 : 4
<10 : 5
<10 : 6
<10 : 7
<10 : 8
<10 : 9
===
<=10 : 1
<=10 : 2
<=10 : 3
<=10 : 4
<=10 : 5
<=10 : 6
<=10 : 7
<=10 : 8
<=10 : 9
<=10 : 10";

            TestUtils.AssertMultilineEqual(expected, output);
        }



        [Category("Lecture")]
        [Test]
        public void Test_LCT04_LoopAndArray()
        {
            // Arrange
            string[] suits = new string[] { "Mark I", "Mark II", "Mark III", "Mark IV", "Mark V", "Mark VI", "Mark VII" };

            // Act
            assignment.LCT04_LoopAndArray(suits);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            string expected = @"Mark I
Mark II
Mark III
Mark IV
Mark V
Mark VI
Mark VII
===
Mark I
Mark III
Mark V
Mark VII";

            TestUtils.AssertMultilineEqual(expected, output);
        }

        [Test]
        [Category("Lecture")]
        public void Test_LCT05_Syntax2DArray()
        {
            // Act
            assignment.LCT05_Syntax2DArray();
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            string expected = @"my2DArray[0, 0] = 1
my2DArray[0, 1] = 2
my2DArray[1, 0] = 3
my2DArray[1, 1] = 4
After change value
my2DArray[0, 1] = 6
my2DArray[1, 1] = 8";

            TestUtils.AssertMultilineEqual(expected, output);
        }

        [Test]
        [Category("Lecture")]
        public void Test_LCT06_SizeOf2DArray()
        {
            // Arrange
            int[,] testArray = new int[3, 5] {
                { 1, 2, 3, 4, 5 },
                { 1, 2, 3, 4, 5 },
                { 1, 2, 3, 4, 5 }
            };

            // Act
            assignment.LCT06_SizeOf2DArray(testArray);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            string expected = @"rows = 3
cols = 5";

            TestUtils.AssertMultilineEqual(expected, output);
        }

        [TestCase(3, 4, "***\n***\n***\n***", TestName = "LCT07_SyntaxNestedLoop_3x4", Description = "3 columns, 4 rows")]
        [TestCase(10, 1, "**********", TestName = "LCT07_SyntaxNestedLoop_10x1", Description = "10 columns, 1 row")]
        [TestCase(5, 3, "*****\n*****\n*****", TestName = "LCT07_SyntaxNestedLoop_5x3", Description = "5 columns, 3 rows")]
        [TestCase(1, 5, "*\n*\n*\n*\n*", TestName = "LCT07_SyntaxNestedLoop_1x5", Description = "1 column, 5 rows")]
        [Category("Lecture")]
        public void Test_LCT07_SyntaxNestedLoop_AllCases(int columns, int rows, string expected)
        {
            // Act
            assignment.LCT07_SyntaxNestedLoop(columns, rows);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual(expected, output);
        }

        #region Assignment Tests

        [Category("Assignment")]
        [TestCase(new string[] { "Sword", "Shield", "Potion" }, 1, TestName = "AS01_RandomItemDrop_ThreeItems", Description = "Random item drop with 3 items using seed 42")]
        [TestCase(new string[] { "Helmet" }, 100, TestName = "AS01_RandomItemDrop_SingleItem", Description = "Random item drop with only 1 item")]
        [TestCase(new string[] { "Bow", "Arrow", "Quiver", "Magic Ring", "Health Potion" }, 25, TestName = "AS01_RandomItemDrop_FiveItems", Description = "Random item drop with 5 items using seed 25")]
        [TestCase(new string[] { "Item A", "Item B" }, 1, TestName = "AS01_RandomItemDrop_TwoItems", Description = "Random item drop with 2 items using seed 1")]
        public void Test_AS01_RandomItemDrop(string[] itemNames, int randomSeed)
        {
            // Arrange
            GameObject[] items = new GameObject[itemNames.Length];
            for (int i = 0; i < itemNames.Length; i++)
            {
                items[i] = new GameObject(itemNames[i]);
            }

            try
            {
                // Act
                assignment.AS01_RandomItemDrop(items);
                string output = AssignmentDebugConsole.GetOutput();

                string o = output.Replace("Got item: ", "").Trim();
                Debug.Log("contains: " + itemNames.Contains(o));
                Assert.IsTrue(itemNames.Contains(o), $"Expected one of {string.Join(", ", itemNames)} but got {o}");
                string expected = $"Got item: {o}";
                TestUtils.AssertMultilineEqual(expected, output);
            }
            finally
            {
                // Clean up created GameObjects
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null)
                    {
                        UnityEngine.Object.DestroyImmediate(items[i]);
                    }
                }
            }
        }

        [Category("Assignment")]
        [TestCase(new int[] { 10, 15, 20, 25, 30 }, 2, 3, "FirstEnemy hp :8\nLastEnemy hp :28\nTargetEnemy 3 hp :23", TestName = "AS04_AttackEnemy_BasicScenario", Description = "Basic attack scenario with 5 enemies")]
        [TestCase(new int[] { 5, 10, 15 }, 10, 1, "FirstEnemy hp :0\nLastEnemy hp :5\nTargetEnemy 1 hp :0", TestName = "AS04_AttackEnemy_HPCannotGoBelowZero", Description = "HP should not go below 0 when damage exceeds current HP")]
        [TestCase(new int[] { 20 }, 5, 0, "FirstEnemy hp :15\nLastEnemy hp :10\nTargetEnemy 0 hp :5", TestName = "AS04_AttackEnemy_SingleEnemy", Description = "Single enemy attacked as first, last, and target")]
        [TestCase(new int[] { 100, 200 }, 50, 1, "FirstEnemy hp :50\nLastEnemy hp :150\nTargetEnemy 1 hp :100", TestName = "AS04_AttackEnemy_TwoEnemies", Description = "Two enemies where first and last are different")]
        [TestCase(new int[] { 1, 1, 1, 1 }, 2, 2, "FirstEnemy hp :0\nLastEnemy hp :0\nTargetEnemy 2 hp :0", TestName = "AS04_AttackEnemy_AllEnemiesKilled", Description = "All enemies reduced to 0 HP")]
        [TestCase(new int[] { 50, 60, 70, 80, 90 }, 0, 2, "FirstEnemy hp :50\nLastEnemy hp :90\nTargetEnemy 2 hp :70", TestName = "AS04_AttackEnemy_ZeroDamage", Description = "Zero damage should not change HP")]
        [TestCase(new int[] { 15, 25, 35 }, 5, 0, "FirstEnemy hp :10\nLastEnemy hp :30\nTargetEnemy 0 hp :5", TestName = "AS04_AttackEnemy_TargetFirstEnemy", Description = "Target the first enemy (should be attacked twice)")]
        [TestCase(new int[] { 15, 25, 35 }, 5, 2, "FirstEnemy hp :10\nLastEnemy hp :30\nTargetEnemy 2 hp :25", TestName = "AS04_AttackEnemy_TargetLastEnemy", Description = "Target the last enemy (should be attacked twice)")]
        public void Test_AS04_AttackEnemy(int[] enemyHP, int damage, int target, string expected)
        {
            // Act
            assignment.AS04_AttackEnemy(enemyHP, damage, target);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual(expected, output);
        }

        [Category("Assignment")]
        [TestCase(0, "", TestName = "AS05_DynamicIterationLoop_Zero", Description = "No output when n=0")]
        [TestCase(1, "0", TestName = "AS05_DynamicIterationLoop_One", Description = "Single iteration when n=1")]
        [TestCase(3, "0\n1\n2", TestName = "AS05_DynamicIterationLoop_Three", Description = "Three iterations when n=3")]
        [TestCase(5, "0\n1\n2\n3\n4", TestName = "AS05_DynamicIterationLoop_Five", Description = "Five iterations when n=5")]
        [TestCase(10, "0\n1\n2\n3\n4\n5\n6\n7\n8\n9", TestName = "AS05_DynamicIterationLoop_Ten", Description = "Ten iterations when n=10")]
        public void Test_AS05_DynamicIterationLoop(int n, string expected)
        {
            // Act
            assignment.AS05_DynamicIterationLoop(n);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual(expected, output);
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS06_WhileLoopAndArray()
        {
            // Arrange
            string[] suits = new string[] { "Mark I", "Mark II", "Mark III", "Mark IV", "Mark V", "Mark VI", "Mark VII" };

            // Act
            assignment.AS06_WhileLoopAndArray(suits);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            string expected = @"Mark I
Mark II
Mark III
Mark IV
Mark V
Mark VI
Mark VII
===
Mark I
Mark III
Mark V
Mark VII";

            TestUtils.AssertMultilineEqual(expected, output);
        }

        [Category("Assignment")]
        [TestCase(new int[] { 10, 15, 20, 25, 30 }, 5, 3, "FirstHero hp :15\nLastHero hp :35\nTargetHero 3 hp :30", TestName = "Test_AS07_HealTargetAtIndex_BasicScenario", Description = "Basic heal scenario with 5 heroes")]
        [TestCase(new int[] { 1, 2, 3 }, 10, 1, "FirstHero hp :11\nLastHero hp :13\nTargetHero 1 hp :12", TestName = "Test_AS07_HealTargetAtIndex_LowHP", Description = "Heal heroes with low HP")]
        [TestCase(new int[] { 100 }, 50, 0, "FirstHero hp :150\nLastHero hp :200\nTargetHero 0 hp :250", TestName = "Test_AS07_HealTargetAtIndex_SingleHero", Description = "Single hero healed as first, last, and target")]
        [TestCase(new int[] { 50, 100 }, 25, 1, "FirstHero hp :75\nLastHero hp :125\nTargetHero 1 hp :150", TestName = "Test_AS07_HealTargetAtIndex_TwoHeroes", Description = "Two heroes where first and last are different")]
        [TestCase(new int[] { 0, 0, 0, 0 }, 20, 2, "FirstHero hp :20\nLastHero hp :20\nTargetHero 2 hp :20", TestName = "Test_AS07_HealTargetAtIndex_ZeroHP", Description = "Heal heroes with 0 HP")]
        [TestCase(new int[] { 50, 60, 70 }, 0, 1, "FirstHero hp :50\nLastHero hp :70\nTargetHero 1 hp :60", TestName = "Test_AS07_HealTargetAtIndex_ZeroHeal", Description = "Zero heal should not change HP")]
        [TestCase(new int[] { 15, 25, 35 }, 5, 0, "FirstHero hp :20\nLastHero hp :40\nTargetHero 0 hp :25", TestName = "Test_AS07_HealTargetAtIndex_TargetFirstHero", Description = "Target the first hero (should be healed twice)")]
        [TestCase(new int[] { 15, 25, 35 }, 5, 2, "FirstHero hp :20\nLastHero hp :40\nTargetHero 2 hp :45", TestName = "Test_AS07_HealTargetAtIndex_TargetLastHero", Description = "Target the last hero (should be healed twice)")]
        public void Test_AS07_HealTargetAtIndex_AllCases(int[] heroHPs, int heal, int targetIndex, string expected)
        {
            // Act
            assignment.AS07_HealTargetAtIndex(heroHPs, heal, targetIndex);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual(expected, output);
        }

        [Category("Assignment")]
        [TestCase(new string[] { "สวัสดีครับ", "คุณเป็นอย่างไรบ้าง", "มีอะไรให้ช่วยไหม" }, 0, TestName = "AS08_RandomPickingDialogue_ThaiDialogues", Description = "Random dialogue selection with Thai text using seed 42")]
        [TestCase(new string[] { "Hello there!", "How are you?", "What can I do for you?" }, 0, TestName = "AS08_RandomPickingDialogue_EnglishDialogues", Description = "Random dialogue selection with English text")]
        [TestCase(new string[] { "Welcome!" }, 0, TestName = "AS08_RandomPickingDialogue_SingleDialogue", Description = "Random dialogue selection with only 1 dialogue")]
        [TestCase(new string[] { "Good morning", "Good afternoon", "Good evening", "Good night", "See you later" }, 0, TestName = "AS08_RandomPickingDialogue_FiveDialogues", Description = "Random dialogue selection with 5 dialogues using seed 1")]
        public void Test_AS08_RandomPickingDialogue_AllCases(string[] dialogues, int _)
        {
            // Act
            assignment.AS08_RandomPickingDialogue(dialogues);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            Assert.IsTrue(dialogues.Contains(output.Trim()), $"Expected one of {string.Join(", ", dialogues)} but got {output.Trim()}");
        }

        [Category("Assignment")]
        [TestCase(1, "1x1=1\n1x2=2\n1x3=3\n1x4=4\n1x5=5\n1x6=6\n1x7=7\n1x8=8\n1x9=9\n1x10=10\n1x11=11\n1x12=12", TestName = "AS09_MultiplicationTable_One", Description = "Multiplication table for 1")]
        [TestCase(5, "5x1=5\n5x2=10\n5x3=15\n5x4=20\n5x5=25\n5x6=30\n5x7=35\n5x8=40\n5x9=45\n5x10=50\n5x11=55\n5x12=60", TestName = "AS09_MultiplicationTable_Five", Description = "Multiplication table for 5")]
        [TestCase(0, "0x1=0\n0x2=0\n0x3=0\n0x4=0\n0x5=0\n0x6=0\n0x7=0\n0x8=0\n0x9=0\n0x10=0\n0x11=0\n0x12=0", TestName = "AS09_MultiplicationTable_Zero", Description = "Multiplication table for 0")]
        [TestCase(12, "12x1=12\n12x2=24\n12x3=36\n12x4=48\n12x5=60\n12x6=72\n12x7=84\n12x8=96\n12x9=108\n12x10=120\n12x11=132\n12x12=144", TestName = "AS09_MultiplicationTable_Twelve", Description = "Multiplication table for 12")]
        public void Test_AS09_MultiplicationTable_AllCases(int n, string expected)
        {
            // Act
            assignment.AS09_MultiplicationTable(n);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual(expected, output, $"AS09_MultiplicationTable with n={n}");
        }

        [Category("Assignment")]
        [TestCase(0, "ผลรวมของ n จาก 0 ถึง ${n} คือ ${sum}", TestName = "AS10_FindSummationFromOneToNUsingWhileLoop_Zero", Description = "Summation from 0 to 0")]
        [TestCase(1, "ผลรวมของ n จาก 0 ถึง ${n} คือ ${sum}", TestName = "AS10_FindSummationFromOneToNUsingWhileLoop_One", Description = "Summation from 0 to 1")]
        [TestCase(5, "ผลรวมของ n จาก 0 ถึง ${n} คือ ${sum}", TestName = "AS10_FindSummationFromOneToNUsingWhileLoop_Five", Description = "Summation from 0 to 5 should be 15")]
        [TestCase(10, "ผลรวมของ n จาก 0 ถึง ${n} คือ ${sum}", TestName = "AS10_FindSummationFromOneToNUsingWhileLoop_Ten", Description = "Summation from 0 to 10 should be 55")]
        [TestCase(100, "ผลรวมของ n จาก 0 ถึง ${n} คือ ${sum}", TestName = "AS10_FindSummationFromOneToNUsingWhileLoop_Hundred", Description = "Summation from 0 to 100 should be 5050")]
        public void Test_AS10_FindSummationFromOneToNUsingWhileLoop_AllCases(int n, string expectedTemplate)
        {
            // Calculate expected sum: sum = 0 + 1 + 2 + ... + n = n*(n+1)/2
            int expectedSum = n * (n + 1) / 2;
            string expected = $"ผลรวมของ n จาก 0 ถึง {n} คือ {expectedSum}";

            // Act
            assignment.AS10_FindSummationFromZeroToNUsingWhileLoop(n);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual(expected, output);
        }

        [Category("Assignment")]
        [TestCase(new int[] { 100 }, TestName = "AS11_SpawnEnemies_SingleEnemy", Description = "Spawn single enemy at position x=1")]
        [TestCase(new int[] { 50, 75 }, TestName = "AS11_SpawnEnemies_TwoEnemies", Description = "Spawn two enemies at positions x=1,2")]
        [TestCase(new int[] { 25, 50, 75, 100 }, TestName = "AS11_SpawnEnemies_FourEnemies", Description = "Spawn four enemies at positions x=1,2,3,4")]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, TestName = "AS11_SpawnEnemies_SixEnemies", Description = "Spawn six enemies at positions x=1,2,3,4,5,6")]
        public void Test_AS11_SpawnEnemies_AllCases(int[] enemyHPs)
        {
            // Arrange
            GameObject enemyPrefab = new("EnemyPrefab");

            // Act
            assignment.AS11_SpawnEnemies(enemyHPs, enemyPrefab);
            string output = AssignmentDebugConsole.GetOutput();

            // Build expected output
            string[] expectedLines = new string[enemyHPs.Length];
            for (int i = 0; i < enemyHPs.Length; i++)
            {
                float expectedX = i + 1;
                expectedLines[i] = $"new enemy at position x = {expectedX}";
            }
            string expected = string.Join("\n", expectedLines);

            // Assert
            TestUtils.AssertMultilineEqual(expected, output);

            // Clean up
            UnityEngine.Object.DestroyImmediate(enemyPrefab);
        }

        [Category("Assignment")]
        [UnityTest]
        public IEnumerator Test_AS12_CountTime_ZeroSecond()
        {
            yield return internal_test_Test_AS12_CountTime(0.0f);
        }
        [Category("Assignment")]
        [UnityTest]
        public IEnumerator Test_AS12_CountTime_OneSecond()
        {
            yield return internal_test_Test_AS12_CountTime(1.0f);
        }
        [Category("Assignment")]
        [UnityTest]
        public IEnumerator Test_AS12_CountTime_OnePointFiveSecond()
        {
            yield return internal_test_Test_AS12_CountTime(1.5f);
        }

        private IEnumerator internal_test_Test_AS12_CountTime(float countTime)
        {
            yield return assignment.AS12_CountTime(countTime);

            // Act
            string output = AssignmentDebugConsole.GetOutput();
            var lines = output.Trim().Split('\n');
            var lastLine = lines[^1];
            Assert.IsTrue(lastLine.Contains($"End timer :"), $"Expected 'End timer :' in last line but got: {lastLine}");
            var actualEndTimeStr = lastLine.Split(':').Last().Trim();
            Assert.IsTrue(float.TryParse(actualEndTimeStr, out float actualEndTime), $"Expected valid float after 'End timer :' but got: {actualEndTimeStr}");
            Assert.IsTrue(actualEndTime >= countTime, $"Expected End Timer >= {countTime} but got {actualEndTime}");
        }

        [Category("Assignment")]
        [TestCase(new string[] { "0", "1", "2" }, 3, 3, TestName = "AS02_NestedLoopForCreate2DMap_3x3", Description = "Create 3x3 map with 3 floor tiles")]
        [TestCase(new string[] { "0", "1" }, 2, 2, TestName = "AS02_NestedLoopForCreate2DMap_2x2", Description = "Create 2x2 map with 2 floor tiles")]
        [TestCase(new string[] { "0", "1", "2" }, 5, 2, TestName = "AS02_NestedLoopForCreate2DMap_5x2", Description = "Create 5x2 map with 3 floor tiles")]
        [TestCase(new string[] { "0" }, 4, 1, TestName = "AS02_NestedLoopForCreate2DMap_4x1_SingleTile", Description = "Create 4x1 map with single floor tile")]
        public void Test_AS02_NestedLoopForCreate2DMap_AllCases(string[] tileNames, int columns, int rows)
        {
            // Arrange
            GameObject[] floorTiles = new GameObject[tileNames.Length];
            for (int i = 0; i < tileNames.Length; i++)
            {
                floorTiles[i] = new GameObject(tileNames[i]);
            }

            // Set a fixed random seed for predictable testing
            UnityEngine.Random.InitState(42);

            // Act
            assignment.AS02_NestedLoopForCreate2DMap(floorTiles, columns, rows);
            // Clean up the floor tiles ...
            foreach (GameObject tile in floorTiles)
            {
                UnityEngine.Object.DestroyImmediate(tile);
            }

            // Assert - get all game objects in scene
            var allTiles = GameObject.FindObjectsByType<Transform>(FindObjectsSortMode.None);
            allTiles = allTiles.Where(t => t.name.StartsWith("[")).ToArray();
            Assert.AreEqual(columns * rows, allTiles.Length);
            for (int i = 0; i < allTiles.Length; i++)
            {
                var pos = allTiles[i].gameObject.transform.position;
                var expectedName = $"[{(int)pos.x}:{(int)pos.y}]";
                Assert.IsTrue(allTiles[i].gameObject.name.Contains(expectedName), $"Tile at index {i} has unexpected name {allTiles[i].gameObject.name}, it should be {expectedName}");
            }

            // Clean up created tiles
            foreach (var tile in allTiles)
            {
                UnityEngine.Object.DestroyImmediate(tile.gameObject);
            }
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS03_NestedLoopForMakingWallAround_5x3()
        {
            // Arrange
            GameObject wall = new("*");
            int columns = 5;
            int rows = 3;

            // Act
            assignment.AS03_NestedLoopForMakingWallAround(wall, columns, rows);

            // remove wall to avoid confusion between testcase's generated object and actual object
            UnityEngine.Object.DestroyImmediate(wall);

            // Assert - get all game objects in scene
            var allWall = GameObject.FindObjectsByType<Transform>(FindObjectsSortMode.None);
            allWall = allWall.Where(t => t.name.StartsWith("[")).ToArray();
            Assert.AreEqual((2 * (columns + rows)) - 4, allWall.Length);
            for (int i = 0; i < allWall.Length; i++)
            {
                var pos = allWall[i].gameObject.transform.position;
                var expectedName = $"[{(int)pos.x}:{(int)pos.y}]";
                Assert.IsTrue(allWall[i].gameObject.name.Contains(expectedName), $"Wall at index {i} has unexpected name {allWall[i].gameObject.name}, it should be {expectedName}");
            }

            // Clean up created tiles
            foreach (var tile in allWall)
            {
                UnityEngine.Object.DestroyImmediate(tile.gameObject);
            }
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS13_SumOfNumbersInRow_Row0()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            // Act
            assignment.AS13_SumOfNumbersInRow(matrix, 0);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual("6", output);
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS13_SumOfNumbersInRow_Row1()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            // Act
            assignment.AS13_SumOfNumbersInRow(matrix, 1);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual("15", output);
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS13_SumOfNumbersInRow_Row2()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            // Act
            assignment.AS13_SumOfNumbersInRow(matrix, 2);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual("24", output);
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS14_SumOfNumbersInColumn_Col0()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            // Act
            assignment.AS14_SumOfNumbersInColumn(matrix, 0);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual("12", output);
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS14_SumOfNumbersInColumn_Col1()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            // Act
            assignment.AS14_SumOfNumbersInColumn(matrix, 1);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual("15", output);
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS14_SumOfNumbersInColumn_Col2()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            // Act
            assignment.AS14_SumOfNumbersInColumn(matrix, 2);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual("18", output);
        }

        [Category("Assignment")]
        [TestCase(1, "*", TestName = "AS15_MakeTheTriangle_Size1", Description = "Triangle with size 1")]
        [TestCase(3, "*\n**\n***", TestName = "AS15_MakeTheTriangle_Size3", Description = "Triangle with size 3")]
        [TestCase(5, "*\n**\n***\n****\n*****", TestName = "AS15_MakeTheTriangle_Size5", Description = "Triangle with size 5")]
        [TestCase(7, "*\n**\n***\n****\n*****\n******\n*******", TestName = "AS15_MakeTheTriangle_Size7", Description = "Triangle with size 7")]
        public void Test_AS15_MakeTheTriangle_AllCases(int size, string expected)
        {
            // Act
            assignment.AS15_MakeTheTriangle(size);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual(expected, output);
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS16_MultiplicationTableOf_2_3_and_4()
        {
            // Act
            assignment.AS16_MultiplicationTableOf_2_3_and_4();
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            string expected = @"2 x 1 = 2	3 x 1 = 3	4 x 1 = 4
2 x 2 = 4	3 x 2 = 6	4 x 2 = 8
2 x 3 = 6	3 x 3 = 9	4 x 3 = 12
2 x 4 = 8	3 x 4 = 12	4 x 4 = 16
2 x 5 = 10	3 x 5 = 15	4 x 5 = 20
2 x 6 = 12	3 x 6 = 18	4 x 6 = 24
2 x 7 = 14	3 x 7 = 21	4 x 7 = 28
2 x 8 = 16	3 x 8 = 24	4 x 8 = 32
2 x 9 = 18	3 x 9 = 27	4 x 9 = 36
2 x 10 = 20	3 x 10 = 30	4 x 10 = 40
2 x 11 = 22	3 x 11 = 33	4 x 11 = 44
2 x 12 = 24	3 x 12 = 36	4 x 12 = 48";

            TestUtils.AssertMultilineEqual(expected, output);
        }

        [Category("Extra")]
        [TestCase("___,___,___", "X", 0, 0, "-------------\n| X |   |   |\n-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n\n>> Continue", TestName = "EX01_ValidMove_FirstMove")]
        [TestCase("___,___,___", "O", 1, 1, "-------------\n|   |   |   |\n-------------\n|   | O |   |\n-------------\n|   |   |   |\n-------------\n\n>> Continue", TestName = "EX01_ValidMove_Center")]
        [TestCase("___,___,___", "X", 2, 2, "-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n|   |   | X |\n-------------\n\n>> Continue", TestName = "EX01_ValidMove_BottomRight")]

        // Row wins - all three rows
        [TestCase("XX_,OO_,___", "X", 0, 2, "-------------\n| X | X | X |\n-------------\n| O | O |   |\n-------------\n|   |   |   |\n-------------\n\n>> X wins!", TestName = "EX01_RowWin_TopRow")]
        [TestCase("OO_,XX_,___", "X", 1, 2, "-------------\n| O | O |   |\n-------------\n| X | X | X |\n-------------\n|   |   |   |\n-------------\n\n>> X wins!", TestName = "EX01_RowWin_MiddleRow")]
        [TestCase("OOX,X__,OO_", "O", 2, 2, "-------------\n| O | O | X |\n-------------\n| X |   |   |\n-------------\n| O | O | O |\n-------------\n\n>> O wins!", TestName = "EX01_RowWin_BottomRow")]

        // Column wins - all three columns
        [TestCase("X__,X__,___", "X", 2, 0, "-------------\n| X |   |   |\n-------------\n| X |   |   |\n-------------\n| X |   |   |\n-------------\n\n>> X wins!", TestName = "EX01_ColumnWin_LeftColumn")]
        [TestCase("XO_,_O_,X__", "O", 2, 1, "-------------\n| X | O |   |\n-------------\n|   | O |   |\n-------------\n| X | O |   |\n-------------\n\n>> O wins!", TestName = "EX01_ColumnWin_MiddleColumn")]
        [TestCase("__X,O_X,O__", "X", 2, 2, "-------------\n|   |   | X |\n-------------\n| O |   | X |\n-------------\n| O |   | X |\n-------------\n\n>> X wins!", TestName = "EX01_ColumnWin_RightColumn")]

        // Diagonal wins
        [TestCase("O_X,_O_,___", "O", 2, 2, "-------------\n| O |   | X |\n-------------\n|   | O |   |\n-------------\n|   |   | O |\n-------------\n\n>> O wins!", TestName = "EX01_DiagonalWin_TopLeftBottomRight")]
        [TestCase("__X,_X_,___", "X", 2, 0, "-------------\n|   |   | X |\n-------------\n|   | X |   |\n-------------\n| X |   |   |\n-------------\n\n>> X wins!", TestName = "EX01_DiagonalWin_TopRightBottomLeft")]

        // Draw scenarios
        [TestCase("XOX,OXO,OX_", "O", 2, 2, "-------------\n| X | O | X |\n-------------\n| O | X | O |\n-------------\n| O | X | O |\n-------------\n\n>> Draw", TestName = "EX01_Draw_BoardFull")]
        [TestCase("XOO,OXX,XO_", "O", 2, 2, "-------------\n| X | O | O |\n-------------\n| O | X | X |\n-------------\n| X | O | O |\n-------------\n\n>> Draw", TestName = "EX01_Draw_NoWinner")]

        // Invalid moves
        [TestCase("X__,___,___", "O", 0, 0, "-------------\n| X |   |   |\n-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n\n>> Invalid move", TestName = "EX01_InvalidMove_PositionOccupied")]
        [TestCase("_X_,___,___", "O", 0, 1, "-------------\n|   | X |   |\n-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n\n>> Invalid move", TestName = "EX01_InvalidMove_OccupiedByX")]
        [TestCase("___,_O_,___", "X", 1, 1, "-------------\n|   |   |   |\n-------------\n|   | O |   |\n-------------\n|   |   |   |\n-------------\n\n>> Invalid move", TestName = "EX01_InvalidMove_OccupiedByO")]

        // Continue game scenarios
        [TestCase("X__,_O_,___", "X", 0, 1, "-------------\n| X | X |   |\n-------------\n|   | O |   |\n-------------\n|   |   |   |\n-------------\n\n>> Continue", TestName = "EX01_Continue_GameInProgress")]
        [TestCase("XO_,___,___", "O", 1, 0, "-------------\n| X | O |   |\n-------------\n| O |   |   |\n-------------\n|   |   |   |\n-------------\n\n>> Continue", TestName = "EX01_Continue_EarlyGame")]
        [TestCase("XOX,O__,X__", "O", 1, 1, "-------------\n| X | O | X |\n-------------\n| O | O |   |\n-------------\n| X |   |   |\n-------------\n\n>> Continue", TestName = "EX01_Continue_MidGame")]

        // Edge case - game won after the move
        [TestCase("XX_,OO_,___", "O", 1, 2, "-------------\n| X | X |   |\n-------------\n| O | O | O |\n-------------\n|   |   |   |\n-------------\n\n>> O wins!", TestName = "EX01_WinAfterMove_SecondRowWin")]
        [TestCase("XO_,XO_,X__", "X", 2, 1, "-------------\n| X | O |   |\n-------------\n| X | O |   |\n-------------\n| X | X |   |\n-------------\n\n>> X wins!", TestName = "EX01_WinAfterMove_ColumnWin")]

        // All corner moves
        [TestCase("___,___,___", "X", 0, 0, "-------------\n| X |   |   |\n-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n\n>> Continue", TestName = "EX01_ValidMove_TopLeft")]
        [TestCase("___,___,___", "O", 0, 2, "-------------\n|   |   | O |\n-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n\n>> Continue", TestName = "EX01_ValidMove_TopRight")]
        [TestCase("___,___,___", "X", 2, 0, "-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n| X |   |   |\n-------------\n\n>> Continue", TestName = "EX01_ValidMove_BottomLeft")]

        // Edge moves
        [TestCase("___,___,___", "O", 0, 1, "-------------\n|   | O |   |\n-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n\n>> Continue", TestName = "EX01_ValidMove_TopEdge")]
        [TestCase("___,___,___", "X", 1, 0, "-------------\n|   |   |   |\n-------------\n| X |   |   |\n-------------\n|   |   |   |\n-------------\n\n>> Continue", TestName = "EX01_ValidMove_LeftEdge")]
        [TestCase("___,___,___", "O", 1, 2, "-------------\n|   |   |   |\n-------------\n|   |   | O |\n-------------\n|   |   |   |\n-------------\n\n>> Continue", TestName = "EX01_ValidMove_RightEdge")]
        [TestCase("___,___,___", "X", 2, 1, "-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n|   | X |   |\n-------------\n\n>> Continue", TestName = "EX01_ValidMove_BottomEdge")]
        public void Test_EX_01_TicTacToeGame_TurnPlay(string boardString, string player, int row, int column, string expected)
        {
            // Convert string representation to 2D board (use '_' for empty spaces, ',' to separate rows)
            string[,] board = new string[3, 3];
            string[] rows = boardString.Split(',');

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    char c = rows[i][j];
                    board[i, j] = c == '_' ? " " : c.ToString();
                }
            }

            // Act
            assignment.EX_01_TicTacToeGame_TurnPlay(board, player, row, column);
            string output = AssignmentDebugConsole.GetOutput();

            // Assert
            TestUtils.AssertMultilineEqual(expected, output);
        }


        #endregion
    }

    public class TestUtils
    {
        internal static void AssertMultilineEqual(string expected, string actual, string message = null)
        {
            string normExpected = expected.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            string normActual = actual.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            if (string.IsNullOrEmpty(message))
            {
                message = $"Expected output:\n{normExpected}\n----\nActual output:\n{normActual}";
            }
            Assert.AreEqual(normExpected, normActual, message);
        }
    }
}
