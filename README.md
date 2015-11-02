TED - KSP Tech Tree Editor - v0.2.4 Alpha
=================

Description
-----
An external, visual, point-and-click tool for editing and creating custom tech trees for Kerbal Space Program. The tool generates the text files used by *other* plugins, such as **TechManager** and **ATC**, hence one of these plugins are required for the trees to get loaded into the game itself.

Installation
-----
1. Unpack the archive in any location.
2. Launch TED-v[x.x].exe

Troubleshooting
-----
- You may be missing the .NET 4.5 framework. [Download and install from here](http://www.microsoft.com/en-us/download/confirmation.aspx?id=42643).

Usage
-----

1. **Startup**
  1. Start by selecting your KSP root folder, usually that's `C:\Program Files (x86)\Steam\SteamApps\common\Kerbal Space Program` but it may differ on your machine
2. **Load**
  2. *(Option 1)* Load an existing tech tree file (*.cfg*)
     - **Make sure you select the right format!**
     - For *TechManager* files use **Load TechManager Tree..**
     - For *ATC* files use **Load ATC Tree...**
  3. *(Option 2)* Create a new tech tree from scratch
     - Click on **New Blank Tree**
  4. *(Option 4)* Create a new tech tree starting from the Stock tech
     - Click on **New Stock Tree**

3. **Edit**
   1. Click on a node to edit it's values on the right (the sidebar).
   2. Move nodes around by draging.
   2. Add or remove parts from nodes at the bottom of the sidebar.
      * The top section indicates the parts assigned to that node.
      * The bottom section is a list of all detected parts in your KSP folder.
   3. Press `DELETE` to delete a node.
   4. Press `SHIFT+CLICK` to add a blank node on an empty space
   5. Select a node and press `CTRL+CLICK` on *another* node to link or unlink parents.
      - The little cirlce indicates the direction of the link.

4. **Save**
   1. Click **Save** at the top menu to save your file in **TechManager** format.
   2. Click **Save (ATC)** to save in **ATC** format.
   3. You will be prompted to select the filename and where to save.
   4. **NOTE:** It does *not* matter what file the tree was when you loaded, you can save in any format (this can be used to convert a tree from one format to another!)

5. **Load into KSP**
   1. **Follow the corresponding mod instructions!**
   2. This has nothing to do with TED, TED only generates the files.
   3. Again, see the corresponding mods instructions: [TechManager](http://forum.kerbalspaceprogram.com/threads/98293-0-25-TechManager-Version-1-1), [ATC](http://forum.kerbalspaceprogram.com/threads/93759-0-25-ATC-Alternative-Tree-Configurator-15-10-V0-5-1)

Known Issues
-----

- It looks terrible! UI work has not properly started yet, this is a "skin-less" version of the application.
- Lots and lots of bugs. Yes, this is early alpha, there are LOTS of bugs. Please report and I'll fix as soon as I can.

Changelog
-----
### v0.2.4 Alpha (2015-01-18)
* TechManager v1.5 support (hideIfNoBranch support)
* Added debug logging - Output will be stored in output.log next to the .exe
* Added node snapping - (Finally!)
* Now shows "[Modname] Part Name - (Original TechRequired: Original Cost)" in parts list
* TechId is now editable and not auto-generated
* Fixes to TechManager file saver - Now uses ModuleManager config
* This should mean more consistent part allocation when using many mods that edit tech requirements

### v0.2.3 Alpha (2014-11-15)
* TechManager v1.3 support
* No longer supports TreeLoader, TreeLoader has discontinued
* Adding and removing parts from nodes should make more sense now as the list only shows parts that haven't already been assigned to a node

### v0.2.2 Alpha 2 (2014-11-04)
* Fix bug when loading parts from KSP folder

### v0.2.1 Alpha 2 (2014-11-02)

* Fix UI overlaying issue by forcing ZLayer of nodes to stay between -1 and -24
* Expanded workspace area slightly to accomodate larger trees (still not 1 on 1 with KSP though)

### v0.2 Alpha 2 (2014-11-02)

   \[[Milestone - Alpha 1](https://github.com/jcalero/ksp-techtree-edit/issues?q=milestone%3A%22Basic+Features+v0.1%22+is%3Aclosed)\]\[[Milestone - Alpha 2](https://github.com/jcalero/ksp-techtree-edit/issues?q=milestone%3A%22First+Release+-+Alpha+v0.2%22+is%3Aclosed)\] - Total of 15 closed issues

* First public release
