# KartingGame
20126608 coursewrok

## Project File
Please follow the following steps to install and run

1. Install Unity (2020.3.31f1c1)
2. Install Packages:
    *   WebGL: https://docs.unity3d.com/Manual/webgl-building.html
    *   Karting Microgame: https://assetstore.unity.com/packages/templates/karting-microgame-150956
    *   ML agent: https://github.com/Unity-Technologies/ml-agents
3. Import [KartingGame/ProjectFiles/Karting/]
4. The experiments and game scenes are in [KartingGame/ProjectFiles/Karting/Assets/DIA_coursework/Scenes/], you can run any of them


## Demo Game
You can run demo game online or on your local machine
* Online version: https://play.unity.com/mg/other/test_v3-f (The first run may be slow)
* Run on local machine (You can also use other server, here I use python3 for example):
    1. Download [KartingGame/DemoGame/Kart_local/]
    2. Run a server
        `python -m http.server --directory [directory of Kart_local]`
    3. Enter the port in web browser (for example, 'localhost:8000')

