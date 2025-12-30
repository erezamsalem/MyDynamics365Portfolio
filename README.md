# Microsoft Dynamics 365 & Power Apps Development Portfolio

This repository contains custom development solutions for **Microsoft Dynamics 365 (CRM)** and **Power Platform**, demonstrating back-end logic through C# Plugins and Workflows, as well as front-end enhancements using JavaScript and Web Resources.

## 🚀 Technical Overview

### 1. Back-End Development (C# / .NET)
The solutions leverage the **Dynamics 365 SDK (XRM)** to implement complex business logic.

* **Plugins (MyPlugins project):**
    * **DuplicateCheck.cs:** Implements a sophisticated prevention logic using QueryExpression to validate records and prevent duplicate entries based on custom business rules.
    * **TaskCreate.cs:** Automates task creation based on specific entity lifecycle events.
    * **HelloWorld.cs:** A foundational plugin demonstrating event execution pipeline registration.
* **Custom Workflows (MyCustomWorkflows project):**
    * **GetTaxWorkflow.cs:** A custom workflow activity (CodeActivity) that extends standard out-of-the-box workflow capabilities to perform real-time tax calculations.

### 2. Front-End & Web Resources
Enhancing User Experience (UX) and User Interface (UI) within the Unified Interface.

* **JavaScript Client-Side Logic (contactscripts.js):**
    * Implements form event handlers (onLoad, onChange, onSave) using the Xrm object model.
* **HTML Web Resources:**
    * **DashboardWelcome.html:** A custom dashboard component providing a personalized entry point for users.
    * **Maps_contact.html:** Integration with external APIs to display visual data directly within a record form.

## 🛠️ Skills & Technologies
* **Languages:** C#, JavaScript (ES6+), HTML5, CSS3.
* **Frameworks:** .NET Framework 4.6.2+, XRM SDK.
* **Efficiency:** Developed using **AI-Assisted Development** (Google Gemini) for code optimization and debugging.

## 📂 Repository Structure
* /MyPlugins: C# Plugin source code.
* /MyCustomWorkflows: Custom Workflow Activity source code.
* contactscripts.js: Form scripts.
* DashboardWelcome.html & Maps_contact.html: Custom UI components.
