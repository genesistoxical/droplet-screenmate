<p align="center"></p>
<p align="center"><a href="#"><img width="115px" src="docs/assets/Logo-115px.png" align="center" alt="Droplet Screenmate"/></a></p>
<h1 align="center">Droplet Screenmate</h1>
<p align="center">Droplet Screenmate, una mascota corriendo por tu escritorio.</p>

<p align="center">
 <a href="LICENSE"><img alt="License" src="https://img.shields.io/badge/License-MIT-A62323?style=flat-square&labelColor=343B45"/></a>
 <a href="https://github.com/genesistoxical/droplet-screenmate/releases/latest"><img src="https://img.shields.io/github/v/release/genesistoxical/droplet-screenmate.svg?color=A62323&label=Release&style=flat-square&labelColor=343B45"/></a>
 <a href="#"><img alt="NET" src="https://img.shields.io/badge/.NET_Framework-4.8-A62323?style=flat-square&labelColor=343B45"/></a> 
</p>

<p align="center">
<a href="README.md">English</a> :speech_balloon: <a href="README-es.md">Español</a>
</p>

## Características
* Tu mascota detecta la barra de tareas y camina por encima de ella.
* Puedes arrastrarlo y soltarlo en cualquier parte de tu escritorio.
* Animaciones diferentes al caminar, detenerse, sentarse y arrastrar.
* Elige entre los 8 skins por defecto.
* Opciones para cambiar la velocidad en la que camina.
* Opción de iniciar automáticamente al encender tu PC.
* Crea tu propio skin usando las plantillas (PNG y editables).

## Preview
<a href="#"><img src="docs/assets/Droplet-Screenmate.png"/></a>

## Uso
Lo único que debes hacer es ejecutar **Droplet Screenmate.exe**. ¡Y listo! Aparecerá tu mascota caminando sobre tu barra de tareas, no solo eso, también se detiene, se sienta e incluso basta con que lo arrastres y lo sueltes para cambiarlo de lugar. De hecho, también tiene una animación especial cuando lo estás arrastrando.

<br>

Dirígete al icono que está en tu bandeja, dale click derecho: 

**Options** abrirá la ventanita de opciones de la mascota:

* En el apartado de _Skin_, solo despliega, elige uno y da click en OK. ¡Eso es todo!
* Para cambiar qué tan rápido camina y qué tan largos da los pasos, ve al apartado de _Config_:
  * **Velocity**: Entre mayor sea el valor, más rápido se moverá.
  * **Step Size**: Entre menor sea el valor, más cortos serán los pasos.

  Puedes usar estas combinaciones al crear tu skin personalizado, dependiendo si se arrastra, si salta, etc.

**Run at Startup**: Actívala para que se inicie al momento que enciendes tu PC, puedes desactivarla también cuando desees. IMPORTANTE; una vez que actives esta opción, si vuelves a mover la carpeta de **Droplet Screenmate** de lugar ya no se iniciará con tu PC, aunque tenga el check. Únicamente debes desactivarla y activarla nuevamente.

**About**: Licencia MIT, créditos y enlace al respositorio.

**Exit**: Cierra la aplicación. Sin embargo, cuando vuelvas a abrirla nuevamente, tu configuración y skin seguirán siendo los mismos ya que todo se guarda en archivos _Config.ini_

<br>
<a href="#"><img src="docs/assets/Droplet-Screenmate.gif"/></a>

## Crear tu propia mascota

Es muy fácil, solo deberás editar o crear 5 imágenes. Descarga la plantilla y descomprime el archivo ZIP, encontrarás algunas carpetas llamadas:
* Default - PNG, SVG, PSD y AF (Affinity).
* Outline - PNG, SVG y PSD

_Default_ está listo para ser decorado y _Outline_ es solamente el borde con ojitos. Elige el estilo y formato que requieras para empezar a editarlas; incluso puedes crear cualquier diseño de mascota siempre y cuando las dimensiones sean de 128 ⨯ 128 px.

Una vez que hayas editado **drag**, **idle**, **idleAlt**, **walk-1** y **walk-2**, deberás guardar cada una en formato PNG (sin reenombrarlas) dentro de una nueva carpeta, por ejemplo "Mi mascota". Posteriormente copia el archivo **Config.ini** y pégalo dentro esa carpeta que acabas de crear.

La configuración de tu nuevo skin la puedes editar en la aplicación y los cambios se van a guardar automáticamente. Recuerda que puedes compartir tu skin con cualquier persona una vez lo hayas terminado.

<a href="#"><img src="docs/assets/Template.png"/></a>

<br></br>

## Configuración
El archivo `Config.ini`primario, almacena qué skin se utilizó por última vez.

~~~
[Options]
Skin = Mushroom
~~~

El archivo `Config.ini` del skin almacena su propia configuración.

~~~
[Config]
Velocity = 0.2
Step size = 12
~~~

## Contribuciones
* Si haces comentarios en el código, preferiblemente en Español, por favor.
* Los nombres de las variables deben estar en Inglés.
* Si abres un **Issue**, puede ser en Inglés o Español.
* **Pull request** en Inglés, en la descripción puedes agregar detalles en Inglés o Español.
* Debido a la simplicidad y optimización que se requiere en esta aplicación, no se harán traducciones.

## Licencia
**MIT License**

Copyright (c) 2026 Génesis Toxical ([read here](LICENSE)).

<br>

## Related:
`❤️ Q'zero Cursor` Black cursor with danger style: [`Descarga`](https://genesistoxical.github.io/qzero-cursor/) o [`Repositorio`](https://github.com/genesistoxical/qzero-cursor).
