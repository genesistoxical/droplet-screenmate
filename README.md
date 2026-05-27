<p align="center"></p>
<p align="center"><a href="#"><img width="115px" src="docs/assets/Logo-115px.png" align="center" alt="Droplet Screenmate"/></a></p>
<h1 align="center">Droplet Screenmate</h1>
<p align="center">Droplet Screenmate, a pet running on your desktop.</p>

<p align="center">
 <a href="LICENSE"><img alt="License" src="https://img.shields.io/badge/License-MIT-A62323?style=flat-square&labelColor=343B45"/></a>
 <a href="https://github.com/genesistoxical/droplet-screenmate/releases/latest"><img src="https://img.shields.io/github/v/release/genesistoxical/droplet-screenmate.svg?color=A62323&label=Release&style=flat-square&labelColor=343B45"/></a>
 <a href="#"><img alt="NET" src="https://img.shields.io/badge/.NET_Framework-4.8-A62323?style=flat-square&labelColor=343B45"/></a> 
</p>

<p align="center">
<a href="README.md">English</a> :speech_balloon: <a href="README-es.md">Español</a>
</p>

## Features
* Your pet detects the taskbar and walks over it.
* You can drag and drop it anywhere on your desktop.
* Different animations for walking, stopping, sitting, and dragging.
* Choose from 8 default skins.
* Options to change its walking speed.
* Option to start automatically when you turn on your PC.
* Create your own skin using the templates (PNG and editable).

## Preview
<a href="#"><img src="docs/assets/Droplet-Screenmate.png"/></a>

## Usage
All you have to do is run `Droplet Screenmate.exe` and you're ready to go!! Your pet will appear walking on your taskbar. It can also stop, sit, and you can drag and drop it to change its position. It even has a different animation while you're dragging it.

<br>

Go to the icon in your system tray and right-click it:

**Options** will open the pet options window:

* In the _Skin_ section, just open the dropdown menu, choose one and click OK. That's it!
* To change how fast it walks and how long its strides are, go to _Config_ section:
  * **Velocity**: The higher the value, the faster it moves.
  * **Step Size**: The lower the value, the shorter the steps.
  
  You can use different combinations when creating your own custom skin, depending on whether it crawls, jumps, etc.

**Run at Startup**: Enable this option to launch the application when you turn on your PC. You can also disable it at any time. IMPORTANT: Once you enable this option, if you move `Droplet Screenmate` folder it will no longer launch with your PC, even if it's checked. Just disable the option and enable it again.

**About**: MIT license, credits, and repository link.

**Exit**: Close the application. However, when you open it again, your settings and skin will remain the same since everything is saved in _Config.ini_ files.

<br>
<a href="#"><img src="docs/assets/Droplet-Screenmate.gif"/></a>

## Create your own pet

It's very simple, you just need to edit or create 5 images. Download and unzip the template ZIP file, you'll find some folders called:
* Default - PNG, SVG, PSD y AF (Affinity).
* Outline - PNG, SVG y PSD

_Default_ is ready to be decorated and _Outline_ is just the border with eyes. Choose the style and format you need to start editing; you can even create any pet design as long as the dimensions are 128 ⨯ 128 px.

Once you've edited **drag**, **idle**, **idleAlt**, **walk-1** and **walk-2**, you'll need to save each one as PNG (without renaming them) in a new folder, for example "My Pet". Then copy `onfig.ini` file and paste it into the folder you just created.

You can edit your new skin settings in the app and the changes will be saved automatically. Remember that you can share your skin with anyone once you're finished.

<a href="#"><img src="docs/assets/Template.png"/></a>

<br></br>

## Config
Primary `Config.ini` file stores which skin was last used.

~~~
[Options]
Skin = Mushroom
~~~

Skin's `Config.ini` file stores its own configuration.

~~~
[Config]
Velocity = 0.2
Step size = 12
~~~

## Contributing
* If you make comments in the code, preferably in Spanish, please.
* Variable names must be in English.
* If you open an **Issue**, it can be in English o Spanish.
* **Pull request** in English, in the description you can add details in English or Spanish.
* Due to the simplicity and optimization required in this application, no translations will be made.

## License
**MIT License**

Copyright (c) 2026 Génesis Toxical ([read here](LICENSE)).

<br>

## Related:
`❤️ Q'zero Cursor` Black cursor with danger style: [`Download`](https://genesistoxical.github.io/qzero-cursor/) o [`Repository`](https://github.com/genesistoxical/qzero-cursor).
