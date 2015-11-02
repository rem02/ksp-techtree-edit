-------------------------------------------------------------
Note on all icons::::::::::::::::::::::::::::::::::::::::::::

All icons contained in the 'Icons' and 'SimpleIcons' folders are automatically loaded into the game and available to be placed on any custom partlist tab category or subcategory.

All icons are supposed to be 32x32 in png format. Icons in the 'Icons' and 'SimpleIcons' folder will be named after the myIcon.png template. In this case the name of the icon would be 'myIcon' and can be loaded by script with 'PartCategorizer.Instance.GetIcon("myIcon");' Note that PartCategorizer is only instantiated within the VAB/SPH.

Make sure to not use the '_' char or any other 'weird' chars in your icon names. 

-------------------------------------------------------------
The 'Icons' folder:::::::::::::::::::::::::::::::::::::::::::
This folder contains standard icons and are loaded in sets. for example.
myIcon.png
myIcon_selected.png

myIcon.png represents the 'normal' state of an icon, The one you see in the partlist toolbar when the filter/category/subcategory is not selected. Typically a dark colored icon on a transparent background.

myIcon_selected.png represent the 'selected' state of an icon. The one you see in the partlist toolbar when the filter/category/subcategory is not selected. Typically a light colored icon on a transparent background.

-------------------------------------------------------------
The 'SimpleIcons' folder:::::::::::::::::::::::::::::::::::::
This folder contains simple icons which are generated from white icons on a transparent background. 

