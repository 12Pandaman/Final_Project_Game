
# MEOW GARDEN

## Game Concept

Meow Garden is a Simulation + Casual game where players own a plant garden. The main goal is to sell plants to earn money for decorating, changing room items, cat colors, and acquiring rare and expensive plants. Players will plant, care for, and expand their garden, featuring item collection, decoration, and engaging quests.

## Core Features

-   **Item Pickup System and Item Placement System:** Players can grab and drag items such as plant pots, watering cans, scissors and place them in designated areas.
    
-   **Purchasing System:** Players use in-game resources (coins, gems) to buy plants, pots, room decorations.
    
-   **Tree Decay System:** Planted trees may decay if not properly cared for.
    
-   **Tree Selling System:** Players can sell grown plants for in-game currency (coins).
    
-   **Tree Growth System:** Plants will grow from seedlings to mature trees and may decay.
    
-   **Watering System:** Watering helps plants grow and prevents decay.
    
-   **Tree Decay and Cutting System:** Players must manage decayed plants.
    
-   **Interior Decoration System:** Players can decorate rooms with furniture and decorations.
    
-   **Coin and Gem System:**
    
    -   Coins are used to buy plants.
        
    -   Gems are used to buy decorations and speed up plant growth.
        

## Gameplay

Players will plant, water, nurture, and sell plants to earn coins. They can also decorate the room and collect rare plants. Players must also manage decayed plants.

## Monetization

The game uses a Freemium + In-app Purchases (IAP) model.

-   **In-app Purchases (IAP):** Players can buy gems to unlock items.
    
-   **Rewarded Ads:** Players can watch ads for in-game rewards.
    

## Unity 2D Game Build Instructions

### 1. Configure Build Settings

-   Open your Unity project.
-   Go to `File` > `Build Settings...`
-   In the `Build Settings` window:
    -   Select the desired `Platform` (e.g., `PC, Mac & Linux Standalone` or `Android` or `iOS`)
    -   If you haven't added the `Scene(s)` to be built, click `Add Open Scenes` to include the currently open scene(s) in the build.

### 2. Set Player Properties

-   In `Build Settings` click the `Player Settings...` button.
-   The `Inspector` panel will appear.
-   Configure the game's `Product Name`, `Company Name`, `Resolution`, `Orientation` (for mobile), etc. as needed.

### 3. Build the Game

-   Return to the `Build Settings` window.
-   Click `Build`
-   Choose the folder where you want to save the game files (you can create a new folder).
-   Wait for Unity to complete the build process.

### 4. Test the Built File

-   Once the build is complete, Unity will generate the game file (e.g., `.exe` for Windows, or `.APK` for Android).
-   Navigate to the folder where you saved the file and open it to test the game.

## Prototype

The prototype includes the following core features:

-   Cat and its components (Body, Tail)
    
-   Plant pots (POT1, POT2, POT3) and various plant types
    
-   Table, Shelf
    
-   UI (shop, settings, start screen)
    
-   Plant spawning system (SpawnPlant)
    
-   Items (sell point, scissors, watering can)
    
-   Coin management system
    

### Cat Components

-   Transform, Sprite Renderer, Animator, Player Controller (Script)
    
-   `Player Controller Script` controls the cat's blinking animation
    

### Plant (POT1) Components

-   Transform, Sprite Renderer, Rigidbody 2D, Tree Growth (Script), Object Click (Script), Drag Item (Script), Plant Size Adjust (Script), Capsule Collider 2D, Draggable (Script)
    
-   `Tree Growth Script` manages growth, decay, watering, and cutting of trees
    

### Key Scripts

-   `Tree Growth Script`:
    -   `WaterTree()`: Handles watering
        
    -   `BecomeRotten()`: Changes state to rotten plant
        
    -   `CutTree()`: Handles cutting rotten trees
        
    -   `RecoverTree()`: Recovers plant after cutting
        
-   `Object Click Script`: Detects clicks on objects
    
-   `Drag Item Script`: Enables dragging of objects
    
-   `Plant Size Adjust Script`: Adjusts plant size when colliding with shelves
    
-   `Draggable Script`: Manages dragging and dropping objects
    
-   `CoinManager`: Manages the coin system
    
-   `UIController`: Controls the UI
    
-   `PlantSpawner`: Spawns plants
    
-   `WateringCan`: Handles plant watering
    

แหล่งข้อมูล
