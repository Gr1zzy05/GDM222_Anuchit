# แบบทดสอบ Stack และ Queue

## Quiz Item 1: ความแตกต่างระหว่าง Stack และ Queue
**คำถาม:** อะไรคือความแตกต่างหลักระหว่าง Stack และ Queue?  
A) Stack ใช้สำหรับการจัดเก็บข้อมูลชั่วคราว Queue ใช้สำหรับการจัดเก็บถาวร  
B) Stack เป็น LIFO Queue เป็น FIFO  
C) Stack เร็วกว่า Queue  
D) Stack ใช้หน่วยความจำน้อยกว่า Queue  

**คำตอบที่ถูกต้อง:** B) Stack เป็น LIFO Queue เป็น FIFO  
**หมายเหตุ:** Stack (Last In First Out) ข้อมูลที่ใส่ล่าสุดออกก่อน Queue (First In First Out) ข้อมูลที่ใส่ก่อนออกก่อน

## Quiz Item 2: Operation พื้นฐานของ Stack
**คำถาม:** Operation ใดต่อไปนี้ไม่ใช่ operation พื้นฐานของ Stack?  
A) Push  
B) Pop  
C) Enqueue  
D) Peek  

**คำตอบที่ถูกต้อง:** C) Enqueue  
**หมายเหตุ:** Enqueue เป็น operation ของ Queue Push, Pop, Peek เป็น operation พื้นฐานของ Stack

## Quiz Item 3: Operation พื้นฐานของ Queue
**คำถาม:** Operation ใดต่อไปนี้ไม่ใช่ operation พื้นฐานของ Queue?  
A) Enqueue  
B) Dequeue  
C) Push  
D) Peek  

**คำตอบที่ถูกต้อง:** C) Push  
**หมายเหตุ:** Push เป็น operation ของ Stack Enqueue, Dequeue, Peek เป็น operation พื้นฐานของ Queue

## Quiz Item 4: การใช้งาน Stack ในเกม
**คำถาม:** Stack มักใช้ในเกมเพื่อวัตถุประสงค์ใด?  
A) จัดการ Event Queue  
B) Implement Undo/Redo System  
C) จัดการ Turn-based Combat  
D) จัดการ Network Messages  

**คำตอบที่ถูกต้อง:** B) Implement Undo/Redo System  
**หมายเหตุ:** Stack เหมาะสำหรับ Undo/Redo เพราะสามารถเก็บ Action ล่าสุดและเรียกคืนได้ตามลำดับย้อนกลับ

## Quiz Item 5: การใช้งาน Queue ในเกม
**คำถาม:** Queue มักใช้ในเกมเพื่อวัตถุประสงค์ใด?  
A) จัดการ Action History  
B) จัดการ Event Queue ใน Game Loop  
C) Implement Backtracking  
D) จัดการ Function Call Stack  

**คำตอบที่ถูกต้อง:** B) จัดการ Event Queue ใน Game Loop  
**หมายเหตุ:** Queue เหมาะสำหรับ Event Queue เพราะ Events ที่เกิดก่อนจะถูกประมวลผลก่อน

## Quiz Item 6: ความซับซ้อนของเวลาใน Stack Operations
**คำถาม:** Push และ Pop ใน Stack มีความซับซ้อนของเวลาเท่าไรโดยทั่วไป?  
A) O(1)  
B) O(log n)  
C) O(n)  
D) O(n log n)  

**คำตอบที่ถูกต้อง:** A) O(1)  
**หมายเหตุ:** Push และ Pop ใน Stack ที่ implement ด้วย Array หรือ Linked List มีความซับซ้อน O(1)

## Quiz Item 7: ความซับซ้อนของเวลาใน Queue Operations
**คำถาม:** Enqueue และ Dequeue ใน Queue มีความซับซ้อนของเวลาเท่าไรโดยทั่วไป?  
A) O(1)  
B) O(log n)  
C) O(n)  
D) O(n log n)  

**คำตอบที่ถูกต้อง:** A) O(1)  
**หมายเหตุ:** Enqueue และ Dequeue ใน Queue ที่ implement ด้วย Circular Array หรือ Linked List มีความซับซ้อน O(1)

## Quiz Item 8: การ Reverse String ด้วย Stack
**คำถาม:** การใช้ Stack ในการ Reverse String ทำงานอย่างไร?  
A) Push ทุก character แล้ว Pop ออกมา  
B) Enqueue ทุก character แล้ว Dequeue ออกมา  
C) ใช้ Peek เพื่อดู character สุดท้าย  
D) ใช้ Count เพื่อนับจำนวน character  

**คำตอบที่ถูกต้อง:** A) Push ทุก character แล้ว Pop ออกมา  
**หมายเหตุ:** การ Push character เข้า Stack แล้ว Pop ออกมาจะได้ลำดับย้อนกลับ ทำให้ String ถูก reverse

## Quiz Item 9: การตรวจสอบ Palindrome ด้วย Stack
**คำถาม:** การใช้ Stack ในการตรวจสอบ Palindrome ต้องทำอย่างไร?  
A) Push ครึ่งแรกของ String แล้วเปรียบเทียบกับ Pop  
B) Push ทั้ง String แล้ว Pop เปรียบเทียบกับ original  
C) ใช้ Queue แทน Stack  
D) ใช้ Peek เพื่อตรวจสอบ  

**คำตอบที่ถูกต้อง:** B) Push ทั้ง String แล้ว Pop เปรียบเทียบกับ original  
**หมายเหตุ:** การสร้าง reversed String ด้วย Stack แล้วเปรียบเทียบกับ original จะบอกได้ว่าเป็น Palindrome หรือไม่

## Quiz Item 10: การตรวจสอบ Balanced Parentheses ด้วย Stack
**คำถาม:** การใช้ Stack ในการตรวจสอบ Balanced Parentheses ทำงานอย่างไร?  
A) Push opening brackets Pop เมื่อพบ closing และตรวจสอบ matching  
B) Enqueue opening brackets Dequeue เมื่อพบ closing  
C) ใช้ Count เพื่อนับจำนวน brackets  
D) ใช้ Peek เพื่อดู bracket สุดท้าย  

**คำตอบที่ถูกต้อง:** A) Push opening brackets Pop เมื่อพบ closing และตรวจสอบ matching  
**หมายเหตุ:** Stack ช่วยตรวจสอบว่า opening และ closing brackets 匹配 และไม่มี leftover ใน Stack