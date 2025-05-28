
# 🌿🐱 MEOW GARDEN 🪴💰

## About The Game

Meow Garden is a delightful **Simulation + Casual** game where players immerse themselves in managing their very own plant garden. The primary objective is to **grow and sell plants** to earn in-game currency. This currency can then be used to **decorate their cozy room**, change the **cat's appearance**, and acquire **rare and valuable plants** to expand their collection. The game emphasizes **item collection, decoration, and engaging quests**.

## ✨ Core Features

* **Interactive Item System:**
    * **Pickup & Placement:** Players can grab, drag, and strategically place items like plant pots, watering cans, and scissors within their garden space.
* **Dynamic Purchasing System:**
    * Acquire new plants, various pots, and charming room decorations using in-game **coins** and **gems**.
* **Realistic Plant Mechanics:**
    * **Growth Cycle:** Watch your plants grow from tiny seedlings to mature trees, progressing through various stages.
    * **Watering System:** Keep your plants hydrated to ensure healthy growth and prevent decay.
    * **Decay & Recovery:** Plants may decay if neglected, requiring players to manage and sometimes "cut" rotten trees.
* **Customizable Interior Decoration:**
    * Unleash your creativity by decorating your room with a wide array of furniture and decorative items.
* **Dual Currency System:**
    * **Coins:** Earned by selling plants, primarily used for purchasing new plants.
    * **Gems:** Used for acquiring premium decorations and speeding up plant growth.
* **Monetization Strategy:**
    * **In-app Purchases (IAP):** Purchase gems to unlock exclusive items and accelerate progress.
    * **Rewarded Ads:** Watch advertisements to earn valuable in-game rewards.

## 🎮 Gameplay Overview

Players will engage in the satisfying cycle of planting, watering, nurturing, and ultimately selling their plants to accumulate coins. Beyond gardening, they can personalize their living space through extensive decoration and strive to collect a diverse range of rare plants. Managing decayed plants adds a strategic layer to the gameplay, ensuring players remain attentive to their garden's well-being.

## 🚀 Unity 2D Game Build Instructions

Follow these steps to build the game from the Unity project:

### 1. Configure Build Settings

* Open your Unity project.
* Navigate to `File` > `Build Settings...`.
* In the `Build Settings` window:
    * Select your desired `Platform` (e.g., `PC, Mac & Linux Standalone`, `Android`, or `iOS`).
    * Ensure the `Scene(s)` to be built are added. If not, click `Add Open Scenes` to include the currently open scene(s).

### 2. Set Player Properties

* From the `Build Settings` window, click the `Player Settings...` button.
* In the `Inspector` panel, configure your game's `Product Name`, `Company Name`, `Resolution`, `Orientation` (for mobile builds), and other relevant properties.

### 3. Build the Game

* Return to the `Build Settings` window.
* Click `Build`.
* Choose a destination folder for your game files (you can create a new one).
* Wait for Unity to complete the build process.

### 4. Test the Built File

* Once the build is finished, Unity will generate the executable game file (e.g., `.exe` for Windows, `.APK` for Android).
* Locate the built file in your chosen folder and run it to test the game.

## ⚙️ Prototype Features (Detailed)

The current prototype showcases a robust set of features:

* **Cat Entity:** The main character, consisting of a Body and Tail, controlled by the `Player Controller` script (which also manages the cat's blinking animation).
* **Planting System:** Includes various plant pots (POT1, POT2, POT3) and diverse plant types.
* **Environment Elements:** Table and Shelf objects for placing items.
* **User Interface (UI):** Comprehensive UI for the shop, settings, and start screen.
* **Dynamic Plant Spawning:** The `PlantSpawner` system manages plant generation.
* **Interactive Items:** Implementations for sell points, scissors, and a functional watering can.
* **Currency Management:** Robust systems for managing both **Coins** and **Diamonds**.
    * **Diamond Management System:** Allows players to gain diamonds through purchases or by watching advertisements.
* **Advertisement Integration:** Utilizes `AdsInitializer` for Unity Ads initialization and `Interstitial` for displaying full-screen ads.
* **Object Switching:** The `ObjectSwitcher` allows an object to toggle between two GameObjects with a customizable delay.
* **Responsive Plant Sizing:** The `PlantSizeAdjust` script dynamically alters plant size and smoothly moves plants towards shelf contact points upon collision.
* **Tree Sale Tracking:** `TreeSaleManager` tracks the total number of trees sold, updating a UI text element with a subtle animation.
* **Sound Control:** `SoundManager` provides in-game volume controls, saving and loading user preferences.
* **Advanced Tree Growth Mechanics:**
    * `TreeGrowth.cs` / `TreeGrowthV2.cs` now includes blinking visual cues for unwatered plants.
    * Growth delays are precisely controlled for each growth stage.

### 🧑‍💻 Key Scripts Explained

* `Tree Growth Script` (`TreeGrowth.cs` / `TreeGrowthV2.cs`):
    * `WaterTree()`: Handles plant hydration, stopping any blinking animation.
    * `BecomeRotten()`: Transitions the plant to a rotten state.
    * `CutTree()`: Manages the cutting of rotten trees, including animation and sound effects.
    * `RecoverTree()`: Restores a plant after it's been cut, restarting its blinking cycle.
    * `StartBlinking()`: Initiates a visual blinking effect for the plant (e.g., when unwatered).
    * `StopBlinking()`: Halts the blinking effect, returning the plant to normal appearance.
    * `SetStageAlpha()`: Adjusts the transparency of the plant's current growth stage.
    * `growthDelays`: An array allowing for specific delay durations for each growth stage.
* `Object Click Script` (`ObjectClick.cs`): Detects mouse clicks on game objects.
* `Drag Item Script` (`DragItem.cs`): Enables dragging objects, ensuring the dragged object appears on top.
* `Plant Size Adjust Script` (`PlantSizeAdjust.cs`): Adjusts plant size and position based on shelf collisions, with smooth transitions.
* `Draggable Script` (`Draggable.cs` / `DraggableV2.cs`): Manages object dragging and dropping, handles plant selling into a "hole" layer, and awards coins based on plant growth stage.
* `CoinManager` (`CoinManager.cs`): Manles the game's coin economy, including adding, spending, and updating the coin UI.
* `UIController` (`UIController.cs`): Manages main UI panels (shop, settings, start screen), enabling their opening, closing, and game exit functionality.
* `UIMenu` (`UI Menu.cs`): Handles specific UI interactions for diamond purchases and rewarded ad viewing, including cooldowns.
* `PlantSpawner` (`PlantSpawner.cs`): Responsible for spawning plants at a designated point, managing purchase costs, and implementing a cooldown system for purchasing specific plant types. It also initializes the `PlantSizeAdjust` script's original scale.
* `WateringCan` (`WateringCan.cs`): Detects plants within its range and calls their `WaterTree()` method, controlling the watering animation.
* `AdsInitializer` (`AdsInitializer.cs`): Initializes the Unity Ads SDK for the target platform.
* `DiamondManager` (`DiamondManager.cs`): Manages the player's diamond currency, including methods for adding diamonds via purchases or ads.
* `Interstitial` (`Interstitial.cs`): Manages the loading and showing of interstitial (full-screen) advertisements.
* `ObjectSwitcher` (`ObjectSwitcher.cs`): Provides a utility to switch the active state between two GameObjects with a configurable delay.
* `PlayController` (`PlayController.cs`): Controls the cat's blinking animation with a random cooldown.
* `SoundManager` (`SoundManager.cs`): Manages in-game sound volume via a UI slider and persists the volume setting.
* `TreeSaleManager` (`TreeSaleManager.cs`): Tracks the total number of trees sold and updates a UI text element, including a visual scale and color animation upon each sale.

---

## 💻 GitHub Usage and Version Control

Leveraging GitHub in Unity game development is paramount for effective **collaboration**, meticulous **change tracking**, and maintaining an **organized codebase**. Here's a foundational guide:

### 1. Preparing Your Unity Project for GitHub

* **Create a New Repository on GitHub:**
    * Visit [github.com](https://github.com/) and log in.
    * Click the `+` sign in the top-right corner and select `New repository`.
    * Assign a descriptive name to your repository (e.g., `MeowGarden`) and choose whether it should be Public or Private.
    * **Crucial Step:** Select `Add a .gitignore` and search for `Unity`. This will generate a `.gitignore` file tailored for Unity projects, preventing unnecessary files (like build artifacts, `Library` folder content) from being committed. This is vital for keeping your repository lean and avoiding complex merge conflicts.
    * Click `Create repository`.

* **Configure `.gitignore` in Your Unity Project (if not already done via GitHub):**
    * If you created the `.gitignore` from GitHub, download it and place it directly in the **Root Folder** of your Unity project (where the `Assets`, `ProjectSettings` folders reside).
    * Alternatively, create a file named `.gitignore` in the Root Folder and add the following entries to exclude common Unity-generated files:
        ```gitignore
        # Unity generated files
        /[Ll]ibrary/
        /[Tt]emp/
        /[Oo]bj/
        /[Bb]uild/
        /[Bb]uilds/
        /Assets/AssetStoreTools/
        /Assets/Plugins/
        /Assets/Standard Assets/
        /Assets/ProCore/

        # Visual Studio
        .vs/
        *.csproj
        *.unityproj
        *.sln
        *.suo
        *.user
        *.userosf
        *.opendb
        *.VC.db

        # Rider
        .idea/
        *.iml

        # OS generated files
        .DS_Store
        .localized
        Thumbs.db
        ```
    * **Verify:** Double-check that your `.gitignore` correctly excludes Unity-generated folders like `Library`, `Temp`, `Obj`, and `Build` to prevent version control complications.

* **Install Git:**
    * If Git is not already installed on your system, download and install it from the official website: [git-scm.com](https://git-scm.com/).

### 2. Connecting Your Unity Project to GitHub

* **Open your Command Line or Git Bash** and navigate to your Unity project's **Root Folder**.
* **Initialize Git Repository:**
    ```bash
    git init
    ```
* **Add all relevant files to the Staging Area:**
    ```bash
    git add .
    ```
    (This command stages all files not ignored by `.gitignore`).
* **Make the First Commit:**
    ```bash
    git commit -m "Initial project setup and commit"
    ```
* **Add Remote Origin (Link to your GitHub Repository):**
    ```bash
    git remote add origin [https://github.com/your-username/MeowGarden.git](https://github.com/your-username/MeowGarden.git)
    ```
    (Replace `your-username/MeowGarden.git` with your actual GitHub repository URL).
* **Push your code to GitHub:**
    ```bash
    git push -u origin master
    ```
    (Use `main` instead of `master` if `main` is your default branch name).

### 3. Version Management During Development

* **Before starting work each time:**
    * **Pull Latest Changes:** If collaborating, always pull the most recent changes from GitHub to avoid conflicts:
        ```bash
        git pull origin master
        ```
* **While working (as you make changes to code or assets):**
    * Save your work periodically within Unity.
    * Once you complete a logical, functional segment of work, commit your changes:
        1.  **Add files to staging:**
            ```bash
            git add .
            ```
            (Alternatively, stage specific modified files, e.g., `git add Assets/Scripts/TreeGrowth.cs`).
        2.  **Commit changes:**
            ```bash
            git commit -m "A concise and clear description of your changes"
            ```
            (Examples: `"Implemented tree selling system and updated UI"` or `"Fixed bug where plants would not grow after watering"`).
        3.  **Push changes to GitHub:**
            ```bash
            git push origin master
            ```

### 4. Branching Strategy

Employing a branching strategy is vital for collaborative development and safely integrating new features without disrupting the stable main codebase:

* **`master` (or `main`) branch:** This serves as the primary branch, which should always contain code that is "production-ready" or "stable."
* **Feature branches:** When you begin developing a new feature or fixing a bug, create a new branch from `master`:
    ```bash
    git checkout -b feature/your-feature-name
    ```
    (Examples: `git checkout -b feature/diamond-system` or `git checkout -b bugfix/plant-decay`).
* **Work on the Feature branch:** All development for that specific feature or bug fix should occur on this dedicated branch.
* **Commit and Push on the Feature branch:** Regularly commit your work to your feature branch and push it to GitHub:
    ```bash
    git add .
    git commit -m "Added diamond purchase functionality"
    git push origin feature/diamond-system
    ```
* **Pull Request (PR):** Once your feature is complete and thoroughly tested, create a Pull Request on GitHub. This process allows teammates to review your code before it's merged into the `master` branch.
* **Merge:** After the Pull Request is approved and any feedback is addressed, proceed to merge the feature branch into `master`.

### 5. Frequently Used Git Commands

* `git status`: Shows the status of your working directory and staging area (e.g., modified, new, deleted files).
* `git diff`: Displays the differences between your working directory and the staging area, or between commits.
* `git log`: Shows a history of commits for the current branch.
* `git checkout [branch-name]`: Switches to a different branch.
* `git merge [branch-name]`: Integrates changes from a specified branch into your current branch.
* `git clone [URL]`: Creates a local copy of a remote Git repository.

### 6. Handling Large Files (Git LFS)

Unity projects often contain large binary asset files (like images, audio, 3D models) which Git is not optimized to handle efficiently. For these, you should use **Git Large File Storage (LFS)**:

* **Install Git LFS:**
    ```bash
    git lfs install
    ```
* **Track desired file types (from your project's Root Folder):**
    ```bash
    git lfs track "*.psd"
    git lfs track "*.png"
    git lfs track "*.jpg"
    git lfs track "*.wav"
    git lfs track "*.mp3"
    git lfs track "*.unity"  # Essential for Scene files
    git lfs track "*.prefab" # Essential for Prefab files
    ```
    (You can extend this list to include any other large asset file types relevant to your project).
* **Verify `.gitattributes`:** After running `git lfs track`, a `.gitattributes` file will be created or updated in your root directory. Ensure this file is also committed to your repository.
* **Commit and Push Normally:** Once Git LFS is configured, you can commit and push your large files as usual. Git LFS will handle the storage and versioning of these large files efficiently.

---
