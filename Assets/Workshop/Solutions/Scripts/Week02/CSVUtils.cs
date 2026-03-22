using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine; // *สำคัญ: ต้องเพิ่มบรรทัดนี้เพื่อใช้ Regex

public static class CSVUtils
{
    // ชื่อโฟลเดอร์หลักที่จะถูกสร้างขึ้นมาเก็บไฟล์ (แก้ชื่อตรงนี้ได้เลย)
    private static string _mainFolderName = "GameData";

    // ตัวแปรเก็บ Root Path (จะถูกกำหนดค่าอัตโนมัติใน Constructor)
    private static string _rootPath;

    static CSVUtils()
    {
    #if UNITY_EDITOR
            // ถ้าอยู่ใน Editor ให้เริ่มที่ Assets/
            _rootPath = Application.dataPath;
    #else
                // ถ้า Build แล้ว ให้ไปที่ PersistentDataPath
            _rootPath = Application.persistentDataPath;
    #endif
    }
    private static string BaseDirectory
    {
        get { return Path.Combine(_rootPath, _mainFolderName); }
    }

    // ฟังก์ชันสำหรับรับ 2D Array และ path ปลายทางเพื่อบันทึกไฟล์
    public static void Save2DArrayToCSV(string[,] data, string fileName)
    {
        // 1. ตรวจสอบว่ามีข้อมูลหรือไม่
        if (data == null || data.Length == 0)
        {
            Debug.LogError("Data is null or empty.");
            return;
        }
        string finalDirectory = Path.Combine(BaseDirectory);
        // ตรวจสอบและสร้างโฟลเดอร์
        if (!Directory.Exists(finalDirectory))
        {
            Directory.CreateDirectory(finalDirectory);
        }

        StringBuilder sb = new StringBuilder();// ใช้ StringBuilder เพื่อประสิทธิภาพในการสร้าง String
        int rows = data.GetLength(0); // จำนวนแถว
        int cols = data.GetLength(1); // จำนวนคอลัมน์

        // 2. วนลูปสร้างข้อมูล CSV
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // ดึงข้อมูลแต่ละช่อง
                string cell = data[i, j];

                // (Optional) จัดการกรณีข้อมูลมีเครื่องหมาย , หรือ " อยู่แล้ว (Escape Characters)
                if (cell.Contains(",") || cell.Contains("\"") || cell.Contains("\n"))
                {
                    cell = "\"" + cell.Replace("\"", "\"\"") + "\"";
                }

                sb.Append(cell);

                // ถ้าไม่ใช่คอลัมน์สุดท้าย ให้เติมลูกน้ำ (,)
                if (j < cols - 1)
                {
                    sb.Append(",");
                }
            }
            // จบแถวให้ขึ้นบรรทัดใหม่
            sb.AppendLine();
        }

        // 3. กำหนด path และบันทึกไฟล์
        string filePath = Path.Combine(finalDirectory, fileName + ".csv");

        try
        {
            File.WriteAllText(filePath, sb.ToString());
            Debug.Log($"บันทึก CSV สำเร็จที่: {filePath}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"เกิดข้อผิดพลาดในการบันทึก: {e.Message}");
        }
    }

    public static string[,] LoadCSV(string fileName)
    {
        string filePath = Path.Combine(BaseDirectory, fileName + ".csv");
        if (!File.Exists(filePath))
        {
            Debug.LogError($"ไม่พบไฟล์ที่: {filePath}");
            return null;
        }

        // อ่านข้อมูลทั้งหมดในไฟล์ออกมาเป็น String เดียว
        string fileContent = File.ReadAllText(filePath);

        return ParseCSV(fileContent);
    }

    // ฟังก์ชันสำหรับแปลง String เป็น 2D Array (แยกออกมาเพื่อให้ใช้กับ TextAsset ได้ด้วย)
    public static string[,] ParseCSV(string content)
    {
        // 1. แยกบรรทัด (รองรับทั้ง \r\n ของ Windows และ \n ของ Mac/Linux)
        string[] lines = content.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length == 0) return null;

        // คำนวณขนาดแถวและคอลัมน์ (นับจากแถวแรกเป็นหลัก)
        int rows = lines.Length;
        int cols = SplitCsvLine(lines[0]).Length;

        string[,] outputGrid = new string[rows, cols];

        // 2. วนลูปทีละบรรทัดเพื่อแกะข้อมูล
        for (int i = 0; i < rows; i++)
        {
            string[] rowData = SplitCsvLine(lines[i]);

            for (int j = 0; j < cols; j++)
            {
                if (j < rowData.Length)
                {
                    // ลบเครื่องหมาย " ที่เราเคยใส่กันไว้ (Unescape)
                    string cell = rowData[j];
                    cell = cell.TrimStart('"').TrimEnd('"').Replace("\"\"", "\"");
                    outputGrid[i, j] = cell;
                }
            }
        }

        return outputGrid;
    }

    // Helper: ฟังก์ชันแยกคอลัมน์โดยไม่ตัด , ที่อยู่ใน "..." (ใช้ Regex)
    private static string[] SplitCsvLine(string line)
    {
        // Regex นี้จะแยกด้วย , แต่จะข้าม , ที่อยู่ภายใต้เครื่องหมายฟันหนู
        string pattern = ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))";
        return Regex.Split(line, pattern);
    }
}
