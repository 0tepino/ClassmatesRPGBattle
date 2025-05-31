GAME DESCRIPTION:
-----------------
A turn-based RPG battle simulator featuring 5 unique classroom warriors, inspired by Mobile Legends hero name skills. 
Players select characters, enter custom names, and engage in strategic combat using keyboard controls.

TECHNICAL ARCHITECTURE:
-----------------------
- Windows Forms application with double-buffered graphics
- Custom control rendering for smooth animations
- Async/await for non-blocking animations
- Timer-based animation system
- Comprehensive game state management

CHARACTER DESCRIPTIONS:
-----------------------
All characters have 100 HP but different attack patterns:

NEMO - The Precision Striker
- 50% chance for high damage (12-19), else moderate (5-9)
- Attacks: Ultimate Snipe, Swan Song, Blazing Finale, Death Sonata
- Color: Deep Sky Blue (RGB: 0, 100, 139)

ONAY - The Divine Warrior  
- 50% chance for heavy damage (15-23), else standard (5-11)
- Attacks: Divine Judgment, Phantom Shuriken, Implosion, Sacred Hammer  
- Color: Dark Goldenrod (RGB: 184, 134, 11)

MOMO - The Berserker
- 40% chance for devastating damage (15-24), else weak (5-6)
- Attacks: Destruction Rush, Circling Eagle, Blood Ode, Abysm Strike
- Color: Dark Red (RGB: 139, 0, 0)

JA - The Consistent Mage
- 60% chance for reliable damage (14-16), else moderate (5-10)
- Attacks: Super Magic, Spatial Migration, Violet Requiem, Energy Wave
- Color: Dark Slate Blue (RGB: 72, 61, 139)

LILET - The Versatile Fighter
- 40% chance for varied damage (11-21), else standard (5-10)
- Attacks: Dragon Flurry, Spear Strike, Sword Spike, Shadowblade Slaughter
- Color: Forest Green (RGB: 34, 139, 34)

GAME FEATURES:
--------------
1. ANIMATED COMBAT SYSTEM:
   - Character movement towards center during attacks
   - Sword swing animations for attacking
   - Hit effect animations (red glow + sparks)
   - Smooth return animations after attacks

2. VISUAL FEEDBACK:
   - Color-coded health bars (green > orange > red)
   - Turn indicators showing current player
   - Attack name displays during combat
   - Character color changes when low health

3. INPUT SYSTEM:
   - Player 1: SPACE or ENTER to attack
   - Player 2: A/S/D or Arrow Keys to attack
   - Input disabled during animations
   - Visual feedback for invalid inputs

4. BATTLE LOG:
   - Detailed record of all actions
   - Automatic scrolling to newest entries
   - Fixed-width font for alignment
   - Black background with white text

OOP IMPLEMENTATION:
-------------------
1. CORE CLASS STRUCTURE:
   - Abstract ClassroomWarrior base class
   - 5 concrete character implementations
   - Nested HealthBar custom control
   - Form classes for UI management

2. POLYMORPHISM:
   - Abstract Attack() and GetAttackName() methods
   - Character-specific damage calculations
   - Unique attack name pools per character

3. ENCAPSULATION:
   - Health clamping in property setter
   - Private random generators per character
   - Protected fields with public properties

4. ABSTRACTION:
   - Complex animation logic hidden behind simple method calls
   - Battle mechanics abstracted through clean interfaces
   - UI updates triggered by property changes

HOW TO PLAY:
------------
1. Select characters for both players
2. Enter names for both warriors
3. Click "START BATTLE!"
4. Player 1 attacks with SPACE/ENTER
5. Player 2 attacks with A/S/D/Arrow Keys
6. Watch the animated combat unfold
7. Battle continues until one warrior is defeated

CHALLENGES WE FACED:
-----------------------------------
1. LIMITED GAME DEVELOPMENT EXPERIENCE:
   - Challenge: First attempt at creating a game with animations and complex state management

2. ANIMATION SYSTEM DESIGN:
   - Challenge: Creating smooth animations without game engine support

3. VISUAL FEEDBACK IMPLEMENTATION:
   - Challenge: Making combat feel impactful without complex assets

4. GAME STATE MANAGEMENT:
   - Challenge: Preventing actions during animations while keeping UI responsive

5. CHARACTER BALANCING:
   - Challenge: Making each character unique but fair
