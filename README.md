# QuincyGameEnginePractice

QuincyGameEnginePractice is a shit temp name that I came up with for this project.

Here is my shit tutorial on how to setup 'games' with it.

Basically I made it feel sorta similar to unity where everything is a gameObject and the way the objects interact in the scene. 
The scenes are also very unity like in the way that they switch from a internal dictionary.

To add a new scene you go to the content manager and add it by using the QDictionary and add a new Scene to it then swap to that scene
using ChangeScene(string scene);

To make a scene all you need to do is make a new class that inherits Scene.cs and it gives you many things that you would need to make a game
like random or a spriteBatch...etc..

To add a gameObject that interacts in the scene you just make a new class that inherits GameObject and that object will have stuff
in it just like the scene does. The gameobject will automatically get added to the component manager and will get its methods
called automatically, all you need to do is tell what the gameobjects what to do in the scene and how they interact.


