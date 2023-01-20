# FivePD vehicles.json Extras/Livery Plugin
This plugin allows you to define what extras/livery a car spawns with, when spawning with the Duty Menu (F11)


## Installation:
1. Paste the plugin file into your `plugins` folder:
![image](https://user-images.githubusercontent.com/33298379/211183470-159244c0-bab8-4ecd-99f6-c0b2ee5c4fbc.png)


2. Edit the `vehicles.json` from the `config` folder:

![image](https://user-images.githubusercontent.com/33298379/211229512-0001a7c7-1324-46d8-9990-2022bc5d1ae5.png)


In this example, the `police4` vehicle will always spawn with the `0` livery enabled and extras `0`, `1`, and `2` enabled. The plate will automatically change to the player's callsign, too.

- the `livery:` line must have a number value, representing which livery to spawn. If the line is not present, the livery will be random.
- the `extras:` line must have either a number value, or an array of numbers, ex: `[1]`, or `[1, 3, 5]`, or `4`. However, you can also set the value as a string of `"all"` or `"none"` to set all available extras enabled or disabled.
- the `SetCallsignOnPlate:` line must be set to `true` or `false`. If it isn't there, it will default to `false`. If a value other than `true`/`false` is set, there will be an error 

Don't forget to add commas (,) to the end of lines when creating new lines! (not the last line)

After every change, you can restart FivePD by running `ensure fivepd`. Then, spawn your vehicles!

If you find any bugs, you can DM on discord with GGGDunlix#0628.

