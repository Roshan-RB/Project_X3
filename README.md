# **2D DSA VR Training Application**
*A Unity-based Virtual Reality (VR) training simulation for cerebral aneurysm detection using 2D Digital Subtraction Angiography (DSA) images.*

![VR Simulation Screenshot](path-to-image) *(Replace with actual image path from your repo)*

## **Table of Contents**
- [Overview](#overview)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Technical Details](#technical-details)
- [Evaluation & Feedback](#evaluation--feedback)
- [Future Work](#future-work)
- [Contributors](#contributors)
- [License](#license)

---

## **Overview**
This project is a **VR training simulation** that helps medical professionals enhance their understanding of **2D DSA images** for cerebral aneurysm identification. The application provides an **interactive 3D Circle of Willis model** in a **VR environment**, allowing users to **map 2D angiography images to 3D structures**.

It is built using:
- **Unity (XR Interaction Toolkit)**
- **SteamVR for VR input handling**
- **Custom shader-based angiography simulation**
- **HTC Vive or other VR-supported headsets**

---

## **Features**
✅ **Fully immersive VR environment**  
✅ **3D Circle of Willis with interactive rotation**  
✅ **Gamified training with levels and scoring**  
✅ **Custom shaders for realistic DSA angiography visualization**  
✅ **SteamVR & XR Toolkit integration**  
✅ **Real-time feedback for aneurysm identification**  
✅ **Expert-reviewed aneurysm modeling and placement**  

---

## **Installation**
### **Prerequisites**
- **Unity 2021.3+** *(with XR Plugin Management)*
- **SteamVR installed and running**
- **HTC Vive / Oculus Rift / Windows Mixed Reality headset**
- **Visual Studio 2019/2022** *(for script debugging)*

### **Setup Steps**
1. **Clone the Repository**
   ```sh
   git clone https://github.com/your-username/VR-DSA-Training.git
   cd VR-DSA-Training
   ```
2. **Open in Unity**
   - Launch **Unity Hub** → Open **VR-DSA-Training**  
   - Ensure **XR Plugin Management** is enabled for your VR device  
3. **Install Required Packages**
   - Open **Unity Package Manager** (`Window → Package Manager`)
   - Install:
     - **XR Interaction Toolkit**
     - **SteamVR Plugin**
     - **Post-processing stack (for angiography shaders)**
4. **Connect Your VR Headset**
   - Ensure **SteamVR** is running  
   - Open **Unity Play Mode** and test the VR simulation  

---

## **Usage**
1. **Launch the Training Scene**
2. **View the 2D DSA Image**
3. **Interact with the 3D Circle of Willis Model**
4. **Identify and Select Aneurysms**
5. **Receive Feedback on Accuracy**
6. **Advance Through Training Levels**

---

## **Project Structure**
```
VR-DSA-Training/
│── Assets/
│   ├── Models/        # 3D models (Circle of Willis, Aneurysms)
│   ├── Shaders/       # Custom angiography simulation shaders
│   ├── Scripts/       # Core Unity C# scripts for VR interaction
│   ├── Textures/      # UI elements and DSA images
│   ├── Scenes/        # Unity training levels and main scene
│── SteamVR/           # SteamVR Plugin integration files
│── XR-Interaction/    # XR Toolkit samples and scripts
│── README.md          # Project documentation
│── LICENSE            # License file
│── Project_X3.sln     # Visual Studio solution for Unity project
│── .gitignore         # Files ignored by Git
```

---

## **Technical Details**
- **VR Development:** Unity with **XR Interaction Toolkit**  
- **Rendering:** Custom **Fresnel-based shader** for angiography  
- **3D Modeling:** Blender-based **aneurysm and CoW modeling**  
- **Game Logic:** **C# scripts** for interaction & gamification  
- **User Interaction:** HTC Vive Controllers / XR Toolkit controls  

---

## **Evaluation & Feedback**
- **Expert Neurosurgeon Review:**  
  🔹 Suggested adding **aneurysms in more challenging areas**  
  🔹 Recommended **zoom feature** for improved DSA image analysis  
- **Usability Study (5 Participants):**  
  ✅ **High immersion & usability**  
  ✅ **Effective training environment for medical students**  
  🔸 **Navigation and UI refinements needed**  

---

## **Future Work**
🚀 **Enhanced Image Processing** – Improved 2D DSA image clarity in VR  
🚀 **Advanced Gamification** – Leaderboards, adaptive difficulty levels  
🚀 **Expanded Medical Cases** – More cerebrovascular conditions  
🚀 **Multi-User Support** – Medical team collaboration in VR  
🚀 **Haptic Feedback** – Future integration for **surgical training**  

---

## **Contributors**
👨‍💻 **Roshan Rayala Bhaskar** *(Developer & Researcher)*  
🎓 **Prof. Dr. Christian Hansen** *(Supervisor, Virtual and Augmented Reality Group, OVGU Magdeburg)*  
🩺 **Dr. Mareen Allgaier** *(Medical Advisor, Neuroradiology & Neurosurgery)*  

---

## **License**
This project is licensed under the **MIT License** – see the [LICENSE](LICENSE) file for details.

---

This README gives your project a **professional and structured** look, making it easy for anyone to understand and contribute. Let me know if you need any modifications! 🚀
