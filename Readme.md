
# MEOW GARDEN

##  แนวคิดเกม (Game Concept)

Meow Garden เป็นเกมแนว Simulation + Casual ที่ให้ผู้เล่นสวมบทบาทเป็นเจ้าของสวนต้นไม้ [cite: 11, 2, 3] โดยมีเป้าหมายหลักคือการขายต้นไม้เพื่อนำเงินมาตกแต่งสวน, เปลี่ยนของในห้อง, สีตัวแมว, และซื้อต้นไม้หายาก [cite: 11] ผู้เล่นจะได้ดูแลต้นไม้, ปลูก, และขยายสวน, พร้อมกับระบบสะสมของ, ตกแต่ง, และทำภารกิจต่างๆ [cite: 11]

##  ฟีเจอร์หลัก (Core Features)

* **ระบบจับสิ่งของ (Item Pickup System) และ ระบบวางไอเทม (Item Placement System):** ผู้เล่นสามารถจับและลากไอเทมต่างๆ เช่น กระถางต้นไม้, ที่รดน้ำต้นไม้, กรรไกร [cite: 11] และนำไปวางในพื้นที่ที่กำหนด [cite: 11]
   
* **ระบบการซื้อ (Purchasing System):** ผู้เล่นใช้ทรัพยากรในเกม (เหรียญ, เพชร) เพื่อซื้อต้นไม้, กระถาง, ของตกแต่งห้อง [cite: 12]
   
* **ระบบการเน่าของต้นไม้ (Tree Decay System):** ต้นไม้ที่ปลูกอาจเน่าเสียได้หากไม่ได้รับการดูแลที่เหมาะสม [cite: 12]
   
* **ระบบขายต้นไม้ (Tree Selling System):** ผู้เล่นสามารถขายต้นไม้ที่ปลูกแล้วเพื่อแลกเป็นเหรียญในเกม [cite: 13]
   
* **ระบบการเติบโตของต้นไม้ (Tree Growth System):** ต้นไม้จะเติบโตจากต้นกล้าไปเป็นต้นไม้โตเต็มวัยและอาจเน่าเสียได้ [cite: 13]
   
* **ระบบรดน้ำต้นไม้ (Watering System):** การรดน้ำช่วยให้ต้นไม้เติบโตและป้องกันการเน่าเสีย [cite: 14]
   
* **ระบบการตัดต้นไม้เน่า (Tree Decay and Cutting System):** ผู้เล่นต้องจัดการกับต้นไม้ที่เน่าเสีย [cite: 14]
   
* **ระบบตกแต่งภายในห้อง (Interior Decoration System):** ผู้เล่นสามารถตกแต่งห้องด้วยเฟอร์นิเจอร์และของตกแต่งต่างๆ [cite: 14]
   
* **ระบบเหรียญและเพชร:**
    * เหรียญใช้ซื้อต้นไม้ [cite: 15]
    * เพชรใช้ซื้อของตกแต่งและเร่งการเติบโตของต้นไม้ [cite: 15]

##  วิธีเล่น (Gameplay)

ผู้เล่นจะทำการปลูกต้นไม้, รดน้ำ, ดูแลให้เติบโต, และขายเพื่อรับเหรียญ [cite: 11, 13, 14] นอกจากนี้ยังสามารถตกแต่งห้องและสะสมต้นไม้หายากได้ [cite: 11, 14] ผู้เล่นต้องจัดการต้นไม้ที่เน่าเสียด้วย [cite: 14]

##  การสร้างรายได้ (Monetization)

เกมใช้รูปแบบ Freemium + In-app Purchases (IAP) [cite: 16]

* **In-app Purchases (IAP):** ผู้เล่นสามารถซื้อเพชรเพื่อปลดล็อกไอเทม [cite: 16]
   
* **Rewarded Ads:** ผู้เล่นสามารถดูโฆษณาเพื่อรับรางวัลในเกม [cite: 16]

##  วิธี Build เกม Unity 2D

### 1. ตั้งค่า Build Settings

* เปิดโปรเจกต์ Unity ของคุณขึ้นมา
* ไปที่เมนู `File` > `Build Settings...`
* ในหน้าต่าง `Build Settings`:
    * เลือก `Platform` ที่ต้องการ (เช่น `PC, Mac & Linux Standalone` หรือ `Android` หรือ `iOS`)
    * ถ้ายังไม่ได้เพิ่มซีน (`Scene`) ที่จะบิ้ว ให้กด `Add Open Scenes` เพื่อเพิ่มซีนที่เปิดอยู่ลงใน Build

### 2. ตั้งค่าคุณสมบัติของ Player

* ใน `Build Settings` กดที่ปุ่ม `Player Settings...`
* จะมีแถบ `Inspector` ปรากฏขึ้นด้านข้าง
* ตั้งค่าชื่อเกม (`Product Name`), Company Name, Resolution, Orientation (ถ้าเป็นมือถือ) ฯลฯ ตามที่ต้องการ

### 3. Build เกม

* กลับไปที่หน้าต่าง `Build Settings`
* กด `Build`
* เลือกโฟลเดอร์ที่ต้องการเก็บไฟล์เกม (สร้างโฟลเดอร์ใหม่ได้)
* รอให้ Unity ทำการ Build จนเสร็จ

### 4. ทดสอบไฟล์ที่ Build ออกมา

* เมื่อ Build เสร็จ Unity จะสร้างไฟล์เกมให้ เช่น `.exe` สำหรับ Windows, หรือ `.APK` สำหรับ Android
* ไปที่โฟลเดอร์ที่เก็บไฟล์ แล้วเปิดไฟล์เกมเพื่อลองเล่น

##  Prototype

Prototype นี้มีฟีเจอร์หลักดังนี้:

* แมวและส่วนประกอบ (ลำตัว, หาง) [cite: 56]
   
* กระถางต้นไม้ (POT1, POT2, POT3) และต้นไม้หลากหลายแบบ [cite: 56]
   
* โต๊ะ, ชั้นวางของ [cite: 56]
   
* UI (ร้านค้า, การตั้งค่า, หน้าจอเริ่มต้น) [cite: 56, 57]
   
* ระบบเกิดต้นไม้ (SpawnPlant) [cite: 57]
   
* ไอเทม (จุดขาย, กรรไกร, ที่รดน้ำ) [cite: 57]
   
* ระบบจัดการเหรียญ [cite: 57]

###   ส่วนประกอบของแมว (Cat Components)

* Transform, Sprite Renderer, Animator, Player Controller (Script) [cite: 58]
* `Player Controller Script` ควบคุมแอนิเมชันการกระพริบตา [cite: 58, 59]

###   ส่วนประกอบของต้นไม้ (POT1 Components)

* Transform, Sprite Renderer, Rigidbody 2D, Tree Growth (Script), Object Click (Script), Drag Item (Script), Plant Size Adjust (Script), Capsule Collider 2D, Draggable (Script) [cite: 62]
* `Tree Growth Script` จัดการการเติบโต, การเน่าเสีย, การรดน้ำ, และการตัดต้นไม้ [cite: 62, 63]

###   สคริปต์หลัก (Key Scripts)

* `Tree Growth Script`:
    * `WaterTree()`:  จัดการการรดน้ำ [cite: 64]
    * `BecomeRotten()`: เปลี่ยนสถานะเป็นต้นไม้เน่า [cite: 69]
    * `CutTree()`: จัดการการตัดต้นไม้เน่า [cite: 70]
    * `RecoverTree()`: ฟื้นฟูต้นไม้หลังการตัด [cite: 72]
* `Object Click Script`: ตรวจจับการคลิกบนวัตถุ [cite: 76]
* `Drag Item Script`: ทำให้วัตถุลากได้ [cite: 77]
* `Plant Size Adjust Script`: ปรับขนาดต้นไม้เมื่อชนกับชั้นวาง [cite: 79]
* `Draggable Script`: จัดการการลากและวางวัตถุ [cite: 63]
* `CoinManager`: จัดการระบบเหรียญ [cite: 81]
* `UIController`: ควบคุม UI [cite: 51]
* `PlantSpawner`: สร้างต้นไม้ [cite: 51]
* `WateringCan`:  จัดการการรดน้ำต้นไม้ [cite: 52]
