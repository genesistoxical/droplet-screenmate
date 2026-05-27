cd "src\DropletScreenmate\bin\"
ren "Release" "Droplet Screenmate"
"C:\Program Files\7-Zip\7z.exe" a "..\..\..\Droplet-Screenmate.zip" "Droplet Screenmate\" -r
ren "Droplet Screenmate" "Release"

cd "..\..\..\"
ren "template" "Skin Template"
"C:\Program Files\7-Zip\7z.exe" a "Skin-Template.zip" "Skin Template\" -r
ren "Skin Template" "template"